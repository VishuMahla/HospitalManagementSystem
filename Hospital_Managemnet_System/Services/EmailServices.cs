using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;

namespace Hospital_Managemnet_System.Services
{
    public class EmailServices
    {

        private readonly IConfiguration _configuration;


        // EmailServices constructor
        public EmailServices(IConfiguration configuration)

        {

            _configuration = configuration;

        }


        // SendEmailAsync method
        public async Task SendEmailAsync(

            string toEmail,

            string subject,

            string body)

        {

            var email = new MimeMessage();


            email.From.Add(new MailboxAddress(

                _configuration["SmtpSettings:FromName"],

                _configuration["SmtpSettings:FromEmail"]));


            email.To.Add(MailboxAddress.Parse(toEmail));


            email.Subject = subject;


            email.Body = new TextPart("html")

            {

                Text = body
            };


            using var smtp = new SmtpClient();


            await smtp.ConnectAsync(

                _configuration["SmtpSettings:Host"],

                int.Parse(_configuration["SmtpSettings:Port"]!),

                SecureSocketOptions.StartTls);


            await smtp.AuthenticateAsync(

                _configuration["SmtpSettings:Username"],

                _configuration["SmtpSettings:Password"]);


            await smtp.SendAsync(email);


            await smtp.DisconnectAsync(true);

        }

    }
}
