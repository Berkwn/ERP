using ERPServer.Domain.DTo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Orders.CreateOrders
{
    public sealed record CreateOrderCommand
        (
        Guid CustomerId,
        DateOnly Date,
        DateOnly DeliveryDate,
        List<OrderDetailDto> OrderDetails
        ) :IRequest<Result<string>>;
}
