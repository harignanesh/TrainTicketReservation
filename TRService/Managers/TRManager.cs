using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRModels;
using TRService.IManager;
using System.Net.Mail;
using System.Net;

namespace TRService.Managers
{
    public class TRManager : ITRManager
    {
     
       

        public  void SendEmail(TrainTicketInfo objTR)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("traintickettesting01@gmail.com");
            mail.To.Add(objTR.EmailId);
            mail.Subject = "<b> Train Ticket Has Been SuccessFully Booked By : " + objTR.BookedBY + "<b>";
            mail.Body = "This is for testing SMTP mail from GMAIL";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("traintickettesting01@gmail.com", "trainticket123");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            SmtpServer.Send("traintickettesting01@gmail.com", objTR.EmailId, mail.Subject, mail.Body);
          
        }
    }
}