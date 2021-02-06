CREATE TABLE Teachers
(
TeacherID INT IDENTITY(101,1) PRIMARY KEY,
[Name] VARCHAR(50),
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID) VALUES 
('John',	NULL),
('Maya',	106),
('Silvia',	106),
('Ted',	105),
('Mark',	101),
('Greta',	101)