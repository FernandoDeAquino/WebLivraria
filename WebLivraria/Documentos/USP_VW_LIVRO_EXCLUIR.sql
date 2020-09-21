CREATE PROCEDURE [dbo].[USP_VW_LIVRO_EXCLUIR]
	-- Add os parâmetros da stored procedure
	@pCodLivro INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[livro]
	WHERE Codl = @pCodLivro

	SELECT * FROM [dbo].[livro] WHERE Codl = @pCodLivro
END