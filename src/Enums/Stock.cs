using Ardalis.SmartEnum;

namespace Kata
{
    public abstract class Stock : SmartEnum<Stock>
    {
        public static readonly Stock WaterFall = new WaterfallStock();
        public static readonly Stock Crafter = new CrafterStock();
        public static readonly Stock XP = new XPStock();

        private Stock(string name, int value) : base(name, value)
        {
        }

        public abstract decimal Price { get; }

        private sealed class WaterfallStock : Stock
        {
            public WaterfallStock() : base(CompanyConstants.OLD_SCHOOL_WATERFALL, 1) { }

            public override decimal Price => 5.75m;
        }

        private sealed class CrafterStock : Stock
        {
            public CrafterStock() : base(CompanyConstants.CRAFTER_MASTERS, 2) { }

            public override decimal Price => 17.25m;
        }
        private sealed class XPStock : Stock
        {
            public XPStock() : base(CompanyConstants.XP_PRACTITIONERS, 3) { }

            public override decimal Price => 25.55m;
        }
    }
}
