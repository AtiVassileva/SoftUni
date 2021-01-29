-- 01. Records Count
SELECT COUNT(*) AS Count FROM WizzardDeposits

-- 02. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

-- 03. Longest Magic Wand Per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand 
FROM WizzardDeposits
GROUP BY DepositGroup

--04. * Smallest Deposit Group Per Magic Wand Size
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) ASC

-- 05. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
GROUP BY DepositGroup

-- 06. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- 07. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum 
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- 08. Deposit Charge
SELECT DepositGroup, MagicWandCreator, 
MIN(DepositCharge) AS MinDepositCharge 
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator 
ORDER BY MagicWandCreator ASC, DepositGroup ASC

-- 09. Age Groups
SELECT AgeGroup, COUNT(AgeGroup) AS WizardCount 
FROM 
(
SELECT 
CASE
WHEN Age >= 0 AND Age <= 10 THEN '[0-10]' 
WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
WHEN Age >= 61 THEN '[61+]' 
END AS AgeGroup
FROM WizzardDeposits) AS Result
GROUP BY Result.AgeGroup

-- 10. First Letter
SELECT SUBSTRING(FirstName, 1, 1) AS FirstLetter
FROM WizzardDeposits 
WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName, 1, 1)

-- 11. Average Interest 
SELECT DepositGroup, IsDepositExpired, 
AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

-- 12. * Rich Wizard, Poor Wizard
SELECT 
SUM(HostWizard.DepositAmount - GuestWizard.DepositAmount) AS SumDifference
FROM WizzardDeposits HostWizard
JOIN WizzardDeposits GuestWizard 
ON HostWizard.Id + 1 = GuestWizard.Id 