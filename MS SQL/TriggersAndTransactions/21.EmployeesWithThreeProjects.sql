CREATE PROC usp_AssignProject(@employeeId INT, @projectID INT) AS
BEGIN TRANSACTION
DECLARE @employeeProjectsCount INT = (SELECT COUNT(*) FROM EmployeesProjects
WHERE EmployeeID = @employeeId);

IF (@employeeProjectsCount >= 3)
BEGIN
	ROLLBACK;
	THROW 50001, 'The employee has too many projects!', 1;
END

INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES
(@employeeId, @projectID)
COMMIT

-- Tests
EXEC usp_AssignProject 1, 19 -- Throws Exception
EXEC usp_AssignProject 2, 20 -- Passes Correctly