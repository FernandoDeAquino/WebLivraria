CREATE PROCEDURE [dbo].[USP_VW_LIVRO_ATUALIZA]
	-- Add os parâmetros da stored procedure
	@pCodLivro INT,
	@pTitulo VARCHAR(40),
	@pEditora VARCHAR(40),
    @pEdicao  INT,
    @pAnoPublicacao VARCHAR(4),
	@pPreco NUMERIC(10,2)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[livro]
	SET Titulo = @pTitulo, Editora = @pEditora, Edicao = @pEdicao , AnoPublicacao = @pAnoPublicacao,Preco = @pPreco
	WHERE Codl = @pCodLivro

	SELECT * FROM [dbo].[livro]
END