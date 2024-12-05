using ERPServer.Domain.Abstractions;
using ERPServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.DTo
{
    public sealed record InvoiceDetailDto (
            Guid Id,
            Guid ProductId,
            Guid DepotId,
            int Quantity,
            int Price

        );
   
}
