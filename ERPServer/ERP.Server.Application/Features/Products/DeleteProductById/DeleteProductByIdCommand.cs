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

namespace ERP.Server.Application.Features.Products.DeleteProductById
{
    public sealed record  DeleteProductByIdCommand(Guid Id) :IRequest<Result<string>>;

    internal sealed class DeleteProductByIdCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository) : IRequestHandler<DeleteProductByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {

            Product product = await productRepository.GetByExpressionAsync(x => x.Id == request.Id);

            if (product is null) 
            {
                return Result<string>.Failure("Böyle bir ürün bulunamadı");
            }

             productRepository.Delete(product);
           await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün başarıyla silindi.";
        }
    }
}
