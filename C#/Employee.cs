using System;

public class Employee
{
    public static void Main(string[] args)
    {
        int EmployeeId = 0;
        string Name = "";
        double Salary = 0.0;
        Console.WriteLine ("Enter employee id : ");
        EmployeeId = System.Convert.ToInt32(Console.ReadLine());
        Console.WriteLine ("Enter employee name : ");
        Name = Console.ReadLine();
        Console.WriteLine ("Enter employee salary : ");
        Salary = System.Convert.ToDouble(Console.ReadLine());
        string msg = "";
        msg = "Employee Id : " + EmployeeId + "\n";
        msg += "Employee Name : " + Name + "\n";
		    msg += "Employee Salary : " + Salary + "\n";
		    Console.WriteLine(msg);
    }
}
