namespace Practice_3
{
    enum CommodityCategory
    {
        Furniture, Grocery, Service
    }
    class Commodity
    {
        public CommodityCategory Category;
        public string CommodityName;
        public int CommodityQuantity;
        public double CommodityPrice;
        public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
        {
            this.Category = category;
            this.CommodityQuantity = commodityQuantity;
            this.CommodityName = commodityName;
            this.CommodityPrice = commodityPrice;
        }
    }
    class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates;
        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }
        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            if (!_taxRates.ContainsKey(category))
            {
                _taxRates.Add(category, taxRate);
            }
        }
        public double CalculateBillAmount(IList<Commodity> items)
        {
            double total = 0;
            foreach (var item in items)
            {
                if (!_taxRates.ContainsKey(item.Category))
                {
                    throw new ArgumentException($"Tax Rate for category{item.Category} is not set");
                }
                double taxRate = _taxRates[item.Category];
                double totalprice = item.CommodityPrice * item.CommodityQuantity;
                double totaltax = totalprice + (totalprice * taxRate / 100);
                total += totaltax;
            }
            return total;
        }


        static void Main(string[] args)
        {
            var commodities = new List<Commodity>()
            {
                new Commodity(CommodityCategory.Furniture,"Bed",2,50000),
                new Commodity(CommodityCategory.Grocery,"Flour",5,80),
                new Commodity(CommodityCategory.Service,"Insurance",8,8500),
            };
            var prepareBill = new PrepareBill();
            prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);
            var billAmount = prepareBill.CalculateBillAmount(commodities);
            Console.WriteLine($"{billAmount}");
        }
    }
}

            
