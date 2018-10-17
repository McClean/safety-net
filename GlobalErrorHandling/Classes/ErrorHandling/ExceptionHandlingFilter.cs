using System;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace GlobalErrorHandling.Classes.ErrorHandling
{
    public class ExceptionHandlingFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionHandlingFilter> _logger;

        public ExceptionHandlingFilter(ILogger<ExceptionHandlingFilter> logger)
        {
            _logger = logger;
        }

        //Excecuted whenever an action throws an exception
        public override void OnException(ExceptionContext context)
        {
           LogError(context);
        }

        private void LogError(ExceptionContext context)
        {
            Exception exception = context.Exception;
            ActionDescriptor actionInformation = context.ActionDescriptor;
            //TODO: Log any exception related information here
            _logger.Log(LogLevel.Critical, exception, $"{actionInformation.DisplayName} error");
            context.ExceptionHandled = false; //optional
                                              // Set this to true to avoid the catch block in the exception middleware
        }
    }
}