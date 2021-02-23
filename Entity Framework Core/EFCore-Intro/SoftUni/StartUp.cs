using System;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();
            Console.WriteLine(DeleteProjectById(context));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new {e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary})
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var highPaidEmployees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new {e.FirstName, e.Salary})
                .OrderBy(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in highPaidEmployees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeesFromResearchAndDevelopment = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new {e.FirstName, e.LastName, DepName = e.Department.Name, e.Salary})
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employeesFromResearchAndDevelopment)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.DepName} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees.First(e => e.LastName == "Nakov");

            employee.Address = address;
            context.SaveChanges();

            var employeeAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            var sb = new StringBuilder();

            foreach (var empAddress in employeeAddresses)
            {
                sb.AppendLine(empAddress);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(x => x.Manager)
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(e => e.EmployeesProjects
                    .Any(p => p.Project.StartDate.Year >= 2001
                                    && p.Project.StartDate.Year <= 2003))
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");

                foreach (var project in employee.EmployeesProjects)
                {
                    sb.AppendLine($"--{project.Project.Name} -" +
                                       $" {project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - " +
                                       $"{(project.Project.EndDate == null ? "not finished" : project.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new { a.AddressText, TownName = a.Town.Name, EmployeesCount = a.Employees.Count })
               .OrderByDescending(a => a.EmployeesCount)
               .ThenBy(a => a.TownName)
               .ThenBy(a => a.AddressText)
               .Take(10)
               .ToList();


            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .First(e => e.EmployeeId == 147);

            var projects = context.EmployeesProjects
                .Where(ep => ep.EmployeeId == employee147.EmployeeId)
                .Select(ep => ep.Project.Name)
                .OrderBy(p => p)
                .ToList();

            var sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in projects)
            {
                sb.AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(e => e.Manager)
                .Include(d => d.Employees)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.Name} – {dep.Manager.FirstName} {dep.Manager.LastName}");

                var employeesInDep = dep.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

                foreach (var emp in employeesInDep)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var project in latestProjects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            var orderedEmployees = employees
                .Select(e => new {e.FirstName, e.LastName, e.Salary})
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in orderedEmployees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeesWithSa = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .Select(e => new {e.FirstName, e.LastName, e.JobTitle, e.Salary})
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employeesWithSa)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.First(p => p.ProjectId == 2);

            context.EmployeesProjects.ToList().ForEach(ep => context.EmployeesProjects.Remove(ep));
            context.Projects.Remove(project);

            context.SaveChanges();

            var sb = new StringBuilder();
            var afterDeleteProjects = context.Projects.Take(10).ToList();

            foreach (var proj in afterDeleteProjects)
            {
                sb.AppendLine(proj.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .First(t => t.Name == "Seattle");

            var employees = context.Employees
                .Where(e => e.Address.TownId == town.TownId)
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            var addresses = context.Addresses
                .Where(a => a.TownId == town.TownId)
                .ToList();

            foreach (var address in addresses)
            {
                address.TownId = null;
            }

            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }
    }
}