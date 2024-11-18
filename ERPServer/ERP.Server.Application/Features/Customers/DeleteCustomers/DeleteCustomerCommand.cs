using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Customers.DeleteCustomers
{
    public sealed record DeleteCustomerCommand(Guid id) :IRequest<Result<string>>;


    
    
}
