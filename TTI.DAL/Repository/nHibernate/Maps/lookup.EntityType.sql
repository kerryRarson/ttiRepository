USE TestData
GO
/****** Object:  Schema [lookup]    Script Date: 2/12/2013 12:19:28 PM ******/
CREATE SCHEMA [lookup]
GO
/****** Object:  Table [lookup].[EntityType]    Script Date: 2/12/2013 12:18:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [lookup].[EntityType](
	[EntityTypeID] [tinyint] NOT NULL,
	[EntityTypeDesc] [varchar](25) NOT NULL,
 CONSTRAINT [PK_EntityType] PRIMARY KEY CLUSTERED 
(
	[EntityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [lookup].[EntityType] ([EntityTypeID], [EntityTypeDesc]) VALUES (0, N'None')
GO
INSERT [lookup].[EntityType] ([EntityTypeID], [EntityTypeDesc]) VALUES (1, N'Vendor')
GO
INSERT [lookup].[EntityType] ([EntityTypeID], [EntityTypeDesc]) VALUES (2, N'Company')
GO
INSERT [lookup].[EntityType] ([EntityTypeID], [EntityTypeDesc]) VALUES (3, N'MGA')
GO
INSERT [lookup].[EntityType] ([EntityTypeID], [EntityTypeDesc]) VALUES (4, N'Agency')
GO
INSERT [lookup].[EntityType] ([EntityTypeID], [EntityTypeDesc]) VALUES (5, N'AdjustingCompany')
GO
INSERT [lookup].[EntityType] ([EntityTypeID], [EntityTypeDesc]) VALUES (6, N'Law Firm')
GO
INSERT [lookup].[EntityType] ([EntityTypeID], [EntityTypeDesc]) VALUES (7, N'Engineering Firm')
GO
INSERT [lookup].[EntityType] ([EntityTypeID], [EntityTypeDesc]) VALUES (8, N'Accounting Firm')
GO
