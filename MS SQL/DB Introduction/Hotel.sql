CREATE DATABASE Hotel 

CREATE TABLE Employees(
Id INT PRIMARY KEY,
FirstName VARCHAR(90) NOT NULL,
LastName VARCHAR(90) NOT NULL ,
Title VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Employees(Id, FirstName, LastName, Title, Notes) VALUES 
('1', 'PESHO', 'PESHEV', 'CTO', NULL),
('2', 'GOSHO', 'GOSHEV', 'JUNIOR DEV', 'LOVES PIZZA'),
('3', 'STAMAT', 'STAMATOV', 'TEAM LEADER', 'COOL GUY')


CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY,
FirstName VARCHAR(90) NOT NULL,
LastName VARCHAR(90) NOT NULL,
PhoneNumber CHAR(10) NOT NULL,
EmergencyName VARCHAR(90) NOT NULL,
EmergencyNumber CHAR(10) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES 
('321', 'PESHO', 'PESHEV', '4324332', 'WEE', 'EWW', NULL),
('65454', 'GOSHO', 'GOSHEV', '39058', 'DWJX', 'DEWN', 'BIG BOSS'),
('9474', 'STAMAT', 'STAMATOV', '93938', 'AKSLS', 'SWKSW', 'COOL')

CREATE TABLE RoomStatus(
RoomStatus VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES 
('FREE', NULL),
('BEING CLEANED', 'SO MESSY'),
('TAKEN', 'SORRY')

CREATE TABLE RoomTypes(
RoomType VARCHAR(20) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes(RoomType, Notes) VALUES 
('APARTMENT', NULL),
('SINGLE', 'GOOD'),
('LUXURY', 'CLASSY AND STYLISH')

CREATE TABLE BedTypes(
BedType VARCHAR(20)  NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO BedTypes(BedType, Notes) VALUES 
('DOUBLE', NULL),
('SINGLE', 'GOOD'),
('WATERBED', 'SO COOL')

CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY,
RoomType VARCHAR(20) NOT NULL,
BedType VARCHAR(20) NOT NULL,
Rate INT,
RoomStatus VARCHAR(30)NOT NULL, 
Notes VARCHAR(MAX)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
('3902', 'LUXURY', 'DOUBLE', 10, 'TAKEN', NULL),
('5476', 'SINGLE', 'SINGLE', 8, 'FREE', 'IT IS NICE'),
('9320', 'DOUBLE', 'DOUBLE', 9, 'TAKEN', 'COMFY')

CREATE TABLE Payments(
Id INT PRIMARY KEY, 
EmployeeId INT NOT NULL,
PaymentDate DATETIME NOT NULL,
AccountNumber INT NOT NULL,
FirstDateOccupied DATETIME NOT NULL,
LastDateOccupied DATETIME NOT NULL,
TotalDays INT NOT NULL,
AmountCharged DECIMAL(15,2),
TaxRate DECIMAL(15,2),
TaxAmount INT,
PaymentTotal DECIMAL(15,2),
Notes VARCHAR(MAX)
)

INSERT INTO  Payments(Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, 
TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
('1', '34', 11/25/2020, '439430', 11/10/2020, 11/25/2020, 15, 43434, 9, 0, 2324, NULL),
('2', '32', 11/25/2020, '439430', 11/10/2020, 11/25/2020, 15, 224800, 9, 0, 432432, NULL),
('3', '93', 11/25/2020, '439430', 11/10/2020, 11/25/2020, 15, 423, 9, 0, 423432, NULL)

CREATE TABLE Occupancies (
Id INT PRIMARY KEY, 
EmployeeId INT NOT NULL,
DateOccupied DATETIME NOT NULL,
AccountNumber INT NOT NULL,
RoomNumber INT NOT NULL, 
RateApplied INT,
PhoneCharge DECIMAL(15,2),
Notes VARCHAR(MAX)
)

INSERT INTO Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, 
RateApplied, PhoneCharge, Notes) VALUES 
('1', '23', 12/9/2020, '7823', 362, 10, NULL, NULL),
('2', '32', 12/9/2020, '3232', 435, 8, 3232, NULL),
('3', '88', 12/9/2020, '329', 976, 6, 789, NULL)

-- Decrease Tax Rate 
UPDATE Payments
SET TaxRate = TaxRate * 0.97
SELECT TaxRate FROM Payments

-- Delete All Records From Occupancies
DELETE FROM Occupancies