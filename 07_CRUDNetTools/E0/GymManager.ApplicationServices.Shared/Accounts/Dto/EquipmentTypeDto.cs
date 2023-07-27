using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Accounts.Dto
{
    public class EquipmentTypeDto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(45)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string Measure { get; set; }

    }
}
