using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPServer.Domain.Entities;
using GenericRepository;
namespace ERPServer.Domain.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
