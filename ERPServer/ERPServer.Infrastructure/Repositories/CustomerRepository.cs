using ERPServer.Domain.Repository;
using System;
using GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPServer.Domain.Entities;
using ERPServer.Infrastructure.Context;

namespace ERPServer.Infrastructure.Repositories
{
    internal class CustomerRepository : Repository<Customer, ApplicationDbContext>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
