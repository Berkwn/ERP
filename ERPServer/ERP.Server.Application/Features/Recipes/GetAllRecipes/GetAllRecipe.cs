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

namespace ERP.Server.Application.Features.Recipes.GetAllRecipes
{
    public sealed record GetAllRecipeCommand() :IRequest<Result<List<Recipe>>>;

    public sealed class GetAllRecipeCommandHandler(IRecipeRepository recipeRepository) : IRequestHandler<GetAllRecipeCommand, Result<List<Recipe>>>
    {
        public async Task<Result<List<Recipe>>> Handle(GetAllRecipeCommand request, CancellationToken cancellationToken)
        {
            List<Recipe> recipes = await recipeRepository.GetAll().Include(x => x.Product).OrderBy(x => x.Product!.Name).ToListAsync();

            return recipes;
        }
    }
}
