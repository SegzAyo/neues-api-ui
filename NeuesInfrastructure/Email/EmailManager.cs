using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Neues.Infrastructure.Email
{
    public class EmailManager
    {
        public static void SendEmail(string Subject, string Body, string To)
        {
            string From = "nelson.godwin456@gmail.com";
            string Password = "tlsnzmvlacbkxsii";
            string SMTPPort = "587";
            string Host = "smtp.gmail.com";
            string userName = "nelson.godwin456@gmail.com";
            MailMessage mail = new MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(From);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt16(SMTPPort);
            smtp.Credentials = new NetworkCredential(userName, Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}