using System.Collections.Generic;

namespace Kata
{
    public interface PortfolioFormatter
    {
        string FormatItems(IEnumerable<PortfolioItem> portfolioItems);
    }
}