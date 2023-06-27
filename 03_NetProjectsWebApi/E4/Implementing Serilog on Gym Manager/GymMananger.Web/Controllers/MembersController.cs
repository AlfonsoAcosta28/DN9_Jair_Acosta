using GymManager.ApplicationServices.Members;
using GymManager.Core.Members;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Formatting.Compact;

namespace GymManager.Web.Controllers
{
   // [Authorize]
    public class MembersController : Controller
    {
        private readonly IMembersAppService _membersAppService;
        readonly IDiagnosticContext _diagnosticContext;

        public MembersController(IMembersAppService membersAppService) { 
            this._membersAppService = membersAppService;
        }

        public IActionResult Index()
        {
            Log.Information("Se ejecutó la acción Index del controlador Members.");
            List<Member> members = _membersAppService.GetMembers();
            MemberListViewModel viewModel = new MemberListViewModel();

            viewModel.NewMembersCount = 2;
            viewModel.Members = members;

            return View(viewModel);
        }

        public IActionResult Edit(int memberId)
        {
            Member members = _membersAppService.GetMember(memberId);
           

            return View(members);
        }
        [HttpPost]
        public IActionResult Edit(Member member)
        {
            _membersAppService.EditMember(member);
            return RedirectToAction("Index");
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Member member)
        {
            _membersAppService.AddMember(member);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int memberId)
        {
            _membersAppService.DeleteMember(memberId);
            return RedirectToAction("Index");
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
