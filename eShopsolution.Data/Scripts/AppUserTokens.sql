IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AppUserTokens' AND xtype='U')
BEGIN

    CREATE TABLE AppUserTokens
    (
		 UserId INT PRIMARY KEY,            
		LoginProvider NVARCHAR(MAX),    
		Name NVARCHAR(MAX),               
		Value NVARCHAR(MAX)    
   
    )
END;



