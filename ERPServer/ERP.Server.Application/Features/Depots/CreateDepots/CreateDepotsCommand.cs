using AutoMapper;
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

namespace ERP.Server.Application.Features.Depots.CreateDepots
{
    public sealed record CreateDepotsCommand
        (
        string Name,
        string City,
        string Town,
        string Address
        ) :IRequest<Result<string>> ;

    internal sealed class CreateDepotsCommandHandler(IUnitOfWork unitOfWork,IDepotRepository depotRepository,IMapper mapper) : IRequestHandler<CreateDepotsCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateDepotsCommand request, CancellationToken cancellationToken)
        {
           Depot depot = mapper.Map<Depot>(request);
            await depotRepository.AddAsync(depot,cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Depo Başarıyla oluşturuldu.";
        }
    }
}
