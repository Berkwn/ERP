using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERP.Server.Application.Features.Customers.UpdateCustomers
{
    internal sealed class UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository) : IRequestHandler<UpdateCustomerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await customerRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id,cancellationToken);

            if (customer == null) 
            {
                return Result<string>.Failure("böyle bir müşteri bulunamadı");
            }
            if (customer.taxNumber != request.taxNumber)
            {
                bool isTaxNumberExist = await customerRepository.AnyAsync(x => x.taxNumber == request.taxNumber, cancellationToken);
                if (isTaxNumberExist)
                {
                    return Result<string>.Failure("Vergi numarası daha önce kaydedilmiş");
                }
            }
            mapper.Map(request,customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Müşteri başarıyla güncellendi";
        }
    }
}
