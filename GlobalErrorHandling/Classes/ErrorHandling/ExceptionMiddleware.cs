using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GlobalErrorHandling.Classes.ErrorHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //This function falls between the server receiving the reauest and the action executing the request
        //essentially putting a try/catch block around every controller action.
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            //This block will be bypassed if context.ExceptionHandled = true is set in the exception filter
            catch (Exception ex)
            {
                await FormatResponse(httpContext, ex);
            }
        }

        private static Task FormatResponse(HttpContext context, Exception exception)
        {
            //Your custom response handler here.
            context.Response.ContentType = "application/json";
            return ExceptionHandlerFactory.GetErrorHandler(exception).HandleException(context.Response);
        }
    }
}
