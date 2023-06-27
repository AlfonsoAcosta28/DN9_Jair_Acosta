using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Members
{
    public class MemberAppService : IMembersAppService
    {
        private static List<Member> members = new List<Member>();  
        public int AddMember(Member member)
        {
            member.Id = new Random().Next();
            members.Add(member);    
            return member.Id;
        }

        public void DeleteMember(int memberId)
        {
            var m = members.Where(x => x.Id == memberId).FirstOrDefault();

            members.Remove(m);
        }

        public void EditMember(Member member)
        {
            var m = members.Where(x => x.Id == member.Id).FirstOrDefault();
            m.Name = member.Name;
            m.LastName = member.LastName;
            m.CityId = member.CityId;
            m.Email = member.Email;
            m.BirthDay = member.BirthDay;
            m.AllowNewsletter = member.AllowNewsletter;

        }

        public Member GetMember(int memberId)
        {
            return members.Where(x => x.Id == memberId).FirstOrDefault();

        }

        public List<Member> GetMembers()
        {
           
            return members;
        }


    }
}
