USE [master]
GO
/****** Object:  Database [Nina_skateboarding]    Script Date: 01/18/2016 21:42:47 ******/
CREATE DATABASE [Nina_skateboarding] ON  PRIMARY 
( NAME = N'Nina_skateboarding', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Nina_skateboarding.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Nina_skateboarding_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Nina_skateboarding_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Nina_skateboarding] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nina_skateboarding].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nina_skateboarding] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Nina_skateboarding] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Nina_skateboarding] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Nina_skateboarding] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Nina_skateboarding] SET ARITHABORT OFF
GO
ALTER DATABASE [Nina_skateboarding] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Nina_skateboarding] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Nina_skateboarding] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Nina_skateboarding] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Nina_skateboarding] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Nina_skateboarding] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Nina_skateboarding] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Nina_skateboarding] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Nina_skateboarding] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Nina_skateboarding] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Nina_skateboarding] SET  DISABLE_BROKER
GO
ALTER DATABASE [Nina_skateboarding] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Nina_skateboarding] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Nina_skateboarding] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Nina_skateboarding] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Nina_skateboarding] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Nina_skateboarding] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Nina_skateboarding] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Nina_skateboarding] SET  READ_WRITE
GO
ALTER DATABASE [Nina_skateboarding] SET RECOVERY FULL
GO
ALTER DATABASE [Nina_skateboarding] SET  MULTI_USER
GO
ALTER DATABASE [Nina_skateboarding] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Nina_skateboarding] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Nina_skateboarding', N'ON'
GO
USE [Nina_skateboarding]
GO
/****** Object:  User [ninaskateboarding]    Script Date: 01/18/2016 21:42:47 ******/
CREATE USER [ninaskateboarding] FOR LOGIN [ninaskateboarding] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[tbl_Profielen]    Script Date: 01/18/2016 21:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Profielen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[naam] [nvarchar](50) NOT NULL,
	[voornaam] [nvarchar](50) NOT NULL,
	[straat] [nvarchar](50) NOT NULL,
	[nummer] [int] NOT NULL,
	[postcode] [int] NOT NULL,
	[plaats] [nvarchar](50) NOT NULL,
	[telefoonnummer] [nvarchar](50) NOT NULL,
	[emailadres] [nvarchar](50) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[paswoord] [nvarchar](50) NOT NULL,
	[isAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Profielen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Profielen] ON
INSERT [dbo].[tbl_Profielen] ([id], [naam], [voornaam], [straat], [nummer], [postcode], [plaats], [telefoonnummer], [emailadres], [login], [paswoord], [isAdmin]) VALUES (1, N'bellinkx', N'dennis', N'beyenstraat', 75, 3511, N'kuringen', N'0486666666', N'dennisbellinkx@gmail.com', N'dennis', N'dennis', 1)
SET IDENTITY_INSERT [dbo].[tbl_Profielen] OFF
/****** Object:  Table [dbo].[tbl_Locaties]    Script Date: 01/18/2016 21:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Locaties](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[straat] [nvarchar](50) NOT NULL,
	[nummer] [int] NOT NULL,
	[postcode] [int] NOT NULL,
	[plaats] [nvarchar](50) NOT NULL,
	[naam] [nvarchar](50) NOT NULL,
	[telefoonnummer] [nvarchar](50) NOT NULL,
	[emailadres] [nvarchar](50) NOT NULL,
	[foto_link] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Locaties] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Locaties] ON
INSERT [dbo].[tbl_Locaties] ([id], [straat], [nummer], [postcode], [plaats], [naam], [telefoonnummer], [emailadres], [foto_link]) VALUES (1, N'Skatestraat', 7, 3511, N'Kuringen', N'Skatepark', N'0486666666', N'skatepark@skatepark.com', N'test')
INSERT [dbo].[tbl_Locaties] ([id], [straat], [nummer], [postcode], [plaats], [naam], [telefoonnummer], [emailadres], [foto_link]) VALUES (2, N'NietSkateStraat', 1, 1000, N'Brussel', N'Indoor park', N'012 66 66 66', N'indoor@skatepark.com', N'indoor')
SET IDENTITY_INSERT [dbo].[tbl_Locaties] OFF
/****** Object:  Table [dbo].[tbl_Kinderen]    Script Date: 01/18/2016 21:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Kinderen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[voornaam] [nvarchar](50) NOT NULL,
	[achternaam] [nvarchar](50) NOT NULL,
	[geboortedatum] [date] NOT NULL,
	[profielID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Kinderen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Inschrijvingen]    Script Date: 01/18/2016 21:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Inschrijvingen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kindID] [nchar](10) NULL,
	[cursusID] [int] NOT NULL,
	[heeftBetaald] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Inschrijvingen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Cursustypes]    Script Date: 01/18/2016 21:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Cursustypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[naam] [nvarchar](100) NOT NULL,
	[leeftijd_vanaf] [int] NOT NULL,
	[leeftijd_tot_en_met] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Cursustypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Cursustypes] ON
INSERT [dbo].[tbl_Cursustypes] ([id], [naam], [leeftijd_vanaf], [leeftijd_tot_en_met]) VALUES (1, N'kleuter', 3, 6)
INSERT [dbo].[tbl_Cursustypes] ([id], [naam], [leeftijd_vanaf], [leeftijd_tot_en_met]) VALUES (3, N'lagereSchool1', 7, 9)
INSERT [dbo].[tbl_Cursustypes] ([id], [naam], [leeftijd_vanaf], [leeftijd_tot_en_met]) VALUES (4, N'vrouwen', 16, 99)
SET IDENTITY_INSERT [dbo].[tbl_Cursustypes] OFF
/****** Object:  Table [dbo].[tbl_Cursussen]    Script Date: 01/18/2016 21:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Cursussen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cursustypeID] [int] NOT NULL,
	[datum_van] [date] NOT NULL,
	[datum_tot] [date] NOT NULL,
	[startuur] [int] NOT NULL,
	[einduur] [int] NOT NULL,
	[locatieID] [int] NOT NULL,
	[max_deelnemers] [int] NOT NULL,
	[kostprijs] [int] NOT NULL,
	[omschrijving] [nvarchar](500) NOT NULL,
	[naam] [nvarchar](100) NULL,
 CONSTRAINT [PK_tbl_Cursussen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Cursussen] ON
INSERT [dbo].[tbl_Cursussen] ([id], [cursustypeID], [datum_van], [datum_tot], [startuur], [einduur], [locatieID], [max_deelnemers], [kostprijs], [omschrijving], [naam]) VALUES (1, 1, CAST(0xEC3A0B00 AS Date), CAST(0xF03A0B00 AS Date), 1900, 2100, 1, 20, 5, N'eerste cursus', N'kleuterlesjes januari')
INSERT [dbo].[tbl_Cursussen] ([id], [cursustypeID], [datum_van], [datum_tot], [startuur], [einduur], [locatieID], [max_deelnemers], [kostprijs], [omschrijving], [naam]) VALUES (2, 3, CAST(0x0E3B0B00 AS Date), CAST(0x133B0B00 AS Date), 1200, 1300, 2, 5, 3, N'tweede cursus', N'lesjes voor de lagere school')
INSERT [dbo].[tbl_Cursussen] ([id], [cursustypeID], [datum_van], [datum_tot], [startuur], [einduur], [locatieID], [max_deelnemers], [kostprijs], [omschrijving], [naam]) VALUES (3, 4, CAST(0x0E3B0B00 AS Date), CAST(0x163B0B00 AS Date), 1500, 1830, 1, 10, 10, N'derde cursus', N'for the females aaight')
INSERT [dbo].[tbl_Cursussen] ([id], [cursustypeID], [datum_van], [datum_tot], [startuur], [einduur], [locatieID], [max_deelnemers], [kostprijs], [omschrijving], [naam]) VALUES (4, 1, CAST(0x00000000 AS Date), CAST(0x00000000 AS Date), 1500, 1800, 1, 15, 0, N'test van DAC', N'test van dacia logan')
INSERT [dbo].[tbl_Cursussen] ([id], [cursustypeID], [datum_van], [datum_tot], [startuur], [einduur], [locatieID], [max_deelnemers], [kostprijs], [omschrijving], [naam]) VALUES (5, 1, CAST(0x00000000 AS Date), CAST(0x00000000 AS Date), 1500, 1800, 1, 15, 0, N'test van DAC', N'test van dacia logan')
INSERT [dbo].[tbl_Cursussen] ([id], [cursustypeID], [datum_van], [datum_tot], [startuur], [einduur], [locatieID], [max_deelnemers], [kostprijs], [omschrijving], [naam]) VALUES (6, 1, CAST(0x00000000 AS Date), CAST(0x00000000 AS Date), 1500, 1800, 1, 15, 0, N'test van DAC', N'test van dacia logan')
SET IDENTITY_INSERT [dbo].[tbl_Cursussen] OFF
/****** Object:  StoredProcedure [dbo].[userProfile_select]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[userProfile_select]
	  @id int
AS
	select	id, naam, voornaam, straat, nummer, postcode, plaats,
			telefoonnummer, emailadres, [login], paswoord, isAdmin
	from	tbl_Profielen
	where	id = @id;
GO
/****** Object:  StoredProcedure [dbo].[userProfile_insert]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[userProfile_insert]
	@name nvarchar(50),
	@firstName nvarchar(50),
	@street nvarchar(50),
	@number int,
	@postalCode nvarchar(50),
	@place nvarchar(50),
	@phone nvarchar(50),
	@emailAddress nvarchar(50),
	@userName nvarchar(50),
	@passwordHash nvarchar(50),
	@isAdmin bit
	  
AS
	insert into	tbl_Profielen
				(naam, voornaam, straat, nummer, postcode, plaats, telefoonnummer,
				 emailadres, [login], paswoord, isAdmin)
	values		(@name, 
				 @firstName,
				 @street,
				 @number,
				 @postalCode,
				 @place,
				 @phone,
				 @emailAddress,
				 @userName,
				 @passwordHash,
				 @isAdmin);			
				
	return SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[userProfile_delete]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[userProfile_delete]
	  @id int
AS
	delete
	from	tbl_Profielen
	where	id = @id;
				
	return @@ROWCOUNT;
GO
/****** Object:  StoredProcedure [dbo].[subscription_update]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[subscription_update]
	  @id int,
	  @courseID int,
	  @childID int,
	  @hasPayed bit
AS
	update	tbl_Inschrijvingen
	set		kindID = @childID
		  , cursusID = @courseID
		  , heeftBetaald = @hasPayed
	where	id = @id;
	
	return SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[subscription_selectAllForUserProfile]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[subscription_selectAllForUserProfile]
	  @userProfileID int
AS
	select	a.id, kindID, cursusID, heeftBetaald	
	from	tbl_Inschrijvingen as a
	   join tbl_Kinderen as b
	   on	a.kindID = b.id
	   join tbl_Profielen as c
	   on	b.profielID = c.id
	where	c.id = @userProfileID;
GO
/****** Object:  StoredProcedure [dbo].[subscription_selectAllForCourse]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[subscription_selectAllForCourse]
	  @courseID int
AS
	select	id
	from	tbl_Inschrijvingen
	where	cursusID = @courseID;
GO
/****** Object:  StoredProcedure [dbo].[subscription_select]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[subscription_select]
	  @id int
AS
	select	id, kindID, cursusID, heeftBetaald	
	from	tbl_Inschrijvingen
	where	id = @id;
GO
/****** Object:  StoredProcedure [dbo].[subscription_insert]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[subscription_insert]
	  @courseID int,
	  @childID int,
	  @hasPayed bit
AS
	insert into	tbl_Inschrijvingen
				(kindID, cursusID, heeftBetaald)
	values		(@childID, @courseID, @hasPayed);
				
	return SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[subscription_delete]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[subscription_delete]
	  @id int
AS
	delete
	from	tbl_Inschrijvingen
	where	id = @id;
				
	return @@ROWCOUNT;
GO
/****** Object:  StoredProcedure [dbo].[location_select]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[location_select]
	  @id int
AS
	select	id, straat, nummer, postcode, plaats, naam,
			telefoonnummer, emailadres, foto_link
	from	tbl_Locaties
	where	id = @id;
GO
/****** Object:  StoredProcedure [dbo].[courseType_select]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[courseType_select]
	  @id int
AS
	select	id, naam, leeftijd_vanaf, leeftijd_tot_en_met 
	from	tbl_Cursustypes
	where	id = @id;
GO
/****** Object:  StoredProcedure [dbo].[course_update]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dennis Bellinkx
-- Create date: 2015-11-29
-- Description:	update course
-- =============================================
create PROCEDURE [dbo].[course_update]
	  @courseTypeID int
	, @startDate date
	, @endDateInclusive date
	, @startHour int
	, @endHour int
	, @locationID int
	, @maxSubscriptions int
	, @price int
	, @description nvarchar(500)
	, @name nvarchar(100)

AS
	update	tbl_Cursussen
	set		cursustypeID = @courseTypeID, datum_van = @startDate, datum_tot = @endDateInclusive, 
			startuur = @startHour, einduur = @endHour, locatieID = @locationID, max_deelnemers = @maxSubscriptions, 
			kostprijs = @price, omschrijving = @description, naam = @name;
	
	return @@ROWCOUNT;
GO
/****** Object:  StoredProcedure [dbo].[course_selectAll]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[course_selectAll]
AS
	select	*
	from	tbl_Cursussen;
GO
/****** Object:  StoredProcedure [dbo].[course_select]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[course_select]
	@id int
AS
	select	*
	from	tbl_Cursussen
	where	id = @id;
GO
/****** Object:  StoredProcedure [dbo].[course_insert]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dennis Bellinkx
-- Create date: 2015-11-29
-- Description:	Creates new course
-- =============================================
create PROCEDURE [dbo].[course_insert]
	  @courseTypeID int
	, @startDate date
	, @endDateInclusive date
	, @startHour int
	, @endHour int
	, @locationID int
	, @maxSubscriptions int
	, @price int
	, @description nvarchar(500)
	, @name nvarchar(100)
AS
	insert into	tbl_Cursussen
				(cursustypeID, datum_van, datum_tot, startuur
				, einduur, locatieID, max_deelnemers, kostprijs, omschrijving, naam)
	values		(@courseTypeID, @startDate, @endDateInclusive, @startHour
				, @endHour, @locationID, @maxSubscriptions, @price, @description, @name);
				
	return SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[course_delete]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Dennis Bellinkx
-- Create date: 2015-11-29
-- Description:	delete course
-- =============================================
create PROCEDURE [dbo].[course_delete]
	  @id int
AS
	delete from	tbl_Cursussen
	where		id = @id;
	
	return @@ROWCOUNT;
GO
/****** Object:  StoredProcedure [dbo].[child_update]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[child_update]
	  @id int,
	  @name nvarchar(50),
	  @firstName nvarchar(50),
	  @dateOfBirth datetime,
	  @userProfileID int
AS
	update	tbl_Kinderen
	set		voornaam = @firstName,
			achternaam = @name,
			geboortedatum = @dateOfBirth,
			profielID = @userProfileID
	where	id = @id;
	
	return SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[child_selectAllForUserProfile]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[child_selectAllForUserProfile]
	  @userProfileID int
AS
	select	id
	from	tbl_Kinderen
	where	profielID = @userProfileID;
GO
/****** Object:  StoredProcedure [dbo].[child_select]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[child_select]
	  @id int
AS
	select	id, voornaam, achternaam, geboorteDatum, profielID	
	from	tbl_Kinderen
	where	id = @id;
GO
/****** Object:  StoredProcedure [dbo].[child_insert]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[child_insert]
	  @name nvarchar(50),
	  @firstName nvarchar(50),
	  @dateOfBirth datetime,
	  @userProfileID int
AS
	insert into	tbl_Kinderen
				(achternaam, voornaam, geboortedatum, profielID)
	values		(@name, @firstName, @dateOfBirth, @userProfileID);
				
	return SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[child_delete]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[child_delete]
	  @id int
AS
	delete
	from	tbl_Kinderen
	where	id = @id;
	
	return @@rowcount;
GO
/****** Object:  StoredProcedure [dbo].[checkLogin]    Script Date: 01/18/2016 21:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===========================================================
-- Author:		Dennis Bellinkx
-- Create date: 2015-12-24
-- Description:	Checks if a login/password combination exists
-- ===========================================================
CREATE PROCEDURE [dbo].[checkLogin]
	@login nvarchar(50)
  , @password nvarchar(50)
 AS
	select	id
	from	tbl_Profielen
	where	login = @login
	    and paswoord = @password
GO
