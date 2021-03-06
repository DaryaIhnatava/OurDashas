USE [Jewelry]
GO
/****** Object:  User [JUser]    Script Date: 04/29/2019 2:54:45 PM ******/
CREATE USER [JUser] FOR LOGIN [JUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [JUser]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [JUser]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [JUser]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [JUser]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [JUser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [JUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [JUser]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [JUser]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [JUser]
GO
/****** Object:  Table [dbo].[UserPreferences]    Script Date: 04/29/2019 2:54:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPreferences](
	[UserId] [int] NOT NULL,
	[TimeZone] [nvarchar](100) NULL,
	[Theme] [int] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nchar](10) NULL,
 CONSTRAINT [PK_UserPreferences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/29/2019 2:54:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserPreferences] ON 

INSERT [dbo].[UserPreferences] ([UserId], [TimeZone], [Theme], [Id], [Language]) VALUES (9, N'29.04.2019 11:52:11', 2, 1, N'ru-RU     ')
SET IDENTITY_INSERT [dbo].[UserPreferences] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (1, N'Darya Ihnatava', N'darya.ignatova.99@mail.ru', N'd8578edf8458ce06fbc5bb76a58c5ca4')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (4, N'Darya', N'darya@mail.ru', N'd8578edf8458ce06fbc5bb76a58c5ca4')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (5, N'Darya Ihnatava', N'darya.ignatova@mail.ru', N'd8578edf8458ce06fbc5bb76a58c5ca4')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (6, N'Darya@qw.qw', N'qw@mail.ru', N'd8578edf8458ce06fbc5bb76a58c5ca4')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (7, N'wewe', N'we@we.we', N'd8578edf8458ce06fbc5bb76a58c5ca4')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (8, N'qaqa', N'qa@qa.qa', N'd8578edf8458ce06fbc5bb76a58c5ca4')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (9, N'rt', N'rt@rt.rt', N'd8578edf8458ce06fbc5bb76a58c5ca4')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[UserPreferences]  WITH CHECK ADD  CONSTRAINT [FK_UserPreferences_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserPreferences] CHECK CONSTRAINT [FK_UserPreferences_Users]
GO
