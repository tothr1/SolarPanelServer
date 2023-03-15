USE [SolarPanel]
GO

/****** Object:  Table [dbo].[Components]    Script Date: 2023. 03. 15. 10:55:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Components](
	[component_id] [int] IDENTITY(1,1) NOT NULL,
	[material] [nvarchar](30) NOT NULL,
	[shelf] [nvarchar](20) NOT NULL,
	[project] [int] NULL,
	[row_updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED 
(
	[component_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


