using GymManager.ApplicationServices.Members;
using GymManager.Core.Members;
using GymMananger.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymMananger.Web.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMembersAppService _membersAppService;

        public MembersController(IMembersAppService membersAppService) { 
            this._membersAppService = membersAppService;
        }

        public IActionResult Index()
        {
            List<Member> members = _membersAppService.GetMembers();
            MemberListViewModel viewModel = new MemberListViewModel();

            viewModel.NewMembersCount = 2;
            viewModel.Members = members;

            return View(viewModel);
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
