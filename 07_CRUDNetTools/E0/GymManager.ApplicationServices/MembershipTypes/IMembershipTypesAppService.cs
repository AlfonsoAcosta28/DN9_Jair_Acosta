
using GymManager.Accounts.Dto;
using GymManager.Core.MembershipTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MembershipTypes { 

    public interface IMembershipTypesAppService
    {
        Task<List<MembershipTypeDto>> GetMembershipTypeAsync();

        Task<MembershipTypeDto> AddMembershipTypeAsync(MembershipTypeDto member);

        Task DeleteMembershipTypeAsync(int memberId);

        Task<MembershipTypeDto> GetMembershipTypeAsync(int memberId);

        Task<MembershipTypeDto> EditMembershipTypeAsync(MembershipTypeDto member);



    }
}
