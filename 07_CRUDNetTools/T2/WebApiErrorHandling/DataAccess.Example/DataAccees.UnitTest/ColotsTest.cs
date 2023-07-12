using Microsoft.AspNetCore.TestHost;

namespace DataAccess.UnitTest
{
    [TestFixture]
    public class ColotsTest
    {
        protected readonly TestServer server;
        [OneTimeSetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}