using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAcces.Repositories
{
    public class EquipmentTypeRepository : Repository<int, EquipmentType>
    {
        public EquipmentTypeRepository(GymManagerContext gymManagerContext) : base(gymManagerContext)
        {
        }
    }
}
