CREATE PROCEDURE [dbo].[USP_LISTA_DE_AUTORES_OBTER]
	--Seleciona as tabelas para consulta do relacionmento entre livros e autores
	AS 
	SELECT li.Codl, li.Titulo, li.Editora, a.Nome as 'Autor'
	FROM [dbo].[livro_autor] AS la 
	INNER JOIN [dbo].[livro] AS li on la.livro_Codl = li.Codl
	INNER JOIN [dbo].[autor] AS a on la.autor_CodAu = a.CodAu