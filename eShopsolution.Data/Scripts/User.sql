IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='User' AND xtype='U')
BEGIN

    CREATE TABLE [User]
    (
		ID int identity(1,1) primary key ,
		  UserName NVARCHAR(256),
    NormalizedUserName NVARCHAR(256),
    Email NVARCHAR(256),
    NormalizedEmail NVARCHAR(256),
    EmailConfirmed BIT DEFAULT 0,
    PasswordHash NVARCHAR(MAX),
    SecurityStamp NVARCHAR(MAX),
    ConcurrencyStamp NVARCHAR(MAX),
    PhoneNumber NVARCHAR(15),
    PhoneNumberConfirmed BIT DEFAULT 0,
    TwoFactorEnabled BIT DEFAULT 0,
    LockoutEnd DATETIMEOFFSET,
    LockoutEnabled BIT DEFAULT 0,
    AccessFailedCount INT DEFAULT 0,
	FirstName NVARCHAR(max) not null,
	LastName NVARCHAR(max) not null,
    )
END;
ALTER TABLE [dbo].[User] ADD RememberMe BIT NOT NULL DEFAULT 0;
SELECT * FROM [User];

drop table [User]