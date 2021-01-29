-- 13. Departments Total Salaries
SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees 
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinimumSalary FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

-- 15. Employees Average Salaries
SELECT *
INTO TestTable
FROM Employees
WHERE Salary > 30000

DELETE TestTable
WHERE ManagerID = 42

UPDATE TestTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AvgSalary
FROM TestTable
GROUP BY DepartmentID

-- 16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

-- 17. Employees Count Salaries
SELECT COUNT(Salary) AS Count
FROM Employees
WHERE ManagerID IS NULL

-- 18. *3rd Highest Salary
SELECT DISTINCT Result.DepartmentID, Result.Salary AS ThirdHighestSalary 
FROM (SELECT DepartmentID, Salary,
DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
FROM Employees) AS Result
WHERE Rank = 3

-- 19. **Salary Challenge
SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS e
WHERE Salary > (SELECT AVG(Salary) 
FROM Employees
WHERE DepartmentID = e.DepartmentID
GROUP BY DepartmentID)