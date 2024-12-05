using AutoMapper;
using ERP.Server.Application.Features.Customers.CreateCustomers;
using ERP.Server.Application.Features.Customers.UpdateCustomers;
using ERP.Server.Application.Features.Depots.CreateDepots;
using ERP.Server.Application.Features.Depots.UpdateDepots;
using ERP.Server.Application.Features.Invoices.CreateInvoices;
using ERP.Server.Application.Features.Orders.CreateOrders;
using ERP.Server.Application.Features.Orders.UpdateOrders;
using ERP.Server.Application.Features.Products.CreateProducts;
using ERP.Server.Application.Features.Products.UpdateProducts;
using ERP.Server.Application.Features.RecipeDetails.CreateRecipeDetail;
using ERP.Server.Application.Features.Recipes.CreateRecipes;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Enums;

namespace ERP.Server.Application.Mapping
{
    public sealed class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();

            CreateMap<CreateDepotsCommand, Depot>();
            CreateMap<UpdateDepotCommand, Depot>();

            CreateMap<CreateProductCommand, Product>()
                .ForMember(member => member.type, options => options.MapFrom(value => ProductTypeEnum.FromValue(value.TypeValue)));


            CreateMap<UpdateProductCommand, Product>()
               .ForMember(member => member.type, options => options.MapFrom(value => ProductTypeEnum.FromValue(value.TypeValue)));

            CreateMap<CreateRecipeCommand, Recipe>();

            CreateMap<CreateRecipeDetailCommand,RecipeDetail>();

            CreateMap<CreateOrderCommand, Order>().ForMember(member => member.Details,
                options => options.MapFrom(x => x.OrderDetails.Select(s => new OrderDetail
                {
                    ProductId= s.ProductId,
                    price = s.Price,
                    Quantity = s.Quantity,

                }).ToList()));

            CreateMap<UpdateOrderCommand, Order>().ForMember(member => member.Details, options => options.Ignore());

            CreateMap<CreateInvoicesCommand, Invoice>()
                .ForMember(member=>member.Type,options=>options.MapFrom(x=> InvoiceStatusEnum.FromValue(x.Type)))
                .ForMember(member => member.Details,
               options => options.MapFrom(x => x.InvoiceDetails.Select(s => new OrderDetail
               {
                   ProductId = s.ProductId,
                   price = s.Price,
                   Quantity = s.Quantity,

               }).ToList()));
        }

    }
}
