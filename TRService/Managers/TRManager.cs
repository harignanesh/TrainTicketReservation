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
            mail.Subject = "Train Ticket Has Been SuccessFully Booked By : " + objTR.BookedBY + "\n" ;
            mail.Body += "Your Ticket Number is " + objTR.TID + "\n";
            mail.Body += "------------------------------------" + "\n";
            mail.Body += "Number of Passenger :" + objTR.NumberOfPassenger + "\n";
            mail.Body += "Total Cost :" + objTR.TotalCost + "\n";
            mail.Body += "Place of Travel :" + objTR.Place + "\n";
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("traintickettesting01@gmail.com", "trainticket123");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            SmtpServer.Send("traintickettesting01@gmail.com", objTR.EmailId, mail.Subject, mail.Body);
          
        }
    }
}