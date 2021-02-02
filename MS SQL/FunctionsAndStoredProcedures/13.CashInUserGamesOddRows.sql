CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS @resultTable TABLE
(
SumCash money
)
AS
BEGIN
	DECLARE @result DECIMAL(18,4)

	SET @result = 
	(SELECT SUM(k.Cash) AS Cash
	FROM
		(SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
		FROM UsersGames
		WHERE GameId = (SELECT Id FROM Games WHERE Name = @gameName)
		) AS k
	WHERE k.RowNumber % 2 != 0)

	INSERT INTO @resultTable SELECT @result
	RETURN
END

SELECT * FROM 
dbo.ufn_CashInUsersGames ('Love in a mist')