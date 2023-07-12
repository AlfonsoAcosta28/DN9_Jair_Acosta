using DataAccess.Example.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Example.EntityFramework
{
    public class VehiclesDataManager : IVehiclesDataManager
    {
        private readonly VehiclesDataContext _vehiclesDataContext;


        public VehiclesDataManager(VehiclesDataContext vehiclesDataContext)
        {
            _vehiclesDataContext = vehiclesDataContext;
        }
        public void Insert(Vehicle vehicle)
        {
            var make = _vehiclesDataContext.Makes.Find(vehicle.Make.Id);
            var model =  _vehiclesDataContext.Model.Find(vehicle.Model.Id);

            vehicle.Make = null;
            vehicle.Model = null;

            _vehiclesDataContext.Vehicles.Add(vehicle);

            make.Vehicles.Add(vehicle);
            model.Vehicles.Add(vehicle);

            _vehiclesDataContext.SaveChanges();
        }

        public void Update(Vehicle vehicle)
        {
            var make = _vehiclesDataContext.Makes.Find(vehicle.Make.Id);
            var model = _vehiclesDataContext.Model.Find(vehicle.Model.Id);

            var entity = _vehiclesDataContext.Vehicles.Find(vehicle.Id);

            entity.Year = vehicle.Year;
            entity.Make = make;
            entity.Model = model;

            _vehiclesDataContext.SaveChanges();
        }
        public Vehicle Get(int id)
        {
            var entity = _vehiclesDataContext.Vehicles.Find(id);
            return entity;
        }
        public IList<Vehicle> GetAll()
        {
            var result = _vehiclesDataContext.Vehicles.ToList();
            return result;
        }

        public void Delete(int id)
        {
            var entity = _vehiclesDataContext.Vehicles.Find(id);

            _vehiclesDataContext.Vehicles.Remove(entity);
            _vehiclesDataContext.SaveChanges();
        }
    }
}
