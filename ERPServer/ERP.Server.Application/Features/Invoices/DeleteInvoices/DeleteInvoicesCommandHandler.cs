using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Server.Application.Features.Invoices.DeleteInvoices
{
    internal sealed class DeleteInvoicesCommandHandler(IInvioceRepository ınvioceRepository, IUnitOfWork unitOfWork,IStockMovementRepository stockMovementRepository) : IRequestHandler<DeleteInvoicesCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteInvoicesCommand request, CancellationToken cancellationToken)
        {
            Invoice ınvoice = await ınvioceRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id,cancellationToken);

            if(ınvoice is  null)
            {
                return Result<string>.Failure("böyle bir fatura bulunamadı");
            }

            List<StockMovement> movements = await stockMovementRepository.Where(x=>x.InvoiceId==ınvoice.Id).ToListAsync(cancellationToken);

            stockMovementRepository.DeleteRange(movements);

             ınvioceRepository.Delete(ınvoice);
           await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Fatura başarıyla silindi";
        }
    }
}
