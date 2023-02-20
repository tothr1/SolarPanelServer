USE [SolarPanel]
GO

/****** Object:  Table [dbo].[MATERIAL]    Script Date: 2023. 02. 20. 19:17:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MATERIAL](
	[material_id] [int] IDENTITY(1,1) NOT NULL,
	[material_name] [nvarchar](30) NOT NULL,
	[shelf_limit] [int] NOT NULL,
	[price] [int] NOT NULL,
	[row_updated] [datetime] NOT NULL,
 CONSTRAINT [PK_MATERIAL] PRIMARY KEY CLUSTERED 
(
	[material_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

