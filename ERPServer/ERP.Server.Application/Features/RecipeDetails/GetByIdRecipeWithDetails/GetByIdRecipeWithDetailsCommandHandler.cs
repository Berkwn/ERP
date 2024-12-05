using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Server.Application.Features.RecipeDetails.GetByIdRecipeWithDetails
{
    internal sealed class GetByIdRecipeWithDetailsCommandHandler(IRecipeRepository recipeRepository) : IRequestHandler<GetByIdRecipeWithDetailsCommand, Result<Recipe>>
    {
        public async Task<Result<Recipe>> Handle(GetByIdRecipeWithDetailsCommand request, CancellationToken cancellationToken)
        {
            Recipe? recipe = await recipeRepository
                .Where(x => x.Id == request.RecipeId)
                .Include(x => x.Product)
                .Include(x => x.RecipeDetails!.OrderBy(x => x.Product!.Name)).ThenInclude(x => x.Product).FirstOrDefaultAsync();

            if (recipe is null)
            {
                return Result<Recipe>.Failure("böyle bir reçete bulunamadı");
            }
            return recipe;
        }
    }
}
