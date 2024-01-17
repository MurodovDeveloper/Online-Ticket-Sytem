using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_System_forMVC_Sytem.Enum
{
    public enum TaskStatus
    {
        [Display(Name = "Not Started")]
        NotStarted = 1,
        Deferred = 2,
        [Display(Name = "In Progress")]
        InProgress = 3,
        Completed = 4
    }
}
