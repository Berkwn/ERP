using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Customers.UpdateCustomers
{
    public sealed record  UpdateCustomerCommand
        (Guid Id,
        string Name,
        string taxDepartment,
        string taxNumber,
        string city,
        string district,
        string Address
        ) :IRequest<Result<string>>;
   
}
