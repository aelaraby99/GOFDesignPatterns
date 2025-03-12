using Strategy.Domain.Enums;
using Strategy.Domain.Strategies;

namespace Strategy.Domain.Factories
{
    public static class DiscountStrategyFactory
    {
        public static IDiscountStrategy CreateStrategy(CustomerType customerType)
        {
            return customerType switch
            {
                CustomerType.Regular => new RegularCustomerDiscountStrategy(),
                CustomerType.Silver => new SilverCustomerDiscountStrategy(),
                CustomerType.Gold => new GoldCustomerDiscountStrategy(),
                _ => throw new ArgumentException($"Unknown customer type: {customerType}", nameof(customerType))
            };
        }
    }
}
