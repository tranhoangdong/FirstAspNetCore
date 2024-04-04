USE [FirstWebAppCore]
GO

CREATE TABLE [dbo].[Product](
    [Id] [int] PRIMARY KEY IDENTITY(1,1),
    [Price] [decimal](18, 0) NULL,
    [OriginalPrice] [decimal](18, 0) NULL,
    [Stock] [int] NULL,
    [ViewCount] [int] NULL,
    [DateCreated] [datetime] NULL,
    [IsFeatured] [bit] NULL,
    [Descreption] [nvarchar](100) NULL
)