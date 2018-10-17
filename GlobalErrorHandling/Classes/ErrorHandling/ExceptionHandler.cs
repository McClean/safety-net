using System;
using System.IO;
using System.Threading.Tasks;
using GlobalErrorHandling.Classes.CustomExceptions;
using Microsoft.AspNetCore.Http;


//Implementations for various exception types
namespace GlobalErrorHandling.Classes.ErrorHandling
{
    public class FileNotFoundExceptionHandler : BaseExceptionHandler
    {
        public override bool CanHandleError(Exception ex)
        {
            if (!(ex is FileNotFoundException)) return false;
            Exception = ex;
            return true;
        }

        public override Task HandleException(HttpResponse response)
        {
            response.StatusCode = 404;
            return response.WriteAsync(Exception.Message);
        }
    }
    public class ArgumentNullExceptionHandler : BaseExceptionHandler
    {
        public override bool CanHandleError(Exception ex)
        {
            if (!(ex is ArgumentNullException)) return false;
            Exception = ex;
            return true;
        }

        public override Task HandleException(HttpResponse response)
        {
            response.StatusCode = 406;
            return response.WriteAsync(Exception.Message);
        }
    }
    public class NullReferenceExceptionHandler : BaseExceptionHandler
    {
        public override bool CanHandleError(Exception ex)
        {
            if (!(ex is NullReferenceException)) return false;
            Exception = ex;
            return true;
        }

        public override Task HandleException(HttpResponse response)
        {
            response.StatusCode = 403;
            return response.WriteAsync(Exception.Message);
        }
    }
    public class MyCustomExceptionHandler : BaseExceptionHandler
    {
        public override bool CanHandleError(Exception ex)
        {
            if (!(ex is MyCustomException)) return false;
            Exception = ex;
            return true;
        }

        public override Task HandleException(HttpResponse response)
        {
            response.StatusCode = 401;
            return response.WriteAsync(Exception.Message);
        }
    }
    public class ExceptionHandler : BaseExceptionHandler
    {
        public override bool CanHandleError(Exception ex)
        {
            
            if (!(ex is Exception)) return false;
            Exception = ex;
            return true;
        }

        public override Task HandleException(HttpResponse response)
        {
            response.StatusCode = 500;
            return response.WriteAsync(Exception.Message);
        }
    }
}
