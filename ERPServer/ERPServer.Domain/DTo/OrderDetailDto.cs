using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.DTo
{
    public sealed record OrderDetailDto
        (
        Guid ProductId,
        int Quantity,
        int Price
        );
    
    
}
