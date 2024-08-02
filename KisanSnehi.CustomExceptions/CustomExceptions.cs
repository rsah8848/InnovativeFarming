using System;
using System.Collections.Generic;
using System.Text;

namespace KisanSnehi.CustomExceptions
{
    class CustomExceptions
    {
    }
    public class UserExistsException : Exception
    {
        public UserExistsException(String message)
            : base(message)
        {

        }
        public UserExistsException(String message, Exception ex)
            : base(message)
        {

        }
    }
    public class SqlException : Exception
    {
        public SqlException(String message)
            : base(message)
        {

        }
        public SqlException(String message, Exception ex)
            : base(message)
        {

        }
    }
    public class PasswordNotAvailableException : Exception
    {
        public PasswordNotAvailableException(String message)
            : base(message)
        {

        }
        public PasswordNotAvailableException(String message, Exception ex)
            : base(message)
        {

        }
    }

    public class IncorrectLoginCredentialsException : Exception
    {
        public IncorrectLoginCredentialsException(string message)
            : base(message)
        {

        }

        public IncorrectLoginCredentialsException(string message, Exception ex)
            : base(message)
        {

        }
    }
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string message)
            : base(message)
        {

        }

        public RecordNotFoundException(string message,Exception ex)
            : base(message)
        {

        }
    }

    public class InvalidIdException : Exception
    {
        public InvalidIdException(string message)
            : base(message)
        {

        }

        public InvalidIdException(string message, Exception ex)
            : base(message)
        {

        }
    }
}
