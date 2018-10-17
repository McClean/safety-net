using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GlobalErrorHandling.Interfaces;

namespace GlobalErrorHandling.Classes.ErrorHandling
{
    public static class ExceptionHandlerFactory
    {
        public static IExceptionHandler GetErrorHandler(Exception ex)
        {
            //Get all classes which inherit from BaseExceptionHandler 
            IEnumerable<Type> allErrorHandlers = Assembly.GetEntryAssembly().GetTypes()
                .Where(type => typeof(BaseExceptionHandler).IsAssignableFrom(type) && type != typeof(BaseExceptionHandler));

            //Find the correct exception handler implementation
            return allErrorHandlers.Select(comparator => (IExceptionHandler) Activator.CreateInstance(comparator))
                .FirstOrDefault(comp => comp.CanHandleException(ex));
        }
    }
}
