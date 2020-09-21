using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using WebLivraria.Controller;

namespace WebLivraria.Business
{
    public class ManterLivroAssunto
    {

        public bool assuntoEncontrado = false;
        public void InserirLivroAssunto(livroAssunto livroassunto)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Inclusão na tabela Livro_Assunto
                comando.CommandText = "USP_VW_LIVRO_ASSUNTO_INCLUIR";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pcodLivro", SqlDbType.Int);
                comando.Parameters.Add("@pcodAssunto", SqlDbType.Int);
                comando.Parameters["@pcodLivro"].Value = livroassunto.CodDoLivro_Assunto;
                comando.Parameters["@pcodAssunto"].Value = livroassunto.CodDoAssunto;

                SqlDataAdapter adapterLivroAssunto = new SqlDataAdapter(comando);
                adapterLivroAssunto.Fill(dt);

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

        public void ExcluirLivroAssunto(livroAssunto livroAssunto)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                //Exclusão na tabela livro assunto (Modificado. Faço a deleção por 'CASCADE')
                comando.CommandText = "USP_VW_LIVRO_ASSUNTO_EXCLUIR";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pCodLivro", SqlDbType.Int);
                comando.Parameters.Add("#pCodAssunto", SqlDbType.Int);
                comando.Parameters["@pCodLivro"].Value = livroAssunto.CodDoLivro_Assunto;
                comando.Parameters["@pCodAssunto"].Value = livroAssunto.CodDoAssunto;

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

        public void AtualizaLivroAssunto(livroAssunto livroassunto)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                // Update no assunto cadastrado
                SqlCommand comando = sql.CreateCommand();

                comando.CommandText = "UP_LIVRO_ASSUNTO_ATUALIZA";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pcodLivro", SqlDbType.Int);
                comando.Parameters.Add("@pcodAssunto", SqlDbType.Int);
                comando.Parameters["@pcodLivro"].Value = livroassunto.CodDoLivro_Assunto;
                comando.Parameters["@pcodAssunto"].Value = livroassunto.CodDoAssunto;
                SqlDataAdapter adapterLivroAssunto = new SqlDataAdapter(comando);
                adapterLivroAssunto.Fill(dt);

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

        public void ObterAssuntoNosLivros(int CodAssunto)
        {
            DataTable dt = new DataTable();
            livroAssunto varLivroAssunto = new livroAssunto();
            SqlServerHelper sql = SqlServerHelper.New;
            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Pesquisa se existe um assunto ligado a livros, antes da deleção do assunto
                comando.CommandText = "USP_ASSUNTO_LIVRO_OBTER";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pCodAssunto", SqlDbType.Int);
                comando.Parameters["@pCodAssunto"].Value = CodAssunto;

                SqlDataAdapter adapterAutor = new SqlDataAdapter(comando);
                adapterAutor.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    assuntoEncontrado = true;
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