-- Author:		Fernando Aquino
-- Create date: 04/09/2020
-- Description:	Busca os autores e suas obras
-- =============================================
CREATE PROCEDURE [dbo].[USP_LISTA_AUTORES_OBTER]
	-- Add the parameters for the stored procedure here
	@pCodigoLivro int,
	@pTitulo varchar(40),
	@pEditora varchar(40),
	@pNomeAutor varchar(40)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT l.Codl, l.Titulo, l.Editora, a.Nome as 'Autor'
	FROM livro_autor AS la 
	INNER JOIN LIVRO l on la.livro_Codl = l.Codl
	INNER JOIN AUTOR a on la.autor_CodAu = a.CodAu
	ORDER BY la.livro_Codl
	
END
GO
