using NUnit.Framework;
using System;
using SQLiteUnitTest;
using SQLite.Net;
using NSubstitute;
using SQLite.Net.Interop;
using SQLite.Net.Platform.Generic;
using System.Linq;
using System.ComponentModel;
namespace UnitTests
{
    [TestFixture]
    public class Test
    {
        ISQLConnection factory;
        string testDatabase = ":memory:";
        SQLiteConnection connection;
        ISQLitePlatform platform { get { return new SQLitePlatformGeneric(); } }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            factory = Substitute.For<ISQLConnection>();
            connection = new SQLiteConnection(platform, testDatabase);
            factory.GetConnection().Returns(connection);
        }

        [SetUp]
        public void Setup()
        {
            connection.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            connection.Rollback();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            connection.Close();
        }

        [Test]
        public void TestSaveData()
        {
            // create an instance of the repository
            var repo = new SqLiteRepository(factory);
            // save with random data
            repo.SaveData(new DataEntry { Id = 101, Password = "hello", RandomNumber = new Random().Next(255), Today = DateTime.Today, Username = "paul" });

            // recall the data
            var count = connection.Table<DataEntry>().Count(sc => sc.Id == 101);
            // perform test
            Assert.AreEqual(1, count);
        }

        [Test]
        public void TestMultipleDataSets()
        {
            var repo = new SqLiteRepository(factory);
            repo.SaveData(new DataEntry { Id = 101, Password = "hello", RandomNumber = new Random().Next(255), Today = DateTime.Today, Username = "paul" });
            repo.SaveData(new DataEntry { Id = 102, Password = "apple", RandomNumber = new Random().Next(255), Today = DateTime.Today, Username = "mac" });

            var data = repo.GetList<DataEntry>();

            Assert.AreEqual(2, data.Count);
            Assert.AreEqual(101, data.First().Id);
            Assert.AreEqual("paul", data.First().Username);
            Assert.AreEqual(102, data.Skip(1).First().Id);
            Assert.AreEqual("mac", data.Skip(1).First().Username);
        }

        [Test]
        public void TestDeleteRecord()
        {
            var repo = new SqLiteRepository(factory);
            var deleteData = new DataEntry { Id = 101, Password = "hello", RandomNumber = new Random().Next(255), Today = DateTime.Today, Username = "paul" };
            repo.SaveData(deleteData);
            repo.SaveData(new DataEntry { Id = 102, Password = "apple", RandomNumber = new Random().Next(255), Today = DateTime.Today, Username = "mac" });

            // delete the first entry
            repo.Delete(deleteData);

            // tests
            var data = repo.GetList<DataEntry>();
            Assert.AreEqual(1, data.Count);
            Assert.AreEqual("mac", data.First().Username);
            Assert.AreEqual(DateTime.Today, data.First().Today);
        }

        [Test]
        public void TestRetrieveData()
        {
            var repo = new SqLiteRepository(factory);
            repo.SaveData(new DataEntry { Id = 101, Password = "hello", RandomNumber = new Random().Next(255), Today = DateTime.Today, Username = "paul" });
            repo.SaveData(new DataEntry { Id = 102, Password = "apple", RandomNumber = new Random().Next(255), Today = DateTime.Today, Username = "mac" });
            repo.SaveData(new DataEntry { Id = 103, Password = "elephant", RandomNumber = new Random().Next(255), Today = DateTime.Today, Username = "frog" });
            repo.SaveData(new DataEntry { Id = 104, Password = "giraffe", RandomNumber = new Random().Next(255), Today = DateTime.Today, Username = "becki" });

            var data = repo.GetList<DataEntry>();
            Assert.AreEqual(4, data.Count);

            var first = data.First();
            Assert.AreEqual(101, first.Id);
            Assert.AreEqual(5, first.Password.Length);
            Assert.AreEqual(DateTime.Today, first.Today);
            Assert.AreEqual("elephant", data.Skip(2).First().Password);
            Assert.AreNotEqual("giraffe", data.Skip(2).First().Password);
        }
    }
}
