using System;
using SQLite.Net.Attributes;

namespace SQLiteUnitTest
{
    public class DataEntry
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Today { get; set; }
        [PrimaryKey]
        public int Id { get; set; }
        public int RandomNumber { get; set; }

        public override string ToString()
        {
            return string.Format("[DataEntry: Username={0}, Password={1}, Today={2}, Id={3}, RandomNumber={4}]", Username, Password, Today, Id, RandomNumber);
        }
    }
}
