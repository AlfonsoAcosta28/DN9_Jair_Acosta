using DataAccess.Example.Core;
using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Mvc;


namespace DataAccess.Example.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesDataManager _vehiclesDataManager;

        public VehiclesController(IVehiclesDataManager vehiclesDataManager)
        {
            _vehiclesDataManager = vehiclesDataManager;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _vehiclesDataManager.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Vehicle Get(int id)
        {
            return _vehiclesDataManager.Get(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Vehicle value)
        {
            _vehiclesDataManager.Insert(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vehicle value)
        {
            value.Id = id;
            _vehiclesDataManager.Update(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vehiclesDataManager.Delete(id);
        }
    }
}
