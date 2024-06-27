IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Image' AND xtype='U')
BEGIN

    CREATE TABLE Image
    (
		ID int identity(1,1) primary key ,
		ProductId INT not null,
		[Name] NVARCHAR(100) not null,
		ContentType NVARCHAR(100) not null,
		[Data] VARBINARY(MAX) not null,
		FOREIGN KEY (ProductId) REFERENCES Product(ID)
    )
END;
drop table Image
select * from Image