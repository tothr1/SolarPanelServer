USE [SolarPanel]
GO

/****** Object:  Table [dbo].[SHELF]    Script Date: 2023. 02. 20. 19:18:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SHELF](
	[shelf_id] [int] IDENTITY(1,1) NOT NULL,
	[shelf_name] [nvarchar](20) NOT NULL,
	[part_count] [int] NOT NULL,
	[row_updated] [datetime] NOT NULL,
 CONSTRAINT [PK_SHELF] PRIMARY KEY CLUSTERED 
(
	[shelf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

