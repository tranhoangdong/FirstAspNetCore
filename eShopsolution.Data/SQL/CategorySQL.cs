USE[FirstWebAppCore]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 3/20/2024 9:01:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](

[Id][int] NULL,
	[SortOrder] [int] NULL,
	[IsShowOnHome] [nchar](10) NULL,
	[ParentId] [int] NULL,
	[Status] [nchar](10) NULL
) ON[PRIMARY]
GO


