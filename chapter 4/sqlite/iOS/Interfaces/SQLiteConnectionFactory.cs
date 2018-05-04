using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;

namespace SQLiteExample.iOS
{
    public class SQLiteConnectionFactory : ISqLiteConnectionFactory
    {
        readonly string Filename = "personalinfo.db";

        public SQLiteConnection GetConnection()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, Filename);
            return new SQLiteConnection(SQLitePlatform, path);
        }

        public ISQLitePlatform SQLitePlatform
        {
            get { return new SQLitePlatformIOS(); }
        }
    }
}
