using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Entities
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }

        public Member Members { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double Cost { get; set; }

        public List<SaleLine> SaleLines { get; set; }

        public Sales() {
            SaleLines = new List<SaleLine>();
        }

    }
}
