﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Entities
{
    public class ProductTypes
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public Measuretype Measuretype { get; set; }

        [Required]
        public double Price { get; set; }

        public List<Inventory> Inventories { get; set; }

        public ProductTypes()
        {
            Inventories = new List<Inventory>();
        }
    }
}
