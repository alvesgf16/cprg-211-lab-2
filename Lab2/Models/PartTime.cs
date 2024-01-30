namespace Lab2.Models;

public class PartTime(string id, string name, string address, string phone, long sin, string dob, string dept,
                      double rate, double hours) : Employee(id, name, address, phone, sin, dob, dept)
{
    public PartTime() : this("", "", "", "", 0, "", "", 0, 0) { }

    public double Rate { get; set; } = rate;
    public double Hours { get; set; } = hours;
    public override EmployeeType Type { get; } = EmployeeType.PartTime;

    public override double GetPay() => Rate * Hours;

    public override string ToString() => base.ToString() + $"\nRate: {Rate:C}\nHours: {Hours}\nPay: {GetPay():C}";
}
