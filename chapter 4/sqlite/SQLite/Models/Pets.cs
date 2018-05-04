using SQLite.Net.Attributes;

namespace SQLiteExample
{
    public class Pets : IInterface
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; private set; }

        public int ParentId { get; set; }

        public string PetsName { get; set; }

        public int PetsAge { get; set; }

        public bool IsDog { get; set; }

        public string Breed { get; set; }
    }
}
