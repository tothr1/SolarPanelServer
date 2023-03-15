USE [SolarPanel]
GO

/****** Object:  Table [dbo].[ProjectHistory]    Script Date: 2023. 03. 15. 10:55:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProjectHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[project] [int] NOT NULL,
	[status] [nvarchar](20) NOT NULL,
	[row_updated] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectHistory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


