using GymManager.Accounts.Dto;
using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Members
{
    public interface IMemberAppService
    {
        Task<List<MemberDto>> GetMembersAsync();

        Task<MemberDto> AddMemberAsync(MemberDto member);

        Task DeleteMemberAsync(int memberId);

        Task<MemberDto> GetMemberAsync(int memberId);

        Task<Member> EditMemberAsync(Member member);
    }
}
