using ERP.Server.Application.Features.Customers.CreateCustomers;
using ERP.Server.Application.Features.Customers.DeleteCustomers;
using ERP.Server.Application.Features.Customers.GetAllCustomers;
using ERP.Server.Application.Features.Customers.UpdateCustomers;
using ERPServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.WebAPI.Controllers
{
 
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class CustomerController : ApiController
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCustomersQuery request,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request,cancellationToken);

            return StatusCode(response.StatusCode,response);
        }
        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> Create(CreateCustomerCommand request,CancellationToken cancellationToken) 
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> Delete(DeleteCustomerCommand request,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerCommand request,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
