
using GymManager.Core.MembershipTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MembershipTypes { 

    public interface IMembershipTypesAppService
    {
        Task<List<MembershipType>> GetMembershipTypeAsync();

        Task<int> AddMembershipTypeAsync(MembershipType member);

        Task DeleteMembershipTypeAsync(int memberId);

        Task<MembershipType> GetMembershipTypeAsync(int memberId);

        Task EditMembershipTypeAsync(MembershipType member);



    }
}
