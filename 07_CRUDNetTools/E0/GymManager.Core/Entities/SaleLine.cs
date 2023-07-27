using Microsoft.AspNetCore.Razor.Language.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Entities
{
    public class SaleLine
    {
        [Key]
        public int Num { get; set; }

        public ProductTypes ProductType { get; set; }

        public int Cant { get; set; }
        public double SubCost { get; set; }
        public Sales Sale { get; set; }
    }
}
