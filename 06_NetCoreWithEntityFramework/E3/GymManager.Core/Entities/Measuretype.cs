using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Entities
{
    public class Measuretype
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Cant { get; set; }
        public Types Type { get; set; }

        public List<ProductTypes> ProductTypes { get; set; }

        public Measuretype() { 
            ProductTypes = new List<ProductTypes>();
        }
    }
}
