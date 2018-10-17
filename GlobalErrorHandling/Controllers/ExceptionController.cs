using System;
using System.IO;
using GlobalErrorHandling.Classes.CustomExceptions;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers
{
    [Route("api/[controller]")]
    public class ExceptionController : Controller
    {
        // GET api/exception/5
        [HttpGet("{id}")]
        public string Trigger(int id)
        {
            //Control which exception is to be throw (for demonstrative purposes only
            switch (id)
            {
                case 1:
                    throw new FileNotFoundException("The requested file was not found");
                case 2:
                    throw new ArgumentNullException("The value entered was null");
                case 3:
                    throw new NullReferenceException("Null reference detected");
                case 4:
                    throw new MyCustomException("This is a user-defined exception");
                default:
                    throw new Exception("Final option");
            }
        }
    }
}
