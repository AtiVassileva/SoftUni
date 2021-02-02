CREATE PROCEDURE usp_EmployeesBySalaryLevel (@SalaryLevel NVARCHAR(10))
AS
BEGIN
	SELECT FirstName AS [First Name], 
	LastName AS [Last Name]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
END

EXEC dbo.usp_EmployeesBySalaryLevel 'High'