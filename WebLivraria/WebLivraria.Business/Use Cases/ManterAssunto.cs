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
    /*Tratamento da classe de assuntos*/
    public class ManterAssunto
    {
        public List<assunto> ObterAssunto()
        {
            DataTable dt = new DataTable();
            List<assunto> lista = new List<assunto>();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                comando.CommandText = "USP_LISTA_ASSUNTO_OBTER";
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        lista.Add(ObterAssuntoDeDataRow(new assunto(), reg));
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

        public assunto ObterAssunto(String NmAssunto)
        {
            DataTable dt = new DataTable();
            assunto assunto = new assunto();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Pesquisar um assunto específico
                comando.CommandText = "USP_ASSUNTO_OBTER";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pDESCRICAO", SqlDbType.VarChar);
                comando.Parameters["@pDESCRICAO"].Value = NmAssunto;

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    assunto.CodigoAssunto = Convert.ToInt32(dt.Rows[0][0].ToString());
                        
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

            return assunto;

        }
        public assunto ObterAssuntoDeDataRow(assunto Assunto, DataRow registro)
        {
            try
            {
                Assunto.CodigoAssunto = int.Parse(registro["CODAS"].ToString());

                if (Convert.IsDBNull(registro["DESCRICAO"]))
                {
                    Assunto.DescAssunto = String.Empty;
                }
                else
                {
                    Assunto.DescAssunto = registro["DESCRICAO"].ToString();
                }
            }
            catch
            {
                Assunto = null;
            }

            return Assunto;
        }

        public void InserirAssunto(assunto Assunto)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Inclusão de novo assunto
                comando.CommandText = "USP_VW_ASSUNTO_INCLUIR";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pDescricao", SqlDbType.VarChar);
                comando.Parameters["@pDescricao"].Value = Assunto.DescAssunto.ToUpper();

                SqlDataAdapter adapterAssunto = new SqlDataAdapter(comando);
                adapterAssunto.Fill(dt);

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

        public void ExcluirAssunto(Int32 codigo)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Exclusão de assunto
                comando.CommandText = "USP_VW_ASSUNTO_EXCLUIR";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pCodAssunto", SqlDbType.Int);
                comando.Parameters["@pCodAssunto"].Value = codigo;

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

        public void AtualizaAssunto(assunto Assunto)
        {
            DataTable dt = new DataTable();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Atualiza a tabela assunto
                comando.CommandText = "USP_VW_ASSUNTO_ATUALIZA";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pDescricao", SqlDbType.VarChar);
                comando.Parameters["@pDescricao"].Value = Assunto.DescAssunto;
                SqlDataAdapter adapterAssunto = new SqlDataAdapter(comando);
                adapterAssunto.Fill(dt);

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

        public List<TipoAssunto> ObterListaAssuntos()
        {
            DataTable dt = new DataTable();
            List<TipoAssunto> lista = new List<TipoAssunto>();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                // Selecionar a lista de assuntos cadastrados
                SqlCommand comando = sql.CreateCommand();
                comando.CommandText = "UP_LISTA_ASSUNTO_OBTER";
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        lista.Add(ObterListaAssuntosDataRow(new TipoAssunto(), reg));
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

        public TipoAssunto ObterListaAssuntosDataRow(TipoAssunto tpAssunto, DataRow registro)
        {
            try
            {
                tpAssunto.TipSqAssunto = int.Parse(registro["codAs"].ToString());
                tpAssunto.TipDsAssunto = registro["Descricao"].ToString();
            }
            catch
            {
                tpAssunto = null;
            }

            return tpAssunto;
        }

    }

}
