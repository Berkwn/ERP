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

namespace ERP.Server.Application.Features.Invoices.UpdateInvoice
{
    public sealed record UpdateInvoiceCommand
        (
        Guid Id,
         Guid CustomerId,
        DateOnly Date,
        int Type,
        string InvoiceNumber,
        List<InvoiceDetailDto> InvoiceDetails
        ) :IRequest<Result<string>>;

    internal sealed class UpdateInvoiceCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IInvioceRepository ınvioceRepository,IStockMovementRepository stockMovementRepository) : IRequestHandler<UpdateInvoiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice ınvoice = await ınvioceRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id, cancellationToken);
            
            if (ınvoice is null) 
            {
                return Result<string>.Failure("böyle bir fatura bulunamadı");
            }

            List<StockMovement> movements = await stockMovementRepository.Where(x => x.InvoiceId == ınvoice.Id).ToListAsync(cancellationToken);

            stockMovementRepository.DeleteRange(movements);

            mapper.Map(request,ınvoice);

            List<StockMovement> newmovements = new();
            foreach (var item in request.InvoiceDetails)
            {
                StockMovement movement = new()
                {
                    InvoiceId = ınvoice.Id,
                    NumberOfEntries = request.Type == 1 ? item.Quantity : 0,
                    NumberOfOutputs = request.Type == 2 ? item.Quantity : 0,
                    DepotId=item.DepotId,
                    price = item.Price,
                    ProductId = item.ProductId,
                };

                movements.Add(movement);
            }
            await stockMovementRepository.AddRangeAsync(newmovements, cancellationToken);   
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Fatura başarıyla güncellendi";
        }
    }
}
