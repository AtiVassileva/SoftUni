CREATE TABLE Deleted_Employees
(EmployeeId INT PRIMARY KEY IDENTITY, 
FirstName VARCHAR(50) NOT NULL, 
LastName VARCHAR(50) NOT NULL, 
MiddleName VARCHAR(50), 
JobTitle VARCHAR(50) NOT NULL, 
DepartmentId INT, 
Salary MONEY NOT NULL
) 

CREATE TRIGGER tr_AddDeletedEmployeesInTable
ON Employees AFTER DELETE
AS
INSERT INTO Deleted_Employees
	SELECT FirstName, LastName, MiddleName, 
	JobTitle, DepartmentID, Salary
	FROM deleted