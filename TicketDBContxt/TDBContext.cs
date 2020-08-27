using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketModels;

namespace TicketDBContxt
{
   public class TDBContext : DbContext
    {
        public TDBContext():base(@"Data Source=IN8INE0471\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True")
        {
        }
        public DbSet<TicketInfo> TicketInfos { get; set; }

    }
}
