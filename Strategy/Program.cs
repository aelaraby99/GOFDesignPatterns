using Strategy.Domain.Aggregates.Customer;
using Strategy.Domain.Aggregates.Invoice;
using Strategy.Domain.Enums;
using Strategy.Domain.Services;
using Strategy.Domain.ValueObjects;
using Strategy.Infrastructure;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize the services
            CustomerDataReader? customerReader = new CustomerDataReader();
            InvoiceService invoiceService = new InvoiceService();
            InvoicePrinterService invoicePrinter = new InvoicePrinterService();

            // Add new customers
            Customer? newCustomer = Customer.Create("Alice Brown");
            customerReader.AddCustomer(newCustomer);

            // Retrieve and display all customers
            Console.WriteLine("All Customers:");
            Console.WriteLine("-------------");
            foreach (var customer in customerReader.GetAllCustomers())
            {
                Console.WriteLine($"Name: {customer.Name}, Type: {customer.Type}");
            }

            // Upgrade a customer to Silver
            Customer? johnDoe = customerReader.GetCustomerByName("John Doe");
            customerReader.UpdateCustomerType(johnDoe.Id,CustomerType.Silver);
            Console.WriteLine($"\nUpgraded {johnDoe.Name} to {johnDoe.Type}");

            // Create invoices with different discount strategies using InvoiceService
            Invoice? regularInvoice = invoiceService.CreateInvoiceForCustomer(customerReader.GetCustomerByName("Alice Brown"));
            regularInvoice.AddLine("Laptop",Money.Create(1000),1);
            regularInvoice.AddLine("Mouse",Money.Create(50),2);

            Invoice? silverInvoice = invoiceService.CreateInvoiceForCustomer(customerReader.GetCustomerByName("Jane Smith"));
            silverInvoice.AddLine("Laptop",Money.Create(1000),1);
            silverInvoice.AddLine("Mouse",Money.Create(50),2);

            Invoice? goldInvoice = invoiceService.CreateInvoiceForCustomer(customerReader.GetCustomerByName("Bob Johnson"));
            goldInvoice.AddLine("Laptop",Money.Create(1000),1);
            goldInvoice.AddLine("Mouse",Money.Create(50),2);
            goldInvoice.AddLine("Keyboard",Money.Create(150),1);

            // Print individual invoice details
            Console.WriteLine("\nInvoice Details:");
            Console.WriteLine("---------------");
            invoicePrinter.PrintInvoiceDetails("Regular Customer (0% discount)",regularInvoice);
            invoicePrinter.PrintInvoiceDetails("Silver Customer (5% discount)",silverInvoice);
            invoicePrinter.PrintInvoiceDetails("Gold Customer (10% discount)",goldInvoice);

            // Print Invoice Summary
            Console.WriteLine("\nInvoice Summary:");
            Console.WriteLine("---------------");
            List<(string, Invoice)>? allInvoices = new List<(string, Invoice)>
            {
                ("Regular Customer (0% discount)",regularInvoice),
                ("Silver Customer (5% discount)",silverInvoice),
                ("Gold Customer (10% discount)",goldInvoice)

            };
            invoicePrinter.PrintInvoiceSummary(allInvoices);

            // Delete a customer
            Console.WriteLine("\nDeleting customer Alice Brown...");
            customerReader.DeleteCustomer(newCustomer.Id);

            // Show remaining customers
            Console.WriteLine("\nRemaining Customers:");
            Console.WriteLine("------------------");
            foreach (var customer in customerReader.GetAllCustomers())
            {
                Console.WriteLine($"Name: {customer.Name}, Type: {customer.Type}");
            }
        }
    }
}