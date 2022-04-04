using System.Collections.Generic;

namespace Kata
{
    public interface PortfolioPrinter
    {
        void PrintItems(IEnumerable<PortfolioItem> portfolioItems);
    }
}