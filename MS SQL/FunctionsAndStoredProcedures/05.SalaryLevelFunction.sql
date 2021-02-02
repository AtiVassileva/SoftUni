CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4)) 
RETURNS NVARCHAR(10)
AS
BEGIN
	IF @Salary < 30000
	RETURN 'Low'
	ELSE IF @Salary <= 50000
	RETURN 'Average'
	 
	RETURN 'High'
END

SELECT Salary, 
dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel 
FROM Employees