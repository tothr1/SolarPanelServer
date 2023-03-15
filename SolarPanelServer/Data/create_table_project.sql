USE [SolarPanel]
GO

/****** Object:  Table [dbo].[Projects]    Script Date: 2023. 03. 15. 10:56:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Projects](
	[project_id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[deadline] [date] NULL,
	[fee] [int] NULL,
	[status] [nvarchar](20) NOT NULL,
	[owner] [nvarchar](30) NOT NULL,
	[row_updated] [datetime] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


