using DataAccesLayer.Mapping;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class SqlContext : DbContext
    {
        public SqlContext() : base("SigortamNetDb")
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseIfModelChanges<DbContext>());
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BidMap());
            modelBuilder.Configurations.Add(new CustomerMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
