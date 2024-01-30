namespace Lab2.Models;

class EmployeeDashboard(List<Employee> employees)
{
    private readonly List<Employee> _employees = employees;

    public void DisplayAverageWeeklyPay() =>
        Console.WriteLine($"The average weekly pay for all employees is {new EmployeeStatistics(_employees).AveragePay:C}");

    public void DisplayHighestPaidOfType(EmployeeType type)
    {
        var highestPayedEmployeeOfType = new EmployeeStatistics(EmployeesOfType(type)).LowestPaid;
        Console.WriteLine($"The {type} employee with the highest weekly pay is " +
        highestPayedEmployeeOfType.Name +
        $", who receives {highestPayedEmployeeOfType.GetPay():C}");
    }

    public void DisplayLowestPaidOfType(EmployeeType type)
    {
        var lowestPayedEmployeeOfType = new EmployeeStatistics(EmployeesOfType(type)).HighestPaid;
        Console.WriteLine($"The {type} employee with the lowest weekly pay is " +
        lowestPayedEmployeeOfType.Name +
        $", who receives {lowestPayedEmployeeOfType.GetPay():C}");
    }

    public void DisplayPercentagesByType()
    {
        var percentagesOfEmployeesByType = new EmployeeStatistics(_employees).PercentagesByType;
        Console.WriteLine("These are the percentages of employees by type:");
        percentagesOfEmployeesByType.Select(Format).ToList().ForEach(Console.WriteLine);
    }

    private List<Employee> EmployeesOfType(
        EmployeeType employeeType) => _employees.FindAll((employee) => employee.Type == employeeType);

    private string Format(KeyValuePair<EmployeeType, double> employeePercentageByType)
    {
        EmployeeType employeeType = employeePercentageByType.Key;
        double percentage = employeePercentageByType.Value;
        return $"{employeeType}: {percentage:F2}%";
    }
}