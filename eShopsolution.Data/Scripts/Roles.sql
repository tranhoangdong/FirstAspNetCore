IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Roles' AND xtype='U')
BEGIN

    CREATE TABLE Roles
    (
		Id int identity(1,1) primary key ,
		Name NVARCHAR(max) not null,
		
    )
END;
