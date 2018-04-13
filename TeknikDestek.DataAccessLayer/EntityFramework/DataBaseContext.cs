using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikDestek.Entities;

namespace TeknikDestek.DataAccessLayer.EntityFramework
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<RAction> RActions { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestHistory> RequestHistories { get; set; }
        public DbSet<Responsible> ResponsibleOnes { get; set; }
        public DbSet<SCategory> SCategories { get; set; }
        public DbSet<Supporter> Supporters { get; set; }

        public DataBaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }

    }
}
