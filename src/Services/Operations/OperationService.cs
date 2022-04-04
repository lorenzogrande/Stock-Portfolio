
using System.Collections.Generic;

namespace Kata
{
    public interface OperationService
    {
        public void SaveOperation(Operation operation);
        public IReadOnlyList<PortfolioItem> GetPortfolio();
    }
}