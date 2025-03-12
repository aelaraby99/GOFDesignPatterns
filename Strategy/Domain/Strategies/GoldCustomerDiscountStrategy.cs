using Strategy.Domain.ValueObjects;

namespace Strategy.Domain.Strategies
{
    public class GoldCustomerDiscountStrategy : IDiscountStrategy
    {
        private const decimal DiscountPercentage = 0.10m; 
        public Money CalculateDiscount(Money total)
        {
            return Money.Create(total.Amount * DiscountPercentage, total.Currency);
        }
    }
}
