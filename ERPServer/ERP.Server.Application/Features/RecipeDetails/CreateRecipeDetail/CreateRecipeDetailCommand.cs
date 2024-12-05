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

namespace ERP.Server.Application.Features.RecipeDetails.CreateRecipeDetail
{
    public sealed record CreateRecipeDetailCommand
        (
        Guid RecipeId,
        Guid ProductId,
        int Quantity
        ) : IRequest<Result<string>>;


    internal sealed class CreateRecipeDetailCommandHandler(
     IRecipeDetailRepository recipeDetailRepository,
     IUnitOfWork unitOfWork,
     IMapper mapper) : IRequestHandler<CreateRecipeDetailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            RecipeDetail? recipeDetail =
                await recipeDetailRepository
                .GetByExpressionWithTrackingAsync(p =>
                    p.RecipeId == request.RecipeId &&
                    p.ProductId == request.ProductId &&
                    p.Quantity == request.Quantity ,cancellationToken
                   
                    
                    );

            if (recipeDetail is not null)
            {
                recipeDetail.Quantity += request.Quantity;
            }
            else
            {
                recipeDetail = mapper.Map<RecipeDetail>(request);
                await recipeDetailRepository.AddAsync(recipeDetail, cancellationToken);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçete ürün kaydı başarıyla tamamlandı";
        }
    }
}
