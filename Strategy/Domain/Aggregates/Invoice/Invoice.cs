using Strategy.Domain.Aggregates.Customer;
using Strategy.Domain.ValueObjects;
using Strategy.Domain.Strategies;

namespace Strategy.Domain.Aggregates.Invoice
{
    public class Invoice
    {
        private readonly IDiscountStrategy _discountStrategy;
        private readonly List<InvoiceLine> _lines;

        public InvoiceId Id { get; }
        public CustomerId CustomerId { get; }
        public IReadOnlyCollection<InvoiceLine> Lines => _lines.AsReadOnly();
        public DateTime CreatedAt { get; }

        private Invoice(InvoiceId id, CustomerId customerId, IDiscountStrategy discountStrategy)
        {
            Id = id;
            CustomerId = customerId;
            _discountStrategy = discountStrategy;
            _lines = new List<InvoiceLine>();
            CreatedAt = DateTime.UtcNow;
        }

        public static Invoice Create(CustomerId customerId, IDiscountStrategy discountStrategy)
        {
            return new Invoice(InvoiceId.New(), customerId, discountStrategy);
        }

        public void AddLine(string description, Money unitPrice, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));

            var line = InvoiceLine.Create(description, unitPrice, quantity);
            _lines.Add(line);
        }

        public Money CalculateTotal()
        {
            var total = _lines.Aggregate(
                Money.Create(0),
                (current, line) => current.Add(line.CalculateSubtotal())
            );

            return total;
        }

        public Money CalculateNetTotal()
        {
            var total = CalculateTotal();
            var discount = _discountStrategy.CalculateDiscount(total);
            return total.Subtract(discount);
        }
    }
}
