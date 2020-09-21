CREATE PROCEDURE [dbo].[USP_VW_LIVRO_ASSUNTO_EXCLUIR]
	-- Add os parâmetros da stored procedure
	@pcodLivro int,
	@pcodAssunto int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[livro_assunto]
	WHERE livro_Codl = @pcodLivro AND assunto_CodAs = @pcodAssunto
	
	
END