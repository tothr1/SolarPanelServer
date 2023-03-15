USE [SolarPanel]
GO

/****** Object:  Table [dbo].[Shelves]    Script Date: 2023. 03. 15. 10:57:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shelves](
	[shelf_id] [int] IDENTITY(1,1) NOT NULL,
	[shelf_row] [int] NOT NULL,
	[shelf_column] [nvarchar](1) NOT NULL,
	[shelf_level] [int] NOT NULL,
	[part_count] [int] NOT NULL,
	[row_updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Shelves] PRIMARY KEY CLUSTERED 
(
	[shelf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


