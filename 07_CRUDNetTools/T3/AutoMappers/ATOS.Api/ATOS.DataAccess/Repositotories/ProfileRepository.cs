using ATOS.Core.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.DataAccess.Repositotories
{
    public class ProfileRepository : Repository<int, Profile>
    {
        public ProfileRepository(Context gymManagerContext) : base(gymManagerContext)
        {
        }
    }
}
