using System;
using System.Collections.Generic;
using System.Data.Entity;
using TRModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRDBContext
{
   public class TrainDBContext:DbContext
    {
        public TrainDBContext() : base(@"Data Source=.;Initial Catalog=TESTDB;Integrated Security=True")
        {
        }
        public DbSet<TrainTicketInfo> TicketInfos { get; set; }
    }
}
