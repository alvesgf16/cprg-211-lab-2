using Lab2.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            DisplayEmployeeStatistics();
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    private static void DisplayEmployeeStatistics()
    {
        List<Employee> employees = ParseEmployeesFromFile();
        EmployeeDashboard dashboard = new(employees);
        dashboard.DisplayAverageWeeklyPay();
        dashboard.DisplayHighestPaidOfType(EmployeeType.Wages);
        dashboard.DisplayLowestPaidOfType(EmployeeType.Salaried);
        dashboard.DisplayPercentagesByType();
    }

    private static List<Employee> ParseEmployeesFromFile() => File.ReadLines("../../../res/employees.txt")
                                                                  .Select(ParseEmployeeFromLine)
                                                                  .ToList();

    private static Employee ParseEmployeeFromLine(string line)
    {
        var data = line.Split(':');
        return CreateEmployeeFrom(data);
    }

    private static Employee CreateEmployeeFrom(string[] employeeData)
    {
        
        string id = employeeData[0];
        string name = employeeData[1];
        string address = employeeData[2];
        string phone = employeeData[3];
        long sin = long.Parse(employeeData[4]);
        string dob = employeeData[5];
        string dept = employeeData[6];

        char firstDigitOfId = id[0];
        
        if ("01234".Contains(firstDigitOfId))
        {
            double salary = double.Parse(employeeData[7]);
            return new Salaried(id, name, address, phone, sin, dob, dept, salary);
        }
        else if ("567".Contains(firstDigitOfId))
        {
            double rate = double.Parse(employeeData[7]);
            double hours = double.Parse(employeeData[8]);
            return new Wages(id, name, address, phone, sin, dob, dept, rate, hours);
        }
        else
        {
            double rate = double.Parse(employeeData[7]);
            double hours = double.Parse(employeeData[8]);
            return new PartTime(id, name, address, phone, sin, dob, dept, rate, hours);
        }
    }
}