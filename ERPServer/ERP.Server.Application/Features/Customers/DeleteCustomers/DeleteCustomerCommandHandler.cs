using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TS.Result;

namespace ERP.Server.Application.Features.Customers.DeleteCustomers
{
    internal sealed class DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository) : IRequestHandler<DeleteCustomerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await customerRepository.GetByExpressionAsync(x => x.Id == request.id);

            if (customer == null) 
            {
                return Result<string>.Failure("Böyle bir müşteri bulunamadı");
            }
            customerRepository.Delete(customer);
          await  unitOfWork.SaveChangesAsync(cancellationToken);


            return "Müşteri başarıyla silindi";
        }
    }
}
