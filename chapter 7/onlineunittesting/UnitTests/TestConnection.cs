using NUnit.Framework;
using NSubstitute;
using OnlineUnitTesting;

namespace UnitTests
{
    [TestFixture]
    public class TestConnection
    {
        [Test]
        public void TestCase()
        {
            var connection = Substitute.For<IConnection>();
            connection.IsConnected().Returns(true);
        }
    }
}
