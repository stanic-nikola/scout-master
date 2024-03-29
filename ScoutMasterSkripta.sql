USE [ScoutMaster]
GO
ALTER TABLE [dbo].[Ucinak] DROP CONSTRAINT [FK__Ucinak__IDutakmi__440B1D61]
GO
ALTER TABLE [dbo].[Ucinak] DROP CONSTRAINT [FK__Ucinak__IDigraca__4316F928]
GO
ALTER TABLE [dbo].[OmiljeniIgraci] DROP CONSTRAINT [FK__OmiljeniI__IDKor__3D5E1FD2]
GO
ALTER TABLE [dbo].[OmiljeniIgraci] DROP CONSTRAINT [FK__OmiljeniI__IDIgr__3E52440B]
GO
/****** Object:  Table [dbo].[Utakmica]    Script Date: 12.02.2020. 04:03:54 ******/
DROP TABLE [dbo].[Utakmica]
GO
/****** Object:  Table [dbo].[Ucinak]    Script Date: 12.02.2020. 04:03:54 ******/
DROP TABLE [dbo].[Ucinak]
GO
/****** Object:  Table [dbo].[OmiljeniIgraci]    Script Date: 12.02.2020. 04:03:54 ******/
DROP TABLE [dbo].[OmiljeniIgraci]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 12.02.2020. 04:03:54 ******/
DROP TABLE [dbo].[Korisnik]
GO
/****** Object:  Table [dbo].[Igrac]    Script Date: 12.02.2020. 04:03:54 ******/
DROP TABLE [dbo].[Igrac]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12.02.2020. 04:03:54 ******/
DROP TABLE [dbo].[Admin]
GO
USE [master]
GO
/****** Object:  Database [ScoutMaster]    Script Date: 12.02.2020. 04:03:54 ******/
DROP DATABASE [ScoutMaster]
GO
/****** Object:  Database [ScoutMaster]    Script Date: 12.02.2020. 04:03:54 ******/
CREATE DATABASE [ScoutMaster]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ScoutMaster', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ScoutMaster.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ScoutMaster_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ScoutMaster_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ScoutMaster].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ScoutMaster] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ScoutMaster] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ScoutMaster] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ScoutMaster] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ScoutMaster] SET ARITHABORT OFF 
GO
ALTER DATABASE [ScoutMaster] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ScoutMaster] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ScoutMaster] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ScoutMaster] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ScoutMaster] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ScoutMaster] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ScoutMaster] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ScoutMaster] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ScoutMaster] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ScoutMaster] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ScoutMaster] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ScoutMaster] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ScoutMaster] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ScoutMaster] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ScoutMaster] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ScoutMaster] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ScoutMaster] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ScoutMaster] SET RECOVERY FULL 
GO
ALTER DATABASE [ScoutMaster] SET  MULTI_USER 
GO
ALTER DATABASE [ScoutMaster] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ScoutMaster] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ScoutMaster] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ScoutMaster] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ScoutMaster] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ScoutMaster', N'ON'
GO
USE [ScoutMaster]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12.02.2020. 04:03:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[IDAdmina] [int] IDENTITY(1,1) NOT NULL,
	[korisnickoIme] [nvarchar](50) NOT NULL,
	[lozinka] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDAdmina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Igrac]    Script Date: 12.02.2020. 04:03:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Igrac](
	[IDigraca] [int] IDENTITY(1,1) NOT NULL,
	[ime] [nvarchar](40) NOT NULL,
	[prezime] [nvarchar](40) NOT NULL,
	[godiste] [int] NOT NULL,
	[pozicija] [nvarchar](30) NULL,
	[klub] [nvarchar](60) NULL,
	[visina] [int] NOT NULL,
	[nacionalnost] [nvarchar](60) NOT NULL,
	[youtubeLink] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDigraca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 12.02.2020. 04:03:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[IDKorisnika] [int] IDENTITY(1,1) NOT NULL,
	[korisnickoIme] [nvarchar](50) NOT NULL,
	[email] [nvarchar](80) NOT NULL,
	[lozinka] [varchar](15) NOT NULL,
	[ime] [nvarchar](40) NULL,
	[prezime] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDKorisnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OmiljeniIgraci]    Script Date: 12.02.2020. 04:03:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OmiljeniIgraci](
	[IDOmiljenogIgraca] [int] IDENTITY(1,1) NOT NULL,
	[IDKorisnika] [int] NOT NULL,
	[IDIgraca] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDOmiljenogIgraca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ucinak]    Script Date: 12.02.2020. 04:03:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ucinak](
	[IDUcinka] [int] IDENTITY(1,1) NOT NULL,
	[IDutakmice] [int] NOT NULL,
	[IDigraca] [int] NOT NULL,
	[golovi] [int] NULL,
	[asistencije] [int] NULL,
	[zutiKartoni] [int] NULL,
	[crveniKartoni] [int] NULL,
	[dodavanja] [int] NULL,
	[uspesnaDodavanja] [int] NULL,
	[prekrsaji] [int] NULL,
	[minuti] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDUcinka] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utakmica]    Script Date: 12.02.2020. 04:03:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utakmica](
	[IDutakmice] [int] IDENTITY(1,1) NOT NULL,
	[datum] [datetime] NOT NULL,
	[mesto] [nvarchar](50) NULL,
	[klubovi] [nvarchar](120) NULL,
	[rezultat] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDutakmice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([IDAdmina], [korisnickoIme], [lozinka]) VALUES (2, N'Duka', N'duka123')
INSERT [dbo].[Admin] ([IDAdmina], [korisnickoIme], [lozinka]) VALUES (3, N'Brodie', N'brodie123')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Igrac] ON 

INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (2, N'Nikola', N'Danilovic', 1999, N'Golman', N'Spartak', 189, N'Srbija', NULL)
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (3, N'Luka', N'Gajic', 1998, N'Bek', N'Radnicki Nis', 183, N'Srbija', N'https://www.youtube.com/watch?v=m0OwQJYOamA')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (4, N'Sava', N'Radic', 2000, N'Vezni', N'Cukaricki', 178, N'Srbija', N'https://www.youtube.com/watch?v=VYZvoFAEuSc')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (5, N'Igor', N'Vasovic', 2002, N'Krilo', N'Vozdovac', 175, N'Srbija', N'https://www.youtube.com/watch?v=5uci_uV_QU8')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (8, N'Milos', N'Ilic', 2003, N'Napadac', N'Radnicki Nis', 185, N'Srbija', NULL)
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (9, N'Filip', N'Djukic', 2002, N'Vezni', N'Indjija', 183, N'Srbija', N'https://www.youtube.com/watch?v=Mrwdwv2Xn_o')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (26, N'Dusan', N'Jovičić', 1996, N'Krilo', NULL, 188, N'Srbija', N'https://youtu.be/fJ1mVWnt0cY')
SET IDENTITY_INSERT [dbo].[Igrac] OFF
SET IDENTITY_INSERT [dbo].[Korisnik] ON 

INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (1, N'nikola11', N'nstanic81@gmail.com', N'nikola123', N'Nikola', N'Stanic')
INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (2, N'duka10', N'dukaaaa10@gmail.com', N'duka123', N'Dusan', N'Jovicic')
INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (9, N'DukaJ', N'duka@gmail.com', N'123456', N'Dusan', N'Jovičić')
INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (11, N'ObMartin', N'omartins@gmail.com', N'123456', N'Obafemi', N'Martins')
INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (13, N'LukaM', N'mitrovic@gmail.com', N'luka123', N'Luka', N'Mitrovic')
INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (17, N'Bane', N'bane@gmail.com', N'bane123', N'Branko', N'Ivkovic')
INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (18, N'Mirko', N'mirko@live.com', N'mire123', N'Mirko', N'Maljković')
INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (19, N'JecaM', N'jeca@hotmail.com', N'jeca123', N'Jelena', N'Topalović')
INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (20, N'ScoutUser', N'scoutuser@live.com', N'master123', N'Scout', N'User')
SET IDENTITY_INSERT [dbo].[Korisnik] OFF
SET IDENTITY_INSERT [dbo].[OmiljeniIgraci] ON 

INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (1, 1, 2)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (3, 1, 3)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (4, 2, 3)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (5, 2, 4)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (6, 2, 8)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (7, 1, 26)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (8, 1, 4)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (9, 1, 5)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (10, 2, 26)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (11, 1, 9)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (12, 1, 8)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (14, 2, 9)
SET IDENTITY_INSERT [dbo].[OmiljeniIgraci] OFF
SET IDENTITY_INSERT [dbo].[Ucinak] ON 

INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (2, 7, 2, 0, 0, 0, 0, 15, 14, 0, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (3, 4, 2, 0, 0, 1, 0, 20, 14, 6, 83)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (4, 1, 4, 0, 1, 0, 0, 37, 28, 2, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (5, 4, 4, 0, 0, 1, 0, 28, 20, 4, 78)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (6, 1, 5, 0, 1, 0, 0, 22, 16, 2, 84)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (8, 2, 8, 1, 1, 1, 0, 24, 15, 1, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (9, 4, 8, 1, 0, 0, 0, 26, 17, 1, 88)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (10, 5, 9, 0, 1, 0, 0, 16, 13, 2, 40)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (15, 8, 5, 0, 0, 0, 0, 17, 14, 1, 38)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (16, 9, 3, 0, 0, 1, 0, 23, 16, 5, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (17, 2, 3, 0, 1, 0, 0, 20, 15, 3, 70)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (18, 4, 3, 0, 0, 0, 0, 25, 19, 2, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (19, 9, 8, 1, 1, 0, 0, 24, 16, 1, 87)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (20, 9, 9, 0, 0, 1, 0, 41, 33, 4, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (25, 6, 2, 2, 0, 0, 0, 30, 20, 10, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (29, 5, 26, 1, 3, 2, 1, 22, 15, 8, 73)
SET IDENTITY_INSERT [dbo].[Ucinak] OFF
SET IDENTITY_INSERT [dbo].[Utakmica] ON 

INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (1, CAST(N'2019-09-01T20:00:00.000' AS DateTime), N'Beograd', N'Vozdovac - Cukaricki', N'2:1')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (2, CAST(N'2019-01-21T13:15:00.000' AS DateTime), N'Nis', N'Radnicki Nis - Vojvodina', N'2:2')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (3, CAST(N'2019-08-05T16:00:00.000' AS DateTime), N'Novi Sad', N'Vojvodina - Cukaricki', N'2:0')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (4, CAST(N'2018-07-20T18:00:00.000' AS DateTime), N'Beograd', N'Cukaricki - Radnicki Nis', N'1:1')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (5, CAST(N'2020-01-12T13:45:00.000' AS DateTime), N'Indjija', N'Indjija - Vojvodina', N'1:3')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (6, CAST(N'2020-01-17T13:30:00.000' AS DateTime), N'Smederevo', N'Smederevo - Donji Srem', N'1:0')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (7, CAST(N'2019-03-12T16:15:00.000' AS DateTime), N'Subotica', N'Spartak - Vojvodina', N'2:3')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (8, CAST(N'2020-02-01T14:00:00.000' AS DateTime), N'Beograd', N'Vozdovac - Vojvodina', N'1:1')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (9, CAST(N'2019-09-22T13:00:00.000' AS DateTime), N'Nis', N'Radnicki Nis - Indjija', N'3:1')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (21, CAST(N'1930-08-05T16:00:00.000' AS DateTime), N'Montevideo', N'Jugoslavija - Brazil', N'2-1')
SET IDENTITY_INSERT [dbo].[Utakmica] OFF
ALTER TABLE [dbo].[OmiljeniIgraci]  WITH CHECK ADD FOREIGN KEY([IDIgraca])
REFERENCES [dbo].[Igrac] ([IDigraca])
GO
ALTER TABLE [dbo].[OmiljeniIgraci]  WITH CHECK ADD FOREIGN KEY([IDKorisnika])
REFERENCES [dbo].[Korisnik] ([IDKorisnika])
GO
ALTER TABLE [dbo].[Ucinak]  WITH CHECK ADD FOREIGN KEY([IDigraca])
REFERENCES [dbo].[Igrac] ([IDigraca])
GO
ALTER TABLE [dbo].[Ucinak]  WITH CHECK ADD FOREIGN KEY([IDutakmice])
REFERENCES [dbo].[Utakmica] ([IDutakmice])
GO
USE [master]
GO
ALTER DATABASE [ScoutMaster] SET  READ_WRITE 
GO
