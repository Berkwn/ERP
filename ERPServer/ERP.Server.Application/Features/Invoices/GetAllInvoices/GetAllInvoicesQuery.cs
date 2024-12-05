using ERPServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Invoices.GetAllInvoices
{
    public sealed record GetAllInvoicesQuery(int type) :IRequest<Result<List<Invoice>>>
    {
    }
}
