CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan 
(@Number DECIMAL(18,4)) AS
BEGIN
	SELECT ah.FirstName, ah.LastName 
	FROM Accounts ac
	JOIN AccountHolders ah ON ac.AccountHolderId = ah.Id
	GROUP BY ah.Id, ah.FirstName, ah.LastName
	HAVING SUM(ac.Balance) > @Number
	ORDER BY ah.FirstName, ah.LastName
END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 50000