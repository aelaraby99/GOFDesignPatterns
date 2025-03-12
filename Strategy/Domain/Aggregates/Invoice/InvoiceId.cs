namespace Strategy.Domain.Aggregates.Invoice
{
    public class InvoiceId
    {
        public Guid Value { get; }

        private InvoiceId(Guid value)
        {
            Value = value;
        }

        public static InvoiceId New()
        {
            return new InvoiceId(Guid.NewGuid());
        }

        public static InvoiceId FromGuid(Guid value)
        {
            return new InvoiceId(value);
        }

        public override bool Equals(object obj)
        {
            if (obj is InvoiceId other)
                return Value.Equals(other.Value);
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
