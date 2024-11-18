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

namespace ERP.Server.Application.Features.Products.UpdateProducts
{
    public sealed record UpdateProductCommand
        (
        Guid Id,
        string Name,
        int TypeValue
        ) :IRequest<Result<string>>;


    internal sealed class UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByExpressionAsync(x => x.Id == request.Id);

            if (product is null)
            {
                return Result<string>.Failure("Ürün bulunamadı");
            }

            if (product.Name != request.Name)
            {
                bool isNameExists = await productRepository.AnyAsync(x => x.Name == request.Name);

                if (isNameExists)
                {
                    return Result<string>.Failure("Bu Ürün adı daha önce kullanılmış");
                }

            }

            mapper.Map(product,request);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Ürün başarıyla güncellendi";

        }
    }
}
