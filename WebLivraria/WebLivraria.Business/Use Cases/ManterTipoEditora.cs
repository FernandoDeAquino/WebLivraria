using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebLivraria.Business;
using WebLivraria.Controller;

namespace WebLivraria.Business
{
    public class ManterTipoEditora
    {
        public List<TipoEditora> ObterListaDeEditoras()
        {
            DataTable dt = new DataTable();
            List<TipoEditora> lista = new List<TipoEditora>();
            SqlServerHelper sql = SqlServerHelper.New;

            try
            {
                SqlCommand comando = sql.CreateCommand();
                // Obtem a lista de editoras
                comando.CommandText = "USP_LISTA_EDITORAS";
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        lista.Add(ObterListaEditorasDataRow(new TipoEditora(), reg));
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

        public TipoEditora ObterListaEditorasDataRow(TipoEditora edita, DataRow registro)
        {
            try
            {
                //edita.TipSqLivro = int.Parse(registro["codl"].ToString());

                edita.TipDsEditora = registro["editora"].ToString();
            }
            catch
            {
                edita = null;
            }

            return edita;
        }

    }
}