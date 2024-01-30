namespace Lab2.Models;

public class Salaried(string id, string name, string address, string phone, long sin, string dob, string dept,
                      double salary) : Employee(id, name, address, phone, sin, dob, dept)
{
    public Salaried() : this("", "", "", "", 0, "", "", 0) { }

    public double Salary { get; set; } = salary;
    public override EmployeeType Type { get; } = EmployeeType.Salaried;

    public override double GetPay() => Salary;

    public override string ToString() => base.ToString() + $"\nSalary: {Salary:C}";
}
