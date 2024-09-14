IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AppUserClaims' AND xtype='U')
BEGIN

    CREATE TABLE AppUserClaims
    (
		Id int identity(1,1) primary key ,
	 ClaimType NVARCHAR(MAX),
		ClaimValue NVARCHAR(MAX),
		UserId NVARCHAR(MAX) --
   
    )
END;



