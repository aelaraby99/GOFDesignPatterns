namespace BuilderPattern
{
    public class SalaryCalculator
    {
        public SalaryCalculator(int taxPercentage = 0 , decimal bonusPercentage = 0 , decimal educationPackage = 0 
            , decimal transportation = 0)
        {
            TaxPercentage = taxPercentage;
            BonusPercentage = bonusPercentage;
            EducationPackage = educationPackage;
            Transportation = transportation;
        }
        public int TaxPercentage { get; }
        public decimal BonusPercentage { get; }
        public decimal EducationPackage { get; }
        public decimal Transportation { get; }
        public decimal CalcaulteSalary(Employee employee)
        {
            decimal salary = employee.BasicSalary;
            salary -= (salary * TaxPercentage) / 100;
            salary += (salary * BonusPercentage) / 100;
            salary += EducationPackage;
            salary += Transportation;
            return salary;
        }
    }
}