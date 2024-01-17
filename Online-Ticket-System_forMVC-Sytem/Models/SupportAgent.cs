using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_System_forMVC_Sytem.Models
{
    public class SupportAgent : BaseEntity
    {
        public Guid supportAgentId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string supportAgentName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string applicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }

        public Guid organizationId { get; set; }
        public Organization organization { get; set; }
    }
}
