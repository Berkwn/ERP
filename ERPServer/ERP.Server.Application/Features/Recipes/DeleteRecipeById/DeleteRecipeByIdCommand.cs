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

namespace ERP.Server.Application.Features.Recipes.DeleteRecipeById
{
    public sealed record DeleteRecipeByIdCommand
        (
        Guid Id
        ):IRequest<Result<string>>;

    internal sealed class DeleteRecipeByIdCommandHandler(IUnitOfWork unitOfWork, IRecipeRepository recipeRepository) : IRequestHandler<DeleteRecipeByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
        { 
           Recipe recipe= await recipeRepository.GetByExpressionAsync(x=>x.Id==request.Id,cancellationToken);
            
            if(recipe is null)
            {
                return Result<string>.Failure("Böyle bir reçete bulunamadı");
            }

            recipeRepository.Delete(recipe);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçete başarıyla silindi";
        }
    }
}
