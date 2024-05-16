//using Newtonsoft.Json;
namespace TechStore.API.Middleware
{
    public class ErrorMiddlewareHandle(RequestDelegate _next)
    {
        //private readonly RequestDelegate _next;

        //public ErrorMiddlewareHandle(RequestDelegate next) 
        //{ 
        //    _next = next;
        //}
        public async Task Invoke(HttpContext context)
        {
            //try
            //{
            //    await _next(context);
            //}
            //catch (Exception ex)
            //{
            //    await OnException(ex);
            //}
            await _next(context);
        }

        //private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        //{
        //    var code = HttpStatusCode.InternalServerError;
        //    var result = JsonConvert.SerializeObject(new {error = $"An Error has orcored: {ex.Message}"});
        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode= (int)code;
        //    return context.Response.WriteAsync(result);
        //}
    }
}
