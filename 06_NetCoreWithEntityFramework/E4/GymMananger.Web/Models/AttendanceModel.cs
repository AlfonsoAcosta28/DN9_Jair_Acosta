using GymManager.Core.Members;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Web.Models
{
    public class AttendanceModel
    {
        public int Id { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int Members { get; set; }
    }
}
