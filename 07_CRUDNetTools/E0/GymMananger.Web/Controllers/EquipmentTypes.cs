using GymManager.Accounts.Dto;
using GymManager.ApplicationServices.Entities;
using GymManager.Core.Entities;
using GymManager.Core.Members;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Controllers
{
    public class EquipmentTypes : Controller
    {
        private readonly IEquipmentAppService _membersAppService;

        public EquipmentTypes(IEquipmentAppService membersAppService)
        {
            _membersAppService = membersAppService;
        }   

        public async Task<IActionResult> Index()
        {
            List<EquipmentTypeDto> members = await _membersAppService.GetEquipmentAsync();
            EquipamentTypeListViewModel viewModel = new EquipamentTypeListViewModel();

            viewModel.EquipmentTypes = members.ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentTypeDto model)
        {

            await _membersAppService.AddEquipmentAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int memberId)
        {
            EquipmentTypeDto model = await _membersAppService.GetEquipmentAsync(memberId);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EquipmentTypeDto model)
        {
            await _membersAppService.EditEquipmentAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int memberId)
        {
            await _membersAppService.DeleteEquipmentAsync(memberId);
            return RedirectToAction("Index");
        }
    }
}
