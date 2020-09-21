CREATE PROCEDURE [dbo].[USP_VW_AUTOR_EXCLUIR]
	-- Add os parâmetros da stored procedure
	@pCodAutor INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[autor]
	WHERE CodAu = @pCodAutor

	SELECT * FROM [dbo].[autor] WHERE CodAu = @pCodAutor
END