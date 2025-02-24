namespace BuilderPattern
{
    public interface ISalaryCalculatorBuilder
    {
        public ISalaryCalculatorBuilder WithBonusPercentage(decimal bonusPercentage);
        public ISalaryCalculatorBuilder WithEducationPackage(decimal educationPackage);
        public ISalaryCalculatorBuilder WithTaxPercentage(int taxPercentage);
        public ISalaryCalculatorBuilder WithTransportation(decimal transportation);
        public SalaryCalculator Build();
    }
}