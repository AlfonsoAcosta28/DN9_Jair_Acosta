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

        public List<Member> GetMembers()
        {
           
            return members;
        }
    }
}
