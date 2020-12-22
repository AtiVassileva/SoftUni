using System;
using System.Linq;
using System.Collections.Generic;

namespace Company_Roster
{
    class Program
    {
        static void Main()
        {
            var departments = new List<Department>();

            var employeesCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < employeesCount; i++)
            {
                var inputArr = Console.ReadLine().Split();

                if (!departments.Any(d => d.DepartmentName == inputArr[2]))
                {
                    departments.Add(new Department(inputArr[2]));
                }

                departments.Find(d => d.DepartmentName == inputArr[2]).AddNewEmployee(inputArr[0], decimal.Parse(inputArr[1]));
            }

            var bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (var employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
    }

    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public decimal TotalSalaries { get; set; }

        public void AddNewEmployee(string empName, decimal empSalary)
        {
            this.TotalSalaries += empSalary;
            this.Employees.Add(new Employee(empName, empSalary));
        }

        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
        }
    }
}