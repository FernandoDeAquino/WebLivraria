CREATE PROCEDURE [dbo].[UP_LISTA_ASSUNTO_OBTER]
	  AS SELECT CodAs, Descricao FROM[dbo].[assunto]
	  ORDER BY Descricao
RETURN 0