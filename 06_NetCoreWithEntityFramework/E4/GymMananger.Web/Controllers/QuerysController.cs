using GymManager.ApplicationServices.Attendace;
using GymManager.ApplicationServices.Members;
using GymManager.Core.Entities;
using GymManager.Core.Members;
using GymManager.DataAcces;
using GymManager.DataAcces.Repositories;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Collections;

namespace GymManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuerysController : ControllerBase
    {
        
        private readonly IMemberAppService memberAppService;
        private readonly IAttendaceAppService attendaceAppService;

        public QuerysController(IRepository<int, Member> repositoryMembers, IAttendaceAppService repositoryAttendace)
        {
           memberAppService = new MemberAppService(repositoryMembers);
           attendaceAppService = repositoryAttendace;
        }

        [HttpGet]
        [Route("GetMemberById/{id}")]
        [HttpGet("{id}", Name = "GetMemberById")]
        public async Task<Member> GetMemberById(int id)
        {
            var element = await memberAppService.GetMemberAsync(id);
            return element;
        }

        [HttpPost]
        [Route(nameof(MemberIn))]
        public async void MemberIn([FromBody] AttendanceModel attendance)
        {
            Attendance element = new Attendance
            {
                CheckIn = DateTime.Now,
                Member = new Member
                {
                    Id = attendance.Members
                }
            };
            await attendaceAppService.AddAttendaceAsync(element);
            //return RedirectToAction("/Attendance/MemberIn");
        }

        [HttpPost]
        [Route(nameof(MemberOut))]
        public void MemberOut([FromBody] AttendanceModel attendance)
        {
            Attendance element = new Attendance
            {
                CheckIn = DateTime.Now,
                Member = new Member
                {
                    Id = attendance.Members
                }
            };
            // await attendaceAppService.AddAttendaceAsync(element);
            // return RedirectToAction("MemberIn");
        }




    }
}
