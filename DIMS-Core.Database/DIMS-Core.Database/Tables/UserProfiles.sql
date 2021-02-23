CREATE TABLE [dbo].[UserProfiles]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[DirectionId] INT NOT NULL,
	[Education] NVARCHAR(50) NULL,
	[Address] NVARCHAR(120) NULL,
	[BirthDate] DATE NULL,
	[StartDate] DATE NULL,
	[UniversityAverageScore] FLOAT NOT NULL,
	[MathScore] FLOAT NOT NULL,
	[Sex] TINYINT NOT NULL,
	[Skype] NVARCHAR(50) NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[MobilePhone] NVARCHAR(50) NOT NULL,

	CONSTRAINT FK_UserProfile_Direction FOREIGN KEY (DirectionId) REFERENCES Directions(DirectionId) ON DELETE CASCADE ON UPDATE CASCADE
)
