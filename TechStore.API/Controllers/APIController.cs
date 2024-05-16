using Microsoft.AspNetCore.Mvc;
using TechStore.API.Const;

namespace TechStore.API.Controllers
{
    [ApiController]
    public class APIController : ControllerBase
    {
        protected IActionResult Problem(List<ErrorOr.Error> errors)
        {
            HttpContext.Items[HttpContextKeyItems.errors] = errors;
            var firstError = errors[0];
            var statusCodeHandle = firstError.Type switch
            {
                ErrorOr.ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorOr.ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorOr.ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCodeHandle, title: firstError.Description);
        }
    }
}
