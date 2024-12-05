using ERPServer.Domain.DTo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Invoices.CreateInvoices
{
    public sealed record CreateInvoicesCommand(
         Guid CustomerId,
        DateOnly Date,
        int Type,
        string InvoiceNumber,
        List<InvoiceDetailDto> InvoiceDetails
        ) :IRequest<Result<string>>;
}
