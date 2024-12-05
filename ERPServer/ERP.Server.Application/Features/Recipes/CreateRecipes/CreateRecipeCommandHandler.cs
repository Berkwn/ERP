using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERP.Server.Application.Features.Recipes.CreateRecipes
{
    internal sealed class CreateRecipeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IRecipeRepository recipeRepository) : IRequestHandler<CreateRecipeCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
          bool isRecipeExists= await recipeRepository.AnyAsync(x=>x.ProductId==request.ProductId,cancellationToken);
            if (isRecipeExists) 
            {

                return Result<string>.Failure("Aynı üründen eklenmiş");

            }

            Recipe recipe = new()
            {
                ProductId = request.ProductId,
                RecipeDetails = request.RecipeDetails.Select(s =>
                new RecipeDetail()
                {
                    ProductId = s.productId,
                    Quantity = s.Quantity

                }).ToList(),
            };

            await recipeRepository.AddAsync(recipe);
           await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Reçete başarıyla oluşturuldu";
        }
    }
}
