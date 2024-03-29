USE [master]
GO
/****** Object:  Database [turnirskoNova2]    Script Date: 27.09.2023. 23:01:28 ******/
CREATE DATABASE [turnirskoNova2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'turnirskoNova2_dat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\turnirskoNova2.mdf' , SIZE = 10240KB , MAXSIZE = 51200KB , FILEGROWTH = 5120KB )
 LOG ON 
( NAME = N'turnirskoNova2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\turnirskoNova2.ldf' , SIZE = 5120KB , MAXSIZE = 25600KB , FILEGROWTH = 5120KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [turnirskoNova2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [turnirskoNova2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [turnirskoNova2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [turnirskoNova2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [turnirskoNova2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [turnirskoNova2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [turnirskoNova2] SET ARITHABORT OFF 
GO
ALTER DATABASE [turnirskoNova2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [turnirskoNova2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [turnirskoNova2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [turnirskoNova2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [turnirskoNova2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [turnirskoNova2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [turnirskoNova2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [turnirskoNova2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [turnirskoNova2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [turnirskoNova2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [turnirskoNova2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [turnirskoNova2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [turnirskoNova2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [turnirskoNova2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [turnirskoNova2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [turnirskoNova2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [turnirskoNova2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [turnirskoNova2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [turnirskoNova2] SET  MULTI_USER 
GO
ALTER DATABASE [turnirskoNova2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [turnirskoNova2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [turnirskoNova2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [turnirskoNova2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [turnirskoNova2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [turnirskoNova2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [turnirskoNova2] SET QUERY_STORE = OFF
GO
USE [turnirskoNova2]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27.09.2023. 23:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 27.09.2023. 23:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 27.09.2023. 23:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27.09.2023. 23:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27.09.2023. 23:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disciplina]    Script Date: 27.09.2023. 23:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disciplina](
	[DisciplinaID] [int] IDENTITY(1,1) NOT NULL,
	[NazivDiscip] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DisciplinaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FazaTakmicenja]    Script Date: 27.09.2023. 23:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FazaTakmicenja](
	[FazaTakmicenjaID] [int] IDENTITY(1,1) NOT NULL,
	[NazivFaze] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FazaTakmicenjaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizatorskiNalog]    Script Date: 27.09.2023. 23:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizatorskiNalog](
	[OrganizatorskiNalogID] [int] IDENTITY(1,1) NOT NULL,
	[ImePrezime] [nvarchar](50) NOT NULL,
	[Klub] [nvarchar](40) NOT NULL,
	[OrganizatorskiKod] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrganizatorskiNalogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UcesnickiNalog]    Script Date: 27.09.2023. 23:01:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UcesnickiNalog](
	[UcesnickiNalogID] [int] IDENTITY(1,1) NOT NULL,
	[ImePrezime] [nvarchar](50) NOT NULL,
	[Klub] [nvarchar](40) NOT NULL,
	[Uloga] [nvarchar](10) NOT NULL,
	[DisciplinaID] [int] NOT NULL,
	[FazaTakmicenjaID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UcesnickiNalogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'organizator')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'ucesnik')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'menadzer')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9fdde961-fee3-4a34-9fdc-296e33826dd2', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'de373e0a-e02d-473e-8bd4-254bb30a2338', N'3')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'802ec2d4-ba38-4865-b0dd-4cf5b199e575', N'jabijedannalog@gmail.com', 0, N'APyTadAjEmC1nrBa8LhnNs1E0tzKaMoM86Zb4RvPnksHFxrF23pqoz5iSGiBGkJTpQ==', N'b94d89e1-a3d0-46f6-b89c-2d5784d523cd', NULL, 0, 0, NULL, 1, 0, N'jabijedannalog@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9fdde961-fee3-4a34-9fdc-296e33826dd2', N'organiz@gmail.com', 0, N'AKfjtpTaux/CfMco+lC7YSpHAz5lwGiN22g4+9yzwOmkdj7Z+YKugNniyDbhBEtmqw==', N'ec23f9da-be6a-4462-9dc8-b23f4487833f', NULL, 0, 0, NULL, 1, 0, N'organiz@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de373e0a-e02d-473e-8bd4-254bb30a2338', N'menadzer@gmail.com', 0, N'AGnOSimhSr/IMFyJt+Iblw1HHbUxZtoRaTmyfJBxmwMY0HhtvgQ+rEV1rphCXU/VUA==', N'8e61b687-4d7a-4786-8ebb-277e2250b2ae', NULL, 0, 0, NULL, 1, 0, N'menadzer@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Disciplina] ON 

INSERT [dbo].[Disciplina] ([DisciplinaID], [NazivDiscip]) VALUES (1, N'longsword')
INSERT [dbo].[Disciplina] ([DisciplinaID], [NazivDiscip]) VALUES (2, N'smallsword')
INSERT [dbo].[Disciplina] ([DisciplinaID], [NazivDiscip]) VALUES (5, N'sidesword')
INSERT [dbo].[Disciplina] ([DisciplinaID], [NazivDiscip]) VALUES (8, N'rapir')
INSERT [dbo].[Disciplina] ([DisciplinaID], [NazivDiscip]) VALUES (29, N'sablja')
INSERT [dbo].[Disciplina] ([DisciplinaID], [NazivDiscip]) VALUES (30, N'spadone')
INSERT [dbo].[Disciplina] ([DisciplinaID], [NazivDiscip]) VALUES (45, N'sideswooo')
INSERT [dbo].[Disciplina] ([DisciplinaID], [NazivDiscip]) VALUES (47, N'smallswuu')
INSERT [dbo].[Disciplina] ([DisciplinaID], [NazivDiscip]) VALUES (57, N'disciplina')
SET IDENTITY_INSERT [dbo].[Disciplina] OFF
GO
SET IDENTITY_INSERT [dbo].[FazaTakmicenja] ON 

INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (1, N'grupna')
INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (2, N'eliminaciona')
INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (3, N'finalna')
INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (10, N'polufinalna')
INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (11, N'sudden death')
INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (43, N'grupna')
INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (44, N'eliminaciona')
INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (45, N'grupnaeger')
INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (47, N'grupna')
INSERT [dbo].[FazaTakmicenja] ([FazaTakmicenjaID], [NazivFaze]) VALUES (53, N'faza za izmenu')
SET IDENTITY_INSERT [dbo].[FazaTakmicenja] OFF
GO
SET IDENTITY_INSERT [dbo].[OrganizatorskiNalog] ON 

INSERT [dbo].[OrganizatorskiNalog] ([OrganizatorskiNalogID], [ImePrezime], [Klub], [OrganizatorskiKod]) VALUES (1, N'Organ Organizovanovic', N'SwordFencing', N'12345')
INSERT [dbo].[OrganizatorskiNalog] ([OrganizatorskiNalogID], [ImePrezime], [Klub], [OrganizatorskiKod]) VALUES (2, N'Admin Adminovic', N'MacevanjeMacevima', N'54321')
SET IDENTITY_INSERT [dbo].[OrganizatorskiNalog] OFF
GO
SET IDENTITY_INSERT [dbo].[UcesnickiNalog] ON 

INSERT [dbo].[UcesnickiNalog] ([UcesnickiNalogID], [ImePrezime], [Klub], [Uloga], [DisciplinaID], [FazaTakmicenjaID]) VALUES (1, N'Ana Anic', N'BG fencing', N'borac', 1, 1)
INSERT [dbo].[UcesnickiNalog] ([UcesnickiNalogID], [ImePrezime], [Klub], [Uloga], [DisciplinaID], [FazaTakmicenjaID]) VALUES (2, N'Pera Peric', N'MK Sarajevo', N'borac', 1, 1)
INSERT [dbo].[UcesnickiNalog] ([UcesnickiNalogID], [ImePrezime], [Klub], [Uloga], [DisciplinaID], [FazaTakmicenjaID]) VALUES (3, N'Zhang Weili', N'Hebei fencing', N'borac', 1, 3)
INSERT [dbo].[UcesnickiNalog] ([UcesnickiNalogID], [ImePrezime], [Klub], [Uloga], [DisciplinaID], [FazaTakmicenjaID]) VALUES (4, N'Kamaru Usman', N'Auchi FK', N'borac', 1, 3)
INSERT [dbo].[UcesnickiNalog] ([UcesnickiNalogID], [ImePrezime], [Klub], [Uloga], [DisciplinaID], [FazaTakmicenjaID]) VALUES (7, N'Yevgeniy Grigoriev', N'Rogue Fencing2', N'borac', 1, 2)
INSERT [dbo].[UcesnickiNalog] ([UcesnickiNalogID], [ImePrezime], [Klub], [Uloga], [DisciplinaID], [FazaTakmicenjaID]) VALUES (37, N'fnfgfllojojoj', N'gnfgnfaa', N'fnfgnf', 45, 44)
INSERT [dbo].[UcesnickiNalog] ([UcesnickiNalogID], [ImePrezime], [Klub], [Uloga], [DisciplinaID], [FazaTakmicenjaID]) VALUES (49, N'primer za brisanjee', N'fsdgsg', N'sudija', 1, 2)
INSERT [dbo].[UcesnickiNalog] ([UcesnickiNalogID], [ImePrezime], [Klub], [Uloga], [DisciplinaID], [FazaTakmicenjaID]) VALUES (51, N'primer stvaranja', N'stvaranje MK', N'borac', 1, 1)
INSERT [dbo].[UcesnickiNalog] ([UcesnickiNalogID], [ImePrezime], [Klub], [Uloga], [DisciplinaID], [FazaTakmicenjaID]) VALUES (52, N'uuuuuuuu', N'oooooooo', N'aaaaaaa', 1, 1)
SET IDENTITY_INSERT [dbo].[UcesnickiNalog] OFF
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UcesnickiNalog]  WITH CHECK ADD FOREIGN KEY([DisciplinaID])
REFERENCES [dbo].[Disciplina] ([DisciplinaID])
GO
ALTER TABLE [dbo].[UcesnickiNalog]  WITH CHECK ADD FOREIGN KEY([FazaTakmicenjaID])
REFERENCES [dbo].[FazaTakmicenja] ([FazaTakmicenjaID])
GO
USE [master]
GO
ALTER DATABASE [turnirskoNova2] SET  READ_WRITE 
GO
