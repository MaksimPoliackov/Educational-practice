USE [master]
GO
/****** Object:  Database [Warehouse accounting]    Script Date: 25.02.2025 16:50:30 ******/
CREATE DATABASE [Warehouse accounting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Warehouse accounting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Warehouse accounting.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Warehouse accounting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Warehouse accounting_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Warehouse accounting] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Warehouse accounting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Warehouse accounting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Warehouse accounting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Warehouse accounting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Warehouse accounting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Warehouse accounting] SET ARITHABORT OFF 
GO
ALTER DATABASE [Warehouse accounting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Warehouse accounting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Warehouse accounting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Warehouse accounting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Warehouse accounting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Warehouse accounting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Warehouse accounting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Warehouse accounting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Warehouse accounting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Warehouse accounting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Warehouse accounting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Warehouse accounting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Warehouse accounting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Warehouse accounting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Warehouse accounting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Warehouse accounting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Warehouse accounting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Warehouse accounting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Warehouse accounting] SET  MULTI_USER 
GO
ALTER DATABASE [Warehouse accounting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Warehouse accounting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Warehouse accounting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Warehouse accounting] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Warehouse accounting] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Warehouse accounting]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Contact Info] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Customer ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncomeInvoice]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomeInvoice](
	[Income Invoice ID] [int] IDENTITY(1,1) NOT NULL,
	[Invoice Number] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Supplier ID] [int] NULL,
	[Total Amount] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Income Invoice ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncomeInvoiceDetail]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomeInvoiceDetail](
	[Income Invoice Detail ID] [int] IDENTITY(1,1) NOT NULL,
	[Income Invoice ID] [int] NOT NULL,
	[Product ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Income Invoice Detail ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Inventory ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Responsible] [nvarchar](100) NULL,
	[Results] [nvarchar](max) NULL,
	[Warehouse ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Inventory ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutcomeInvoice]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutcomeInvoice](
	[Outcome Invoice ID] [int] IDENTITY(1,1) NOT NULL,
	[Invoice Number] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Customer ID] [int] NULL,
	[Total Amount] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Outcome Invoice ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutcomeInvoiceDetail]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutcomeInvoiceDetail](
	[Outcome Invoice Detail ID] [int] IDENTITY(1,1) NOT NULL,
	[Outcome Invoice ID] [int] NOT NULL,
	[Product ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Outcome Invoice Detail ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Product ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Article] [nvarchar](50) NOT NULL,
	[Barcode] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[Unit] [nvarchar](20) NULL,
	[Price] [decimal](18, 2) NULL,
	[Serial Number] [nvarchar](50) NULL,
	[Min Stock] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Product ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Supplier ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[INN] [nvarchar](20) NULL,
	[Contact Info] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Supplier ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[Warehouse ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Type] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Warehouse ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WarehouseStock]    Script Date: 25.02.2025 16:50:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseStock](
	[Warehouse Stock ID] [int] IDENTITY(1,1) NOT NULL,
	[Warehouse ID] [int] NOT NULL,
	[Product ID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Warehouse Stock ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[IncomeInvoice]  WITH CHECK ADD FOREIGN KEY([Supplier ID])
REFERENCES [dbo].[Supplier] ([Supplier ID])
GO
ALTER TABLE [dbo].[IncomeInvoiceDetail]  WITH CHECK ADD FOREIGN KEY([Income Invoice ID])
REFERENCES [dbo].[IncomeInvoice] ([Income Invoice ID])
GO
ALTER TABLE [dbo].[IncomeInvoiceDetail]  WITH CHECK ADD FOREIGN KEY([Product ID])
REFERENCES [dbo].[Product] ([Product ID])
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD FOREIGN KEY([Warehouse ID])
REFERENCES [dbo].[Warehouse] ([Warehouse ID])
GO
ALTER TABLE [dbo].[OutcomeInvoice]  WITH CHECK ADD FOREIGN KEY([Customer ID])
REFERENCES [dbo].[Customer] ([Customer ID])
GO
ALTER TABLE [dbo].[OutcomeInvoiceDetail]  WITH CHECK ADD FOREIGN KEY([Outcome Invoice ID])
REFERENCES [dbo].[OutcomeInvoice] ([Outcome Invoice ID])
GO
ALTER TABLE [dbo].[OutcomeInvoiceDetail]  WITH CHECK ADD FOREIGN KEY([Product ID])
REFERENCES [dbo].[Product] ([Product ID])
GO
ALTER TABLE [dbo].[WarehouseStock]  WITH CHECK ADD FOREIGN KEY([Product ID])
REFERENCES [dbo].[Product] ([Product ID])
GO
ALTER TABLE [dbo].[WarehouseStock]  WITH CHECK ADD FOREIGN KEY([Warehouse ID])
REFERENCES [dbo].[Warehouse] ([Warehouse ID])
GO
USE [master]
GO
ALTER DATABASE [Warehouse accounting] SET  READ_WRITE 
GO
