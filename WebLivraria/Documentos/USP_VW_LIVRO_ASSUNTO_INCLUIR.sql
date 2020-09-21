CREATE PROCEDURE [dbo].[USP_VW_LIVRO_ASSUNTO_INCLUIR]
	-- Add os parâmetros da stored procedure
	@pcodLivro int,
	@pcodAssunto int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[livro_assunto](livro_Codl, assunto_CodAs)
	VALUES(@pcodLivro, @pcodAssunto)
	
	SELECT * FROM [dbo].[livro_assunto]
END