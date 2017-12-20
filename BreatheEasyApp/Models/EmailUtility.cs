using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace BreatheEasyApp.Models
{
    public class EmailUtility
    {

        public static void sendMail(String Toemail, String body)
        {
            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("rgarlocktestemail@gmail.com ", "Noswearing2");

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            MailAddress from = new MailAddress("rgarlocktestemail@gmail.com");
            MailAddress to = new MailAddress(Toemail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Welcome to breathe easy!";
            message.Body = body;

            message.BodyEncoding = System.Text.Encoding.UTF8;
            client.Send(message);

            message.Dispose();
            Console.WriteLine("Goodbye.");
        }
    }
}