using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    public class StandardFormatter : PortfolioFormatter
    {
        private const string HEADER =
            "company | shares | current price | current value | last operation";

        public string FormatItems(IEnumerable<PortfolioItem> portfolioItems)
        {
            var output = new StringBuilder();
            output.AppendLine(HEADER);
            foreach (var item in portfolioItems)
            {
                var newLine = item.Name + " | "
                            + item.StockQuantity + " | "
                            + "$" + item.Price.ToString("F") + " | "
                            + "$" + item.StockValue.ToString("F") + " | ";

                newLine += FormatLastOperation(item.LastOperation);
                output.AppendLine(newLine);
            }

            return output.ToString();
        }

        private static string FormatLastOperation(Operation operation)
        {
            var lastOperation = new StringBuilder();

            lastOperation.Append(operation.Type() == OperationType.BUY ? "bought" : "sold");
            lastOperation.Append(" " + (operation.Amount > 0 ? operation.Amount : operation.Amount * -1));
            lastOperation.Append(" on " + operation.Date.ToString("dd/MM/yyyy"));

            return lastOperation.ToString();
        }
    }
}