using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.MembershipTypes
{
    public class MembershipType
    {
        public int Id { get; set; }

        [StringLength(100)] //Longitud maxima de 100 caracteres
        [Required]
        public string Name { get; set; }
        
        [Required]
        public double Cost { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int Duration { get; set; }

    }
}
