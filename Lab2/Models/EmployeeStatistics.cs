namespace Lab2.Models;

class EmployeeStatistics(List<Employee> employees)
{
    readonly List<Employee> _employees = employees;

    public double AveragePay => _employees.Average(WeeklyPay);

    public Employee HighestPaid => _employees.MaxBy(WeeklyPay)!;

    public Employee LowestPaid => _employees.MinBy(WeeklyPay)!;

    public Dictionary<EmployeeType, double> PercentagesByType =>
        _employees.GroupBy(Type).ToDictionary(TypeOfEmployee, PercentageOfType);

    private static EmployeeType Type(Employee employee) => employee.Type;

    private static EmployeeType TypeOfEmployee(IGrouping<EmployeeType, Employee> group) => group.Key;

    private double WeeklyPay(Employee employee) => employee.GetPay();

    private double PercentageOfType(
        IGrouping<EmployeeType, Employee> group) => (double)group.Count() / _employees.Count * 100;
}