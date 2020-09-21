CREATE PROCEDURE [dbo].[USP_AUTOR_OBTER]
	@pNome varchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CodAu,Nome FROM[dbo].[autor]
	WHERE Nome = @pNome
END