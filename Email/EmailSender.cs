using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyPaws.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings Settings { get; set; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            Settings = emailSettings.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var Client = new SendGridClient(Settings.SendGridKey);
            var mesaj = new SendGridMessage()
            {
                From = new EmailAddress("petronela.pall21@gmail.com", "HappyPaws"),
                Subject= subject, //**email will be sent by sendgrid?can use whatever i want??
                PlainTextContent=htmlMessage,
                HtmlContent=htmlMessage
            };
            mesaj.AddTo(new EmailAddress(email));
            try
            {
                return Client.SendEmailAsync(mesaj);
            }
            catch( Exception ex)
            {

            }
            return null;
        }
    }
}
