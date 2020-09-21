CREATE PROCEDURE [dbo].[USP_AUTOR_LIVRO_OBTER]
	@pCodAutor int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[livro_autor]
	WHERE autor_CodAu = @pCodAutor
END