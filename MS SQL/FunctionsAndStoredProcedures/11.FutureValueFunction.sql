CREATE FUNCTION ufn_CalculateFutureValue 
(@Sum DECIMAL(18,4), @InterestRate FLOAT, @Years INT)
RETURNS DECIMAL(18,4)
BEGIN
	DECLARE @FutureValue AS DECIMAL(18,4) = 
	@Sum * POWER((1 + @InterestRate), @Years);

	RETURN @FutureValue;
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS FutureValue