IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AppUserLogins' AND xtype='U')
BEGIN

    CREATE TABLE AppUserLogins
    (
		  UserId INT PRIMARY KEY,               
		LoginProvider NVARCHAR(MAX),          
		ProviderDisplayName NVARCHAR(MAX),    
		ProviderKey NVARCHAR(MAX)   
   
    )
END;



