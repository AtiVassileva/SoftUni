CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(18,4))
AS
BEGIN TRANSACTION
EXEC usp_WithdrawMoney @senderId, @amount
EXEC usp_DepositMoney @receiverId, @amount
COMMIT

-- Tests
SELECT * FROM Accounts
WHERE Id IN (1, 5)
EXEC usp_TransferMoney 5, 1 , 5000
SELECT * FROM Accounts
WHERE Id IN (1, 5)