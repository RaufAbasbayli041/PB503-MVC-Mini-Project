using CAConferenceManagement.EmailOperations.Interface;
using System.Net;
using System.Net.Mail;

namespace CAConferenceManagement.EmailOperations
{
    public class EmailSenderOpt : IEmailSenderOpt
    {
        private readonly IConfiguration _configuration;

        public EmailSenderOpt(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var fromEmail = _configuration["EmailSettings:FromEmail"];
            var password = _configuration["EmailSettings:Password"];

            var mail = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mail.To.Add(email);

            using var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromEmail, password),
                EnableSsl = true
            };

            await client.SendMailAsync(mail);


        }
    }


}
