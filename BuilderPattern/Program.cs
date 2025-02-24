namespace BuilderPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            ISalaryCalculatorBuilder salaryCalculatorBuilder = new SalaryCalculatorBuilder();
            salaryCalculatorBuilder.WithTaxPercentage(10)
               .WithBonusPercentage(20)
               .WithEducationPackage(1000)
               .WithTransportation(500);
            SalaryCalculator salaryCalculator = salaryCalculatorBuilder.Build();
            Employee employee = new Employee("John Doe","john.doe@ninja.com",50000);
            Console.WriteLine(salaryCalculator.CalcaulteSalary(employee));
        }
    }
}