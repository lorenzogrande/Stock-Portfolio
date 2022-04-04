using System;

namespace Kata
{
    public class CurrentDateTimeProvider : DateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
