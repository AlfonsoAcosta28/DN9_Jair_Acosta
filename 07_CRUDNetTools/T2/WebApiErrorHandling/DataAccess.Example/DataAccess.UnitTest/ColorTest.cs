using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
namespace DataAccess.UnitTest
{
    [TestFixture]
    public class ColorTest
    {
        protected TestServer _server;
        [OneTimeSetUp]
        public void Setup()
        {
            this._server = new TestServer(new WebHostBuilder().UseStartup<Startup>());  
        }

        [Test]
        public void GetAllColors_Test()
        {
            var repositor = _server.Host.Services.GetService<IVehiclesDataManager>();
            var list = repositor.GetAll();
            Assert.Pass();
        }
    }
}