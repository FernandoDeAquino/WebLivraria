CREATE PROCEDURE [dbo].[USP_VW_AUTOR_ATUALIZA]
	-- Add os parâmetros da stored procedure
	@pCodAutor INT,
	@pNome VARCHAR(40)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[autor]
	SET Nome = @pNome
	WHERE CodAu = @pCodAutor

	SELECT * FROM [dbo].[autor]
END