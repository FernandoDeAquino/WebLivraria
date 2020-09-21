CREATE PROCEDURE [dbo].[USP_VW_LIVRO_AUTOR_EXCLUIR]
	-- Add os parâmetros da stored procedure
	@pcodLivro int,
	@pcodAutor int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[livro_autor]
	WHERE livro_Codl = @pcodLivro AND autor_CodAu = @pcodAutor
	
END