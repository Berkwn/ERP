using ERP.Server.Application.Features.Depots.CreateDepots;
using ERP.Server.Application.Features.Depots.DeleteById;
using ERP.Server.Application.Features.Depots.GetAllDepots;
using ERP.Server.Application.Features.Depots.UpdateDepots;
using ERPServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepotController : ApiController
    {
        public DepotController(IMediator mediator) : base(mediator)
        {
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(GetAllDepotsCommand request,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateDepotsCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteById(DeleteByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Update(UpdateDepotCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
