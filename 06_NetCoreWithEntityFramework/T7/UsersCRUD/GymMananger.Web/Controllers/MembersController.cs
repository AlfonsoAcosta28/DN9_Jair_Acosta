﻿using GymManager.ApplicationServices.Members;
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

        public async Task<IActionResult> Index()
        {
            //Log.Information("Se ejecutó la acción Index del controlador Members.");
            List<Member> members = await _membersAppService.GetMembersAsync();
            MemberListViewModel viewModel = new MemberListViewModel();

            viewModel.NewMembersCount = 2;
            viewModel.Members = members.ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int memberId)
        {
            Member members = await _membersAppService.GetMemberAsync(memberId);

            MemberViewModel memberViewModel = new MemberViewModel
            {
                Id = memberId,
                Name = members.Name,
                LastName = members.LastName,
                Email = members.Email,
                CityId = members.City.Id,
                BirthDay = members.BirthDay,
                AllowNewsletter = members.AllowNewsletter
            };

            return View(memberViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Member model)
        {
            /*Member member = new Member
            {
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                City = new City
                {
                    Id = model.CityId
                },
                BirthDay = model.BirthDay,
                AllowNewsletter = model.AllowNewsletter
            }; */
            await _membersAppService.EditMemberAsync(model);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MemberViewModel model)
        {
            Member member = new Member
            {
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                City = new City
                {
                    Id = model.CityId
                },
                BirthDay = model.BirthDay, 
                AllowNewsletter = model.AllowNewsletter
            };
            await _membersAppService.AddMemberAsync(member);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int memberId)
        {
            await _membersAppService.DeleteMemberAsync(memberId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Test()
        {
            return View();
        }
    }
}
