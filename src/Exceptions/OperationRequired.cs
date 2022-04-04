using System;
using System.Runtime.Serialization;

namespace Kata
{
    [Serializable]
    public class OperationRequired : Exception
    {
        public OperationRequired()
        {
        }

        public OperationRequired(string? message) : base(message)
        {
        }

        public OperationRequired(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OperationRequired(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}