using System;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace Memes.Services
{
    public class SMTP
    {
        public static string host = "smtp.gmail.com";
        public static Int16 port = 587;
        public static bool SSL = true;
        public static string userMail = "mikolaj.rambiert@gmail.com";
        public static string userName = "Mikolaj";
        public static string password = "Galicjanka1";

        public async Task SendMailAsync(string to, string subject, string message, bool SSL)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(userName, userMail));
            emailMessage.To.Add(new MailboxAddress("", to));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(host, port, SSL);
                await client.AuthenticateAsync(userMail, password, System.Threading.CancellationToken.None);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        public void SendMailSync(string to, string subject, string message, bool SSL)
        {

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(userName, userMail));
            emailMessage.To.Add(new MailboxAddress("", to));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connect(host, port, true);
                client.Authenticate(userMail, password, System.Threading.CancellationToken.None);
                client.Send(emailMessage);
                client.Disconnect(SSL);
            }

        }
    }
}
