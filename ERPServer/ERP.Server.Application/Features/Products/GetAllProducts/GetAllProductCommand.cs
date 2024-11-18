using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Products.CreateProduct
{
    public sealed record GetAllProductCommand():IRequest<Result<List<Product>>>;

    internal sealed class GetAllProductCommandHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductCommand, Result<List<Product>>>
    {
        public async Task<Result<List<Product>>> Handle(GetAllProductCommand request, CancellationToken cancellationToken)
        {
          List<Product> product= await productRepository.GetAll().OrderBy(x=>x.Name).ToListAsync();

            return product;
        }
    }
}
