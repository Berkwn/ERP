using AutoMapper;
using ERPServer.Domain.DTo;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Orders.UpdateOrders
{
    public sealed record UpdateOrderCommand
        (
        Guid Id,
        Guid CustomerId,
        DateOnly Date,
        DateOnly DelieveryDate,
        List<OrderDetailDto> OrderDetails
        ) : IRequest<Result<string>>;


    internal sealed class UpdateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository,IOrderDetailRepository orderDetailRepository) : IRequestHandler<UpdateOrderCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
           Order? order= await orderRepository.Where(x=>x.Id==request.Id).Include(x=>x.Details).FirstOrDefaultAsync();

            if(order is null)
            {
                return Result<string>.Failure("böyle bir sipariş bulunamadı");
            }

            orderDetailRepository.DeleteRange(order.Details);

            List<OrderDetail> orderDetails= request.OrderDetails.Select(s=> new OrderDetail
            {
                OrderId=request.Id,
                price=s.Price,
                ProductId =s.ProductId,
                Quantity = s.Quantity,
                
            }).ToList();

            await orderDetailRepository.AddRangeAsync(orderDetails,cancellationToken);

            mapper.Map(request, order);
           await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Sipariş başarıyla güncellendi";
        }
    }
}
