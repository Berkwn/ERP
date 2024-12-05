using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERP.Server.Application.Features.Invoices.CreateInvoices
{
    internal sealed class CreateInvoicesCommandHandler(IMapper mapper, IInvioceRepository ınvioceRepository,
        IUnitOfWork unitOfWork,IStockMovementRepository stockMovementRepository) : IRequestHandler<CreateInvoicesCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateInvoicesCommand request, CancellationToken cancellationToken)
        {
            Invoice ınvoice= mapper.Map<Invoice>( request );
            if(ınvoice.Details is not null)
            {
                List<StockMovement> movements = new(); 
                foreach (var item in ınvoice.Details)
                {
                    StockMovement stockMovement = new()
                    {
                        InvoiceId = ınvoice.Id,
                        NumberOfEntries = request.Type == 1 ? item.Quantity : 0,
                        NumberOfOutputs = request.Type == 2 ? item.Quantity : 0,
                        DepotId=item.DepotId,
                        price= item.Price,
                        ProductId=item.ProductId,

                       
                    };
                    movements.Add(stockMovement);
                }
                await stockMovementRepository.AddRangeAsync(movements,cancellationToken);
            }
            await ınvioceRepository.AddAsync(ınvoice, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);


            return "Fatura başarıyla oluşturuldu";
        }
    }
}
