using GymManager.Core.Entities;
using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Accounts.Dto
{
    public class SalesDto
    {
        [Key]
        public int Id { get; set; }

        public Member Members { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double Cost { get; set; }

        public List<SaleLineDto> SaleLines { get; set; }

        public SalesDto()
        {
            SaleLines = new List<SaleLineDto>();
        }

    }
}
