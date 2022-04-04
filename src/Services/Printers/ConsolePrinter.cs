using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class ConsolePrinter : PortfolioPrinter
    {
        private readonly PortfolioFormatter _portfolioFormatter;
        public ConsolePrinter(PortfolioFormatter portfolioFormatter)
        {
            _portfolioFormatter = portfolioFormatter;
        }
        public void PrintItems(IEnumerable<PortfolioItem> portfolioItems)
        {
            var formattedItems = _portfolioFormatter.FormatItems(portfolioItems);
            Console.WriteLine(formattedItems);
        }
    }
}