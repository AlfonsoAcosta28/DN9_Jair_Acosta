using GymManager.Accounts.Dto;
using GymManager.Core.MembershipTypes;

namespace GymManager.Web.Models
{
    public class MembershipTypesListViewModel
    {
        public int MembershipTypeCount { get; set; }

        public List<MembershipTypeDto> MembershipTypes { get; set; }
    }
}
