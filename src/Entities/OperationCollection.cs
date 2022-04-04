using System;
using System.Collections.Generic;

namespace Kata
{
    public class OperationCollection
    {
        private readonly List<Operation> _store = new List<Operation>();
        public IReadOnlyList<Operation> GetStoredOperations() => _store.AsReadOnly();

        public void AddOperation(Operation operation)
        {
            _store.Add(operation);
        }
    }
}