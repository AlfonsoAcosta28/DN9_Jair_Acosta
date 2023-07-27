using AutoMapper;
using AutoMapper.Execution;
using GymManager.Accounts.Dto;
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
        private readonly IMapper _mapper;

        public MembershipTypesAppService(IRepository<int, MembershipType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }

        public async Task<MembershipTypeDto> AddMembershipTypeAsync(MembershipTypeDto member)
        {
            var element = _mapper.Map<MembershipType>(member);
            await _repository.AddAsync(element);
            return member;
        }

        public async Task DeleteMembershipTypeAsync(int memberId)
        {
            await _repository.DeleteAsync(memberId);
        }

        public async Task<MembershipTypeDto> EditMembershipTypeAsync(MembershipTypeDto member)
        {
            var element = _mapper.Map<MembershipType>(member);
            await _repository.UpdateAsync(element);
            return member;
        }

        public async Task<List<MembershipTypeDto>> GetMembershipTypeAsync()
        {
           
  
            var element = await _repository.GetAll().ToListAsync();

            var elementDto = _mapper.Map<List<MembershipTypeDto>>(element);

            return elementDto;
        }

        public async Task<MembershipTypeDto> GetMembershipTypeAsync(int memberId)
        {
            
            var element = await _repository.GetAsync(memberId);
            var elementDto = _mapper.Map<MembershipTypeDto>(element);
            return elementDto;
        }
    }
}
