using Strategy.Domain.Enums;
namespace Strategy.Domain.Aggregates.Customer
{
    public class Customer
    {
        public CustomerId Id { get; private set; }
        public string Name { get; private set; }
        public CustomerType Type { get; private set; }
        public bool IsDeleted { get; private set; }

        private Customer(CustomerId id, string name, CustomerType type)
        {
            Id = id;
            Name = name;
            Type = type;
            IsDeleted = false;
        }
        public static Customer Create(string name, CustomerType type = CustomerType.Regular)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name cannot be empty", nameof(name));

            return new Customer(CustomerId.New(), name, type);
        }

        public void UpgradeToSilver()
        {
            if (Type == CustomerType.Gold)
                throw new InvalidOperationException("Cannot downgrade from Gold to Silver");
            
            Type = CustomerType.Silver;
        }
        public void UpgradeToGold()
        {
            Type = CustomerType.Gold;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}