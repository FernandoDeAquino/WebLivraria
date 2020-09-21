CREATE PROCEDURE [dbo].[USP_VW_AUTOR_INCLUIR]
	-- Add os parâmetros da stored procedure
	@pNome VARCHAR(40)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[AUTOR](NOME)
	VALUES(@pNome)
	
	SELECT * FROM [dbo].[autor]
END