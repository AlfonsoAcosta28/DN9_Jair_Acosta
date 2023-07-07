using GymManager.ApplicationServices.Members;
using GymManager.Core.Members;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Drawing;
using GymManager.DataAcces;
using GymManager.Core.MembershipTypes;

namespace GymManager.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly GymManagerContext _membersAppService;

       
        public ApiController(GymManagerContext membersAppService)
        {
            this._membersAppService = membersAppService;
        }

       /* [HttpGet(nameof(GetMemberAsync) + "/{id}")]
        public ActionResult<Member> GetMemberAsync(int id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var result =  _membersAppService.GetMemberAsync(id);

            return Ok(result);
        }
       */
        [HttpGet("{id}")]
        public Member Get(int id)
        {
            
            var result = _membersAppService.Members.Find(id);


            return result;
        }

        [HttpGet(nameof(GetMembershipTypes))]
        public List<MembershipType> GetMembershipTypes()
        {
            var result = _membersAppService.MembershipTypes.ToList();
            return result;
        }


    }
}
