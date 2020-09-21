CREATE PROCEDURE [dbo].[UP_LIVRO_ASSUNTO_ATUALIZA]
	-- Add os parâmetros da stored procedure
	@pcodLivro int,
	@pcodAssunto int
AS
BEGIN

	SET NOCOUNT ON;
	UPDATE [dbo].[livro_assunto]
	SET assunto_CodAs = @pcodAssunto
	WHERE livro_Codl = @pcodLivro 

	SELECT * FROM [dbo].[livro_assunto]
END