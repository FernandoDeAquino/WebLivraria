using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using WebLivraria.Controller;

namespace WebLivraria.Business
{
    public class ManterLivro
    {
        //public ManterLivro(object p)
        //{

        //}

        public List<livro> ObterLivros()
        {
            DataTable dt = new DataTable();
            List<livro> lista = new List<livro>();
            SqlServerHelper sql = SqlServerHelper.New;

            try 
            {
                SqlCommand comando = sql.CreateCommand();
                comando.CommandText = "USP_VW_LIVROS_ATUALIZA";
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        lista.Add(ObterLivroDeDataRow(new livro(), reg));
                    }
                }else
                {
                    return null;
                }
            }
            catch(Exception excecao)
            {
                throw excecao;
            }
            finally
            {
                sql.CloseConnection();
            }

           return lista;

        }
 
        public List<livro> ObterLivrosPorAssunto()
        {
            DataTable dt = new DataTable();
            List<livro> listaLA = new List<livro>();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Obtem a lista de livros por assunto
                comando.CommandText = "USP_LISTA_LIVROS_POR_ASSUNTO";
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        listaLA.Add(ObterLivroDeDataRow(new livro(), reg));
                    }
                }
                else
                {
                    return null;
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
            return listaLA;
 
        }

        public DataTable ObterLivrosPorAssuntos()
        {
            DataTable dtResultado = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                comando.CommandText = "USP_LISTA_LIVROS_POR_ASSUNTO";
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dtResultado);
            }
            catch (Exception excecao)
            {
                throw excecao;
            }
            finally
            {
                sql.CloseConnection();
            }
            return dtResultado;

        }

        public livro ObterLivroDeDataRow(livro Livro, DataRow registro)
        {
            try
            {
                Livro.CodigoLivro = int.Parse(registro["CODL"].ToString());

                if (Convert.IsDBNull(registro["TITULO"]))
                {
                    Livro.TitLivro = String.Empty;
                }
                else
                {
                    Livro.TitLivro = registro["TITULO"].ToString();
                }

                Livro.EditaLivro = registro["EDITORA"].ToString();
                Livro.EdicaoLivro = int.Parse(registro["EDICAO"].ToString());
                Livro.AssuntoLivro = registro["ASSUNTO"].ToString();
                Livro.AutorLivro = registro["AUTOR"].ToString();
                Livro.AnoPublicacao = registro["ANOPUBLICACAO"].ToString();
                if(registro["PRECO"].ToString() != string.Empty)
                {
                   Livro.PrecoLivro = decimal.Parse(registro["PRECO"].ToString());
                }
                
            }
            catch(Exception excecao)
            {
                throw excecao;
            }

            return Livro;
        }

        public void InserirLivro(livro livro)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Inclusão na tabela livro
                comando.CommandText = "USP_VW_LIVRO_INCLUIR";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pTitulo", SqlDbType.VarChar);
                comando.Parameters.Add("@pEditora", SqlDbType.VarChar);
                comando.Parameters.Add("@pEdicao", SqlDbType.Int);
                comando.Parameters.Add("@pAnoPublicacao", SqlDbType.VarChar);
                comando.Parameters.Add("@pPreco", SqlDbType.Money);

                comando.Parameters["@pTitulo"].Value = livro.TitLivro.ToUpper();
                comando.Parameters["@pEditora"].Value = livro.EditaLivro;
                comando.Parameters["@pEdicao"].Value = livro.EdicaoLivro;
                comando.Parameters["@pAnoPublicacao"].Value = livro.AnoPublicacao;
                comando.Parameters["@pPreco"].Value = livro.PrecoLivro;
                SqlDataAdapter adapterLivro = new SqlDataAdapter(comando);
                adapterLivro.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    livro.CodigoLivro = Convert.ToInt32(dt.Rows[0]["CODL"].ToString());
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

        public void ExcluirLivro(Int32 codigo)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                //Exclusãona tabela livro(Deleção em 'cascade' das tabelas livro_autor e livro_assunto)
                comando.CommandText = "USP_VW_LIVRO_EXCLUIR";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pCodLivro", SqlDbType.Int);
                comando.Parameters["@pCodLivro"].Value = codigo;

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

        public void AtualizaLivro(livro livro)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                //Update da tabela livro
                comando.CommandText = "USP_VW_LIVRO_ATUALIZA";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pCodLivro", SqlDbType.VarChar);
                comando.Parameters.Add("@pTitulo", SqlDbType.VarChar);
                comando.Parameters.Add("@pEditora", SqlDbType.VarChar);
                comando.Parameters.Add("@pEdicao", SqlDbType.Int);
                comando.Parameters.Add("@pAnoPublicacao", SqlDbType.VarChar);
                comando.Parameters.Add("@pPreco", SqlDbType.Money);

                comando.Parameters["@pCodLivro"].Value = livro.CodigoLivro;
                comando.Parameters["@pTitulo"].Value = livro.TitLivro.ToUpper();
                comando.Parameters["@pEditora"].Value = livro.EditaLivro;
                comando.Parameters["@pEdicao"].Value = livro.EdicaoLivro;
                comando.Parameters["@pAnoPublicacao"].Value = livro.AnoPublicacao;
                comando.Parameters["@pPreco"].Value = livro.PrecoLivro;

                SqlDataAdapter adapterLivro = new SqlDataAdapter(comando);
                adapterLivro.Fill(dt);

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