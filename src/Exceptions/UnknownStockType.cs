using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    public class UnknownStockType : Exception
    {
        public UnknownStockType()
        {
        }

        public UnknownStockType(string? message) : base(message)
        {
        }

        public UnknownStockType(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnknownStockType(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}