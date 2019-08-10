using System;

namespace OnlineUniversity.Domain.Courses
{
    public class CapacityOverflowException : Exception
    {
        public CapacityOverflowException(string message) : base(message)
        {
        }
    }
}
