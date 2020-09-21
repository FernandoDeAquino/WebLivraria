CREATE VIEW [dbo].[USP_LISTA_LIVROS_OBTER]
    AS SELECT * FROM[dbo].[livro]

CREATE PROCEDURE [dbo].[USP_VW_LIVRO_INCLUIR]
	-- Add os parâmetros da stored procedure
	@pTitulo VARCHAR(40),
	@pEditora VARCHAR(40),
    @pEdicao  INT,
    @pAnoPublicacao VARCHAR(4)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[LIVRO](TITULO, EDITORA, EDICAO, ANOPUBLICACAO)
	VALUES(@pTitulo,@pEditora,@pEdicao,@pAnoPublicacao)
	
	SELECT * FROM [dbo].[livro]
END
GO

CREATE PROCEDURE [dbo].[USP_VW_LIVRO_ATUALIZA]
	-- Add os parâmetros da stored procedure
	@pCodLivro INT,
	@pTitulo VARCHAR(40),
	@pEditora VARCHAR(40),
    @pEdicao  INT,
    @pAnoPublicacao VARCHAR(4)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[livro]
	SET Titulo = @pTitulo, Editora = @pEditora, Edicao = @pEdicao , AnoPublicacao = @pAnoPublicacao
	WHERE Codl = @pCodLivro

	SELECT * FROM [dbo].[livro]
END
GO

CREATE PROCEDURE [dbo].[USP_VW_LIVRO_EXCLUIR]
	-- Add os parâmetros da stored procedure
	@pCodLivro INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[livro]
	WHERE Codl = @pCodLivro

	SELECT * FROM [dbo].[livro] WHERE Codl = @pCodLivro
END
GO