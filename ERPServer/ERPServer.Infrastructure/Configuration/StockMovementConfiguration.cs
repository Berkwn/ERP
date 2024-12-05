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
    internal sealed class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.Property(x => x.NumberOfEntries).HasColumnType("decimal(7,2)");
            builder.Property(x => x.NumberOfOutputs).HasColumnType("decimal(7,2");
            builder.Property(x => x.price).HasColumnType("money");
        }
    }
}
