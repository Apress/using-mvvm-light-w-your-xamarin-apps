using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SQLiteUnitTest;

namespace UnitTests
{
    [TestFixture]
    public class DataEntryUnitTest
    {
        [Test]
        public void CheckToString()
        {
            var model = new DataEntry
            {
                Username = "paul",
                Password = "olliedog",
                Today = DateTime.Now.Date,
                Id = 1971,
                RandomNumber = 123123
            };

            Assert.AreEqual("[DataEntry: Username=paul, Password=olliedog, Today=12/03/2017 00:00:00, Id=1971, RandomNumber=123123]", model.ToString());
        }

    }
}
