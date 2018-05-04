using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using System;

namespace SQLiteExample
{
    public class SqLiteRepository : IRepository
    {
        SQLiteConnection connection;

        public SqLiteRepository(ISqLiteConnectionFactory connectionFactory)
        {
            connection = connectionFactory.GetConnection();
            CreateTables();
        }

        public void SaveData<T>(T toStore)
        {
            connection.InsertOrReplace(toStore);
        }

        public void SaveData<T>(List<T> toStore)
        {
            connection.InsertOrReplaceAll(toStore);
        }

        public int Count<T>() where T : class, new()
        {
            return GetList<T>().Count;
        }

        public List<T> GetList<T>(int top = 0) where T : class, new()
        {
            var sql = string.Format("SELECT * FROM {0}", GetName(typeof(T).ToString()));
            var list = this.connection.Query<T>(sql, string.Empty);
            if (list.Count != 0)
            {
                if (top != 0)
                {
                    list = list.Take(top).ToList();
                }
            }

            return list;
        }

        public T GetData<T>() where T : class, new()
        {
            var sql = string.Format("SELECT * FROM {0}", GetName(typeof(T).ToString()));
            var list = connection.Query<T>(sql, string.Empty);
            return list != null ? list.FirstOrDefault() : default(T);
        }

        public T GetData<T, TU>(string para, TU val) where T : class, new()
        {
            var sql = string.Format("SELECT * FROM {0} WHERE {1}=?", GetName(typeof(T).ToString()), para);
            var list = connection.Query<T>(sql, val);
            return list != null ? list.FirstOrDefault() : default(T);
        }

        public void Delete<T>(T stored)
        {
            connection.Delete(stored);
        }

        public T GetData<T, TU, TV>(string para1, TU val1, string para2, TV val2) where T : class, new()
        {
            var sql = string.Format("SELECT * FROM {0} WHERE {1}=? AND {2}=?", GetName(typeof(T).ToString()), para1, para2);
            var list = connection.Query<T>(sql, val1, val2);
            return list != null ? list.FirstOrDefault() : default(T);
        }

        public int GetID<T>() where T : class, new()
        {
            string sql = string.Format("SELECT last_insert_rowid() FROM {0}", GetName(typeof(T).ToString()));
            var id = connection.ExecuteScalar<int>(sql, string.Empty);
            return id;
        }

        void CreateTables()
        {
            connection.CreateTable<Hobbies>();
            connection.CreateTable<Pets>();
            connection.CreateTable<PersonalInfo>();
        }

        string GetName(string name)
        {
            var list = name.Split('.').ToList();
            if (list.Count == 1)
            {
                return list[0];
            }

            var last = list[list.Count - 1];
            return last;
        }
    }
}
