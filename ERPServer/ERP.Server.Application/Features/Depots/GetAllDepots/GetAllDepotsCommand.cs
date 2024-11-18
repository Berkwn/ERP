using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Depots.GetAllDepots
{
    public sealed record GetAllDepotsCommand() :IRequest<Result<List<Depot>>>;

    public sealed class GetAllDepotsCommandHandler(IDepotRepository depotRepository) : IRequestHandler<GetAllDepotsCommand, Result<List<Depot>>>
{
        public async Task<Result<List<Depot>>> Handle(GetAllDepotsCommand request, CancellationToken cancellationToken)
        {
            List<Depot> depots= await depotRepository.GetAll().OrderBy(x=>x.Name).ToListAsync(cancellationToken);

            return depots;
        }
    }
}
