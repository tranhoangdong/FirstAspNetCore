IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AppRoleClaims' AND xtype='U')
BEGIN

    CREATE TABLE AppRoleClaims
    (
		 RoleId int PRIMARY KEY, 
		ClaimType NVARCHAR(MAX),          
		ClaimValue NVARCHAR(MAX),         
		Id INT        
   
    )
END;



	