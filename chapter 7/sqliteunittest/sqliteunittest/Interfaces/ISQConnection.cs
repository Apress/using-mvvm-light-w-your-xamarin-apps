using SQLite.Net;

namespace SQLiteUnitTest
{
    public interface ISQLConnection
    {
        SQLiteConnection GetConnection();
    }
}
