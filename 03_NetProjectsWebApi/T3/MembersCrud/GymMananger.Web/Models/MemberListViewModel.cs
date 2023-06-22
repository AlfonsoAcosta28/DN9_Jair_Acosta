using GymManager.Core.Members;

namespace GymMananger.Web.Models
{
    public class MemberListViewModel
    {
        public int NewMembersCount { get; set; }

        public List<Member> Members { get; set; }
    }
}
