using Strategy.Domain.ValueObjects;

namespace Strategy.Domain.Strategies
{
    public interface IDiscountStrategy
    {
        Money CalculateDiscount(Money total);
    }
}
