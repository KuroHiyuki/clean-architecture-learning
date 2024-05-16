using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace TechStore.API.Filter
{
    public class ErrorHandlingFilterMiddleware : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //var exception = context.Exception;
            var problemDetail = new ProblemDetails
            {
                Type = "https://bib.ietf.org/public/rfc/bibxml/reference.RFC.7296.xml",
                Title = "An error occurred while processing your request.",
                Status = (int)HttpStatusCode.InternalServerError
            };
            context.Result = new ObjectResult(problemDetail);
            context.ExceptionHandled = true;

        }
    }
}
