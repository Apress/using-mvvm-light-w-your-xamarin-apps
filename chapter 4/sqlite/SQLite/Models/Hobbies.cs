using SQLite.Net.Attributes;

namespace SQLiteExample
{
    public class Hobbies : IInterface
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; private set; }

        public int ParentId { get; set; }

        public string HobbyName { get; set; }

        public string Description { get; set; }

        public string FreqencyAttended { get; set; }

        public double Cost { get; set; }
    }
}
