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

namespace ERP.Server.Application.Features.Depots.DeleteById
{
    public sealed record DeleteByIdCommand(Guid Id) :IRequest<Result<string>>;

    public sealed class DeleteByIdCommandHandler(IDepotRepository depotRepository,IUnitOfWork unitOfWork) : IRequestHandler<DeleteByIdCommand, Result<string>>
{
        public async Task<Result<string>> Handle(DeleteByIdCommand request, CancellationToken cancellationToken)
        {
           
            Depot depot= await depotRepository.GetByExpressionAsync(x=>x.Id==request.Id);
            if(depot is null)
            {
                return Result<string>.Failure("Böyle bir depo bulunamadı");
            }

            depotRepository.Delete(depot);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Depo başarı ile silindi.";

        }
    }
}
