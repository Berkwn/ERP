using Ardalis.SmartEnum;
using ERPServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Enums
{
    public sealed class OrderStatusEnum : SmartEnum<OrderStatusEnum>
    {
        public static readonly OrderStatusEnum Pending = new("Bekliyor", 1);
        public static readonly OrderStatusEnum RequirementPlanWorked =new("İhtiyaçlar planlaması yapıldı", 2);
        public static readonly OrderStatusEnum Complated = new("Tamamlandı", 3);

        public OrderStatusEnum(string name, int value) : base(name, value)
        {
        }
    }
}
