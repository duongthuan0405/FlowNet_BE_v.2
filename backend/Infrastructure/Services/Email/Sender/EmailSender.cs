using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Services.Email.Sender
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailCO _emailCO;
        public EmailSender(IOptions<EmailCO> emailCO)
        {
            _emailCO = emailCO.Value;
        }
        public async Task SendEmailToAsync(EmailMessage message)
        {
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_emailCO.DisplayName, _emailCO.Username));
            mimeMessage.To.Add(MailboxAddress.Parse(message.To));
            mimeMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = message.HtmlBody,
            };

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailCO.Server, _emailCO.Port, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_emailCO.Username, _emailCO.Password);
                    await client.SendAsync(mimeMessage);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }

            }
        }
    }
}
