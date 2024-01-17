namespace Online_Ticket_System_forMVC_Sytem.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
