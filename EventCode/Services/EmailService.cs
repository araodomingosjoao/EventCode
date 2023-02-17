using EventCode.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading;

namespace EventCode.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _email;
        private readonly string _password;
        private readonly string _smtpServer;
        private readonly int _port;
        
        public EmailService(string email, string password, string smtpServer, int port) 
        {
            _email = email;
            _password = password;
            _smtpServer = smtpServer;
            _port = port;
        }
        public async Task Send(string to, string subject, string message)
        {
            using var smtp = new SmtpClient();
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(MailboxAddress.Parse(_email));
                emailMessage.To.Add(MailboxAddress.Parse(to));
                emailMessage.Subject = subject;
                var builder = new BodyBuilder
                {
                    HtmlBody = message
                };
                emailMessage.Body = builder.ToMessageBody();
                if (_port == 587)
                    await smtp.ConnectAsync(_smtpServer, _port, SecureSocketOptions.StartTls);
                else
                    await smtp.ConnectAsync(_smtpServer, _port, true);
                smtp.AuthenticationMechanisms.Remove("XOAUTH2");
                if (!string.IsNullOrEmpty(_email) && !string.IsNullOrEmpty(_password))
                    await smtp.AuthenticateAsync(_email, _password);
                await smtp.SendAsync(emailMessage);
            }
            catch
            {
                throw new Exception("Ocorreu um erro ao enviar e-mail!");
            }
            finally
            {
                await smtp.DisconnectAsync(true);
                smtp.Dispose();
            }

        }
    }
}
