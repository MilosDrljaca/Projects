using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.CustomExceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException() : base()
        {

        }

        public RepositoryException(string message) : base(message)
        {

        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
