using GymManager.Core.Members;
using GymManager.Core.MembershipTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MembershipTypes
{
    public class MembershipTypesAppService : IMembershipTypesAppService
    {
        private static List<MembershipType> MebershipTypes = new List<MembershipType>();

        public int AddMembershipType(MembershipType member)
        {
            member.Id = new Random().Next();
            MebershipTypes.Add(member);
            return member.Id;
        }

        public void DeleteMembershipType(int memberId)
        {
            var m = MebershipTypes.Where(x => x.Id == memberId).FirstOrDefault();

            MebershipTypes.Remove(m);
        }

        public void EditMembershipType(MembershipType member)
        {
            var m = MebershipTypes.Where(x => x.Id == member.Id).FirstOrDefault();
            m.Name = member.Name;
            m.Duration = member.Duration;
            m.CreatedOn = member.CreatedOn;
            m.Cost = member.Cost;
        }

        public MembershipType GetMembershipType(int memberId)
        {
            return MebershipTypes.Where(x => x.Id == memberId).FirstOrDefault();
        }

        public List<MembershipType> GetMemmershipTypes()
        {
            return MebershipTypes;
        }
    }
}
