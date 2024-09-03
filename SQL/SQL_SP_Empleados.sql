USE [DWH_IBERO]
GO

/****** Object:  StoredProcedure [dbo].[SP_Empleados]    Script Date: 1/09/2024 1:53:05 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Empleados]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  Id, Nombre, Documento, Id_Entidad
	FROM     Prueba_Empleados
END
GO


