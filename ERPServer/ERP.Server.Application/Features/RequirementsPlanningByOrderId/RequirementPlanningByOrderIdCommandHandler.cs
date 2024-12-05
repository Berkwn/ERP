using ERPServer.Domain.DTo;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Enums;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Server.Application.Features.RequirementsPlanningByOrderId;

internal sealed class RequirementPlanningByOrderIdCommandHandler(IOrderRepository orderRepository,IStockMovementRepository stockMovementRepository,IRecipeRepository  recipeRepository,IUnitOfWork unitOfWork) : IRequestHandler<RequirementPlanningByOrderIdCommand, Result<RequirementPlanningByOrderIdCommandResponse>>
{
    public async Task<Result<RequirementPlanningByOrderIdCommandResponse>> Handle(RequirementPlanningByOrderIdCommand request, CancellationToken cancellationToken)
    {
       Order? order= await orderRepository
            .Where(x=>x.Id==request.OrderId)
            .Include(x=>x.Details!)
            .ThenInclude(x=>x.Product)
            .FirstOrDefaultAsync(cancellationToken);
        if( order is  null)
        {
            return Result<RequirementPlanningByOrderIdCommandResponse>.Failure("Sipariş bulunamadı");
        }

        List<ProductDto> uretilmesiGerekenUrunListesi = new();
        List<ProductDto> RequirementsPlanningProduct = new();

        if (order.Details is not null)
        {
            foreach (var item in order.Details)
            {
                var product = item.Product;

                List<StockMovement> stockMovements = await stockMovementRepository.Where(x => x.ProductId == product!.Id).ToListAsync(cancellationToken);

                int stock = stockMovements.Sum(x => x.NumberOfEntries) - stockMovements.Sum(x => x.NumberOfOutputs);

                if (stock < item.Quantity)
                {
                    ProductDto uretilmesiGerekenUrun = new()
                    {
                        Id = item.ProductId,
                        Quantity = item.Quantity - stock,
                        Name = product!.Name
                    };

                    uretilmesiGerekenUrunListesi.Add(uretilmesiGerekenUrun);
                }
            }

            foreach (var item in uretilmesiGerekenUrunListesi)
            {
                Recipe? recipe =
                    await recipeRepository
                    .Where(x => x.ProductId == item.Id)
                    .Include(x => x.RecipeDetails!)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefaultAsync(cancellationToken);

                if (recipe is not null && recipe.RecipeDetails is not null)
                {
                    if (recipe.RecipeDetails is not null)
                    {

                        foreach (var productn in recipe.RecipeDetails)
                        {
                            List<StockMovement> ürünMovements = await stockMovementRepository.Where(x => x.ProductId == productn!.ProductId).ToListAsync(cancellationToken);

                            int stock = ürünMovements.Sum(x => x.NumberOfEntries) - ürünMovements.Sum(x => x.NumberOfOutputs);


                            if (stock < productn.Quantity)
                            {
                                ProductDto ihtiyacOlanUrun = new()
                                {
                                    Id = productn.ProductId,
                                    Name = productn.Product!.Name,
                                    Quantity = productn.Quantity,
                                };

                                RequirementsPlanningProduct.Add(ihtiyacOlanUrun);
                            }
                        }

                    }
                }

            }


        }

        RequirementsPlanningProduct=RequirementsPlanningProduct
            .GroupBy(x=>x.Id)
            .Select(g=> new ProductDto()
            {
                Id=g.Key,
                Name=g.First().Name,
                Quantity=g.Sum(x=>x.Quantity)
            }).ToList();


        order.Status=OrderStatusEnum.RequirementPlanWorked;
        orderRepository.Update (order);
       await unitOfWork.SaveChangesAsync(cancellationToken);

        //siparişteki ürünlerin tüm depolarda olup olmadığına bakmam lazım
        //eğer yetersiz ise kaç tane lazım onu öğrenmem lazım
        // her ürün için gereken ürün reçetesini alacağım.

        return new RequirementPlanningByOrderIdCommandResponse(DateOnly.FromDateTime(DateTime.Now), order.OrderNumber + "Nolu sipariş ihtiyaç planlaaması", new(RequirementsPlanningProduct));
    }
}
