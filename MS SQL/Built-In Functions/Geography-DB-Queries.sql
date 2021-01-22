-- 12. Countries Holding ‘A’ 3 or More Times
SELECT CountryName, IsoCode FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'A', '')) >= 3
ORDER BY IsoCode

-- 13. Mix of Peak and River Names
SELECT PeakName, RiverName, 
LOWER(SUBSTRING(PeakName, 1, LEN(PeakName) - 1) + RiverName) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix ASC
