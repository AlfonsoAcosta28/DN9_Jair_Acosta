using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Accounts.Dto
{
    public class CityDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public List<MemberDto> Members { get; set; }

        public CityDto()
        {
            Members = new List<MemberDto>();
        }
    }
}
