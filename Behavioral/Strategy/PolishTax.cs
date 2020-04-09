namespace Behavioral.Strategy
{
    public class PolishTax: ITaxProvider
    {
        public decimal GetTax(Order order) 
        {
            return 0.2m * order.Price;
        }  
    }
}