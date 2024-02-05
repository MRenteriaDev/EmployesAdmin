using Microsoft.AspNetCore.Identity.UI.Services;

namespace EmployesAdmin.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Pending Add Email Logic
            return Task.CompletedTask;
        }
    }
}
