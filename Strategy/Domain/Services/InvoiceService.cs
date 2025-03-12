using Strategy.Domain.Aggregates.Customer;
using Strategy.Domain.Aggregates.Invoice;
using Strategy.Domain.Factories;
namespace Strategy.Domain.Services
{
    public class InvoiceService
    {
        public Invoice CreateInvoiceForCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var invoice = Invoice.Create(
                customer.Id,
                DiscountStrategyFactory.CreateStrategy(customer.Type)
            );
            return invoice;
        }
    }
}