using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Mapping
{
    public class BidMap : EntityTypeConfiguration<Bid>
    {
        public BidMap()
        {
            HasKey(x => x.Id);

            Property(p => p.CompanyName)
               .HasColumnType("nvarchar");

            Property(p => p.CustomerId)
                .HasColumnType("int")
                .IsRequired();

            Property(p => p.Description)
               .HasColumnType("nvarchar");

            Property(p => p.Logo)
               .HasColumnType("nvarchar");

            Property(p => p.Price)
               .HasColumnType("decimal");
             
        }
    }
}
