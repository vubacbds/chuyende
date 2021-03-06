USE [master]
GO
/****** Object:  Database [QLQuanTraSua]    Script Date: 01/14/2022 09:38:33 ******/
CREATE DATABASE [QLQuanTraSua] ON  PRIMARY 
( NAME = N'QLQuanCaPhe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QLQuanTraSua.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLQuanCaPhe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QLQuanTraSua_1.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLQuanTraSua] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLQuanTraSua].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLQuanTraSua] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QLQuanTraSua] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QLQuanTraSua] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QLQuanTraSua] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QLQuanTraSua] SET ARITHABORT OFF
GO
ALTER DATABASE [QLQuanTraSua] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QLQuanTraSua] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QLQuanTraSua] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QLQuanTraSua] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QLQuanTraSua] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QLQuanTraSua] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QLQuanTraSua] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QLQuanTraSua] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QLQuanTraSua] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QLQuanTraSua] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QLQuanTraSua] SET  DISABLE_BROKER
GO
ALTER DATABASE [QLQuanTraSua] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QLQuanTraSua] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QLQuanTraSua] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QLQuanTraSua] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QLQuanTraSua] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QLQuanTraSua] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QLQuanTraSua] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QLQuanTraSua] SET  READ_WRITE
GO
ALTER DATABASE [QLQuanTraSua] SET RECOVERY FULL
GO
ALTER DATABASE [QLQuanTraSua] SET  MULTI_USER
GO
ALTER DATABASE [QLQuanTraSua] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QLQuanTraSua] SET DB_CHAINING OFF
GO
USE [QLQuanTraSua]
GO
/****** Object:  Table [dbo].[BanAn]    Script Date: 01/14/2022 09:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanAn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
	[TrangThai] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BanAn] ON
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (1, N'Bàn 1', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (2, N'Bàn 2', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (3, N'Bàn 3', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (4, N'Bàn 4', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (5, N'Bàn 5', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (6, N'Bàn 6', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (7, N'Bàn 7', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (8, N'Bàn 8', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (9, N'Bàn 9', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (10, N'Bàn 10', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (11, N'Bàn 11', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (12, N'Bàn 12', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (13, N'Bàn 13', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (14, N'Bàn 14', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (15, N'Bàn 15', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (16, N'Bàn 16', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (17, N'Bàn 17', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (18, N'Bàn 18', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (19, N'Bàn 19', N'Trống')
INSERT [dbo].[BanAn] ([id], [Ten], [TrangThai]) VALUES (20, N'Bàn 20', N'Trống')
SET IDENTITY_INSERT [dbo].[BanAn] OFF
/****** Object:  Table [dbo].[DanhMucMatHang]    Script Date: 01/14/2022 09:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucMatHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DanhMucMatHang] ON
INSERT [dbo].[DanhMucMatHang] ([id], [Ten]) VALUES (1, N'Trà sữa')
INSERT [dbo].[DanhMucMatHang] ([id], [Ten]) VALUES (2, N'Trà')
INSERT [dbo].[DanhMucMatHang] ([id], [Ten]) VALUES (3, N'Cà phê')
SET IDENTITY_INSERT [dbo].[DanhMucMatHang] OFF
/****** Object:  Table [dbo].[ChucVu]    Script Date: 01/14/2022 09:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__ChucVu__3213E83F5629CD9C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON
INSERT [dbo].[ChucVu] ([id], [Ten]) VALUES (1, N'Quản trị viên')
INSERT [dbo].[ChucVu] ([id], [Ten]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 01/14/2022 09:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenDangNhap] [varchar](100) NOT NULL,
	[MatKhau] [varchar](1000) NOT NULL,
	[TenTaiKhoan] [nvarchar](100) NOT NULL,
	[id_CV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [TenTaiKhoan], [id_CV]) VALUES (N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'Quản lý quán nek', 1)
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [TenTaiKhoan], [id_CV]) VALUES (N'bao', N'c4ca4238a0b923820dcc509a6f75849b', N'Bảo Nhỏ', 2)
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [TenTaiKhoan], [id_CV]) VALUES (N'baonho', N'c4ca4238a0b923820dcc509a6f75849b', N'Bảo lớn lắm hi', 1)
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [TenTaiKhoan], [id_CV]) VALUES (N'tungbo', N'c4ca4238a0b923820dcc509a6f75849b', N'Tùng bò (*.*)', 2)
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [TenTaiKhoan], [id_CV]) VALUES (N'viet', N'c4ca4238a0b923820dcc509a6f75849b', N'Việt nek ahihi :))', 2)
/****** Object:  Table [dbo].[MatHang]    Script Date: 01/14/2022 09:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
	[id_DM] [int] NOT NULL,
	[Gia] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MatHang] ON
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (1, N'Trà sữa đào', 1, 25000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (2, N'Trà sữa matcha đậu đỏ', 1, 35000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (3, N'Trà sữa okinawa', 1, 50000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (4, N'Trà bí đao', 2, 35000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (5, N'Trà đen', 2, 25000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (6, N'Cà phê đen đá', 3, 30000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (7, N'Cà phê sữa đá', 3, 32000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (12, N'Trà sữa okinawa cà phê', 1, 43000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (13, N'Trà sữa okinawa oreo cream', 1, 35000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (14, N'Trà sữa ô lông', 1, 43000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (15, N'Trà sữa sô cô la', 1, 55000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (16, N'Trà sữa trân châu đường đen', 1, 30000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (17, N'Trà sữa trân châu trắng', 1, 35000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (18, N'Trà bí đao Alisan', 2, 32000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (19, N'Trà ô long', 2, 36000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (20, N'Trà xanh', 2, 25000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (21, N'Trà xanh đào', 2, 37000)
INSERT [dbo].[MatHang] ([id], [Ten], [id_DM], [Gia]) VALUES (22, N'Cà phê sài gòn', 3, 35000)
SET IDENTITY_INSERT [dbo].[MatHang] OFF
/****** Object:  Table [dbo].[HoaDon]    Script Date: 01/14/2022 09:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NgayVao] [date] NOT NULL,
	[NgayRa] [date] NULL,
	[id_Ban] [int] NOT NULL,
	[TrangThai] [int] NOT NULL,
	[TongThanhTien] [float] NOT NULL,
 CONSTRAINT [PK__HoaDon__3213E83F164452B1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (1, CAST(0x72430B00 AS Date), CAST(0x72430B00 AS Date), 6, 1, 155000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (2, CAST(0x72430B00 AS Date), CAST(0x72430B00 AS Date), 7, 1, 45000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (3, CAST(0x72430B00 AS Date), CAST(0x72430B00 AS Date), 1, 1, 885000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (4, CAST(0x72430B00 AS Date), CAST(0x72430B00 AS Date), 6, 1, 810000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (5, CAST(0x72430B00 AS Date), CAST(0x72430B00 AS Date), 8, 1, 920000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (6, CAST(0x72430B00 AS Date), CAST(0x74430B00 AS Date), 1, 1, 480000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (7, CAST(0x73430B00 AS Date), CAST(0x73430B00 AS Date), 10, 1, 0)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (8, CAST(0x73430B00 AS Date), CAST(0x74430B00 AS Date), 13, 1, 0)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (9, CAST(0x74430B00 AS Date), CAST(0x74430B00 AS Date), 10, 1, 0)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (10, CAST(0x74430B00 AS Date), CAST(0x74430B00 AS Date), 6, 1, 0)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (11, CAST(0x74430B00 AS Date), CAST(0x74430B00 AS Date), 12, 1, 300000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (12, CAST(0x74430B00 AS Date), CAST(0x74430B00 AS Date), 13, 1, 495000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (13, CAST(0x74430B00 AS Date), NULL, 18, 0, 0)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (14, CAST(0x74430B00 AS Date), CAST(0x74430B00 AS Date), 5, 1, 0)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (15, CAST(0x74430B00 AS Date), CAST(0x74430B00 AS Date), 6, 1, 280000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (16, CAST(0x74430B00 AS Date), CAST(0x74430B00 AS Date), 7, 1, 0)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (17, CAST(0x74430B00 AS Date), CAST(0x76430B00 AS Date), 16, 1, 150000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (18, CAST(0x74430B00 AS Date), CAST(0x74430B00 AS Date), 6, 1, 585000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (19, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 11, 1, 75000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (20, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 7, 1, 1050000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (21, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 6, 1, 320000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (22, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 10, 1, 507000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (23, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 9, 1, 175000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (24, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 5, 1, 220000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (25, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 8, 1, 210000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (26, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 3, 1, 426000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (27, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 4, 1, 454000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (28, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 2, 1, 430000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (29, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 1, 1, 847000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (30, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 12, 1, 1652000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (31, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 15, 1, 150000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (32, CAST(0x76430B00 AS Date), CAST(0x76430B00 AS Date), 20, 1, 129000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (33, CAST(0x77430B00 AS Date), CAST(0x77430B00 AS Date), 8, 1, 220000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (34, CAST(0x78430B00 AS Date), CAST(0x78430B00 AS Date), 11, 1, 150000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (35, CAST(0x78430B00 AS Date), CAST(0x78430B00 AS Date), 13, 1, 200000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (36, CAST(0x78430B00 AS Date), CAST(0x78430B00 AS Date), 1, 1, 25000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (37, CAST(0x78430B00 AS Date), CAST(0x78430B00 AS Date), 6, 1, 105000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (38, CAST(0x78430B00 AS Date), CAST(0x78430B00 AS Date), 17, 1, 490000)
INSERT [dbo].[HoaDon] ([id], [NgayVao], [NgayRa], [id_Ban], [TrangThai], [TongThanhTien]) VALUES (39, CAST(0x78430B00 AS Date), CAST(0x78430B00 AS Date), 8, 1, 100000)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 01/14/2022 09:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_HD] [int] NOT NULL,
	[id_MH] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (88, 1, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (89, 2, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (90, 1, 4, 8)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (91, 1, 5, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (92, 3, 1, 15)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (93, 3, 2, 12)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (94, 4, 2, 12)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (95, 4, 4, 8)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (96, 4, 6, 14)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (97, 5, 6, 14)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (98, 5, 3, 21)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (99, 6, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (100, 6, 2, 13)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (101, 7, 1, 15)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (102, 7, 2, 11)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (103, 8, 2, 13)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (104, 9, 7, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (105, 9, 5, 8)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (106, 10, 2, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (107, 10, 3, 21)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (108, 11, 1, 5)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (109, 11, 5, 7)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (110, 12, 3, 21)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (111, 12, 2, 7)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (115, 15, 4, 8)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (117, 17, 3, 21)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (118, 18, 21, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (119, 18, 19, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (120, 18, 15, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (121, 19, 1, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (122, 20, 3, 21)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (123, 21, 16, 6)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (124, 21, 17, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (125, 22, 4, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (126, 22, 18, 6)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (127, 22, 20, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (128, 23, 20, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (129, 24, 5, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (130, 24, 6, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (131, 25, 6, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (132, 25, 22, 2)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (133, 25, 1, 2)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (134, 26, 12, 2)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (135, 26, 15, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (136, 26, 17, 5)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (137, 27, 4, 5)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (138, 27, 18, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (139, 27, 19, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (140, 27, 20, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (141, 28, 5, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (142, 28, 19, 5)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (143, 28, 20, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (144, 29, 2, 7)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (145, 29, 14, 14)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (146, 30, 14, 14)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (147, 30, 3, 21)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (148, 31, 3, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (149, 32, 14, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (150, 33, 15, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (151, 34, 3, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (152, 35, 3, 4)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (153, 36, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (154, 37, 17, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (155, 38, 13, 2)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (156, 38, 6, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (157, 38, 19, 5)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (158, 38, 20, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (159, 39, 20, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [id_HD], [id_MH], [SoLuong]) VALUES (160, 39, 5, 1)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 01/14/2022 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateAndPage]
@tungay date, @denngay date, @page int
AS 
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
	
	;WITH BillShow AS( select A.id, B.Ten, NgayVao, NgayRa, TongThanhTien
	from HoaDon A inner join BanAn B on A.id_Ban = B.id
	where A.TrangThai = 1 and NgayVao >=@tungay and NgayRa <=@denngay)
	
	SELECT TOP (@selectRows) * FROM BillShow WHERE id NOT IN (SELECT TOP (@exceptRows) id FROM BillShow)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 01/14/2022 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetListBillByDate]
@tungay date, @denngay date
as
begin
	select B.Ten, NgayVao, NgayRa, TongThanhTien
	from HoaDon A inner join BanAn B on A.id_Ban = B.id
	where A.TrangThai = 1 and NgayVao >=@tungay and NgayRa <=@denngay
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 01/14/2022 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetAccountByUserName]
@TenDangNhap varchar(100)
as
begin
	select * from TaiKhoan where TenDangNhap = @TenDangNhap
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 01/14/2022 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_InsertBill]
@idBan int
as
begin
	insert HoaDon(id_Ban,NgayVao,NgayRa,TrangThai) values(@idBan,GETDATE(),Null,0)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetMaxIdBill]    Script Date: 01/14/2022 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetMaxIdBill]
as
begin
	select MAX(id) from HoaDon
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccout]    Script Date: 01/14/2022 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_UpdateAccout]
@tendangnhap varchar(100), @tentaikhoan nvarchar(100), @matkhau varchar(1000), @matkhaumoi varchar(1000)
as
begin
	declare @isRightPass int
	
	select @isRightPass = COUNT(*) from TaiKhoan where TenDangNhap = @tendangnhap and MatKhau = @matkhau
	if(@isRightPass > 0)
	begin
		if(@matkhaumoi is null or @matkhaumoi = '')
		begin
			update TaiKhoan set TenTaiKhoan = @tentaikhoan where TenDangNhap = @tendangnhap
		end
		else
			update TaiKhoan set TenTaiKhoan = @tentaikhoan, MatKhau = @matkhaumoi where TenDangNhap = @tendangnhap 
		return 1;
	end
	return 0;
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 01/14/2022 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Login]
@TenDangNhap varchar(100),
@MatKhau varchar(1000)
as
begin
	select * from TaiKhoan where TenDangNhap = @TenDangNhap and MatKhau= @MatKhau
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 01/14/2022 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_InsertBillInfo]
@idHD int,@idMH int,@SL int
as
begin
	declare @isExistsBillInfo int, @soluong int = 1
	
	select @isExistsBillInfo = id, @soluong = SoLuong from ChiTietHoaDon where id_HD = @idHD and id_MH = @idMH
	if(@isExistsBillInfo > 0)
	begin
		declare @SLMoi int = @soluong + @SL
		if (@SLMoi > 0)
			update ChiTietHoaDon set SoLuong = @SLMoi where id_MH = @idMH
		else
			delete ChiTietHoaDon where id_HD = @idHD and id_MH = @idMH
		
	end
	else
	begin
		if(@SL > 0)
			insert ChiTietHoaDon(id_HD,id_MH,SoLuong) values(@idHD,@idMH,@SL)
	end
	
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListMenuByTable]    Script Date: 01/14/2022 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetListMenuByTable]
@id int
as
begin
	select C.Ten, B.SoLuong, C.Gia, B.SoLuong*C.Gia as ThanhTien 
	from HoaDon A inner join ChiTietHoaDon B on A.id = B.id_HD 
				  inner join MatHang C on B.id_MH = C.id 
	where A.id_Ban = @id and A.TrangThai=0
end
GO
/****** Object:  Default [DF__BanAn__Ten__014935CB]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[BanAn] ADD  DEFAULT (N'Bàn chưa có tên') FOR [Ten]
GO
/****** Object:  Default [DF__BanAn__TrangThai__023D5A04]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[BanAn] ADD  DEFAULT (N'Trống') FOR [TrangThai]
GO
/****** Object:  Default [DF__DanhMucMatH__Ten__0CBAE877]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[DanhMucMatHang] ADD  DEFAULT (N'Chưa đặt tên') FOR [Ten]
GO
/****** Object:  Default [DF__ChucVu__Ten__5812160E]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[ChucVu] ADD  CONSTRAINT [DF__ChucVu__Ten__5812160E]  DEFAULT (N'Chưa đặt tên') FOR [Ten]
GO
/****** Object:  Default [DF__TaiKhoan__TenTai__07020F21]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT (N'Chưa đặt tên') FOR [TenTaiKhoan]
GO
/****** Object:  Default [DF__TaiKhoan__ChucVu__07F6335A]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT ((0)) FOR [id_CV]
GO
/****** Object:  Default [DF__MatHang__ten__117F9D94]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[MatHang] ADD  DEFAULT (N'Chưa đặt tên') FOR [Ten]
GO
/****** Object:  Default [DF__MatHang__Gia__1273C1CD]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[MatHang] ADD  DEFAULT ((0)) FOR [Gia]
GO
/****** Object:  Default [DF__HoaDon__NgayVao__182C9B23]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[HoaDon] ADD  CONSTRAINT [DF__HoaDon__NgayVao__182C9B23]  DEFAULT (getdate()) FOR [NgayVao]
GO
/****** Object:  Default [DF__HoaDon__TrangTha__1920BF5C]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[HoaDon] ADD  CONSTRAINT [DF__HoaDon__TrangTha__1920BF5C]  DEFAULT ((0)) FOR [TrangThai]
GO
/****** Object:  Default [DF_HoaDon_TongThanhTien]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[HoaDon] ADD  CONSTRAINT [DF_HoaDon_TongThanhTien]  DEFAULT ((0)) FOR [TongThanhTien]
GO
/****** Object:  Default [DF__ChiTietHo__SoLuo__1ED998B2]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  DEFAULT ((0)) FOR [SoLuong]
GO
/****** Object:  ForeignKey [FK_TaiKhoan_ChucVu]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_ChucVu] FOREIGN KEY([id_CV])
REFERENCES [dbo].[ChucVu] ([id])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_ChucVu]
GO
/****** Object:  ForeignKey [FK__MatHang__id_DM__1367E606]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[MatHang]  WITH CHECK ADD FOREIGN KEY([id_DM])
REFERENCES [dbo].[DanhMucMatHang] ([id])
GO
/****** Object:  ForeignKey [FK__HoaDon__TrangTha__1A14E395]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK__HoaDon__TrangTha__1A14E395] FOREIGN KEY([id_Ban])
REFERENCES [dbo].[BanAn] ([id])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK__HoaDon__TrangTha__1A14E395]
GO
/****** Object:  ForeignKey [FK_BillInfo_Bill]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_BillInfo_Bill] FOREIGN KEY([id_HD])
REFERENCES [dbo].[HoaDon] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_BillInfo_Bill]
GO
/****** Object:  ForeignKey [FK_BillInfo_Food]    Script Date: 01/14/2022 09:38:34 ******/
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_BillInfo_Food] FOREIGN KEY([id_MH])
REFERENCES [dbo].[MatHang] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_BillInfo_Food]
GO
