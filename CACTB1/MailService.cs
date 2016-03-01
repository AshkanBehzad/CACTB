using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CACTB1
{
    public class MailService
    {
        public static void SendMail(string mailBody,string subject,string to)
        {
            try
            {
                MailMessage mailMessage = new MailMessage("cea.iauctb@gmail.com",to)
                {
                    Subject = subject,
                    Body = mailBody
                };
                SmtpClient smtp = new SmtpClient();
                smtp.Send(mailMessage);
            }
            catch (Exception) { }

        }
    }
}