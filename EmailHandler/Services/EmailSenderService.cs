using System.Net.Mail;
using System.Net;
using EmailHandler.Interfaces;
using EmailHandler.Utilities.Enums;
using EmailHandler.Utilities;
using EmailHandler.Models;

namespace EmailHandler.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public Task SendEmailAsync(string email, string subject, Mailtype mailtype, Activity activity)
        {
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sandeepthippareddy@hotmail.com", "Sandeep98$")
            };
            string message = string.Empty;

            if(mailtype == Mailtype.UserRegistration)
            {
                message = MailMessageHandler.GetHtmlTemplateForUserregistration(activity);
            }

            if (mailtype == Mailtype.ActivityRegistration)
            {
                message = MailMessageHandler.GetHtmlTemplateForActivityRegistration(activity);
            }

            if (mailtype == Mailtype.ActivityRegistrationCancellation)
            {
                message = MailMessageHandler.GetHtmlTemplateForActivityRegistrationCancellation(activity);
            }

            if (mailtype == Mailtype.ActivityEnrollment)
            {
                message = MailMessageHandler.GetHtmlTemplateForActivityEnrollment(activity);
            }

            MailMessage mail = new MailMessage
            {
                From = new MailAddress("sandeepthippareddy@hotmail.com")
            };
            mail.To.Add(email);
            mail.Subject = subject;

            string htmlBody = message;

            mail.Body = htmlBody;
            mail.IsBodyHtml = true;

            return client.SendMailAsync(mail);
        }
    }
}
