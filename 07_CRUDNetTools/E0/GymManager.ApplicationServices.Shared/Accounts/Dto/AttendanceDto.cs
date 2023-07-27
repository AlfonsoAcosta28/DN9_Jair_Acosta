using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Accounts.Dto
{
    public class AttendanceDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public Member Member { get; set; }
    }
}
