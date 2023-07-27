using GymManager.Accounts.Dto;
using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Entities
{
    public interface IEquipmentAppService
    {
        Task<List<EquipmentTypeDto>> GetEquipmentAsync();

        Task<EquipmentTypeDto> AddEquipmentAsync(EquipmentTypeDto member);

        Task DeleteEquipmentAsync(int memberId);

        Task<EquipmentTypeDto> GetEquipmentAsync(int memberId);

        Task EditEquipmentAsync(EquipmentTypeDto member);
    }
}
