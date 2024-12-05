using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Server.Application.Features.Orders.GetAllOrders
{
    internal sealed class GetAllOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<GetAllOrderCommand, Result<List<Order>>>
    {
        public async Task<Result<List<Order>>> Handle(GetAllOrderCommand request, CancellationToken cancellationToken)
        {
            List<Order> orders = await orderRepository.GetAll()
                .Include(x => x.Customer)
                .Include(x => x.Details)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.Date)
                .ToListAsync(cancellationToken);

            return orders;
        }
        
    }
}
