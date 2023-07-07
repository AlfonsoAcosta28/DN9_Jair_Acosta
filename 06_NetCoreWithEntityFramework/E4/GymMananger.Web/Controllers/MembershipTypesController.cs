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

        public async Task<IActionResult> Index()
        {
            List<MembershipType> members = await _membershipTypesAppService.GetMembershipTypeAsync();
            MembershipTypesListViewModel viewModel = new MembershipTypesListViewModel();

            viewModel.MembershipTypeCount = members.Count;
            viewModel.MembershipTypes = members.ToList();

            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MembershipType member)
        {

            await _membershipTypesAppService.AddMembershipTypeAsync(member);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int memberId)
        {
            MembershipType memberViewModel = await _membershipTypesAppService.GetMembershipTypeAsync(memberId);


            return View(memberViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MembershipType model)
        {
            await _membershipTypesAppService.EditMembershipTypeAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int memberId)
        {
            _membershipTypesAppService.DeleteMembershipTypeAsync(memberId);
            return RedirectToAction("Index");
        }
    }
}
