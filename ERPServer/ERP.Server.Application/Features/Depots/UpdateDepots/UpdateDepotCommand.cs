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

namespace ERP.Server.Application.Features.Depots.UpdateDepots
{
    public sealed record UpdateDepotCommand
        (
        Guid Id,
        string Name,
        string city,
        string town,
        string Address
        ) : IRequest<Result<string>>;

    public sealed class UpdateDepotCommandHandler(IUnitOfWork unitOfWork, IDepotRepository depotRepository, IMapper mapper) : IRequestHandler<UpdateDepotCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateDepotCommand request, CancellationToken cancellationToken)
        {
            Depot depot= await depotRepository.GetByExpressionWithTrackingAsync(x=>x.Id==request.Id,cancellationToken); 
            
            if(depot is null)
            {
                return Result<string>.Failure("Depo bulunamadı");
            }

            mapper.Map(request, depot);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Depo başarıyla güncellendi";
        }
    }
}
