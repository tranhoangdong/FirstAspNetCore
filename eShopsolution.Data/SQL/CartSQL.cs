﻿USE[FirstWebAppCore]
GO

/****** Object:  Table [dbo].[Cart]    Script Date: 3/20/2024 9:02:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cart](

[Id][int] NOT NULL,

[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT[PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]
GO


