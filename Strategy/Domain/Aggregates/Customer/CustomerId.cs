namespace Strategy.Domain.Aggregates.Customer
{
    public class CustomerId
    {
        public Guid Value { get; }

        private CustomerId(Guid value)
        {
            Value = value;
        }

        public static CustomerId New()
        {
            return new CustomerId(Guid.NewGuid());
        }

        public static CustomerId FromGuid(Guid value)
        {
            return new CustomerId(value);
        }

        public override bool Equals(object obj)
        {
            if (obj is CustomerId other)
                return Value.Equals(other.Value);
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
