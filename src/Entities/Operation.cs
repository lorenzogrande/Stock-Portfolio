using System;

namespace Kata
{
    public record Operation
    {
        public Stock Stock { get; }
        public int Amount { get; }
        public DateTime Date { get; }

        public Operation(
            Stock stock,
            int amount,
            DateTime dateOfOperation)
        {
            this.Stock = stock;
            this.Amount = amount;
            this.Date = dateOfOperation;
        }

        public OperationType Type()
        {
            if (Amount > 0)
            {
                return OperationType.BUY;
            }
            else
            {
                return OperationType.SELL;
            }
        }
    }
}