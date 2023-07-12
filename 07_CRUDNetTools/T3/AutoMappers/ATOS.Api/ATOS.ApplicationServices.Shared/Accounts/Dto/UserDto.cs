using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.Accounts.Dto
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        [Required]
        public string Name { get; set; }
        public int IdEmploye { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
