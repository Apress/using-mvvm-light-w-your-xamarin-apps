using System;
using SQLite.Net.Attributes;

namespace SQLiteExample
{
    public class PersonalInfo : IInterface
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; private set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string MobilePhone { get; set; }

        public string AddressLineOne { get; set; }

        public string AddressLineTwo { get; set; }

        public string AddressLineThree { get; set; }

        public string PostCode { get; set; }

        public DateTime LastUpdated { get; private set; } = DateTime.Now;
    }
}
