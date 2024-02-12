using Restaurant.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    internal class EmailService : IEmailService
    {
        public void SendEmail(string subject, string body)
        {
            string senderEmail = "tesingvisemail@gmail.com";
            string senderPassword = "nsnw pbbt nlye tsif";
            string receiverEmail = "tesingvisemail@gmail.com";


            MailMessage mail = new MailMessage(senderEmail, receiverEmail);
            mail.Subject = "Invoice";
            mail.Body = body;

            //Attachment attachment = new Attachment(body);
            //mail.Attachments.Add(attachment);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
            finally
            {
                mail.Dispose();
                smtpClient.Dispose();
            }
            Console.WriteLine($"Sending email to: {senderEmail}\nSubject: {subject}\nBody: {body}");
        }
    }
}
