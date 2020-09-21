CREATE PROCEDURE [dbo].[UP_LISTA_AUTOR_OBTER]
     --Lista todos os autores da tabela Autor
	  AS SELECT CodAu, Nome FROM[dbo].[autor]
	  ORDER BY Nome
RETURN 0