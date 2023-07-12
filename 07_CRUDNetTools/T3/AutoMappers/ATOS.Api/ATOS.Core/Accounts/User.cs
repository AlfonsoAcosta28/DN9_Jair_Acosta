using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.Core.Accounts
{

    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(18,ErrorMessage ="The {0} must be least {2} characters long", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public Profile Profile { get; set; }
        public int IdEmploye { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
        public int Login { get; set; }
    }
}
