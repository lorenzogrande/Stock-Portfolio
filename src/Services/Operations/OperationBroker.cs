using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class OperationBroker : OperationService
    {
        private readonly OperationCollection _operationStore = new OperationCollection();

        public void SaveOperation(Operation operation)
        {
            _operationStore.AddOperation(operation);
        }
        public IReadOnlyList<Operation> GetHistory()
        {
            return _operationStore.GetStoredOperations();
        }

        public IReadOnlyList<PortfolioItem> GetPortfolio()
        {
            var portfolioList = new List<PortfolioItem>();
            var stockTypes = GetStockTypes();
            foreach (var currentStock in stockTypes)
            {
                portfolioList.Add(CreatePortfolioItem(currentStock));
            }

            return portfolioList.AsReadOnly();
        }

        public IReadOnlyList<Stock> GetStockTypes()
        {
            return _operationStore.
                GetStoredOperations()
                .Select(x => x.Stock)
                .Distinct()
                .ToList();
        }
        private PortfolioItem CreatePortfolioItem(Stock currentStock)
        {
            return new PortfolioItem
                    (
                        currentStock.Name,
                        GetStockQuantity(currentStock.Name),
                        currentStock.Price,
                        GetStockTotalValue(currentStock.Name),
                        GetLastOperation(currentStock.Name)
                    );
        }

        public int GetStockQuantity(string shareName)
        {
            return _operationStore.
                GetStoredOperations()
                .Where(x => x.Stock.Name.Equals(shareName))
                .Select(x => x.Amount)
                .Sum();
        }

        public decimal GetStockTotalValue(string shareName)
        {
            var quantityOfAStock = GetStockQuantity(shareName);
            var stockType = Stock.FromName(shareName);
            return stockType.Price * quantityOfAStock;
        }

        public Operation GetLastOperation(string shareName)
        {
            return _operationStore.
                GetStoredOperations()
                .Last(x => x.Stock.Name.Equals(shareName));
        }
    }
}