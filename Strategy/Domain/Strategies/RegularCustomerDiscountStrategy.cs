using Strategy.Domain.ValueObjects;

namespace Strategy.Domain.Strategies
{
    public class RegularCustomerDiscountStrategy : IDiscountStrategy
    {
        public Money CalculateDiscount(Money total)
        {
            return Money.Create(0, total.Currency);
        }
    }
}
