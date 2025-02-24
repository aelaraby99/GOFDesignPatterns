namespace BuilderPattern
{
    public sealed class Employee
    {
        public Employee(string name,string email,decimal basicSalary)
        {
            Name = name;
            Email = email;
            BasicSalary = basicSalary;
        }
        public decimal BasicSalary { get; }
        public string Name { get; }
        public string Email { get; }
    }
}