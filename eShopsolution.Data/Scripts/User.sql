IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='User' AND xtype='U')
BEGIN

    CREATE TABLE [User]
    (
		ID int identity(1,1) primary key ,
		Username NVARCHAR(max) not null,
		Password NVARCHAR(max) not null,
		FirstName NVARCHAR(max) not null,
		LastName NVARCHAR(max) not null,
		Email NVARCHAR(max) not null,
		Phone NVARCHAR(max) not null
    )
END;

SELECT * FROM [User];