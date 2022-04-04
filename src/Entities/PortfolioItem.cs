namespace Kata
{
    public record PortfolioItem
    {
        public string Name { get; }
        public int StockQuantity { get; }
        public decimal Price { get; }
        public decimal StockValue { get; }
        public Operation LastOperation { get; }

        public PortfolioItem(string name,
            int stockQuantity,
            decimal price,
            decimal stockValue,
            Operation operation)
        {
            if (operation == null)
            {
                throw new OperationRequired();
            }

            this.Name = name;
            this.StockQuantity = stockQuantity;
            this.Price = price;
            this.StockValue = stockValue;
            this.LastOperation = operation;
        }
    }
}