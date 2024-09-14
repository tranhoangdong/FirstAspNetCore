IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AppUserRoles' AND xtype='U')
BEGIN

    CREATE TABLE AppUserRoles
    (
		  RoleId INT,
			UserId INT,
			PRIMARY KEY (RoleId, UserId)
   
    )
END;



