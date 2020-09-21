CREATE PROCEDURE [dbo].[USP_ASSUNTO_LIVRO_OBTER]
	@pCodAssunto int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[livro_assunto]
	WHERE assunto_CodAs = @pCodAssunto  
END