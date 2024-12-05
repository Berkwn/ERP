using ERPServer.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Entities
{
    public sealed class InvoiceDetail :Entity
    {
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid DepotId { get; set; }
        public Depot? Depot { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
