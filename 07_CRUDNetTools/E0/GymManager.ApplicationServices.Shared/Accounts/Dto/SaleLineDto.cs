using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Accounts.Dto
{
    public class SaleLineDto
    {
        [Key]
        public int Num { get; set; }

        public ProductTypes ProductType { get; set; }

        public int Cant { get; set; }
        public double SubCost { get; set; }
        public Sales Sale { get; set; }
    }
}
