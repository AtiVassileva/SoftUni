CREATE TABLE NotificationEmails
(Id INT PRIMARY KEY IDENTITY, 
Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
Subject VARCHAR(100) NOT NULL, 
Body VARCHAR(200) NOT NULL
)

CREATE TRIGGER tr_SendEmailWheneverANewLogIsInserted 
ON Logs FOR INSERT
AS
DECLARE @recepient INT = (SELECT TOP(1) AccountId FROM inserted);
DECLARE @date DATETIME = GETDATE();
DECLARE @oldSum DECIMAL(15,2) = (SELECT TOP(1) OldSum FROM inserted);
DECLARE @newSum DECIMAL(15,2) = (SELECT TOP(1) NewSum FROM inserted);

DECLARE @subject VARCHAR(100) = 
'Balance change for account: ' + CAST(@recepient AS VARCHAR(20));
DECLARE @body VARCHAR(200) = 
'On ' + CONVERT(VARCHAR(30), @date, 103) + ' your balance was changed from ' + 
CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20)) + '.';

INSERT INTO NotificationEmails (Recipient, Subject, Body) VALUES
(@recepient, @subject, @body)

-- Tests
UPDATE Accounts
SET Balance -= 10
WHERE Id = 1

SELECT * FROM Logs
SELECT * FROM NotificationEmails