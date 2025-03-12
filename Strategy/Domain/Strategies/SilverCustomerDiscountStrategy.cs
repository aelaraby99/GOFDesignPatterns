using Strategy.Domain.ValueObjects;

namespace Strategy.Domain.Strategies
{
    public class SilverCustomerDiscountStrategy : IDiscountStrategy
    {
        private const decimal DiscountPercentage = 0.05m; 

        public Money CalculateDiscount(Money total)
        {
            return Money.Create(total.Amount * DiscountPercentage, total.Currency);
        }
    }
}
