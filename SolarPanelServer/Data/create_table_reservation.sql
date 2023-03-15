USE [SolarPanel]
GO

/****** Object:  Table [dbo].[Reservations]    Script Date: 2023. 03. 15. 10:56:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reservations](
	[reservation_id] [int] IDENTITY(1,1) NOT NULL,
	[material] [nvarchar](30) NOT NULL,
	[count] [int] NOT NULL,
	[project] [int] NOT NULL,
	[user] [nvarchar](30) NOT NULL,
	[row_updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[reservation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


