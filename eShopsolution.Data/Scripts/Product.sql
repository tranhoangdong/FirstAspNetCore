IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Product' AND xtype='U')
BEGIN

    CREATE TABLE Product
    (
		ID int identity(1,1) primary key ,
		[Name] VARCHAR(255) NOT NULL,
		Price DECIMAL(10, 2) NOT NULL,
		Stock INT DEFAULT 0,
		
    )
END;

INSERT INTO Product ([Name], Price, Stock)
VALUES 
    ('Product A', 9.99, 100),
    ('Product B', 19.99, 50),
    ('Product C', 29.99, 25);

select * from Product