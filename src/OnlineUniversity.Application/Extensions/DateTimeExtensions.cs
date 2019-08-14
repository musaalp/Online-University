using System;

namespace OnlineUniversity.Application.Extensions
{
    public static class DateTimeExtensions
    {
        public static int ToAge(this DateTime dateOfBirth)
        {
            return DateTime.Now.Year - dateOfBirth.Year;
        }

        public static int ToAge(this double average)
        {
            return (int)(DateTime.Now.Year - average);
        }
    }
}
