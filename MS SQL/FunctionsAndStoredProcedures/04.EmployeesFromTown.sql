CREATE PROCEDURE usp_GetEmployeesFromTown 
(@TownName VARCHAR(50)) AS
BEGIN
	SELECT FirstName AS [First Name], 
	LastName AS [Last Name]
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	WHERE t.Name = @TownName	
END

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'