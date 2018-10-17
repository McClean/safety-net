using System;
using System.Threading.Tasks;
using GlobalErrorHandling.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GlobalErrorHandling.Classes.ErrorHandling
{
    public abstract class BaseExceptionHandler :IExceptionHandler
    {
        protected Exception Exception { get; set; }

        //Qualifying function
        public abstract bool CanHandleException(Exception ex);
        //Response formatter
        public abstract Task FormatResponse(HttpResponse response);
    }
}
