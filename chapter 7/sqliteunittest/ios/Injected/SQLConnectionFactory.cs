using System;
using System.IO;
using GalaSoft.MvvmLight.Ioc;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;

namespace SQLiteUnitTest.iOS
{
    public class SQLiteConnectionFactory : ISQLConnection
    {
        readonly string Filename = "testingdb.db";

        public SQLiteConnection GetConnection()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, Filename);

            SimpleIoc.Default.Register<ISQLConnection, SQLiteConnectionFactory>();
            return new SQLiteConnection(SQLitePlatform, path);
        }

        public ISQLitePlatform SQLitePlatform
        {
            get { return new SQLitePlatformIOS(); }
        }
    }
}

