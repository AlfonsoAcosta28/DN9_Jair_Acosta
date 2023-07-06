using GymManager.Core.Navegation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Navegation
{
    public interface IMenuAppService
    {
        List<UserMenuItem> GetMenu();
    }
}
