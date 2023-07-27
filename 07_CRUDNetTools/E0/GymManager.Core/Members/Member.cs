using GymManager.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Members
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        [Required (ErrorMessage = "Debe ingresar el nombre del miembro")]
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

        public List<Sales> Sales { get; set; }

        public List<Attendance> Attendances { get; set; }

        public Member()
        {
            Sales = new List<Sales>();   
            Attendances = new List<Attendance>();   
        }

    }
}
