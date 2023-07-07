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
        Task<List<EquipmentType>> GetEquipmentAsync();

        Task<int> AddEquipmentAsync(EquipmentType member);

        Task DeleteEquipmentAsync(int memberId);

        Task<EquipmentType> GetEquipmentAsync(int memberId);

        Task EditEquipmentAsync(EquipmentType member);
    }
}
