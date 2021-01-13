CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(200) NOT NULL,
Picture VARCHAR(MAX),
Height DECIMAL(15,2),
[Weight] DECIMAL(15,2),
Gender CHAR(1) NOT NULL,
Birthdate DATETIME NOT NULL,
Biography VARCHAR(MAX)
)


INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
('PESHO PESHOV', NULL, 1.78, 72.3, 'M', '4/11/1994', NULL),
('GOSHO PESHOV', NULL, 1.99, 98.3, 'M', '8/16/1992', 'QA'),
('MARIA PENEVA', NULL, 1.56, 43, 'F', '12/18/2001', 'MANAGER'),
('STAMAT STAMATOV', NULL, 1.82, 81, 'M', '1/24/1996', NULL),
('PENKA PENKOVA', NULL, 1.65, 58, 'F', '2/10/1999', 'FE DEV')