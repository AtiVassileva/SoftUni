CREATE TABLE Users (
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARCHAR(MAX),
LastLoginTime DATETIME,
IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('wxwe', '2jdeuo29', 'https://cutt.ly/RjbIZXl', '12/24/2020', 0),
('xwqw', 'ydegfyhb', 'https://cutt.ly/RjbIZXl', '1/12/2020', 0),
('deew', 'y5de45gt', 'https://cutt.ly/RjbIZXl', '5/17/2020', 1),
('tndn', 'gtedr45', 'https://cutt.ly/RjbIZXl', '11/5/2020', 0),
('kuki', '65ed4g', 'https://cutt.ly/RjbIZXl', '8/3/2020', 1)

--Remove Primary Key
ALTER TABLE Users 
DROP CONSTRAINT PK__Users__3214EC077261921C

-- Change Primary Key
ALTER TABLE Users 
DROP CONSTRAINT PK__IdUsername

-- Set Only Id For Primary Key
ALTER TABLE Users	
ADD CONSTRAINT PK_Id PRIMARY KEY (Id) 

-- Set Constraints For Username and Password Length
ALTER TABLE Users
ADD CONSTRAINT CH_UsernameIsAtLeastThreeSymbols CHECK (LEN(Username) > 3)

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeastFiveSymbols CHECK (LEN([Password]) > 5)

-- Set Default Value For LastLoginTime
ALTER TABLE Users
ADD CONSTRAINT DF_SETLastLoginTime DEFAULT GETDATE() FOR LastLoginTime