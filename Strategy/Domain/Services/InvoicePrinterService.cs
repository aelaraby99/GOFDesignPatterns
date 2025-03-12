using Strategy.Domain.Aggregates.Invoice;

namespace Strategy.Domain.Services
{
    public class InvoicePrinterService
    {
        public void PrintInvoiceDetails(string customerType, Invoice invoice)
        {
            if (invoice == null)
                throw new ArgumentNullException(nameof(invoice));

            if (string.IsNullOrWhiteSpace(customerType))
                throw new ArgumentException("Customer type cannot be empty", nameof(customerType));

            var total = invoice.CalculateTotal();
            var netTotal = invoice.CalculateNetTotal();
            var discount = total.Amount - netTotal.Amount;

            Console.WriteLine($"\n{customerType}");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Total Amount: ${total.Amount:F2}");
            Console.WriteLine($"Discount Amount: ${discount:F2}");
            Console.WriteLine($"Net Total: ${netTotal.Amount:F2}");
        }

        public void PrintInvoiceSummary(IEnumerable<(string CustomerType, Invoice Invoice)> invoices)
        {
            if (invoices == null)
                throw new ArgumentNullException(nameof(invoices));

            Console.WriteLine("\nInvoice Details:");
            Console.WriteLine("---------------");
            
            foreach (var (customerType, invoice) in invoices)
            {
                PrintInvoiceDetails(customerType, invoice);
            }
        }
    }
}
