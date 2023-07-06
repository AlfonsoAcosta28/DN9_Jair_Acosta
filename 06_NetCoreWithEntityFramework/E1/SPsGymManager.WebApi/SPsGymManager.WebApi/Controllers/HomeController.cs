using Microsoft.AspNetCore.Mvc;
using SPsGymManager.DataAccess;
using SPsGymManager.DataAccess.Entities;

namespace SPsGymManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IQueriesExample _queries;
        public HomeController(IQueriesExample queriesExample)
        {
            _queries = queriesExample;
        }
        [HttpGet]
        public IEnumerable<Members> Get()
        {
            var result = _queries.GetMembers();
            return result;
        }

        [HttpGet(nameof(GetProductsByType)+"/{id}")]
        public IEnumerable<Producto> GetProductsByType(int id)
        {
            var result = _queries.GetProductsByType(id);
            return result;
        }

        [HttpPost(nameof(NewSale))]
        public void NewSale([FromBody] Sale sale)
        {
            _queries.NewSale(sale);
        }
    }


}
