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
    public class MemberDto
    {
        public int Id { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Debe ingresar el nombre del miembro")]
        public string Name { get; set; }

        [StringLength(20)]
        [Required]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public bool AllowNewsletter { get; set; }

        public City City { get; set; }

        public List<AttendanceDto> Attendances { get; set; }

        public MemberDto()
        {
            Attendances = new List<AttendanceDto>();
        }

    }
}
