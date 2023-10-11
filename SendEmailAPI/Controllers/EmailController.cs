using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace SendEmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("abraham6@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("abraham6@ethereal.email"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtpClient.Authenticate("abraham6@ethereal.email", "QRVyzzVDTWMhX96HYK");
            smtpClient.Send(email);
            smtpClient.Disconnect(true);

            //smtp.gmail.com
            //xxmz yzyg gnpo hswi


            return Ok();

        }
    }
}
