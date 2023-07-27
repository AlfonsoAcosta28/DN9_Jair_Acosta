using GymManager.Accounts.Dto;
using GymManager.Core.Members;

namespace GymManager.Web.Models
{
    public class MemberListViewModel
    {
        public int NewMembersCount { get; set; }

        public List<MemberDto> Members { get; set; }
    }
}
