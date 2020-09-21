CREATE PROCEDURE [dbo].[USP_VW_LIVRO_AUTOR_INCLUIR]
	-- Add os parâmetros da stored procedure
	@pcodLivro int,
	@pcodAutor int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[livro_autor](livro_Codl, autor_CodAu)
	VALUES(@pcodLivro, @pcodAutor)
	
	SELECT * FROM [dbo].[livro_autor]
END