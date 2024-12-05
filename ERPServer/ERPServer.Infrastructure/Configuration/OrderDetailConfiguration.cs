using ERPServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Infrastructure.Configuration
{
    public sealed class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasOne(x=>x.Product).WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.price).HasColumnType("money");
            builder.Property(x => x.Quantity).HasColumnType("decimal");
        }
    }
}
