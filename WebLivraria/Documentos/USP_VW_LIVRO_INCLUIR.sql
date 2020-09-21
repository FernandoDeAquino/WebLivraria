CREATE PROCEDURE [dbo].[USP_VW_LIVRO_INCLUIR]
	-- Add os parâmetros da stored procedure
	@pTitulo VARCHAR(40),
	@pEditora VARCHAR(40),
    @pEdicao  INT,
    @pAnoPublicacao VARCHAR(4),
	@pPreco MONEY
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[LIVRO](TITULO, EDITORA, EDICAO, ANOPUBLICACAO, PRECO)
	VALUES(@pTitulo,@pEditora,@pEdicao,@pAnoPublicacao, @pPreco)
	
	SELECT * FROM [dbo].[livro]
	WHERE (TITULO = @pTitulo AND EDITORA = @pEditora
		AND EDICAO = @pEdicao AND ANOPUBLICACAO = @pAnoPublicacao AND PRECO = @pPreco)

END