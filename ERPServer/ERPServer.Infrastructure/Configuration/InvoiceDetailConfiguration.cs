using ERPServer.Domain.DTo;
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
    internal sealed class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.HasOne(x=>x.Product)
                .WithMany().OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.Quantity).HasColumnType("decimal(7,2)");
        }
    }
}
