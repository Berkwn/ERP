using ERPServer.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Entities
{
    public sealed class StockMovement : Entity
    {
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }
        public Guid DepotId { get; set; }
        public int NumberOfEntries { get; set; }
        public int NumberOfOutputs { get; set; }
        public int price { get; set; }
        public Invoice? Invoice { get; set; }
        public Guid? InvoiceId { get; set; }

    }
}
