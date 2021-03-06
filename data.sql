USE [master]
GO
/****** Object:  Database [RestaurantSystem]    Script Date: 08/06/2018 13:34:29 ******/
CREATE DATABASE [RestaurantSystem] 
ALTER DATABASE [RestaurantSystem] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestaurantSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestaurantSystem] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [RestaurantSystem] SET ANSI_NULLS OFF
GO
ALTER DATABASE [RestaurantSystem] SET ANSI_PADDING OFF
GO
ALTER DATABASE [RestaurantSystem] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [RestaurantSystem] SET ARITHABORT OFF
GO
ALTER DATABASE [RestaurantSystem] SET AUTO_CLOSE ON
GO
ALTER DATABASE [RestaurantSystem] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [RestaurantSystem] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [RestaurantSystem] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [RestaurantSystem] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [RestaurantSystem] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [RestaurantSystem] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [RestaurantSystem] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [RestaurantSystem] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [RestaurantSystem] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [RestaurantSystem] SET  ENABLE_BROKER
GO
ALTER DATABASE [RestaurantSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [RestaurantSystem] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [RestaurantSystem] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [RestaurantSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [RestaurantSystem] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [RestaurantSystem] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [RestaurantSystem] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [RestaurantSystem] SET  READ_WRITE
GO
ALTER DATABASE [RestaurantSystem] SET RECOVERY SIMPLE
GO
ALTER DATABASE [RestaurantSystem] SET  MULTI_USER
GO
ALTER DATABASE [RestaurantSystem] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [RestaurantSystem] SET DB_CHAINING OFF
GO
USE [RestaurantSystem]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Quan ly')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Nhan vien')
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[Region]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Region] ON
INSERT [dbo].[Region] ([Id], [Name]) VALUES (1, N'A')
INSERT [dbo].[Region] ([Id], [Name]) VALUES (2, N'B')
SET IDENTITY_INSERT [dbo].[Region] OFF
/****** Object:  Table [dbo].[CategoryFood]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryFood](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryFood] ON
INSERT [dbo].[CategoryFood] ([Id], [Name]) VALUES (1, N'Pizza')
INSERT [dbo].[CategoryFood] ([Id], [Name]) VALUES (2, N'Beverage')
INSERT [dbo].[CategoryFood] ([Id], [Name]) VALUES (3, N'Hamburger')
SET IDENTITY_INSERT [dbo].[CategoryFood] OFF
/****** Object:  Table [dbo].[Supplier]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](200) NULL,
	[MoreInfo] [nvarchar](max) NULL,
	[ContractDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Supplier] ([Id], [Name], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (N'NCC404', N'NCC A', NULL, N'12345', NULL, NULL, CAST(0x0000A92E00000000 AS DateTime))
/****** Object:  Table [dbo].[Unit]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Unit] ON
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (1, N'piece')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (2, N'loong')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (3, N'g')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (4, N'phần')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (5, N'chai')
SET IDENTITY_INSERT [dbo].[Unit] OFF
/****** Object:  Table [dbo].[TableFood]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IdRegion] [int] NULL,
	[Status] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON
INSERT [dbo].[TableFood] ([Id], [Name], [IdRegion], [Status]) VALUES (1, N'1', 1, N'Đang sử dụng')
INSERT [dbo].[TableFood] ([Id], [Name], [IdRegion], [Status]) VALUES (2, N'2', 1, N'Đang trống')
INSERT [dbo].[TableFood] ([Id], [Name], [IdRegion], [Status]) VALUES (3, N'3', 2, N'Đang trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
/****** Object:  Table [dbo].[Staff]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[IdRole] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Staff] ([Id], [UserName], [Password], [Name], [IdRole]) VALUES (N'NV010', N'nhanvien', N'cdd96d3cc73d1dbdaffa03cc6cd7339b', N'Nhân viên A', 2)
INSERT [dbo].[Staff] ([Id], [UserName], [Password], [Name], [IdRole]) VALUES (N'QL001', N'admin', N'db69fc039dcbd2962cb4d28f5891aae1', N'T.Anh', 1)
/****** Object:  Table [dbo].[Goods]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[IdUnit] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Goods] ON
INSERT [dbo].[Goods] ([Id], [Name], [Status], [IdUnit]) VALUES (1, N'Bột mì', NULL, 3)
INSERT [dbo].[Goods] ([Id], [Name], [Status], [IdUnit]) VALUES (2, N'Thịt', NULL, 3)
INSERT [dbo].[Goods] ([Id], [Name], [Status], [IdUnit]) VALUES (3, N'Pepsi', NULL, 2)
SET IDENTITY_INSERT [dbo].[Goods] OFF
/****** Object:  Table [dbo].[Food]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [float] NULL,
	[IdCategoryFood] [int] NULL,
	[IdUnit] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Food] ON
INSERT [dbo].[Food] ([Id], [Name], [Price], [IdCategoryFood], [IdUnit]) VALUES (1, N'Pizza Cali', 50000, 1, 1)
INSERT [dbo].[Food] ([Id], [Name], [Price], [IdCategoryFood], [IdUnit]) VALUES (2, N'Pepsi', 10000, 2, 2)
INSERT [dbo].[Food] ([Id], [Name], [Price], [IdCategoryFood], [IdUnit]) VALUES (3, N'Hambergur Italy', 36000, 3, 1)
INSERT [dbo].[Food] ([Id], [Name], [Price], [IdCategoryFood], [IdUnit]) VALUES (4, N'Pizza Chan', 40000, 1, 1)
INSERT [dbo].[Food] ([Id], [Name], [Price], [IdCategoryFood], [IdUnit]) VALUES (5, N'Monster', 20000, 2, 2)
INSERT [dbo].[Food] ([Id], [Name], [Price], [IdCategoryFood], [IdUnit]) VALUES (9, N'Vila', 10000, 2, 2)
INSERT [dbo].[Food] ([Id], [Name], [Price], [IdCategoryFood], [IdUnit]) VALUES (10, N'Pizza Haha', 30000, 1, 1)
INSERT [dbo].[Food] ([Id], [Name], [Price], [IdCategoryFood], [IdUnit]) VALUES (11, N'Lavi', 10000, 2, 5)
SET IDENTITY_INSERT [dbo].[Food] OFF
/****** Object:  Table [dbo].[Bill]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeIn] [datetime] NULL,
	[TimeOut] [datetime] NULL,
	[TotalPrice] [float] NULL,
	[MoreInfo] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Discount] [int] NULL,
	[IdTable] [int] NULL,
	[IdStaff] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bill] ON
INSERT [dbo].[Bill] ([Id], [TimeIn], [TimeOut], [TotalPrice], [MoreInfo], [Status], [Discount], [IdTable], [IdStaff]) VALUES (5, CAST(0x0000A92E01567A2D AS DateTime), CAST(0x0000A93000BFFD9E AS DateTime), 90000, NULL, 1, 0, 1, N'QL001')
INSERT [dbo].[Bill] ([Id], [TimeIn], [TimeOut], [TotalPrice], [MoreInfo], [Status], [Discount], [IdTable], [IdStaff]) VALUES (7, CAST(0x0000A9310164400C AS DateTime), CAST(0x0000A9310164F670 AS DateTime), 100000, NULL, 1, 0, 1, N'QL001')
INSERT [dbo].[Bill] ([Id], [TimeIn], [TimeOut], [TotalPrice], [MoreInfo], [Status], [Discount], [IdTable], [IdStaff]) VALUES (8, CAST(0x0000A932014AFAF7 AS DateTime), CAST(0x0000A932014B1CCE AS DateTime), 108000, NULL, 1, 10, 2, N'QL001')
INSERT [dbo].[Bill] ([Id], [TimeIn], [TimeOut], [TotalPrice], [MoreInfo], [Status], [Discount], [IdTable], [IdStaff]) VALUES (9, CAST(0x0000A932014B6763 AS DateTime), NULL, 0, NULL, 0, NULL, 1, N'QL001')
SET IDENTITY_INSERT [dbo].[Bill] OFF
/****** Object:  Table [dbo].[Input]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input](
	[Id] [nvarchar](128) NOT NULL,
	[DateInput] [datetime] NULL,
	[MoreInfo] [nvarchar](max) NULL,
	[IdStaff] [nvarchar](128) NULL,
	[IdSupplier] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Input] ([Id], [DateInput], [MoreInfo], [IdStaff], [IdSupplier]) VALUES (N'HD414343', CAST(0x0000A930000F1A20 AS DateTime), NULL, N'QL001', N'NCC404')
INSERT [dbo].[Input] ([Id], [DateInput], [MoreInfo], [IdStaff], [IdSupplier]) VALUES (N'HD648384', CAST(0x0000A92F018999AA AS DateTime), NULL, N'QL001', N'NCC404')
/****** Object:  Table [dbo].[GoodsForFood]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoodsForFood](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFood] [int] NULL,
	[IdGoods] [int] NULL,
	[Count] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GoodsForFood] ON
INSERT [dbo].[GoodsForFood] ([Id], [IdFood], [IdGoods], [Count]) VALUES (1, 1, 1, 200)
INSERT [dbo].[GoodsForFood] ([Id], [IdFood], [IdGoods], [Count]) VALUES (2, 1, 3, 1)
SET IDENTITY_INSERT [dbo].[GoodsForFood] OFF
/****** Object:  Table [dbo].[Output]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Output](
	[Id] [nvarchar](128) NOT NULL,
	[DateOutput] [datetime] NULL,
	[MoreInfo] [nvarchar](max) NULL,
	[IdStaff] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Output] ([Id], [DateOutput], [MoreInfo], [IdStaff]) VALUES (N'HDX632899', CAST(0x0000A93000B8136B AS DateTime), NULL, N'QL001')
/****** Object:  Table [dbo].[OutputInfo]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutputInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdOutput] [nvarchar](128) NULL,
	[IdGoods] [int] NULL,
	[Count] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OutputInfo] ON
INSERT [dbo].[OutputInfo] ([Id], [IdOutput], [IdGoods], [Count]) VALUES (1, N'HDX632899', 1, 2000)
SET IDENTITY_INSERT [dbo].[OutputInfo] OFF
/****** Object:  Table [dbo].[InputInfo]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdInput] [nvarchar](128) NULL,
	[IdGoods] [int] NULL,
	[Count] [float] NULL,
	[InputPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[InputInfo] ON
INSERT [dbo].[InputInfo] ([Id], [IdInput], [IdGoods], [Count], [InputPrice]) VALUES (1, N'HD648384', 1, 10000, 5000000)
INSERT [dbo].[InputInfo] ([Id], [IdInput], [IdGoods], [Count], [InputPrice]) VALUES (2, N'HD648384', 2, 10000, 10000000)
INSERT [dbo].[InputInfo] ([Id], [IdInput], [IdGoods], [Count], [InputPrice]) VALUES (3, N'HD414343', 3, 480, 6000000)
SET IDENTITY_INSERT [dbo].[InputInfo] OFF
/****** Object:  Table [dbo].[BillInfo]    Script Date: 08/06/2018 13:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBill] [int] NULL,
	[IdFood] [int] NULL,
	[Count] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Count]) VALUES (7, 5, 1, 1)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Count]) VALUES (8, 5, 4, 1)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Count]) VALUES (12, 7, 11, 3)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Count]) VALUES (13, 7, 11, 5)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Count]) VALUES (14, 7, 11, 2)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Count]) VALUES (15, 8, 1, 2)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Count]) VALUES (16, 8, 2, 2)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Count]) VALUES (17, 9, 4, 3)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Count]) VALUES (19, 9, 4, 2)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
/****** Object:  ForeignKey [FK__TableFood__IdReg__0DAF0CB0]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[TableFood]  WITH CHECK ADD FOREIGN KEY([IdRegion])
REFERENCES [dbo].[Region] ([Id])
GO
/****** Object:  ForeignKey [FK__Staff__IdRole__0519C6AF]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
/****** Object:  ForeignKey [FK__Goods__IdUnit__2F10007B]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[Goods]  WITH CHECK ADD FOREIGN KEY([IdUnit])
REFERENCES [dbo].[Unit] ([Id])
GO
/****** Object:  ForeignKey [FK__Food__IdUnit__1A14E395]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([IdCategoryFood])
REFERENCES [dbo].[CategoryFood] ([Id])
GO
/****** Object:  ForeignKey [FK__Food__IdUnit__1B0907CE]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([IdUnit])
REFERENCES [dbo].[Unit] ([Id])
GO
/****** Object:  ForeignKey [FK__Bill__IdStaff__1FCDBCEB]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([IdTable])
REFERENCES [dbo].[TableFood] ([Id])
GO
/****** Object:  ForeignKey [FK__Bill__IdStaff__20C1E124]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([IdStaff])
REFERENCES [dbo].[Staff] ([Id])
GO
/****** Object:  ForeignKey [FK__Input__IdSupplie__398D8EEE]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[Input]  WITH CHECK ADD FOREIGN KEY([IdStaff])
REFERENCES [dbo].[Staff] ([Id])
GO
/****** Object:  ForeignKey [FK__Input__IdSupplie__3A81B327]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[Input]  WITH CHECK ADD FOREIGN KEY([IdSupplier])
REFERENCES [dbo].[Supplier] ([Id])
GO
/****** Object:  ForeignKey [FK__GoodsForF__Count__33D4B598]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[GoodsForFood]  WITH CHECK ADD FOREIGN KEY([IdFood])
REFERENCES [dbo].[Food] ([Id])
GO
/****** Object:  ForeignKey [FK__GoodsForF__IdGoo__34C8D9D1]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[GoodsForFood]  WITH CHECK ADD FOREIGN KEY([IdGoods])
REFERENCES [dbo].[Goods] ([Id])
GO
/****** Object:  ForeignKey [FK__Output__IdStaff__44FF419A]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[Output]  WITH CHECK ADD FOREIGN KEY([IdStaff])
REFERENCES [dbo].[Staff] ([Id])
GO
/****** Object:  ForeignKey [FK__OutputInf__Count__49C3F6B7]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[OutputInfo]  WITH CHECK ADD FOREIGN KEY([IdOutput])
REFERENCES [dbo].[Output] ([Id])
GO
/****** Object:  ForeignKey [FK__OutputInf__IdGoo__4AB81AF0]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[OutputInfo]  WITH CHECK ADD FOREIGN KEY([IdGoods])
REFERENCES [dbo].[Goods] ([Id])
GO
/****** Object:  ForeignKey [FK__InputInfo__IdGoo__403A8C7D]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[InputInfo]  WITH CHECK ADD FOREIGN KEY([IdGoods])
REFERENCES [dbo].[Goods] ([Id])
GO
/****** Object:  ForeignKey [FK__InputInfo__Input__3F466844]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[InputInfo]  WITH CHECK ADD FOREIGN KEY([IdInput])
REFERENCES [dbo].[Input] ([Id])
GO
/****** Object:  ForeignKey [FK__BillInfo__Count__25869641]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([IdBill])
REFERENCES [dbo].[Bill] ([Id])
GO
/****** Object:  ForeignKey [FK__BillInfo__IdFood__267ABA7A]    Script Date: 08/06/2018 13:34:30 ******/
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([IdFood])
REFERENCES [dbo].[Food] ([Id])
GO
