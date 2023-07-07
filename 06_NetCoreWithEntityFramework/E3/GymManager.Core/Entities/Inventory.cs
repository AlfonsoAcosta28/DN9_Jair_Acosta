using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Entities
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public ProductTypes ProductTypes { get; set; }

        [Required]
        public int Cant { get; set; }
    }
}
