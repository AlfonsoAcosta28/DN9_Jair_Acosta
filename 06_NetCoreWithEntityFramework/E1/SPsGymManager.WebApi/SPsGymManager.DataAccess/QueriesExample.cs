using SPsGymManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPsGymManager.DataAccess
{
    public class QueriesExample : IQueriesExample
    {
        private readonly ProcedimientosAlmacenados _context;
        public QueriesExample()
        {
            _context = new ProcedimientosAlmacenados();
        }

        public List<Members> GetMembers()
        {
            List<Members> members = _context.GetMemberLastWeek();
            return members;
        }

        public List<Producto> GetProductsByType(int id)
        {
            return _context.GetProductsByType(id);
        }

        public void NewSale(Sale sale)
        {
            _context.NewSale(sale);
        }
    }
}
