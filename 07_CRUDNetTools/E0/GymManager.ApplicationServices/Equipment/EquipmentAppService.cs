
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

namespace GymManager.ApplicationServices.Entities.Equipment
{
    public class EquipmentAppService : IEquipmentAppService
    {
        private readonly IRepository<int, EquipmentType> _repository;
        private readonly IMapper _mapper;
        public EquipmentAppService(IRepository<int, EquipmentType> repository, IMapper mapper) { 
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EquipmentTypeDto> AddEquipmentAsync(EquipmentTypeDto member)
        {
            var element = _mapper.Map<EquipmentType>(member);
            await _repository.AddAsync(element);
            return member;
        }

        public async Task DeleteEquipmentAsync(int memberId)
        {
            await _repository.DeleteAsync(memberId);
        }

        public async Task EditEquipmentAsync(EquipmentTypeDto member)
        {
            var element = _mapper.Map<EquipmentType>(member);
            await _repository.UpdateAsync(element);
        }

        public async Task<EquipmentTypeDto> GetEquipmentAsync(int memberId)
        {
           var element = await _repository.GetAsync(memberId);

            var equipamentTypeDto = _mapper.Map<EquipmentTypeDto>(element);

            return equipamentTypeDto;
        }

        public async Task<List<EquipmentTypeDto>> GetEquipmentAsync()
        {
            var elementos = await _repository.GetAll().ToListAsync();

            var element = _mapper.Map<List<EquipmentTypeDto>>(elementos);

            return element;
        }

       
    }
}
