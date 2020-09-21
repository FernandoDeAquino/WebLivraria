CREATE PROCEDURE [dbo].[USP_VW_ASSUNTO_ATUALIZA]
	-- Add os parâmetros da stored procedure
	@pCodAssunto INT,
	@pDescricao VARCHAR(40)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[assunto]
	SET Descricao = @pDescricao
	WHERE CodAs = @pCodAssunto

	SELECT * FROM [dbo].[assunto]
END