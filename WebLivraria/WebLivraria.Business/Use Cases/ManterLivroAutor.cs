using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using WebLivraria.Controller;

namespace WebLivraria.Business
{
    public class ManterLivroAutor
    {
        public bool autorEncontrado = false;

        public void InserirLivroAutor(livroAutores livroAutor)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Inclusão na tabela livro_autor
                comando.CommandText = "USP_VW_LIVRO_AUTOR_INCLUIR";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pCodLivro", SqlDbType.Int);
                comando.Parameters.Add("@pCodAutor", SqlDbType.Int);
                comando.Parameters["@pCodLivro"].Value = livroAutor.CodDoLivro_Autor;
                comando.Parameters["@pCodAutor"].Value = livroAutor.CodDoAutor;

                SqlDataAdapter adapterAutor = new SqlDataAdapter(comando);
                adapterAutor.Fill(dt);

            }
            catch (Exception excecao)
            {
                throw excecao;
            }
            finally
            {
                sql.CloseConnection();
            }
        }

        public void ExcluirLivroAutor(livroAutores livroAutor)
    {
        DataTable dt = new DataTable();
        SqlServerHelper sql = SqlServerHelper.New;

        try
        {
            SqlCommand comando = sql.CreateCommand();
            // Exclusão da tabela livro_autor (Modificado. Faço a deleção por 'CASCADE')
            comando.CommandText = "USP_VW_LIVRO_AUTOR_EXCLUIR";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@pCodLivro", SqlDbType.Int);
            comando.Parameters.Add("#pCodAutor", SqlDbType.Int);
            comando.Parameters["@pCodLivro"].Value = livroAutor.CodDoLivro_Autor;
            comando.Parameters["@pCodAutor"].Value = livroAutor.CodDoAutor;

            comando.ExecuteNonQuery();
        }
        catch (Exception excecao)
        {
            throw excecao;
        }
        finally
        {
            sql.CloseConnection();
        }
    }

        public void AtualizarLivroAutor(livroAutores livroAutor)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                
                // Update na tabela Livro_Autor
                comando.CommandText = "UP_LIVRO_AUTOR_ATUALIZA";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pCodLivro", SqlDbType.Int);
                comando.Parameters.Add("@pCodAutor", SqlDbType.Int);
                comando.Parameters["@pCodLivro"].Value = livroAutor.CodDoLivro_Autor;
                comando.Parameters["@pCodAutor"].Value = livroAutor.CodDoAutor;
                SqlDataAdapter adapterAutor = new SqlDataAdapter(comando);
                adapterAutor.Fill(dt);

            }
            catch (Exception excecao)
            {
                throw excecao;
            }
            finally
            {
                sql.CloseConnection();
            }
        }

        public void ObterAutorDeLivros(int CodAutor)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;
            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Busca por autor de livros.
                comando.CommandText = "USP_AUTOR_LIVRO_OBTER";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pCodAutor", SqlDbType.Int);
                comando.Parameters["@pCodAutor"].Value = CodAutor;

                SqlDataAdapter adapterAutor = new SqlDataAdapter(comando);
                adapterAutor.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    autorEncontrado = true;
                }
            }
            catch (Exception excecao)
            {
                throw excecao;
            }
            finally
            {
                sql.CloseConnection();
            }
        }

    }

}