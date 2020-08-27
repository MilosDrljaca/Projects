using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ValidationServiceException : ServiceException
    {
        public ValidationServiceException() : base()
        {

        }

        public ValidationServiceException(string message) : base(message)
        {

        }

        public ValidationServiceException(string message, Exception innerException) : base(message, innerException)
        {

        }


    }
}
