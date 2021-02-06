CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
IF @moneyAmount < 0
BEGIN
	ROLLBACK;
	THROW 50001, 'Money amount cannot be a negative number!', 1;
END
	
IF NOT EXISTS (SELECT * FROM Accounts WHERE Id = @accountId)
BEGIN
	ROLLBACK;
	THROW 50002, 'Unexisting account!', 1;
END

UPDATE Accounts
SET Balance += @moneyAmount
WHERE Id = @accountId
COMMIT

-- Tests
EXEC usp_DepositMoney 1, 10
SELECT * FROM Accounts WHERE Id = 1