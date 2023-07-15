using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Webcores.Example.Client.Pages
{
    public class ContactModel : PageModel
    {
        [Required(ErrorMessage = "NameRequired")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "EmailRequired")]
        [Required(ErrorMessage = "EmailRequired")]
        public string Email { get; set; }

        [Required(ErrorMessage = "MessageRequired")]
        public string Message { get; set; }

        

        public void OnGet()
        {
        }
    }
}
