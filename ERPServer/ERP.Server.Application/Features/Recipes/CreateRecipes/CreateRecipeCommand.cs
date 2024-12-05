using ERPServer.Domain.DTo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Recipes.CreateRecipes
{
    public sealed record CreateRecipeCommand
        (
        Guid ProductId,
        List<RecipeDetailDto> RecipeDetails
        ) : IRequest<Result<string>>;
}
