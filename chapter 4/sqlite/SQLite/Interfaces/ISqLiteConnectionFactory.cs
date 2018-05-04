using SQLite.Net;

namespace SQLiteExample
{
    public interface ISqLiteConnectionFactory
    {
        SQLiteConnection GetConnection();
    }
}
