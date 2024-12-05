using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Server.Application.Features.Invoices.GetAllInvoices
{
    internal sealed class GetAllInvoicesQueryHandler(IInvioceRepository  ınvioceRepository) : IRequestHandler<GetAllInvoicesQuery, Result<List<Invoice>>>
    {
        public async Task<Result<List<Invoice>>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {
           List<Invoice> invoices= await ınvioceRepository.Where(x=>x.Type.Value==request.type).OrderBy(x=>x.Date).ToListAsync(cancellationToken);

           return invoices;
        }
    }
}
