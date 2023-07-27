using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Accounts.Dto
{
    public class TypesDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public List<ProductTypesDto> measuretypes { get; set; }

        public TypesDto()
        {
            measuretypes = new List<ProductTypesDto>();
        }
    }
}
