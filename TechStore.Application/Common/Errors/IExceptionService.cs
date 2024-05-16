using System.Net;


namespace TechStore.Application.Common.Errors
{
    public interface IExceptionService
    {
        public HttpStatusCode statusCode { get; }
        public string ErrorMessage { get; }
    }
}
