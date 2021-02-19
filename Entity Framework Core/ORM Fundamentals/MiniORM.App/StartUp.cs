namespace MiniORM.App
{
	using Data;
    using System.Linq;
    using Data.Entities;

	public class StartUp
	{
        private const string connectionString =
			"Server=.\\SQLEXPRESS;Database=MiniORM;Integrated Security=True";
		public static void Main()
		{
            var context = new SoftUniDbContext(connectionString);
			
			context.Employees.Add(new Employee
			{
				FirstName = "Gosho",
				LastName = "Inserted",
				DepartmentId = context.Departments.First().Id,
				IsEmployed = true,
			});

			var employee = context.Employees.Last();
			employee.FirstName = "Modified";

			context.SaveChanges();
		}
	}
}