CREATE TABLE Logs
(
LogId INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
OldSum DECIMAL(15,2) NOT NULL,
NewSum DECIMAL(15,2) NOT NULL
)

CREATE TRIGGER tr_UpdateLogsOnChangeSum
ON Accounts FOR UPDATE 
AS
DECLARE @accountId INT = (SELECT Id FROM inserted);
DECLARE @newSum DECIMAL(15,2) = (SELECT Balance FROM inserted);
DECLARE @oldSum DECIMAL(15,2) = (SELECT Balance FROM deleted);

INSERT INTO Logs (AccountId, NewSum, OldSum) VALUES
(@accountId, @newSum, @oldSum)

--Tests
UPDATE Accounts
SET Balance -= 10
WHERE Id = 1

SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Logs