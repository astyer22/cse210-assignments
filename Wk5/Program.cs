using System

namespace employee_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            HourlyEmployee hEmployee = new HourlyEmployee;
            hEmployee.SetName("John Doe");
            hEmployee.SetIdNumber("123abc");
            hEmployee.SetPayRate(15);
            hEmployee.SetHoursWorked(35);

            SalaryEmployee sEmployee = new SalaryEmployee;
            sEmployee.SetName("Jane Doe");
            sEmployee.SetIdNumber("456def");
            sEmployee.SetSalary(60000);

        DisplayEmployeeInformation(hEmployee);
        DisplayEmployeeInformation(sEmployee);
        }

        public static void DisplayEmployeeInformation(employee_demo employee)
        {
            Console.WriteLine($"{employee.GetName()}");
        }
    }
}