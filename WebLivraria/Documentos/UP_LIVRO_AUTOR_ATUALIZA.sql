CREATE PROCEDURE [dbo].[UP_LIVRO_AUTOR_ATUALIZA]
	-- Add os parâmetros da stored procedure
	@pcodLivro int,
	@pcodAutor int
AS
BEGIN

	SET NOCOUNT ON;
	UPDATE [dbo].[livro_autor]
	SET autor_CodAu = @pcodAutor
	WHERE livro_Codl = @pcodLivro

	SELECT * FROM [dbo].[livro_autor]
END