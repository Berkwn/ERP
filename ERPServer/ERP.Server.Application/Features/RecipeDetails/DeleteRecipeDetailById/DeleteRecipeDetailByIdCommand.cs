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

namespace ERP.Server.Application.Features.RecipeDetails.DeleteRecipeDetailById
{
    public sealed record DeleteRecipeDetailByIdCommand(
        Guid Id
        ) : IRequest<Result<string>>;

    internal sealed class DeleteRecipeDetailByIdCommandHandler(IRecipeDetailRepository recipeDetailRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteRecipeDetailByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteRecipeDetailByIdCommand request, CancellationToken cancellationToken)
        {

            RecipeDetail recipeDetail = await recipeDetailRepository.GetByExpressionAsync(x => x.Id == request.Id);
            if (recipeDetail == null)
            {
                return Result<string>.Failure("böyle bir reçete detay bulunamadı");

            }

            recipeDetailRepository.Delete(recipeDetail);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Reçete detay başarıyla silindi";
        }
    }
}
