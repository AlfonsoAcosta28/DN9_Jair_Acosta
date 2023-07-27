using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Accounts.Dto
{
    public class ProductTypesDto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public Measuretype Measuretype { get; set; }

        [Required]
        public double Price { get; set; }

        public List<InventoryDto> Inventories { get; set; }

        public ProductTypesDto()
        {
            Inventories = new List<InventoryDto>();
        }
    }
}
