namespace Behavioral.Strategy
{
    public class USATax: ITaxProvider
    {
        public decimal GetTax(Order order) 
        {
            return 0.05m * order.Price;
        }
    }
}