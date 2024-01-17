using Microsoft.AspNetCore.Identity;
using Online_Ticket_System_forMVC_Sytem.DataAcces;
using Online_Ticket_System_forMVC_Sytem.Models;

namespace Online_Ticket_System_forMVC_Sytem.Services
{
    public interface IDotnetdesk
    {
        Task SendEmailBySendGridAsync(string apiKey, string fromEmail, string fromFullName, string subject, string message, string email);

        Task<bool> IsAccountActivatedAsync(string email, UserManager<ApplicationUser> userManager);

        Task SendEmailByGmailAsync(string fromEmail,
            string fromFullName,
            string subject,
            string messageBody,
            string toEmail,
            string toFullName,
            string smtpUser,
            string smtpPassword,
            string smtpHost,
            int smtpPort,
            bool smtpSSL);

        Task CreateDefaultOrganization(string applicationUserId,
            ApplicationDbContext context);

        Task<string> UploadFile(List<IFormFile> files, Microsoft.AspNetCore.Hosting.IHostingEnvironment env);

    }
}