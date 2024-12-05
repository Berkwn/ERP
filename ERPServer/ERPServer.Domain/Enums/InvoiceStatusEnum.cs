using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Enums
{
    public sealed class InvoiceStatusEnum : SmartEnum<InvoiceStatusEnum>
    {
        public static readonly InvoiceStatusEnum Purchase= new ("Alış faturası",1);
        public static readonly InvoiceStatusEnum Sales= new ("Satış faturası",2);

        public InvoiceStatusEnum(string name, int value) : base(name, value)
        {
        }
    }
}
