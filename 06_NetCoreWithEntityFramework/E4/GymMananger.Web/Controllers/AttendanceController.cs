using GymManager.ApplicationServices.Attendace;
using GymManager.ApplicationServices.Members;
using GymManager.Core.Entities;
using GymManager.Core.Members;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymMananger.Web.Controllers
{
    
    public class AttendanceController : Controller
    {
        private readonly IAttendaceAppService attendaceAppService;

        public AttendanceController(IAttendaceAppService attendaceAppService) { 
            this.attendaceAppService = attendaceAppService;
        }
        
        public IActionResult MemberIn()
        {
            return View();
        }


        public IActionResult MemberOut() { 
            return View();
        }

        [HttpGet]
        public async Task<List<Attendance>> GetAll()
        {
            var elementos = await attendaceAppService.GetAttendaceAsync();
            return elementos;
        }
    }
}
