using Microsoft.AspNetCore.Mvc;

namespace GymMananger.Web.Controllers
{
    public class AttendanceController : Controller
    {
        
        public IActionResult MemberIn()
        {
            return View();
        }

        public IActionResult MemberOut() { 
            return View();
        }
    }
}
