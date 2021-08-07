/*------------------------------------------------AspNetUsers---------------------------------------------------------------*/

CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](30) NULL,
	[Street] [nvarchar](30) NULL,
	[City] [nvarchar](20) NULL,
	[ZipCode] [nvarchar](10) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/*------------------------------------------------AspNetRoles---------------------------------------------------------------*/

CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*------------------------------------------------AspNetUserRoles---------------------------------------------------------------*/

CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO

/*------------------------------------------------AspNetUserLogins---------------------------------------------------------------*/

CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO

/*------------------------------------------------AspNetUserClaims---------------------------------------------------------------*/

CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO

/*------------------------------------------------Trip---------------------------------------------------------------*/

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

/*------------------------------------------------Ticket---------------------------------------------------------------*/

create table Ticket(

Id int NOT null    primary key identity (1,1),
TicketName         varchar(35)      NOT NULL,
TicketDescription  varchar(150),
Price              decimal(9,2)     NOT NULL,
MaxTickets         int            NOT NULL,
Active             Bit            DEFAULT 1, 
TripId           int         NOT NULL,
    CONSTRAINT fk_Ticket_Trip FOREIGN KEY (TripId) REFERENCES Trip(ID)
);

/*------------------------------------------------UserTicket---------------------------------------------------------------*/

create table UserTicket(
Id int NOT null    primary key identity (1,1),
FirstName      nvarchar(30) NOT NULL,
LastName       nvarchar(30) NOT NULL,
Active             Bit            DEFAULT 1, 
TicketId       int NOT NULL,
UserId         nvarchar(128) NOT NULL,
	CONSTRAINT fk_UserTicket_Ticket FOREIGN KEY (TicketId) REFERENCES Ticket(Id),
	CONSTRAINT fk_UserTicket_UserAccount FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);


/*------------------------------------------------Add roles---------------------------------------------------------------*/

INSERT INTO dbo.AspNetRoles (Id, Name) Values('508e0c6e-fb88-481f-ba02-77f6e1df2711', 'Basic');
GO

INSERT INTO dbo.AspNetRoles (Id, Name) Values('d3f34e89-c210-428d-ab45-9e946c5b8b75', 'Admin');
GO

INSERT INTO dbo.AspNetRoles (Id, Name) Values('d4bc7517-660c-43cc-8121-234935e6a6da', 'Business');
GO

/*------------------------------------------------Add admin user---------------------------------------------------------------*/

INSERT INTO dbo.AspNetUsers(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName) 
VALUES('b8654dca-e5da-4af0-bf3a-a92534cacd85', 'admin@admin.com', 0, 'AIkm584I1fd2h2hwZMrjTCADJ2STAv+ykft3Fl83C3W0Ox++m8d72xaAU9bfh52X3w==', 'd3c0afe2-88df-4a4b-a47b-a25231f6c4bd', NULL, 0, 0, NULL, 0, 0, 'admin@admin.com');

INSERT INTO dbo.AspNetUserRoles(UserId, RoleId) VALUES('b8654dca-e5da-4af0-bf3a-a92534cacd85', 'd3f34e89-c210-428d-ab45-9e946c5b8b75');