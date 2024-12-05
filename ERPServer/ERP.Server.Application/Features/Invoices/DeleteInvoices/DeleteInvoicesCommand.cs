using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Invoices.DeleteInvoices
{
    public sealed record DeleteInvoicesCommand(Guid Id):IRequest<Result<string>>;
}
