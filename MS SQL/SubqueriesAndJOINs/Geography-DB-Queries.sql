-- 12. Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM Countries c
JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
JOIN Mountains m ON mc.MountainId = m.Id
JOIN Peaks p ON m.Id = p.MountainId
WHERE c.CountryCode = 'BG'  AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- 13. Count Mountain Ranges
SELECT c.CountryCode, COUNT(*) AS MountainRanges
FROM Countries c
JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
WHERE c.CountryCode IN ('BG', 'US', 'RU')
GROUP BY c.CountryCode

-- 14. Countries with Rivers
SELECT TOP(5) c.CountryName, r.RiverName FROM Countries c
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

-- 15. *Continents and Currencies
SELECT ContinentCode,  CurrencyCode ,CurrencyUsage FROM (
SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage,
DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
FROM Countries 
GROUP BY ContinentCode, CurrencyCode) AS k
WHERE Ranked = 1 AND CurrencyUsage > 1
ORDER BY ContinentCode

-- 16. Countries Without Any Mountains
SELECT COUNT(*) AS Count FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL

-- 17. Highest Peak and Longest River by Country
SELECT TOP(5) c.CountryName, 
MAX(p.Elevation) AS HighestPeakElevation, 
MAX(r.Length) AS LongestRiverLength
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m ON mc.MountainId = m.Id
LEFT JOIN Peaks p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName ASC

-- 18. Highest Peak Name and Elevation by Country
SELECT TOP(5) k.Country, k.[Highest Peak Name], k.[Highest Peak Elevation], k.Mountain
FROM (
SELECT c.CountryName AS Country,
ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation],
ISNULL(m.MountainRange, '(no mountain)') AS Mountain,
DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranked
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m ON mc.MountainId = m.Id
LEFT JOIN Peaks p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
WHERE Ranked = 1
ORDER BY Country ASC, [Highest Peak Name] ASC