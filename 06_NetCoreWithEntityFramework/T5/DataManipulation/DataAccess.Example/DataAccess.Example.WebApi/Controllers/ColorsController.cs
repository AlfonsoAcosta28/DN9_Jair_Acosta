using DataAccess.Example.Core;
using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Mvc;


namespace DataAccess.Example.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorsDataManager _colorsDataManager;
        public ColorsController(IColorsDataManager colorsDataManager) {
            _colorsDataManager = colorsDataManager;
        }

        // GET: api/<ColorsController>
        [HttpGet]
        public IEnumerable<Color> Get()
        {
            return _colorsDataManager.GetAll();
        }

        // GET api/<ColorsController>/5
        [HttpGet("{id}")]
        public Color Get(int id)
        {
            return _colorsDataManager.Get(id);

        }

        // POST api/<ColorsController>
        [HttpPost]
        public void Post([FromBody] Color value)
        {
            _colorsDataManager.Insert(value);
        }

        // PUT api/<ColorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Color value)
        {
            value.Id = id;
            _colorsDataManager.Update(value);
        }

        // DELETE api/<ColorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _colorsDataManager.Delete(id);
        }
    }
}
