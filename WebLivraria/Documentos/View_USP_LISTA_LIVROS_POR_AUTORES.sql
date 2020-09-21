CREATE VIEW [dbo].[USP_LISTA_LIVROS_POR_AUTORES]
	-- Lista de livros por assunto. Utilizada para o relatório de Crystal Reports
	AS SELECT la.autor_CodAu, au.Nome AS "Autor", l.Codl AS "Cód_Livro", l.Titulo AS "Título", ass.Descricao AS "Descrição", l.Editora, l.Edicao,l.AnoPublicacao
	FROM [dbo].[livro_autor] as la
	INNER JOIN [dbo].[livro] as l on la.livro_Codl = l.Codl
	INNER JOIN [dbo].[autor] as au on la.autor_CodAu = au.CodAu
	INNER JOIN [dbo].[livro_assunto] as ls on ls.livro_Codl = l.Codl 
	INNER JOIN [dbo].[assunto] as ass on ls.assunto_CodAs = ass.CodAs