
INSERT INTO dbo.AspNetRoles (Id, Name) Values('508e0c6e-fb88-481f-ba02-77f6e1df2711', 'Basic');
GO

INSERT INTO dbo.AspNetRoles (Id, Name) Values('d3f34e89-c210-428d-ab45-9e946c5b8b75', 'Admin');
GO

INSERT INTO dbo.AspNetRoles (Id, Name) Values('d4bc7517-660c-43cc-8121-234935e6a6da', 'Business');
GO

INSERT INTO dbo.AspNetUsers(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName) 
VALUES('b8654dca-e5da-4af0-bf3a-a92534cacd85', 'admin@admin.com', 0, 'AIkm584I1fd2h2hwZMrjTCADJ2STAv+ykft3Fl83C3W0Ox++m8d72xaAU9bfh52X3w==', 'd3c0afe2-88df-4a4b-a47b-a25231f6c4bd', NULL, 0, 0, NULL, 0, 0, 'admin@admin.com');

INSERT INTO dbo.AspNetUserRoles(UserId, RoleId) VALUES('b8654dca-e5da-4af0-bf3a-a92534cacd85', 'd3f34e89-c210-428d-ab45-9e946c5b8b75');