using ERPServer.Domain.Abstractions;
using ERPServer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Entities
{
    public sealed class Order:Entity
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int OrderNumberYear { get; set; }
        public int OrderNumber { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;
        public List<OrderDetail>? Details { get; set; }
    }
}
