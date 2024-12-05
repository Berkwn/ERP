using ERP.Server.Application.Features.Recipes.CreateRecipes;
using ERP.Server.Application.Features.Recipes.DeleteRecipeById;
using ERP.Server.Application.Features.RecipeDetails.DeleteRecipeDetailById;
using ERP.Server.Application.Features.Recipes.GetAllRecipes;
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
    public class RecipeController : ApiController
    {
        public RecipeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> GetAll(GetAllRecipeCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request,cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Create(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> DeleteById(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

    
    }
}
