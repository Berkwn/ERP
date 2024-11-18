using AutoMapper;
using ERP.Server.Application.Features.Customers.CreateCustomers;
using ERP.Server.Application.Features.Customers.UpdateCustomers;
using ERP.Server.Application.Features.Depots.CreateDepots;
using ERP.Server.Application.Features.Depots.UpdateDepots;
using ERP.Server.Application.Features.Products.CreateProducts;
using ERP.Server.Application.Features.Products.UpdateProducts;
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
        }
    }
}
