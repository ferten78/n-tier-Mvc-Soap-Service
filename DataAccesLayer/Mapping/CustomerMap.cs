using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(x => x.Id);

            Property(p => p.IdentityNo)
                .HasColumnType("nvarchar");

            Property(p => p.LicenseSerialCode)
                .HasColumnType("nvarchar");

            Property(p => p.LicenseSerialNumber)
                .HasColumnType("nvarchar");

            Property(p => p.Plate)
                .HasColumnType("nvarchar");

            HasMany(p => p.CustomerBids)
                .WithRequired(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

        }
    }
}
