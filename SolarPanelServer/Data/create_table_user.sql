USE [SolarPanel]
GO

/****** Object:  Table [dbo].[USER]    Script Date: 2023. 02. 20. 19:18:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USER](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](30) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[role] [int] NOT NULL,
	[row_updated] [datetime] NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

