using DataAccess.Example.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Example.EntityFramework
{
    public class ColorsDataManager : IColorsDataManager
    {
        private readonly VehiclesDataContext _vehiclesDataContext;


        public ColorsDataManager(VehiclesDataContext vehiclesDataContext)
        {
            _vehiclesDataContext = vehiclesDataContext;
        }
        public void Insert(Color color)
        {
            _vehiclesDataContext.Colors.Add(color);
           
            _vehiclesDataContext.SaveChanges();
        }

        public void Update(Color color)
        {
            var entity = _vehiclesDataContext.Colors.Find(color.Id);

            entity.Code = color.Code;
            entity.Name = color.Name;
            

            _vehiclesDataContext.SaveChanges();
        }
        public Color Get(int id)
        {
            var entity = _vehiclesDataContext.Colors.Find(id);
            return entity;
        }
        public IList<Color> GetAll()
        {
            var result = _vehiclesDataContext.Colors.ToList();
            return result;
        }

        public void Delete(int id)
        {
            var entity = _vehiclesDataContext.Colors.Find(id);

            _vehiclesDataContext.Colors.Remove(entity);
            _vehiclesDataContext.SaveChanges();
        }
    }
}
