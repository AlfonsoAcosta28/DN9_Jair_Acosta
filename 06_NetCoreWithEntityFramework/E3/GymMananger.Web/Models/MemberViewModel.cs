using GymManager.Core.Members;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Web.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public int CityId { get; set; }

        public string Email { get; set; }

        public bool AllowNewsletter { get; set; }
    }
}
