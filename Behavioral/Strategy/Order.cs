namespace Behavioral.Strategy
{
    public class Order
    {
        public string Name {get; set; }
        public decimal Price {get; set;}
        private ITaxProvider _taxProvider {get;}

        public Order(ITaxProvider taxProvider)
        {
            _taxProvider = taxProvider;
        }

        public decimal TotalPrice { 
            get => Price + _taxProvider.GetTax(this);
        }
    }
}