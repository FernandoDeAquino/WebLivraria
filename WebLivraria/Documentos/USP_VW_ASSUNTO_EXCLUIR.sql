CREATE PROCEDURE [dbo].[USP_VW_ASSUNTO_EXCLUIR]
	-- Add os parâmetros da stored procedure
	@pCodAssunto INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[assunto]
	WHERE CodAs = @pCodAssunto

	SELECT * FROM [dbo].[assunto] WHERE CodAs = @pCodAssunto
END