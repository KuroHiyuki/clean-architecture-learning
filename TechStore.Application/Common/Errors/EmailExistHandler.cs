using System.Net;

namespace TechStore.Application.Common.Errors
{
    public class EmailExistHandler : Exception, IExceptionService
    {
        public HttpStatusCode statusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Email already exists.";
    }
}
