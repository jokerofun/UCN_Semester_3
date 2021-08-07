CREATE TABLE [dbo].[Trip]
(
	[ID]             INT       IDENTITY (1, 1) NOT NULL,
	[Name]           NVARCHAR           (50)   NOT NULL,
	[Description]      NVARCHAR         (150)   NOT NULL,
	[DeparturePlace]      NVARCHAR      (20)   NOT NULL,
	[ArrivalPlace]      NVARCHAR         (20)   NOT NULL,
	[DepartureDate]   DATETIME                     NOT NULL,
	[ArrivalDate]      DATETIME                  NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,

	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT fk_Trip_UserAccount FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
)
