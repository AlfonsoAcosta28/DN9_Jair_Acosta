using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Accounts.Dto
{
    public class MeasuretypeDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Cant { get; set; }
        public Types Type { get; set; }

        public List<ProductTypesDto> ProductTypes { get; set; }

        public MeasuretypeDto()
        {
            ProductTypes = new List<ProductTypesDto>();
        }
    }
}
