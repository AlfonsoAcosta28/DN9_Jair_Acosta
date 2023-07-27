using AutoMapper;
using AutoMapper.Execution;
using GymManager.Accounts.Dto;
using GymManager.Core.Entities;
using GymManager.Core.Members;
using GymManager.DataAcces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Members
{
    public class MemberAppService : IMemberAppService
    {
        private readonly IRepository<int, Core.Members.Member> _repository;
        private readonly IMapper _mapper;
        public MemberAppService(IRepository<int, Core.Members.Member> repository, IMapper mapper) { 
            _repository = repository;
            _mapper = mapper;   
        }

        public async Task<MemberDto> AddMemberAsync(MemberDto member)
        {
            var element = _mapper.Map<Core.Members.Member>(member);
            await _repository.AddAsync(element);
            return member;
        }

        public async Task DeleteMemberAsync(int memberId)
        {
            await _repository.DeleteAsync(memberId);
        }

        public async Task<Core.Members.Member> EditMemberAsync(Core.Members.Member member)
        {
            //var element = _mapper.Map<Core.Members.Member>(member);
            await _repository.UpdateAsync(member);

            return member;
             
        }

        public async Task<MemberDto> GetMemberAsync(int memberId)
        {
           var element = await _repository.GetAsync(memberId);
            MemberDto memberDto = _mapper.Map<MemberDto>(element);
            return memberDto;
        }

        public async Task<List<MemberDto>> GetMembersAsync()
        {

            var elements = await _repository.GetAll().ToListAsync();
            List<MemberDto> memberDtos = _mapper.Map<List<MemberDto>>(elements);
            /*
            foreach (var  element in elements)
            {
                memberDtos.Add(new MemberDto{
                    Id = element.Id,
                    Name = element.Name,
                    LastName = element.LastName,
                    City = element.City,
                    Email = element.Email,
                    AllowNewsletter = element.AllowNewsletter,
                    BirthDay = element.BirthDay
                });
            }
            */
            return memberDtos;
        }

       
    }
}
