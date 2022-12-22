CREATE DATABASE [SQLSpreadsTest]
GO 
USE [SQLSpreadsTest]
GO
CREATE TABLE [dbo].[fact_Finance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeriodKey] [int] NOT NULL,
	[AccountKey] [int] NOT NULL,
	[Amount] [money] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[fact_Finance] ON 
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (1, 202201, 1010, 1.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (2, 202202, 1010, 2.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (3, 202203, 1010, 3.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (4, 202204, 1010, 4.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (5, 202205, 1010, 5.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (6, 202206, 1010, 6.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (7, 202207, 1010, 7.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (8, 202208, 1010, 8.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (9, 202209, 1010, 9.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (10, 202210, 1010, 10.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (11, 202211, 1010, 11.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (12, 202212, 1010, 12.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (13, 202201, 1020, 101.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (14, 202202, 1020, 102.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (15, 202203, 1020, 103.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (16, 202204, 1020, 104.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (17, 202205, 1020, 105.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (18, 202206, 1020, 106.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (19, 202207, 1020, 107.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (20, 202208, 1020, 108.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (21, 202209, 1020, 109.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (22, 202210, 1020, 110.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (23, 202211, 1020, 111.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (24, 202212, 1020, 112.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (25, 202201, 1030, 201.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (26, 202202, 1030, 202.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (27, 202203, 1030, 203.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (28, 202204, 1030, 204.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (29, 202205, 1030, 205.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (30, 202206, 1030, 206.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (31, 202207, 1030, 207.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (32, 202208, 1030, 208.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (33, 202209, 1030, 209.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (34, 202210, 1030, 210.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (35, 202211, 1030, 211.0000)
GO
INSERT [dbo].[fact_Finance] ([Id], [PeriodKey], [AccountKey], [Amount]) VALUES (36, 202212, 1030, 212.0000)
GO
SET IDENTITY_INSERT [dbo].[fact_Finance] OFF
GO
