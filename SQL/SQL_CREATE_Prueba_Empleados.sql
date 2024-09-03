USE [DWH_IBERO]
GO

/****** Object:  Table [dbo].[Prueba_Empleados]    Script Date: 1/09/2024 1:54:47 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Prueba_Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NULL,
	[Documento] [nvarchar](50) NULL,
	[Id_Entidad] [int] NOT NULL,
 CONSTRAINT [PK_Prueba_Empleados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Prueba_Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Prueba_Empleados_Prueba_Entidades] FOREIGN KEY([Id_Entidad])
REFERENCES [dbo].[Prueba_Entidades] ([ID])
GO

ALTER TABLE [dbo].[Prueba_Empleados] CHECK CONSTRAINT [FK_Prueba_Empleados_Prueba_Entidades]
GO


