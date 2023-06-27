using GymManager.Core.Members;
using GymManager.Core.MembershipTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MembershipTypes { 

    public interface IMembershipTypesAppService
    {
        List<MembershipType> GetMemmershipTypes();

        int AddMembershipType(MembershipType member);

        void DeleteMembershipType(int memberId);

        MembershipType GetMembershipType(int memberId);

        void EditMembershipType(MembershipType member);
    }
}
