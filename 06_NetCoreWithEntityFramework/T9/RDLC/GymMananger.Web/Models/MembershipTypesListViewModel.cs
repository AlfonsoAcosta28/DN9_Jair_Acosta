using GymManager.Core.MembershipTypes;

namespace GymManager.Web.Models
{
    public class MembershipTypesListViewModel
    {
        public int MembershipTypeCount { get; set; }

        public List<MembershipType> MembershipTypes { get; set; }
    }
}
