DECLARE @username VARCHAR(50) = 'Stamat'
DECLARE @gameName VARCHAR(50) = 'Safflower'
DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = @username)
DECLARE @gameId INT = (SELECT Id FROM Games WHERE Name = @gameName)
DECLARE @userMoney MONEY = (SELECT Cash FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)
DECLARE @itemsPriceSum MONEY
DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

BEGIN TRANSACTION
	SET @itemsPriceSum = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)

	IF(@userMoney - @itemsPriceSum >= 0)
	BEGIN
		INSERT INTO UserGameItems
		SELECT i.Id, @userGameId FROM Items AS i
		WHERE i.Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)

		UPDATE UsersGames
		SET Cash -= @itemsPriceSum
		WHERE GameId = @gameId AND UserId = @userId
		COMMIT
	END
	ELSE
	BEGIN
		ROLLBACK
	END

SET @userMoney = (SELECT Cash FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)
BEGIN TRANSACTION
	SET @itemsPriceSum = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

	IF(@userMoney - @itemsPriceSum >= 0)
	BEGIN
		INSERT INTO UserGameItems
		SELECT i.Id, @userGameId FROM Items AS i
		WHERE i.Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 19 AND 21)

		UPDATE UsersGames
		SET Cash -= @itemsPriceSum
		WHERE GameId = @gameId AND UserId = @userId
		COMMIT
	END
	ELSE
	BEGIN
		ROLLBACK
	END

SELECT Name AS [Item Name]
FROM Items
WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @userGameId)
ORDER BY [Item Name]