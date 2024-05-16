using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechStore.Application.Common.Errors;

namespace TechStore.API.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/errorHandle")]
        public IActionResult Error()
        {
            Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>()!.Error;
            var (statusCode, message) = exception switch
            {
                IExceptionService exceptionService => ((int)exceptionService.statusCode, exceptionService.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error ccourred.")
            };
            return Problem(statusCode: statusCode, title: message);
        }
    }
}
