using ERP.Server.Application.Features.Orders.CreateOrders;
using ERP.Server.Application.Features.Orders.DeleteByIdOrders;
using ERP.Server.Application.Features.Orders.GetAllOrders;
using ERP.Server.Application.Features.Orders.UpdateOrders;
using ERP.Server.Application.Features.RecipeDetails.CreateRecipeDetail;
using ERP.Server.Application.Features.RecipeDetails.DeleteRecipeDetailById;
using ERP.Server.Application.Features.RecipeDetails.GetByIdRecipeWithDetails;
using ERP.Server.Application.Features.RecipeDetails.UpdateRecipeDetail;
using ERP.Server.Application.Features.RequirementsPlanningByOrderId;
using ERPServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ApiController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> GetAll(GetAllOrderCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> DeleteById(DeleteByOrderIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> UpdateRecipeWithDetails(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> RequirementPlanningByOrderId(RequirementPlanningByOrderIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
