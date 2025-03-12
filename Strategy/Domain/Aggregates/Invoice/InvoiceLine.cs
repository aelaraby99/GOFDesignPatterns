using Strategy.Domain.ValueObjects;

namespace Strategy.Domain.Aggregates.Invoice
{
    public class InvoiceLine
    {
        public string Description { get; }
        public Money UnitPrice { get; }
        public int Quantity { get; }

        private InvoiceLine(string description, Money unitPrice, int quantity)
        {
            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public static InvoiceLine Create(string description, Money unitPrice, int quantity)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty", nameof(description));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));

            return new InvoiceLine(description, unitPrice, quantity);
        }

        public Money CalculateSubtotal()
        {
            return UnitPrice.MultiplyBy(Quantity);
        }
    }
}
