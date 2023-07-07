using GymManager.Core.Members;
using GymManager.Core.MembershipTypes;
using GymManager.DataAcces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MembershipTypes
{
    public class MembershipTypesAppService : IMembershipTypesAppService
    {
        private readonly IRepository<int, MembershipType> _repository;

        public MembershipTypesAppService(IRepository<int, MembershipType> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddMembershipTypeAsync(MembershipType member)
        {
            await _repository.AddAsync(member);
            return member.Id;
        }

        public async Task DeleteMembershipTypeAsync(int memberId)
        {
            await _repository.DeleteAsync(memberId);
        }

        public async Task EditMembershipTypeAsync(MembershipType member)
        {
            await _repository.UpdateAsync(member);
        }

        public async Task<List<MembershipType>> GetMembershipTypeAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<MembershipType> GetMembershipTypeAsync(int memberId)
        {
            return await _repository.GetAsync(memberId);
        }
    }
}
