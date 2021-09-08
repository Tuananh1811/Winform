USE [master]
GO
/****** Object:  Database [DoTuanAnh]    Script Date: 30/07/2021 09:03:25 ******/
CREATE DATABASE [DoTuanAnh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoTuanAnh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DoTuanAnh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DoTuanAnh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DoTuanAnh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DoTuanAnh] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoTuanAnh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoTuanAnh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoTuanAnh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoTuanAnh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoTuanAnh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoTuanAnh] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoTuanAnh] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DoTuanAnh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoTuanAnh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoTuanAnh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoTuanAnh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoTuanAnh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoTuanAnh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoTuanAnh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoTuanAnh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoTuanAnh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DoTuanAnh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoTuanAnh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoTuanAnh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoTuanAnh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoTuanAnh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoTuanAnh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DoTuanAnh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoTuanAnh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DoTuanAnh] SET  MULTI_USER 
GO
ALTER DATABASE [DoTuanAnh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoTuanAnh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoTuanAnh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoTuanAnh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DoTuanAnh] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DoTuanAnh] SET QUERY_STORE = OFF
GO
USE [DoTuanAnh]
GO
/****** Object:  Table [dbo].[QLKhachSan224]    Script Date: 30/07/2021 09:03:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QLKhachSan224](
	[Makh] [nvarchar](50) NOT NULL,
	[Tenkh] [nvarchar](50) NOT NULL,
	[Gt] [bit] NULL,
	[SoCMND] [nvarchar](50) NULL,
	[SoPhong] [int] NULL,
	[NgayCheckIn] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[QLKhachSan224] ([Makh], [Tenkh], [Gt], [SoCMND], [SoPhong], [NgayCheckIn]) VALUES (N'KH01', N'Do Tuan Anh', 1, N'026213455', 3, CAST(N'2021-07-08' AS Date))
INSERT [dbo].[QLKhachSan224] ([Makh], [Tenkh], [Gt], [SoCMND], [SoPhong], [NgayCheckIn]) VALUES (N'KH03', N'Nguyen Thi Anh 2', 1, N'026113455', 4, CAST(N'2021-01-01' AS Date))
INSERT [dbo].[QLKhachSan224] ([Makh], [Tenkh], [Gt], [SoCMND], [SoPhong], [NgayCheckIn]) VALUES (N'KH04', N'abc', 1, N'1234567', 2, CAST(N'2021-01-01' AS Date))
INSERT [dbo].[QLKhachSan224] ([Makh], [Tenkh], [Gt], [SoCMND], [SoPhong], [NgayCheckIn]) VALUES (N'Kh05', N'abt', 1, N'32', -9, CAST(N'2021-01-01' AS Date))
GO
USE [master]
GO
ALTER DATABASE [DoTuanAnh] SET  READ_WRITE 
GO
