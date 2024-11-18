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

namespace ERP.Server.Application.Features.Products.CreateProducts
{
    public sealed record CreateProductCommand
        (
          string Name,
          int TypeValue
        ): IRequest<Result<string>>;


    internal sealed class CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository) : IRequestHandler<CreateProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            bool isNameExists = await productRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (isNameExists)
            {
                return Result<string>.Failure("Aynı ürün daha önce kullanılmış");
            }

            Product product =  mapper.Map<Product>(request);
  
            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün başarılı bir şekilde eklendi";

        }
    }
}
