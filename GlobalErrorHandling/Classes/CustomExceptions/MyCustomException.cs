﻿using System;

namespace GlobalErrorHandling.Classes.CustomExceptions
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message)
        {

        }
    }
}
