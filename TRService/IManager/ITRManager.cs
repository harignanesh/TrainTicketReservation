using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRModels;

namespace TRService.IManager
{
    interface ITRManager
    {
         void SendEmail(TrainTicketInfo objTR);
    }
}
