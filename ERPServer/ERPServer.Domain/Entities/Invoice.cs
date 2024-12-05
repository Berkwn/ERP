using ERPServer.Domain.Abstractions;
using ERPServer.Domain.DTo;
using ERPServer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Entities
{
    public sealed class Invoice :Entity
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int InvoiceNumber { get; set; }
        public DateOnly Date { get; set; }

        public InvoiceStatusEnum Type { get; set; } = InvoiceStatusEnum.Purchase;
        public List<InvoiceDetailDto>? Details { get; set; }
    }
}
