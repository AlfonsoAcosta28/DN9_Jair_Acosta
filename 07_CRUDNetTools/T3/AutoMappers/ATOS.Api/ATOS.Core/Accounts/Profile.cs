using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.Core.Accounts
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [StringLength(15)]
        [Required]
        public string PRifileName { get; set; }
        public List<User> Users { get; set; }

        public Profile() { 
            Users = new List<User>();
        }

    }
}
