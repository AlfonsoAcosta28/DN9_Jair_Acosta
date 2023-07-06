using SPsGymManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPsGymManager.DataAccess
{
    public interface IQueriesExample
    {
        List<Members> GetMembers();
        List<Producto> GetProductsByType(int id);
        void NewSale(Sale sale);
    }
}
