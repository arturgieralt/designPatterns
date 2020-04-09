namespace Behavioral.Strategy
{
    public interface ITaxProvider
    {
         decimal GetTax(Order order);
    }
}