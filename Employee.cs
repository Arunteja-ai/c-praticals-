using System;

// Interface
interface IPayroll
{
    double CalculateSalary();
    void DisplayDetails();
}

// Abstract Base Class
abstract class Employee : IPayroll
{
    protected int empId;
    protected string name;

    public Employee(int empId, string name)
    {
        this.empId = empId;
        this.name = name;
    }

    public abstract double CalculateSalary();
    public abstract void DisplayDetails();
}

// Full-Time Employee
class FullTimeEmployee : Employee
{
    private double monthlySalary;

    public FullTimeEmployee(int empId, string name, double monthlySalary)
        : base(empId, name)
    {
        this.monthlySalary = monthlySalary;
    }

    public override double CalculateSalary()
    {
        return monthlySalary;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("----- Full-Time Employee -----");
        Console.WriteLine("Employee ID : " + empId);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Salary      : $" + CalculateSalary());
        Console.WriteLine();
    }
}

// Part-Time Employee
class PartTimeEmployee : Employee
{
    private int hoursWorked;
    private double hourlyRate;

    public PartTimeEmployee(int empId, string name, int hoursWorked, double hourlyRate)
        : base(empId, name)
    {
        this.hoursWorked = hoursWorked;
        this.hourlyRate = hourlyRate;
    }

    public override double CalculateSalary()
    {
        return hoursWorked * hourlyRate;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("----- Part-Time Employee -----");
        Console.WriteLine("Employee ID : " + empId);
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Hours Worked: " + hoursWorked);
        Console.WriteLine("Hourly Rate : $" + hourlyRate);
        Console.WriteLine("Salary      : $" + CalculateSalary());
        Console.WriteLine();
    }
}

// Main Class
class Program
{
    static void Main(string[] args)
    {
        Employee[] employees =
        {
            new FullTimeEmployee(101, "Rahul", 50000),
            new PartTimeEmployee(102, "Priya", 80, 350),
            new FullTimeEmployee(103, "Amit", 65000),
            new PartTimeEmployee(104, "Sneha", 95, 300)
        };

        Console.WriteLine("====== Employee Payroll System ======\n");

        foreach (Employee emp in employees)
        {
            emp.DisplayDetails();
        }

        Console.ReadKey();
    }
}