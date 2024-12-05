using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.RecipeDetails.UpdateRecipeDetail
{
    public sealed record UpdateRecipeDetailCommand(
        Guid Id,
        Guid ProductId,
        int Quantity
        ) : IRequest<Result<string>>;


}
