﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Entities
{
    public class EquipmentType
    {
        [Key]
        public int Id { get; set; }
        [StringLength(45)]
        [Required]
        public string Name { get; set; }

    }
}
