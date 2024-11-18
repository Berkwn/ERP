using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERP.Server.Application.Features.Customers.CreateCustomers
{
    public sealed record CreateCustomerCommand
        (
        string Name,
        string taxDepartment,
        string taxNumber,
        string city,
        string district,
        string Address
        
        ):IRequest<Result<string>>;


    internal sealed class CraeteCustomerCommandHandler(ICustomerRepository customerRepository,IMapper mapper,IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            bool isTaxNumberExists = await customerRepository.AnyAsync(x => x.taxNumber == request.taxNumber);
            if (isTaxNumberExists) 
            {
                Result<string>.Failure("Aynı vergi numarası tekrar kayıt edilemez ");
            }

        

            Customer customer=mapper.Map<Customer>(request);

             await customerRepository.AddAsync(customer,cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Müşteri kaydı başarıyla tamamlandı";
        }
    }
}
