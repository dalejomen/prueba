USE [DWH_IBERO]
GO

/****** Object:  Table [dbo].[Prueba_Entidades]    Script Date: 1/09/2024 1:53:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Prueba_Entidades](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NULL,
 CONSTRAINT [PK_Prueba_Entidades] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


