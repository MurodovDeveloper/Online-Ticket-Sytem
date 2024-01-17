using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_System_forMVC_Sytem.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
