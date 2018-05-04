using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using GalaSoft.MvvmLight.Ioc;

namespace SQLiteUnitTest.Droid
{
    public class SQLConnection : ISQLConnection
    {
        readonly string Filename = "testingdb.db";

        public SQLiteConnection GetConnection()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, Filename);

            SimpleIoc.Default.Register<ISQLConnection, SQLConnection>();

            return new SQLiteConnection(SQLitePlatform, path);
        }

        public ISQLitePlatform SQLitePlatform
        {
            get { return new SQLitePlatformAndroid(); }
        }
    }
}
