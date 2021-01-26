-- 01. Employee Address
SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText 
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
ORDER BY AddressID ASC

-- 02. Addresses with Towns
SELECT TOP(50) e.FirstName, e.LastName, t.Name AS Town, a.AddressText 
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID
ORDER BY FirstName ASC, LastName ASC

-- 03. Sales Employee
SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName 
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

-- 04. Employee Departments
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName 
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary >= 15000
ORDER BY d.DepartmentID ASC

-- 05. Employees Without Project
SELECT TOP(3) e.EmployeeID, FirstName FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

-- 06. Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName 
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate ASC

-- 07. Employees with Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName 
FROM Employees e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC

-- 08. Employee 24
SELECT e.EmployeeID, e.FirstName, 
CASE 
WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
ELSE p.Name
END AS ProjectName
FROM Employees e
FULL JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
FULL JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24 

-- 09. Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName 
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID ASC

-- 10. Employee Summary
SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName,
m.FirstName + ' ' + m.LastName AS ManagerName,
d.Name AS DepartmentName
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
JOIN Departments d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- 11. Min Average Salary
SELECT TOP(1) AVG(Salary) AS MinAverageSalary 
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY e.DepartmentID
ORDER BY MinAverageSalary ASC