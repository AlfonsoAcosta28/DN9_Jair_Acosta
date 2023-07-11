using DataAccess.Example.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Example.EntityFramework
{
    public interface IVehiclesDataManager
    {
        void Insert(Vehicle color);

        void Update(Vehicle color);
        Vehicle Get(int id);
        IList<Vehicle> GetAll();

        void Delete(int id);
    }
}
