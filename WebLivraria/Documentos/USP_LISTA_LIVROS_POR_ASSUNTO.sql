CREATE PROCEDURE [dbo].[USP_LISTA_LIVROS_POR_ASSUNTO]
	-- Lista de livros por assunto
	AS SELECT l.Codl, l.Titulo, l.Editora, l.Edicao, a.Descricao as 'Assunto', b.Nome as 'Autor', l.AnoPublicacao,l.Preco
	FROM [dbo].[livro_assunto] AS ls 
	INNER JOIN [dbo].[livro] l on ls.livro_Codl = l.Codl
	INNER JOIN [dbo].[assunto] a on ls.assunto_CodAs = a.CodAs
	INNER JOIN [dbo].[livro_autor] AS la ON la.livro_Codl = l.Codl 
	INNER JOIN [dbo].[autor] AS b on la.autor_CodAu = b.CodAu