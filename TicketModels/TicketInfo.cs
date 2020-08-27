using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketModels
{
    [Table("dbo.Ticket_reservation")]
    public class TicketInfo
    {
        [Key]
        public int Ticket_Id { get; set; }
        public string TicketNumber { get; set; }
        public string BookedBy { get; set; }
        public DateTime BookedTime { get; set; }
        public DateTime MovieTime { get; set; }
        public int NumberOfTickets { get; set; }
        public int TicketUnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public bool TicketStatus { get; set; }

        //Form DB to Refer
        //Ticket_Id int identity Primary Key,
        //TicketNumber nvarchar(30),
        //BookedBy Varchar(35),
        //BookedTime DateTime,
        //MovieTime DateTime,
        //NumberOfTickets int,
        //TicketUnitPrice int,
        //TotalAmount float,
        //TicketStatus nvarchar(10)
    }
}
