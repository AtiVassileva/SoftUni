CREATE PROCEDURE usp_GetTownsStartingWith 
(@Beginning VARCHAR(30))
AS
BEGIN
	SELECT [Name] FROM Towns
	WHERE [Name] LIKE @Beginning + '%'
END

EXEC dbo.usp_GetTownsStartingWith 'N'