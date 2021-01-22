-- 01. Find Names of All Employees by First Name
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

-- 02. Find Names of All employees by Last Name 
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

-- 03. Find First Names of All Employees
SELECT FirstName FROM Employees 
WHERE DepartmentID IN(3, 10)
AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

-- 04. Find All Employees Except Engineers
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%' 

-- 05. Find Towns with Name Length
SELECT [Name] FROM Towns
WHERE LEN([NAME]) IN (5,6)
ORDER BY [Name] ASC

-- 06. Find Towns Starting With
SELECT * FROM Towns
WHERE [Name] LIKE '[MKBE]%'

-- 07. Find Towns Not Starting With
SELECT * FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name] ASC

-- 08. Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

-- 09. Length of Last Name
SELECT FirstName, LastName FROM Employees 
WHERE LEN(LastName) = 5

-- 10. Rank Employees by Salary
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-- 11. Find All Employees with Rank 2 *
SELECT * FROM (
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
) AS Result
WHERE Rank = 2
ORDER BY Salary DESC