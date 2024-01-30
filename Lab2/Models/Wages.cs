namespace Lab2.Models;

public class Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate,
                   double hours) : Employee(id, name, address, phone, sin, dob, dept)
{
    public Wages() : this("", "", "", "", 0, "", "", 0, 0) { }

    public double Rate { get; set; } = rate;
    public double Hours { get; set; } = hours;
    public override EmployeeType Type { get; } = EmployeeType.Wages;

    public override double GetPay() => Hours < 40 ? Rate * Hours : (Hours - 40) * 1.5 + Rate * 40;

    public override string ToString() => base.ToString() + $"\nRate: {Rate:C}\nHours: {Hours}\nPay: {GetPay():C}";
}
