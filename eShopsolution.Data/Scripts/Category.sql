USE [FirstWebAppCore]
GO

CREATE TABLE [dbo].[Category](
	[Id] [int] PRIMARY KEY IDENTITY(1,1),
	[SortOrder] [int] NULL,
	[IsShowOnHome] [nchar](10) NULL,
	[ParentId] [int] NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
GO


