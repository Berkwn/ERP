using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Server.Application.Features.Orders.CreateOrders
{
    internal sealed class CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateOrderCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
Order? lastOrder = await orderRepository.Where(x => x.OrderNumberYear == request.Date.Year).OrderByDescending(x => x.OrderNumber).FirstOrDefaultAsync(cancellationToken);

            int lastOrderNumber = 0;

           if(lastOrder is not null) lastOrderNumber = lastOrder.OrderNumber;

            Order order = mapper.Map<Order>(request);
            order.OrderNumber += 1;
            order.OrderNumberYear=request.Date.Year;

            await orderRepository.AddAsync(order);
           await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Sipariş Başarıyla kaydedildi";
        }
    }
}
