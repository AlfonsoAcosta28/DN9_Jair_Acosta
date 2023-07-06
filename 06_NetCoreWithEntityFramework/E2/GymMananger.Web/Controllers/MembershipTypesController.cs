using GymManager.ApplicationServices.MembershipTypes;
using GymManager.Core.Members;
using GymManager.Core.MembershipTypes;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Controllers
{
    public class MembershipTypesController : Controller
    {
        private readonly IMembershipTypesAppService _membershipTypesAppService;

        public MembershipTypesController(IMembershipTypesAppService membershipTypesAppService)
        {
            _membershipTypesAppService = membershipTypesAppService;
            
        }

        public IActionResult Index()
        {
            List<MembershipType> members = _membershipTypesAppService.GetMemmershipTypes();
            MembershipTypesListViewModel viewModel = new MembershipTypesListViewModel();

            viewModel.MembershipTypeCount = members.Count;
            viewModel.MembershipTypes = members;

            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MembershipType member)
        {
            _membershipTypesAppService.AddMembershipType(member);
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int memberId)
        {
            MembershipType members = _membershipTypesAppService.GetMembershipType(memberId);

            return View(members);
        }
        [HttpPost]
        public IActionResult Edit(MembershipType member)
        {
            _membershipTypesAppService.EditMembershipType(member);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int memberId)
        {
            _membershipTypesAppService.DeleteMembershipType(memberId);
            return RedirectToAction("Index");
        }
    }
}
