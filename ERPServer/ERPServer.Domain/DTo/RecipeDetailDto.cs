using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.DTo
{
    public sealed  record RecipeDetailDto
        (
        Guid productId,
        int Quantity
        );
    
    
}
