using GymManager.Core.Members;
using GymManager.Core.MembershipTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAcces.Repositories
{
    public class MembershipTypesRepository : Repository<int, MembershipType>
    {
        public MembershipTypesRepository(GymManagerContext gymManagerContext) : base(gymManagerContext)
        {
        }
    }
}
