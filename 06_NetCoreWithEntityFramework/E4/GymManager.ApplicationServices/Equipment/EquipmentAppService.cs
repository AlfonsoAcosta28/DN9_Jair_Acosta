
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
        public EquipmentAppService(IRepository<int, EquipmentType> repository) { 
            _repository = repository;
        }

        public async Task<int> AddEquipmentAsync(EquipmentType member)
        {
            await _repository.AddAsync(member);
            return member.Id;
        }

        public async Task DeleteEquipmentAsync(int memberId)
        {
            await _repository.DeleteAsync(memberId);
        }

        public async Task EditEquipmentAsync(EquipmentType member)
        {
            await _repository.UpdateAsync(member);
        }

        public async Task<EquipmentType> GetEquipmentAsync(int memberId)
        {
           return await _repository.GetAsync(memberId);
        }

        public async Task<List<EquipmentType>> GetEquipmentAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

       
    }
}
