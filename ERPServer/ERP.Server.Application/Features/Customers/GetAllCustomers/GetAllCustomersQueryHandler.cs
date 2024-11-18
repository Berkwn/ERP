using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Server.Application.Features.Customers.GetAllCustomers
{
    internal sealed class GetAllCustomersQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetAllCustomersQuery, Result<List<Customer>>>
    {
        public async Task<Result<List<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customers = await customerRepository.GetAll().OrderBy(x=>x.Name).ToListAsync();

            return customers;
        }
    }
}
