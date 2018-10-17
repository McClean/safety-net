using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GlobalErrorHandling.Interfaces
{
    public interface IExceptionHandler
    {
        bool CanHandleError(Exception ex);
        Task HandleException(HttpResponse response);
    }
}
