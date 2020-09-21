CREATE PROCEDURE [dbo].[USP_VW_ASSUNTO_INCLUIR]
	-- Add os parâmetros da stored procedure
	@pDescricao VARCHAR(40)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[ASSUNTO](DESCRICAO)
	VALUES(@pDescricao)
	
	SELECT * FROM [dbo].[assunto]
END