using System;

namespace Kata
{
    public abstract class OperationFactory
    {
        public abstract Operation CreateOperation
            (string shareName,
            int amount,
            DateTime dateOfOperation);
    }

    public class OperationParser : OperationFactory
    {
        public override Operation CreateOperation
            (string shareName,
            int amount,
            DateTime dateOfOperation)
        {
            var stock = shareName switch
            {
                CompanyConstants.OLD_SCHOOL_WATERFALL => Stock.WaterFall,
                CompanyConstants.XP_PRACTITIONERS => Stock.XP,
                CompanyConstants.CRAFTER_MASTERS => Stock.Crafter,
                _ => throw new UnknownStockType(),
            };

            return new Operation(stock, amount, dateOfOperation);
        }

    }

}