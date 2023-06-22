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
        public List<Member> GetMembers()
        {
           List<Member> members = new List<Member>();
            members.Add(new Member
            {
                Name = "Israel",
                LastName = "Perez",
                BirthDay = new DateTime(),
                CityId = 1,
                Email = "israel@gmail.com"
            });

            members.Add(new Member
            {
                Name = "John",
                LastName = "Doe",
                BirthDay = new DateTime(),
                CityId = 2,
                Email = "john.doe@example.com"
            });

            members.Add(new Member
            {
                Name = "Maria",
                LastName = "Gonzalez",
                BirthDay = new DateTime(),
                CityId = 3,
                Email = "maria.gonzalez@example.com"
            });

            members.Add(new Member
            {
                Name = "Michael",
                LastName = "Smith",
                BirthDay = new DateTime(),
                CityId = 4,
                Email = "michael.smith@example.com"
            });

            members.Add(new Member
            {
                Name = "Sara",
                LastName = "Johnson",
                BirthDay = new DateTime(),
                CityId = 2,
                Email = "sara.johnson@example.com"
            });

            members.Add(new Member
            {
                Name = "Juan",
                LastName = "Lopez",
                BirthDay = new DateTime(),
                CityId = 1,
                Email = "juan.lopez@example.com"
            });

            members.Add(new Member
            {
                Name = "Emily",
                LastName = "Davis",
                BirthDay = new DateTime(),
                CityId = 3,
                Email = "emily.davis@example.com"
            });

            members.Add(new Member
            {
                Name = "Carlos",
                LastName = "Rodriguez",
                BirthDay = new DateTime(),
                CityId = 4,
                Email = "carlos.rodriguez@example.com"
            });

            members.Add(new Member
            {
                Name = "Jessica",
                LastName = "Wilson",
                BirthDay = new DateTime(),
                CityId = 1,
                Email = "jessica.wilson@example.com"
            });

            members.Add(new Member
            {
                Name = "David",
                LastName = "Anderson",
                BirthDay = new DateTime(),
                CityId = 2,
                Email = "david.anderson@example.com"
            });


            return members;
        }
    }
}
