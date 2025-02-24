namespace BuilderPattern
{
    public sealed class SalaryCalculatorBuilder: ISalaryCalculatorBuilder
    {
        private int _taxPercentage = 0;
        private decimal _bonusPercentage = 0;
        private decimal _educationPackage = 0;
        private decimal _transportation = 0;
        public SalaryCalculator Build()
        {
            return new SalaryCalculator(
                _taxPercentage,
                _bonusPercentage,
                _educationPackage,
                _transportation);
        }

        public ISalaryCalculatorBuilder WithBonusPercentage(decimal bonusPercentage)
        {
            _bonusPercentage = bonusPercentage;
            return this;
        }

        public ISalaryCalculatorBuilder WithEducationPackage(decimal educationPackage)
        {
            _educationPackage = educationPackage;
            return this;

        }

        public ISalaryCalculatorBuilder WithTaxPercentage(int taxPercentage)
        {
            _taxPercentage = taxPercentage;
            return this;
        }

        public ISalaryCalculatorBuilder WithTransportation(decimal transportation)
        {
            _transportation = transportation;
            return this;
        }
    }
}