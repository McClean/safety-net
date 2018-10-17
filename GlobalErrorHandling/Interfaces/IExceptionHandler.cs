using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GlobalErrorHandling.Interfaces
{
    public interface IExceptionHandler
    {
        bool CanHandleException(Exception ex);
        Task FormatResponse(HttpResponse response);
    }
}
