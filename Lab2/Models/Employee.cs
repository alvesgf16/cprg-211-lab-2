namespace Lab2.Models;

public class Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
{
    public Employee() : this("", "", "", "", 0, "", "") { }

    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Address { get; set; } = address;
    public string Phone { get; set; } = phone;
    public long Sin { get; set; } = sin;
    public string Dob { get; set; } = dob;
    public string Dept { get; set; } = dept;
    public virtual EmployeeType Type => throw new NotImplementedException();

    public virtual double GetPay() => throw new NotImplementedException();

    public override string ToString() => $"Employee ID: {Id}\n" +
        $"Name: {Name}\n" +
        $"Address: {Address}\n" +
        $"Phone: {Phone}\n" +
        $"SIN: {Sin}\n" +
        $"DOB: {Dob}\n" +
        $"Dept: {Dept}";
}
