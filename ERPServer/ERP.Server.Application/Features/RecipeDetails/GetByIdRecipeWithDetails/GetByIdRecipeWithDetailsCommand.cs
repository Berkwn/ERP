using ERPServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.RecipeDetails.GetByIdRecipeWithDetails
{
    public sealed record GetByIdRecipeWithDetailsCommand(Guid RecipeId) : IRequest<Result<Recipe>>;
}
