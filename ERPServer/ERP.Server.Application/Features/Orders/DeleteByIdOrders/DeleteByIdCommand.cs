using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Orders.DeleteByIdOrders
{
    public sealed record DeleteByOrderIdCommand(Guid Id) :IRequest<Result<string>>;

    internal sealed class DeleteByIdCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository) : IRequestHandler<DeleteByOrderIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteByOrderIdCommand request, CancellationToken cancellationToken)
        {
            Order order = await orderRepository.GetByExpressionAsync(x=>x.Id==request.Id,cancellationToken);
            if(order is null)
            {
                return Result<string>.Failure("Böyle bir kullanıcı bulunamadı");
            }
            orderRepository.Delete(order);
           await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Sipariş başarıyla silindi";
        }
    }
}
