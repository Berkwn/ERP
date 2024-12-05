using ERP.Server.Application.Features.RecipeDetails.CreateRecipeDetail;
using ERP.Server.Application.Features.RecipeDetails.DeleteRecipeDetailById;
using ERP.Server.Application.Features.RecipeDetails.GetByIdRecipeWithDetails;
using ERP.Server.Application.Features.RecipeDetails.UpdateRecipeDetail;
using ERPServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipeDetailController : ApiController
    {
        public RecipeDetailController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Create(CreateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> GetByIdWithDetails(GetByIdRecipeWithDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> DeleteRecipeWithDetails(DeleteRecipeDetailByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> UpdateRecipeWithDetails(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
