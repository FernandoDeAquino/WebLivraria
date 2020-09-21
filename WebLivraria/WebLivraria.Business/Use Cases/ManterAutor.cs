using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebLivraria.Controller;

namespace WebLivraria.Business
{
    /* Tratamento da tabela de autor */
    public class ManterAutor
    {
        public List<autor> ObterListaAutores()
        {
            DataTable dt = new DataTable();
            List<autor> lista = new List<autor>();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                // Selecionar a lista de autores cadastrados
                SqlCommand comando = sql.CreateCommand();
                comando.CommandText = "UP_LISTA_AUTOR_OBTER";
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        lista.Add(ObterAutorDeDataRow(new autor(), reg));
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

            return lista;

        }
        public autor ObterAutor(String NmAutor)
        {
            DataTable dt = new DataTable();
            autor autor = new autor();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Pesquisa autor expecífico pelo nome
                comando.CommandText = "USP_AUTOR_OBTER";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pNOME", SqlDbType.VarChar);
                comando.Parameters["@pNOME"].Value = NmAutor;

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    autor.CodigoAutor = Convert.ToInt32(dt.Rows[0][0].ToString());

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

            return autor;

        }

        public autor ObterAutorDeDataRow(autor Autor, DataRow registro)
        {
            try
            {
                Autor.CodigoAutor = int.Parse(registro["CODAU"].ToString());

                if (Convert.IsDBNull(registro["NOME"]))
                {
                    Autor.NomeAutor = String.Empty;
                }
                else
                {
                    Autor.NomeAutor = registro["NOME"].ToString();
                }
            }
            catch
            {
                Autor = null;
            }

            return Autor;
        }

        public List<TipoAutor> ObterListaDeAutores()
        {
            DataTable dt = new DataTable();
            List<TipoAutor> lista = new List<TipoAutor>();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                comando.CommandText = "UP_LISTA_AUTOR_OBTER";
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        lista.Add(ObterListaAutorDataRow(new TipoAutor(), reg));
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

            return lista;
        }

        public TipoAutor ObterListaAutorDataRow(TipoAutor autor, DataRow registro)
        {
            try
            {
                autor.TipSqAutor = int.Parse(registro["codAu"].ToString());
                autor.TipDsAutor = registro["Nome"].ToString();
            }
            catch
            {
                autor = null;
            }

            return autor;
        }
        public void InserirAutor(autor Autor)
        {

            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Inclusão de autor
                comando.CommandText = "USP_VW_AUTOR_INCLUIR";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pNome", SqlDbType.VarChar);
                comando.Parameters["@pNome"].Value = Autor.NomeAutor.ToUpper();

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

        public void ExcluirAutor(Int32 codigo)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Exclusão de autor
                comando.CommandText = "USP_VW_AUTOR_EXCLUIR";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pCodAutor", SqlDbType.Int);
                comando.Parameters["@pCodAutor"].Value = codigo;

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

        public void AtualizaAutor(autor Autor)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Atualiza o cadastro de autor
                comando.CommandText = "USP_VW_AUTOR_ATUALIZA";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pNome", SqlDbType.VarChar);
                comando.Parameters["@pNome"].Value = Autor.NomeAutor;
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

    }
}