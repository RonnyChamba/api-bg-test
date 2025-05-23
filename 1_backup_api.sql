USE [master]
GO
/****** Object:  Database [PRUEBA_INTEGRITY_BG]    Script Date: 4/20/2025 11:09:14 PM ******/
CREATE DATABASE [PRUEBA_INTEGRITY_BG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRUEBA_INTEGRITY_BG', FILENAME = N'/var/opt/mssql/data/PRUEBA_INTEGRITY_BG.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRUEBA_INTEGRITY_BG_log', FILENAME = N'/var/opt/mssql/data/PRUEBA_INTEGRITY_BG_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRUEBA_INTEGRITY_BG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET RECOVERY FULL 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET  MULTI_USER 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRUEBA_INTEGRITY_BG', N'ON'
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET QUERY_STORE = ON
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PRUEBA_INTEGRITY_BG]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/20/2025 11:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[PorcentajeIva] [decimal](18, 2) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customers]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[CellPhone] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice_details]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice_details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[Price] [decimal](7, 2) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_invoice_details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice_pay_form]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice_pay_form](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Total] [decimal](7, 2) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[PayFormId] [int] NOT NULL,
 CONSTRAINT [PK_invoice_pay_form] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [nvarchar](100) NOT NULL,
	[FullNameCustomer] [nvarchar](100) NOT NULL,
	[EmailCustomer] [nvarchar](100) NOT NULL,
	[CellPhoneCustomer] [nvarchar](100) NOT NULL,
	[FullNameUser] [nvarchar](100) NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
	[PorcentajeIva] [decimal](7, 2) NOT NULL,
	[IvaValue] [decimal](7, 2) NOT NULL,
	[SubTotal] [decimal](7, 2) NOT NULL,
	[Total] [decimal](7, 2) NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[StatusPay] [nvarchar](max) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_invoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceSequences]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceSequences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastNumber] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceSequences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pay_forms]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pay_forms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_pay_forms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Status] [nvarchar](100) NOT NULL,
	[Price] [decimal](7, 2) NOT NULL,
	[SaleCount] [int] NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Templates]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Templates](
	[Id] [nvarchar](450) NOT NULL,
	[Mnemonic] [nvarchar](max) NOT NULL,
	[Html] [text] NOT NULL,
 CONSTRAINT [PK_Templates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 4/20/2025 11:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Names] [nvarchar](100) NOT NULL,
	[LasName] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Rol] [nvarchar](10) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419074851_RebuildModelNuevo', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419075356_AlterNameColumnUserTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250419233955_AddFieldStatusPayInvoiceTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250420004106_RemoveColumnPayFormInvoiceTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250420005401_AddColumnCompanyIdInvoiceTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250420010659_AddInvoiceSequencesTable', N'9.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250420055546_AddTemplatesTable', N'9.0.4')
GO
SET IDENTITY_INSERT [dbo].[company] ON 

INSERT [dbo].[company] ([Id], [FullName], [PorcentajeIva], [City]) VALUES (1, N'Castro', CAST(12.00 AS Decimal(18, 2)), N'Santo Domingo')
INSERT [dbo].[company] ([Id], [FullName], [PorcentajeIva], [City]) VALUES (2, N'Los olivos', CAST(12.00 AS Decimal(18, 2)), N'Machala')
SET IDENTITY_INSERT [dbo].[company] OFF
GO
SET IDENTITY_INSERT [dbo].[customers] ON 

INSERT [dbo].[customers] ([Id], [FullName], [CellPhone], [Email], [Address], [CompanyId], [Status], [CreateAt]) VALUES (1, N'Melanie', N'098100921', N'melanie@gmail.com', N'El Carmen', 1, N'Activo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[customers] ([Id], [FullName], [CellPhone], [Email], [Address], [CompanyId], [Status], [CreateAt]) VALUES (2, N'Carlos', N'098100900', N'carlosupdate@gmail.com', N'Santo Domingo', 1, N'Activo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[customers] ([Id], [FullName], [CellPhone], [Email], [Address], [CompanyId], [Status], [CreateAt]) VALUES (1002, N'Dayan dos', N'0984937833', N'dayanados@gmail.com', N'Quevedo dos', 1, N'Activo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[customers] ([Id], [FullName], [CellPhone], [Email], [Address], [CompanyId], [Status], [CreateAt]) VALUES (1003, N'Pepe', N'0984937849', N'ronnychamba96@gmail.com', N'Quito', 1, N'Eliminado', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[customers] ([Id], [FullName], [CellPhone], [Email], [Address], [CompanyId], [Status], [CreateAt]) VALUES (1004, N'Mayra', N'0984937849', N'manuelcarrillopenuela51@gmail.com', N'Santo Domingo- Ecuador', 1, N'Eliminado', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[customers] OFF
GO
SET IDENTITY_INSERT [dbo].[invoice_details] ON 

INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (3, N'Jabon ML', N'001', CAST(10.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 3, 1)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (4, N'Pasta dos', N'003', CAST(21.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), 3, 2)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (5, N'Jabon ML', N'001', CAST(10.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 4, 1)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (6, N'Pasta dos', N'003', CAST(21.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), 4, 2)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (7, N'Jabon ML', N'001', CAST(10.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 5, 1)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (8, N'Pasta dos', N'003', CAST(21.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), 5, 2)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (9, N'Jabon ML', N'001', CAST(10.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 6, 1)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (10, N'Pasta dos', N'003', CAST(21.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), 6, 2)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (11, N'Jabon ML', N'001', CAST(10.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 7, 1)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (12, N'Pasta dos', N'003', CAST(21.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), 7, 2)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (13, N'Jabon ML', N'001', CAST(10.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 8, 1)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (14, N'Pasta dos', N'003', CAST(21.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), 8, 2)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (21, N'Jabon ML', N'001', CAST(10.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 10, 1)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (22, N'Pasta dos', N'003', CAST(21.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), 10, 2)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (25, N'Jabon ML', N'001', CAST(10.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 9, 1)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (26, N'Pasta dos', N'003', CAST(21.00 AS Decimal(7, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(42.00 AS Decimal(18, 2)), 9, 2)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (1002, N'Jabon ML', N'001', CAST(10.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 1004, 1)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (1003, N'Pasta dos update', N'010', CAST(24.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)), 1004, 2)
INSERT [dbo].[invoice_details] ([Id], [Description], [Code], [Price], [Amount], [Subtotal], [InvoiceId], [ProductId]) VALUES (1004, N'Pasta dos update', N'010', CAST(24.00 AS Decimal(7, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)), 1005, 2)
SET IDENTITY_INSERT [dbo].[invoice_details] OFF
GO
SET IDENTITY_INSERT [dbo].[invoice_pay_form] ON 

INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (2, N'Efectivo', CAST(10.00 AS Decimal(7, 2)), 3, 1)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (3, N'Transferencia Bancaria', CAST(48.24 AS Decimal(7, 2)), 3, 3)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (4, N'Efectivo', CAST(10.00 AS Decimal(7, 2)), 4, 1)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (5, N'Transferencia Bancaria', CAST(48.24 AS Decimal(7, 2)), 4, 3)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (6, N'Efectivo', CAST(10.00 AS Decimal(7, 2)), 5, 1)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (7, N'Transferencia Bancaria', CAST(48.24 AS Decimal(7, 2)), 5, 3)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (8, N'Efectivo', CAST(10.00 AS Decimal(7, 2)), 6, 1)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (9, N'Transferencia Bancaria', CAST(48.24 AS Decimal(7, 2)), 6, 3)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (10, N'Efectivo', CAST(10.00 AS Decimal(7, 2)), 7, 1)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (11, N'Transferencia Bancaria', CAST(48.24 AS Decimal(7, 2)), 7, 3)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (12, N'Efectivo', CAST(10.00 AS Decimal(7, 2)), 8, 1)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (13, N'Transferencia Bancaria', CAST(48.24 AS Decimal(7, 2)), 8, 3)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (19, N'Efectivo', CAST(10.00 AS Decimal(7, 2)), 10, 1)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (20, N'Transferencia Bancaria', CAST(48.24 AS Decimal(7, 2)), 10, 3)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (23, N'Transferencia Bancaria', CAST(58.24 AS Decimal(7, 2)), 9, 3)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (1002, N'Efectivo', CAST(38.08 AS Decimal(7, 2)), 1004, 1)
INSERT [dbo].[invoice_pay_form] ([Id], [Description], [Total], [InvoiceId], [PayFormId]) VALUES (1003, N'Efectivo', CAST(24.00 AS Decimal(7, 2)), 1005, 1)
SET IDENTITY_INSERT [dbo].[invoice_pay_form] OFF
GO
SET IDENTITY_INSERT [dbo].[invoices] ON 

INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (3, N'124344363435', N'Melanie', N'melanie@gmail.com', N'098100921', N'Rosa Castro', N'Eliminado', CAST(12.00 AS Decimal(7, 2)), CAST(6.24 AS Decimal(7, 2)), CAST(52.00 AS Decimal(7, 2)), CAST(58.24 AS Decimal(7, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 1, N'Pagado', 1)
INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (4, N'124344363436', N'Melanie', N'melanie@gmail.com', N'098100921', N'Rosa Castro', N'Eliminado', CAST(12.00 AS Decimal(7, 2)), CAST(6.24 AS Decimal(7, 2)), CAST(52.00 AS Decimal(7, 2)), CAST(58.24 AS Decimal(7, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 1, N'Pagado', 1)
INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (5, N'0000000001', N'Melanie', N'melanie@gmail.com', N'098100921', N'Rosa Castro', N'Activo', CAST(12.00 AS Decimal(7, 2)), CAST(6.24 AS Decimal(7, 2)), CAST(52.00 AS Decimal(7, 2)), CAST(58.24 AS Decimal(7, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 1, N'Pagado', 1)
INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (6, N'0000000002', N'Melanie', N'melanie@gmail.com', N'098100921', N'Rosa Castro', N'Activo', CAST(12.00 AS Decimal(7, 2)), CAST(6.24 AS Decimal(7, 2)), CAST(52.00 AS Decimal(7, 2)), CAST(58.24 AS Decimal(7, 2)), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 1, N'Pagado', 1)
INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (7, N'0000000003', N'Melanie', N'melanie@gmail.com', N'098100921', N'Rosa Castro', N'Activo', CAST(12.00 AS Decimal(7, 2)), CAST(6.24 AS Decimal(7, 2)), CAST(52.00 AS Decimal(7, 2)), CAST(58.24 AS Decimal(7, 2)), CAST(N'2025-04-19T00:00:00.0000000' AS DateTime2), 1, 1, N'Pagado', 1)
INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (8, N'0000000004', N'Melanie', N'melanie@gmail.com', N'098100921', N'Rosa Castro', N'Activo', CAST(12.00 AS Decimal(7, 2)), CAST(6.24 AS Decimal(7, 2)), CAST(52.00 AS Decimal(7, 2)), CAST(58.24 AS Decimal(7, 2)), CAST(N'2025-04-19T20:36:04.6131193' AS DateTime2), 1, 1, N'Pagado', 1)
INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (9, N'0000000006', N'Melanie', N'melanie@gmail.com', N'098100921', N'Rosa Castro', N'Activo', CAST(12.00 AS Decimal(7, 2)), CAST(6.24 AS Decimal(7, 2)), CAST(52.00 AS Decimal(7, 2)), CAST(58.24 AS Decimal(7, 2)), CAST(N'2025-04-19T00:11:00.6105233' AS DateTime2), 1, 1, N'Pagado', 1)
INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (10, N'0000000007', N'Melanie', N'melanie@gmail.com', N'098100921', N'Rosa Castro', N'Eliminado', CAST(12.00 AS Decimal(7, 2)), CAST(6.24 AS Decimal(7, 2)), CAST(52.00 AS Decimal(7, 2)), CAST(58.24 AS Decimal(7, 2)), CAST(N'2025-04-19T00:09:22.6403122' AS DateTime2), 1, 1, N'Pagado', 1)
INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (1004, N'0000000008', N'Melanie', N'melanie@gmail.com', N'098100921', N'Rosa Castro', N'Eliminado', CAST(12.00 AS Decimal(7, 2)), CAST(4.08 AS Decimal(7, 2)), CAST(34.00 AS Decimal(7, 2)), CAST(38.08 AS Decimal(7, 2)), CAST(N'2025-04-20T20:56:08.5305562' AS DateTime2), 1, 1, N'Pagado', 1)
INSERT [dbo].[invoices] ([Id], [InvoiceNumber], [FullNameCustomer], [EmailCustomer], [CellPhoneCustomer], [FullNameUser], [Status], [PorcentajeIva], [IvaValue], [SubTotal], [Total], [CreateAt], [CustomerId], [UserId], [StatusPay], [CompanyId]) VALUES (1005, N'0000000009', N'Carlos', N'carlosupdate@gmail.com', N'098100900', N'Anahi Damian', N'Activo', CAST(12.00 AS Decimal(7, 2)), CAST(2.88 AS Decimal(7, 2)), CAST(24.00 AS Decimal(7, 2)), CAST(26.88 AS Decimal(7, 2)), CAST(N'2025-04-20T22:47:42.9043759' AS DateTime2), 2, 3, N'Pagado', 1)
SET IDENTITY_INSERT [dbo].[invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceSequences] ON 

INSERT [dbo].[InvoiceSequences] ([Id], [LastNumber]) VALUES (1, 9)
SET IDENTITY_INSERT [dbo].[InvoiceSequences] OFF
GO
SET IDENTITY_INSERT [dbo].[pay_forms] ON 

INSERT [dbo].[pay_forms] ([Id], [Description]) VALUES (1, N'Efectivo')
INSERT [dbo].[pay_forms] ([Id], [Description]) VALUES (2, N'Cheque')
INSERT [dbo].[pay_forms] ([Id], [Description]) VALUES (3, N'Transferencia Bancaria')
INSERT [dbo].[pay_forms] ([Id], [Description]) VALUES (4, N'Crédito')
SET IDENTITY_INSERT [dbo].[pay_forms] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([Id], [Code], [Description], [Status], [Price], [SaleCount], [CreateAt], [CompanyId]) VALUES (1, N'001', N'Jabon ML', N'Activo', CAST(10.00 AS Decimal(7, 2)), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[products] ([Id], [Code], [Description], [Status], [Price], [SaleCount], [CreateAt], [CompanyId]) VALUES (2, N'010', N'Pasta dos update', N'Activo', CAST(24.00 AS Decimal(7, 2)), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[products] ([Id], [Code], [Description], [Status], [Price], [SaleCount], [CreateAt], [CompanyId]) VALUES (1002, N'006', N'Tornillos', N'Eliminado', CAST(20.00 AS Decimal(7, 2)), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[products] ([Id], [Code], [Description], [Status], [Price], [SaleCount], [CreateAt], [CompanyId]) VALUES (1003, N'007', N'Lamparas', N'Eliminado', CAST(20.50 AS Decimal(7, 2)), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[products] ([Id], [Code], [Description], [Status], [Price], [SaleCount], [CreateAt], [CompanyId]) VALUES (1004, N'0015', N'Esferos', N'Activo', CAST(1.00 AS Decimal(7, 2)), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[products] OFF
GO
INSERT [dbo].[Templates] ([Id], [Mnemonic], [Html]) VALUES (N'1', N'TEMPLATE_FACTURA', N'<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Factura</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            color: #333;
        }

        .container {
            width: 100%;
            max-width: 800px;
            margin: 0 auto;
            border: 1px solid #ddd;
            padding: 20px;
        }

        .header {
            width: 100%;
            margin-bottom: 20px;
        }

        .header table {
            width: 100%;
            border-collapse: collapse;
        }

        .header td {
            vertical-align: top;
            padding: 5px;
        }

        .logo {
            width: 150px;
        }

        .company-info {
            text-align: center;
        }

        .invoice-number {
            text-align: right;
            font-weight: bold;
            font-size: 16px;
        }

        .client-info {
            margin-bottom: 20px;
        }

        .section-header {
            background-color: #2c3e50;
            color: white;
            padding: 8px;
            margin-bottom: 10px;
            font-weight: bold;
        }

        .client-details {
            padding-left: 10px;
        }

        .invoice-meta {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        .invoice-meta th {
            background-color: #2c3e50;
            color: white;
            text-align: left;
            padding: 8px;
        }

        .invoice-meta td {
            padding: 8px;
            border: 1px solid #ddd;
        }

        .products-table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        .products-table th {
            background-color: #2c3e50;
            color: white;
            text-align: left;
            padding: 8px;
        }

        .products-table td {
            padding: 8px;
            border: 1px solid #ddd;
        }

        .products-table tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .text-right {
            text-align: right;
        }

        .totals {
            width: 100%;
        }

        .totals td {
            text-align: right;
            padding: 5px;
        }

        .thank-you {
            text-align: center;
            margin-top: 30px;
            font-weight: bold;
        }
    </style>
</head>

<body>
    <div class="container">
        <!-- Header Section -->
        <div class="header">
            <table>
                <tr>
                    <td width="25%">
                        <div class="logo">
                            <img src="/placeholder.svg?height=80&width=150" alt="Transportes">
                          
                        </div>
                    </td>
                    <td width="50%">
                        <div class="company-info">
                            <div style="font-weight: bold; font-size: 16px;">[KEY_COMPANY_NAME]</div>
                            <div>[KEY_COMPANY_ADDRESS]</div>
                        </div>
                    </td>
                    <td width="25%">
                        <div class="invoice-number">
                            FACTURA Nº [KEY_INVOICE_NUMBER]
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <!-- Client Information -->
        <div class="client-info">
            <div class="section-header">FACTURAR A</div>
            <div class="client-details">
                <div>[KEY_FULLNAME_CUSTOMER]</div>
                <!-- <div>Artigas 19</div> -->
                <div>Teléfono: [KEY_TLF_CUSTOMER]</div>
                <div>Email: [KEY_EMAIL_CUSTOMER]</div>
            </div>
        </div>

        <!-- Invoice Meta Information -->
        <table class="invoice-meta">
            <tr>
                <th width="50%">VENDEDOR</th>
                <th width="50%">FECHA</th>
            </tr>
            <tr>
                <td>[KEY_FULLNAME_USER]</td>
                <td>[KEY_DATE_CREATE]</td>
            </tr>
        </table>

        <!-- Products Table -->
        <table class="products-table">

            <thead>
                <tr>
                    <th width="10%">CANT.</th>
                    <th width="50%">DESCRIPCION</th>
                    <th width="20%">PRECIO UNIT.</th>
                    <th width="20%">PRECIO TOTAL</th>
                </tr>
            </thead>

            <tbody>
                [KEY_DETAILS]
            </tbody>

        </table>

        <!-- Totals -->
        <table class="totals">
            <tr>
                <td width="80%">SUBTOTAL $</td>
                <td width="20%">[KEY_SUBTOTAL]</td>
            </tr>
            <tr>
                <td>IVA [KEY_PORCENTAJE_IVA]% $</td>
                <td>[KEY_VALOR_IVA]</td>
            </tr>
            <tr>
                <td><strong>TOTAL $</strong></td>
                <td><strong>[KEY_TOTAL]</strong></td>
            </tr>
        </table>

          <!-- Formas de Pago -->
          <div class="section-header" style="margin-top: 20px;">FORMAS DE PAGO</div>
          <table class="products-table" style="margin-top: 10px;">

            <thead>
                <tr>
                    <th width="70%">DESCRIPCIÓN</th>
                    <th width="30%">MONTO</th>
                </tr>
            </thead>

            <tbody>
                [KEY_PAY_FORMS]
            </tbody>
          </table>
          

        <!-- Thank You Message -->
        <div class="thank-you">
            Gracias por su compra!
        </div>
    </div>
</body>

</html>')
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([Id], [Names], [LasName], [Username], [Password], [Email], [CompanyId], [Rol], [Status], [CreateAt]) VALUES (1, N'Rosa', N'Castro', N'rosa', N'$2a$11$gXYoJDgKOkOHHn/Mb2tOy.VG0Yf92KzHUMHwtm/iopPqoDA.glP.K', N'ronny@gmail.com', 1, N'ADMI', N'Activo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[users] ([Id], [Names], [LasName], [Username], [Password], [Email], [CompanyId], [Rol], [Status], [CreateAt]) VALUES (2, N'Pepe', N'Santos', N'antonio', N'$2a$11$NmqkaWvLvQc8Vrh2RYvaX.Ntv4x52Bs3dWLtffN2NL96qBk3oxCnu', N'antonio@gmail.com', 1, N'USER', N'Activo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[users] ([Id], [Names], [LasName], [Username], [Password], [Email], [CompanyId], [Rol], [Status], [CreateAt]) VALUES (3, N'Anahi', N'Damian', N'anahi', N'$2a$11$mavapq4sYmKDOedrsiyTfuf.q8cHX2ty3Rt1TMtWpayNrTFANrIi2', N'antonio@gmail.com', 1, N'USER', N'Activo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[users] ([Id], [Names], [LasName], [Username], [Password], [Email], [CompanyId], [Rol], [Status], [CreateAt]) VALUES (1002, N'Klever dos', N'Gonzales dos', N'klver', N'$2a$11$rxOoCXDT2kRT06Nn66x2i.yoUQpaNd9UMpyzSMWhS9DQWbLUKQk2i', N'kleverdos@gmail.com', 1, N'USER', N'Activo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[users] ([Id], [Names], [LasName], [Username], [Password], [Email], [CompanyId], [Rol], [Status], [CreateAt]) VALUES (1003, N'Nadia', N'Manola', N'nadia', N'$2a$11$dZtlIXvoPojo4FETruU2uO4rM2IhVGHtAHW..BKW8BT5qGzXLuol2', N'dania@gmail.com', 1, N'USER', N'Eliminado', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[users] ([Id], [Names], [LasName], [Username], [Password], [Email], [CompanyId], [Rol], [Status], [CreateAt]) VALUES (1004, N'Santos', N'Chamba', N'santos2', N'$2a$11$r.dK69NDZIEKrEKxEghSreI528/4MpiTDbRfKD03R7xGCr0IrALOu', N'santos@gmail.com', 1, N'USER', N'Eliminado', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[users] ([Id], [Names], [LasName], [Username], [Password], [Email], [CompanyId], [Rol], [Status], [CreateAt]) VALUES (1005, N'Ismael', N'Sanchez', N'sanches', N'$2a$11$gG/Ku12vPQjFhoKHJxxx1.0IQvkcYcgcBJ8Rm2fpZT79Ufg.LBNbu', N'sanches@gmail.com', 2, N'ADMI', N'Activo', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[users] OFF
GO
/****** Object:  Index [IX_customers_CompanyId]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_customers_CompanyId] ON [dbo].[customers]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User_FullName]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_User_FullName] ON [dbo].[customers]
(
	[FullName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_invoice_details_InvoiceId]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_invoice_details_InvoiceId] ON [dbo].[invoice_details]
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_invoice_details_ProductId]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_invoice_details_ProductId] ON [dbo].[invoice_details]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_invoice_pay_form_InvoiceId]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_invoice_pay_form_InvoiceId] ON [dbo].[invoice_pay_form]
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_invoice_pay_form_PayFormId]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_invoice_pay_form_PayFormId] ON [dbo].[invoice_pay_form]
(
	[PayFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoice_CreateAt]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoice_CreateAt] ON [dbo].[invoices]
(
	[CreateAt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Invoice_FullNameCustomer]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoice_FullNameCustomer] ON [dbo].[invoices]
(
	[FullNameCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Invoice_InvoiceNumber]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoice_InvoiceNumber] ON [dbo].[invoices]
(
	[InvoiceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoice_Total]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Invoice_Total] ON [dbo].[invoices]
(
	[Total] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_invoices_CustomerId]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_invoices_CustomerId] ON [dbo].[invoices]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_invoices_UserId]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_invoices_UserId] ON [dbo].[invoices]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Product_Code]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Code] ON [dbo].[products]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Product_Description]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Description] ON [dbo].[products]
(
	[Description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_products_CompanyId]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_products_CompanyId] ON [dbo].[products]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_users_CompanyId]    Script Date: 4/20/2025 11:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_users_CompanyId] ON [dbo].[users]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[invoices] ADD  DEFAULT (N'') FOR [StatusPay]
GO
ALTER TABLE [dbo].[invoices] ADD  DEFAULT ((0)) FOR [CompanyId]
GO
ALTER TABLE [dbo].[customers]  WITH CHECK ADD  CONSTRAINT [FK_customers_company_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[company] ([Id])
GO
ALTER TABLE [dbo].[customers] CHECK CONSTRAINT [FK_customers_company_CompanyId]
GO
ALTER TABLE [dbo].[invoice_details]  WITH CHECK ADD  CONSTRAINT [FK_invoice_details_invoices_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[invoices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[invoice_details] CHECK CONSTRAINT [FK_invoice_details_invoices_InvoiceId]
GO
ALTER TABLE [dbo].[invoice_details]  WITH CHECK ADD  CONSTRAINT [FK_invoice_details_products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[invoice_details] CHECK CONSTRAINT [FK_invoice_details_products_ProductId]
GO
ALTER TABLE [dbo].[invoice_pay_form]  WITH CHECK ADD  CONSTRAINT [FK_invoice_pay_form_invoices_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[invoices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[invoice_pay_form] CHECK CONSTRAINT [FK_invoice_pay_form_invoices_InvoiceId]
GO
ALTER TABLE [dbo].[invoice_pay_form]  WITH CHECK ADD  CONSTRAINT [FK_invoice_pay_form_pay_forms_PayFormId] FOREIGN KEY([PayFormId])
REFERENCES [dbo].[pay_forms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[invoice_pay_form] CHECK CONSTRAINT [FK_invoice_pay_form_pay_forms_PayFormId]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_customers_CustomerId]
GO
ALTER TABLE [dbo].[invoices]  WITH CHECK ADD  CONSTRAINT [FK_invoices_users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[invoices] CHECK CONSTRAINT [FK_invoices_users_UserId]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_company_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[company] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_company_CompanyId]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_company_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[company] ([Id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_company_CompanyId]
GO
USE [master]
GO
ALTER DATABASE [PRUEBA_INTEGRITY_BG] SET  READ_WRITE 
GO
