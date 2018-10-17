using System;
using System.Threading.Tasks;
using GlobalErrorHandling.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GlobalErrorHandling.Classes.ErrorHandling
{
    public abstract class BaseExceptionHandler :IExceptionHandler
    {
        protected Exception Exception { get; set; }

        public abstract bool CanHandleError(Exception ex);

        public abstract Task HandleException(HttpResponse response);
    }
}
