using GymManager.ApplicationServices.Members;
using Microsoft.AspNetCore.Mvc;

namespace GymMananger.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembersAppService _membersAppService;

        public HomeController(IMembersAppService membersAppService)
        {
            this._membersAppService = membersAppService;
        }

        public IActionResult Index()
        {
            var members = _membersAppService.GetMembers();
            return View(members);
        }
    }
}
