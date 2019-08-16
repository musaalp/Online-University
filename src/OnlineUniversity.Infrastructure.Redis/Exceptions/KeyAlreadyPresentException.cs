using System;

namespace OnlineUniversity.Infrastructure.Redis.Exceptions
{
    public class KeyAlreadyPresentException : Exception
    {
        public KeyAlreadyPresentException(string message) : base(message)
        {

        }
    }
}
