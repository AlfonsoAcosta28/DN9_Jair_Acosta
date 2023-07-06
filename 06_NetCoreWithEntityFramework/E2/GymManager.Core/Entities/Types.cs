using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Entities
{
    public class Types
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public List<ProductTypes> measuretypes { get; set; }

        public Types() { 
            measuretypes = new List<ProductTypes>(); 
        }
    }
}
