USE [master]
GO
/****** Object:  Database [ShopBridge]    Script Date: 05-26-2021 20:15:47 ******/
CREATE DATABASE [ShopBridge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopBridge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopBridge.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopBridge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopBridge_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopBridge] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopBridge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopBridge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopBridge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopBridge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopBridge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopBridge] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopBridge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopBridge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopBridge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopBridge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopBridge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopBridge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopBridge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopBridge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopBridge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopBridge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopBridge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopBridge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopBridge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopBridge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopBridge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopBridge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopBridge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopBridge] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopBridge] SET  MULTI_USER 
GO
ALTER DATABASE [ShopBridge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopBridge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopBridge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopBridge] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopBridge] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopBridge] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopBridge] SET QUERY_STORE = OFF
GO
USE [ShopBridge]
GO
/****** Object:  Table [dbo].[CategoryMaster]    Script Date: 05-26-2021 20:15:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryMaster](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_CategoryMaster] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductMaster]    Script Date: 05-26-2021 20:15:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMaster](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[ItemNumer] [int] NULL,
	[CategoryId] [int] NOT NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[Weight] [decimal](18, 2) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[Isdeleted] [bit] NULL,
 CONSTRAINT [PK_ProductMaster] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryMaster] ON 

INSERT [dbo].[CategoryMaster] ([CategoryId], [CategoryName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsDeleted]) VALUES (1, N'Electronics', 0, CAST(N'2021-05-26T17:43:25.263' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CategoryMaster] ([CategoryId], [CategoryName], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsDeleted]) VALUES (2, N'Clothing', 0, CAST(N'2021-05-26T17:43:36.390' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[CategoryMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductMaster] ON 

INSERT [dbo].[ProductMaster] ([ProductId], [ProductName], [ItemNumer], [CategoryId], [ProductDescription], [Price], [Weight], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Isdeleted]) VALUES (1, N'Product 1', 1, 2, N'Clothing Product', CAST(500.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 0, CAST(N'2021-05-26T19:10:38.003' AS DateTime), NULL, NULL, 0)
INSERT [dbo].[ProductMaster] ([ProductId], [ProductName], [ItemNumer], [CategoryId], [ProductDescription], [Price], [Weight], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Isdeleted]) VALUES (2, N'Product 2', 2, 2, N'product description', CAST(900.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), 0, CAST(N'2021-05-26T19:14:25.243' AS DateTime), 0, CAST(N'2021-05-26T20:15:46.473' AS DateTime), 0)
INSERT [dbo].[ProductMaster] ([ProductId], [ProductName], [ItemNumer], [CategoryId], [ProductDescription], [Price], [Weight], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [Isdeleted]) VALUES (3, N'Product 3 1', 3, 1, N'description test', CAST(500.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 0, CAST(N'2021-05-26T20:02:11.183' AS DateTime), 0, CAST(N'2021-05-26T20:15:28.977' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[ProductMaster] OFF
GO
USE [master]
GO
ALTER DATABASE [ShopBridge] SET  READ_WRITE 
GO
