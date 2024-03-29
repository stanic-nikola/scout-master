USE [ScoutMaster]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 1/17/2021 7:13:09 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Igrac]    Script Date: 1/17/2021 7:13:10 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 1/17/2021 7:13:10 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OmiljeniIgraci]    Script Date: 1/17/2021 7:13:10 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ucinak]    Script Date: 1/17/2021 7:13:10 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utakmica]    Script Date: 1/17/2021 7:13:10 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([IDAdmina], [korisnickoIme], [lozinka]) VALUES (1, N'brodie', N'123456')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Igrac] ON 

INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (1, N'Nikola', N'Stanic', 1998, N'Krilo', N'Real Madrid', 180, N'Srbin', N'https://www.youtube.com/watch?v=dghIrvCsIYs')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (2, N'Stevan', N'Mikovic', 1998, N'Stoper', N'Juventus', 185, N'Srbin', NULL)
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (4, N'Dusan', N'Jovicic', 1996, N'Centralni vezni', N'Milan', 186, N'Srbin', N'https://www.youtube.com/watch?v=85E6spD1OjQ')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (1002, N'Luka', N'Filipovic', 1991, N'Odbrana', N'Arsenal', 188, N'Srbija', N'https://www.youtube.com/watch?v=OUKGsb8CpF8')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (1003, N'Petar', N'Barcot', 1996, N'Center Back', N'Man UTD', 185, N'Srbin', NULL)
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (1004, N'Andrija', N'Solunac', 1997, N'Krilo', N'Real Madrid', 183, N'Srbin', N'https://www.youtube.com/watch?v=tBYTDC2ihOo')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (1005, N'Filip', N'Maric', 1989, N'Golman', N'Juventus', 192, N'Srbin', N'https://www.youtube.com/watch?v=_dBz4dTZocg')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (1007, N'Nemanja', N'Vidic', 2001, N'Stoper', N'Man UTD', 188, N'Srbin', NULL)
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (1008, N'Mirko', N'Filipovic', 1985, N'Bek', N'Bayern', 183, N'Hrvat', N'https://www.youtube.com/watch?v=d1-QNhcGsq0')
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (1009, N'Aleksandar', N'Simic', 2004, N'Spic', N'Barcelona', 174, N'Srbin', NULL)
INSERT [dbo].[Igrac] ([IDigraca], [ime], [prezime], [godiste], [pozicija], [klub], [visina], [nacionalnost], [youtubeLink]) VALUES (1010, N'Goran', N'Jokic', 1985, N'Vezni', N'Milan', 177, N'Srbin', N'https://www.youtube.com/watch?v=w9j-PvVU0ew')
SET IDENTITY_INSERT [dbo].[Igrac] OFF
GO
SET IDENTITY_INSERT [dbo].[Korisnik] ON 

INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (2, N'brodie', N'nstanic81@gmail.com', N'123456', N'Nikola', N'Stanic')
INSERT [dbo].[Korisnik] ([IDKorisnika], [korisnickoIme], [email], [lozinka], [ime], [prezime]) VALUES (4, N'drija', N'andrijana@gmail.com', N'123456', N'Andrijana', N'Zivic')
SET IDENTITY_INSERT [dbo].[Korisnik] OFF
GO
SET IDENTITY_INSERT [dbo].[OmiljeniIgraci] ON 

INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (31, 2, 1)
INSERT [dbo].[OmiljeniIgraci] ([IDOmiljenogIgraca], [IDKorisnika], [IDIgraca]) VALUES (33, 2, 4)
SET IDENTITY_INSERT [dbo].[OmiljeniIgraci] OFF
GO
SET IDENTITY_INSERT [dbo].[Ucinak] ON 

INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (6, 2, 2, 1, 0, 3, 3, 65, 56, 9, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (7, 4, 2, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (15, 4, 1010, 0, 1, 1, 0, 34, 27, 5, 76)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (16, 7, 1009, 1, 1, 0, 0, 7, 6, 2, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (17, 9, 1008, 2, 0, 1, 0, 29, 22, 2, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (18, 8, 1007, 1, 0, 2, 1, 65, 55, 7, 85)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (19, 2, 1005, 0, 0, 0, 0, 35, 33, 0, 90)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (20, 8, 1004, 2, 1, 1, 0, 53, 41, 7, 85)
INSERT [dbo].[Ucinak] ([IDUcinka], [IDutakmice], [IDigraca], [golovi], [asistencije], [zutiKartoni], [crveniKartoni], [dodavanja], [uspesnaDodavanja], [prekrsaji], [minuti]) VALUES (22, 1, 1, 2, 1, 1, 0, 34, 32, 10, 90)
SET IDENTITY_INSERT [dbo].[Ucinak] OFF
GO
SET IDENTITY_INSERT [dbo].[Utakmica] ON 

INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (1, CAST(N'2020-07-28T17:45:30.000' AS DateTime), N'Madrid', N'Real Madrid - Juventus', N'4:1')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (2, CAST(N'2020-09-07T13:45:00.000' AS DateTime), N'Torino', N'Juventus - Real Madrid', N'0:2')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (4, CAST(N'2020-11-01T20:45:00.000' AS DateTime), N'Madrid', N'Real Madrid - Milan', N'4:2')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (6, CAST(N'2020-12-08T21:00:00.000' AS DateTime), N'Leipzig', N'RB Leipzig - Man UTD', N'3:2')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (7, CAST(N'2020-12-07T13:45:00.000' AS DateTime), N'Barcelona', N'Barcelona - Arsenal', N'3:1')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (8, CAST(N'2017-01-01T20:45:00.000' AS DateTime), N'Madrid', N'Real Madrid - Man UTD', N'3:1')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (9, CAST(N'2019-07-28T17:45:30.000' AS DateTime), N'Minhen', N'Bayern - Barcelona', N'4:3')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (11, CAST(N'2020-09-08T20:45:00.000' AS DateTime), N'Barcelona', N'Barcelona - Real Madrid', N'1:1')
INSERT [dbo].[Utakmica] ([IDutakmice], [datum], [mesto], [klubovi], [rezultat]) VALUES (12, CAST(N'2020-01-07T18:45:00.000' AS DateTime), N'Leipzig', N'RB Leipzig - Juventus', N'2:2')
SET IDENTITY_INSERT [dbo].[Utakmica] OFF
GO
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
