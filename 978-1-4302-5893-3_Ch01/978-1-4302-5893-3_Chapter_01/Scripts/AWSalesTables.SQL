USE [AdventureWorksDW2012]
GO
/****** Object:  Table [dbo].[Dim_Customer]    Script Date: 1/18/2013 1:05:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Customer](
	[CustomerID] [int] NOT NULL,
	[AccountNumber] [nvarchar](50) NULL,
	[CustomerType] [nvarchar](3) NULL,
 CONSTRAINT [PK_Dim_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dim_DateTime]    Script Date: 1/18/2013 1:05:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_DateTime](
	[DateKey] [int] NOT NULL,
	[FullDate] [date] NOT NULL,
	[DayNumberOfMonth] [tinyint] NOT NULL,
	[DayNumberOfYear] [tinyint] NOT NULL,
	[MonthNumberOfYear] [tinyint] NOT NULL,
	[MonthName] [nvarchar](10) NOT NULL,
	[Quarter] [tinyint] NOT NULL,
	[Year] [smallint] NOT NULL,
 CONSTRAINT [PK_Dim_DateTime] PRIMARY KEY CLUSTERED 
(
	[DateKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dim_SalesOrderHeader]    Script Date: 1/18/2013 1:05:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_SalesOrderHeader](
	[SalesOrderHeaderID] [int] NOT NULL,
	[OrderDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_Dim_SalesOrderHeader] PRIMARY KEY CLUSTERED 
(
	[SalesOrderHeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dim_SalesPerson]    Script Date: 1/18/2013 1:05:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_SalesPerson](
	[SalesPersonID] [int] NOT NULL,
	[SalesQuota] [money] NULL,
	[Bonus] [money] NULL,
	[CommisionPct] [money] NULL,
	[SalesYTD] [money] NULL,
	[SalesLastYear] [money] NULL,
	[TerritoyID] [int] NULL,
 CONSTRAINT [PK_Dim_SalesPerson] PRIMARY KEY CLUSTERED 
(
	[SalesPersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dim_SalesTerritory]    Script Date: 1/18/2013 1:05:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_SalesTerritory](
	[TerritoryID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CountryRegionCode] [nvarchar](3) NULL,
	[Group] [nvarchar](50) NULL,
	[SalesYTD] [money] NULL,
	[SalesLastYear] [money] NULL,
	[CostYTD] [money] NULL,
	[CostLastYear] [money] NULL,
 CONSTRAINT [PK_Dim_SalesTerritory] PRIMARY KEY CLUSTERED 
(
	[TerritoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dim_SalesTerritoryHistory]    Script Date: 1/18/2013 1:05:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_SalesTerritoryHistory](
	[SalesTerritoryHistoryID] [int] NOT NULL,
	[SalesPersonID] [int] NOT NULL,
	[TerritoryID] [int] NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_Dim_SalesTerritoryHistory] PRIMARY KEY CLUSTERED 
(
	[TerritoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dim_Store]    Script Date: 1/18/2013 1:05:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Store](
	[StoreID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[SalesPersonID] [int] NOT NULL,
 CONSTRAINT [PK_Dim_Dim_Store] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fact_SalesOrderDetails]    Script Date: 1/18/2013 1:05:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_SalesOrderDetails](
	[SalesOrderID] [int] NOT NULL,
	[SalesOrderHeaderID] [int] NOT NULL,
	[DateKey] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[TerritoryID] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Dim_SalesPerson]  WITH CHECK ADD  CONSTRAINT [FK_Dim_SalesPerson_Dim_SalesTerritory] FOREIGN KEY([TerritoyID])
REFERENCES [dbo].[Dim_SalesTerritory] ([TerritoryID])
GO
ALTER TABLE [dbo].[Dim_SalesPerson] CHECK CONSTRAINT [FK_Dim_SalesPerson_Dim_SalesTerritory]
GO
ALTER TABLE [dbo].[Dim_SalesTerritoryHistory]  WITH CHECK ADD  CONSTRAINT [FK_Dim_SalesTerritoryHistory_Dim_SalesPerson] FOREIGN KEY([SalesPersonID])
REFERENCES [dbo].[Dim_SalesPerson] ([SalesPersonID])
GO
ALTER TABLE [dbo].[Dim_SalesTerritoryHistory] CHECK CONSTRAINT [FK_Dim_SalesTerritoryHistory_Dim_SalesPerson]
GO
ALTER TABLE [dbo].[Dim_SalesTerritoryHistory]  WITH CHECK ADD  CONSTRAINT [FK_Dim_SalesTerritoryHistory_Dim_SalesTerritory] FOREIGN KEY([TerritoryID])
REFERENCES [dbo].[Dim_SalesTerritory] ([TerritoryID])
GO
ALTER TABLE [dbo].[Dim_SalesTerritoryHistory] CHECK CONSTRAINT [FK_Dim_SalesTerritoryHistory_Dim_SalesTerritory]
GO
ALTER TABLE [dbo].[Dim_Store]  WITH CHECK ADD  CONSTRAINT [FK_Dim_Store_Dim_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Dim_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Dim_Store] CHECK CONSTRAINT [FK_Dim_Store_Dim_Customer]
GO
ALTER TABLE [dbo].[Dim_Store]  WITH CHECK ADD  CONSTRAINT [FK_Dim_Store_Dim_SalesPerson] FOREIGN KEY([SalesPersonID])
REFERENCES [dbo].[Dim_SalesPerson] ([SalesPersonID])
GO
ALTER TABLE [dbo].[Dim_Store] CHECK CONSTRAINT [FK_Dim_Store_Dim_SalesPerson]
GO
ALTER TABLE [dbo].[Fact_SalesOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Fact_SalesOrderDetails_Dim_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Dim_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Fact_SalesOrderDetails] CHECK CONSTRAINT [FK_Fact_SalesOrderDetails_Dim_Customer]
GO
ALTER TABLE [dbo].[Fact_SalesOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Fact_SalesOrderDetails_Dim_DateTime] FOREIGN KEY([DateKey])
REFERENCES [dbo].[Dim_DateTime] ([DateKey])
GO
ALTER TABLE [dbo].[Fact_SalesOrderDetails] CHECK CONSTRAINT [FK_Fact_SalesOrderDetails_Dim_DateTime]
GO
ALTER TABLE [dbo].[Fact_SalesOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Fact_SalesOrderDetails_Dim_SalesOrderHeader] FOREIGN KEY([SalesOrderHeaderID])
REFERENCES [dbo].[Dim_SalesOrderHeader] ([SalesOrderHeaderID])
GO
ALTER TABLE [dbo].[Fact_SalesOrderDetails] CHECK CONSTRAINT [FK_Fact_SalesOrderDetails_Dim_SalesOrderHeader]
GO
ALTER TABLE [dbo].[Fact_SalesOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Fact_SalesOrderDetails_Dim_SalesTerritory] FOREIGN KEY([TerritoryID])
REFERENCES [dbo].[Dim_SalesTerritory] ([TerritoryID])
GO
ALTER TABLE [dbo].[Fact_SalesOrderDetails] CHECK CONSTRAINT [FK_Fact_SalesOrderDetails_Dim_SalesTerritory]
GO
