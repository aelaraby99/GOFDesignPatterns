using Strategy.Domain.Aggregates.Customer;
using Strategy.Domain.Enums;

namespace Strategy.Infrastructure
{
    public class CustomerDataReader
    {
        private static List<Customer> _customers = new List<Customer>();

        public CustomerDataReader()
        {
            // Initialize with some sample data if the list is empty
            if (!_customers.Any())
            {
                _customers.Add(Customer.Create("John Doe"));
                _customers.Add(Customer.Create("Jane Smith", CustomerType.Silver));
                _customers.Add(Customer.Create("Bob Johnson", CustomerType.Gold));
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers.Where(c => !c.IsDeleted).ToList();
        }

        public Customer GetCustomerById(CustomerId id)
        {
            return _customers.FirstOrDefault(c => c.Id.Equals(id) && !c.IsDeleted) 
                ?? throw new KeyNotFoundException($"Customer with ID {id.Value} not found");
        }

        public Customer GetCustomerByName(string name)
        {
            return _customers.FirstOrDefault(c => c.Name == name && !c.IsDeleted)
                ?? throw new KeyNotFoundException($"Customer with name {name} not found");
        }

        public Customer AddCustomer(Customer customer)
        {
            if (_customers.Any(c => c.Name == customer.Name && !c.IsDeleted))
            {
                throw new InvalidOperationException($"Customer with name {customer.Name} already exists");
            }

            _customers.Add(customer);
            return customer;
        }

        public void DeleteCustomer(CustomerId id)
        {
            var customer = GetCustomerById(id);
            customer.Delete();
        }

        public void UpdateCustomerType(CustomerId id, CustomerType newType)
        {
            var customer = GetCustomerById(id);
            
            switch (newType)
            {
                case CustomerType.Silver when customer.Type == CustomerType.Regular:
                    customer.UpgradeToSilver();
                    break;
                case CustomerType.Gold:
                    customer.UpgradeToGold();
                    break;
                default:
                    throw new InvalidOperationException($"Cannot update customer type from {customer.Type} to {newType}");
            }
        }
    }
}
