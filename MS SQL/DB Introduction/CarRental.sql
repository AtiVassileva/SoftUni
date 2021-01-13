CREATE DATABASE CarRental 

CREATE TABLE Categories (
Id INT PRIMARY KEY,
CategoryName VARCHAR(100) NOT NULL,
DailyRate INT,
WeeklyRate INT,
MonthlyRate INT,
WeekendRate INT
)

INSERT INTO Categories(Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
(1, 'BRAND NEW', 10, 50, 200, 16),
(2, 'OLD ONES', 5, 25, 100, 4),
(3, 'LUXURIOUS', 9, 49, 230, 20)

CREATE TABLE Cars(
Id INT PRIMARY KEY,
PlateNumber CHAR(20),
Manufacturer VARCHAR(30) NOT NULL,
Model VARCHAR(20) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT, 
Doors INT NOT NULL,
Picture VARCHAR(60),
Condition VARCHAR(20),
Available BIT NOT NULL
)

INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId,
Doors, Picture, Condition, Available) VALUES
(1, 'D8JS', 'BMW', 'X6', 2009, 1, 5, NULL, 'NEW', 1),
(2, 'H65H', 'AUDI', 'R8', 2018, 3, 4, NULL, 'NEW', 1),
(3, 'D2E3', 'FORD', 'FIESTA', 2005, 2, 5, NULL, 'OLD', 0)

CREATE TABLE Employees(
Id INT PRIMARY KEY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Title VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) VALUES 
(1, 'PESHO', 'PESHOV', 'CEO', NULL),
(2, 'GOSHO', 'GOSHEV', 'MANAGER', 'I AM SO BUSY :('),
(3, 'PENKA', 'PENKOVA', 'THE BOSS', 'I AM THE BOSS')

CREATE TABLE Customers(
Id INT PRIMARY KEY,
DriverLicenceNumber VARCHAR(20) NOT NULL,
FullName VARCHAR(60) NOT NULL,
[Address] VARCHAR(60),
City VARCHAR(30) NOT NULL,
ZIPCode VARCHAR(10),
Notes VARCHAR(MAX)
)

INSERT INTO Customers(Id, DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
(1, '32MD', 'GOSHO PESHOV', NULL, 'SOFIA', NULL, 'I NEED A CAR'),
(2, '9WEN', 'PESHO GOSHEV', NULL, 'PLOVDIV', NULL, NULL),
(3, '348J', 'PENKA PENKOVA', 'PENKA STREET', 'VARNA', NULL, 'I LOVE BMW')

CREATE TABLE RentalOrders (
Id INT PRIMARY KEY,
EmployeeId INT,
CustomerId INT,
CarId INT,
TankLevel DECIMAL(15,2),
KilometrageStart DECIMAL(15,2),
KilometrageEnd DECIMAL(15,2),
TotalKilometrage DECIMAL(15,2) NOT NULL,
StartDate DATETIME NOT NULL,
EndDate DATETIME,
TotalDays INT NOT NULL,
RateApplied DECIMAL(15,2),
TaxRate DECIMAL(15,2),
OrderStatus VARCHAR(20) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders(Id, EmployeeId, CustomerId, CarId, TankLevel, 
KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate,
TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES 
(1, 1, 1, 1, 230.9, NULL, NULL, 230000, 10/23/2020, NULL, 10, 9, 72.3, 'COMPLETED', NULL),
(2, 2, 2, 2, 140, NULL, NULL, 10000, 12/8/2017, NULL, 8, 10, 123, 'PROCESSING', NULL),
(3, 3, 3, 3, 118.3, NULL, NULL, 76999, 5/4/2019, NULL, 6, 4, 720, 'CANCELED', NULL)