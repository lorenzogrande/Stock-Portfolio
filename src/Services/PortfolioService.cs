namespace Kata
{
    public class PortfolioService
    {
        private readonly OperationService _service;
        private readonly PortfolioPrinter _printer;
        private readonly DateTimeProvider _dateTimeProvider;

        public PortfolioService(
            OperationService service,
            PortfolioPrinter printer,
            DateTimeProvider dateTimeProvider)
        {
            _service = service;
            _printer = printer;
            _dateTimeProvider = dateTimeProvider;
        }

        public void Buy(string shareName, int amount)
        {
            var operation = new OperationParser()
                                .CreateOperation
                                    (shareName,
                                    amount,
                                    _dateTimeProvider.Now()
                                    );
            _service.SaveOperation(operation);
        }
        public void Sell(string shareName, int amount)
        {
            var operation = new OperationParser()
                                .CreateOperation
                                    (shareName,
                                    -amount,
                                    _dateTimeProvider.Now()
                                    );

            _service.SaveOperation(operation);
        }
        public void Print()
        {
            var portfolioItems = _service.GetPortfolio();
            _printer.PrintItems(portfolioItems);
        }
    }
}
