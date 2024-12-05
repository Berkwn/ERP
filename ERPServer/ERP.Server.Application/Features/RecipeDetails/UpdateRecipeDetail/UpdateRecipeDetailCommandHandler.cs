using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.RecipeDetails.UpdateRecipeDetail
{
    public sealed class UpdateRecipeDetailCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IRecipeDetailRepository recipeDetailRepository) : IRequestHandler<UpdateRecipeDetailCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            RecipeDetail recipeDetail = await recipeDetailRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id);

            if (recipeDetail is null)
            {

                return Result<string>.Failure("Reçetede bu ürün bulunamadı");
            }

            RecipeDetail? oldRecipeDetail = await recipeDetailRepository
                .Where(
                p => p.Id == request.Id &&
                p.ProductId == request.ProductId &&
                p.RecipeId == recipeDetail.RecipeId
                ).FirstOrDefaultAsync(cancellationToken);

            if (oldRecipeDetail is null)
            {
                recipeDetailRepository.Delete(recipeDetail);

                oldRecipeDetail.Quantity += request.Quantity;
                recipeDetailRepository.Update(recipeDetail);
            }
            else
            {
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            return "Reçetedeki ürün güncellendi";
        }
    }
}
