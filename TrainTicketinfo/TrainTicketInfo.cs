using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRModels
{
    [Table("dbo.TrainTicketReservation")]
     public class TrainTicketInfo
    {
        [Key]
        public int TID { get; set; }
    
        public int TicketNumber { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPassenger { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime DateofTravel { get; set; }
        public string BookedBY { get; set; }
        public string EmailId { get; set; }

        //TicketID int,
        //TicketNumber int,
        //Price decimal,
        //NumberOfPassenger int,
        //TotalCost decimal,
        //DateofTravel datetime

    }
}
