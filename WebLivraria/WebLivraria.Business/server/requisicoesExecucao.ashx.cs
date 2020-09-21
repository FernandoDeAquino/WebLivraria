using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebLivraria.Controller;

namespace WebLivraria.Business
{
    /// <summary>
    /// Descrição resumida de requisicoesExecucao
    /// </summary>
    public class requisicoesExecucao : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private static string NOME_CLASSE = "requisicoesExecucao";

        string LstMensagemRetorno = "";

        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request["method"])
            {
                //====================================
                ///******** MÓDULO DE LIVROS *********
                //====================================
                #region ROTINAS CRUD DE LIVROS
                case "obterDadosLivros":
                    obterDadosLivros(context);
                    break;
                case "incluirNovoLivro":
                    incluirNovoLivro();
                    break;

                #endregion

                default:
                    throw new ArgumentException("Erro! Ação não identificada.");

            }
            context.Response.ContentType = "texto/simples";
            context.Response.Write("Olá, Mundo");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string currentFile
        {
            get
            {
                var fileName = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
                if (fileName != null)
                {
                    string[] path = fileName.Split(Path.DirectorySeparatorChar);
                    string file = (path.Length > 0) ? path[path.Length - 1] : path[path.Length];
                    return file;
                }
                else
                    return string.Empty;
            }
            set
            {
                currentFile = value;
            }
        }

        public string DataTableToJSON(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = (Convert.ToString(row[col]));
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Serialize(list);
        }
        private Dictionary<string, string> deserializeToDictionary(string root, string strJSON)
        {
            var dict_root = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(strJSON);
            var mydict = new Dictionary<string, string>();

            if (dict_root != null)
            {
                mydict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(dict_root[root]);
            }
            return mydict;
        }
        public void obterDadosLivros(HttpContext context)
        {
            string msgStackTrace = currentFile + " method obterDadosLivros";
            string pstStatusRequisicao = string.Empty;

            if ((context.Request["args[valoresJSON]"] == null))
            {
                retornaExceptionAsJSON(context, "Parâmetros não identificados.", msgStackTrace);
            }

            try
            {
                //tratando JSON com parametros de entrada
                Dictionary<string, string> valoresDeserializado = deserializeToDictionary("valores", context.Request["args[valoresJSON]"]);
                if (string.IsNullOrEmpty(valoresDeserializado["codLivro"]))
                {
                    retornaExceptionAsJSON(context, "Parâmetros não identificados.", msgStackTrace);
                }

                string pstCodLivro = valoresDeserializado["codLivro"].Trim();

                ManterLivro lobjManterLivro = new ManterLivro();

                //livro lobjLivros = new livro(null);
                //DataTable dataTable = lobjManterLivro.ObterLivrosPorAssunto();


                //DataTable dataTable = LobjSolicitacao.ObterDadosSolicitacao(pstCodSolicitacao);
                //LobjSolicitacao = null;

                //string json;
                //json = DataTableToJSON(dataTable);

                //context.Response.ContentType = "text/json";
                //context.Response.Write(json);
            }
            catch (Exception e)
            {
                retornaExceptionAsJSON(context, e.Message, e.StackTrace);
            }
        }

        public void incluirNovoLivro(string titulo, string editora, int edicao, string anopublic, decimal valor, string assunto, string autor)
        {
            livro livro = new livro();
            ManterLivro manterLivro = new ManterLivro();

            livro.TitLivro = titulo;
            livro.EditaLivro = editora;
            livro.EdicaoLivro = edicao;
            livro.AnoPublicacao = anopublic;
            livro.PrecoLivro = valor;
            manterLivro.InserirLivro(livro);

            // Atualização das tabelas Livro_Assunto e Livro_Autor
            livroAssunto livroAssunto = new livroAssunto();
            livroAssunto.CodLivro = livro.CodigoLivro;
            livroAssunto.CodAssunto = int.Parse(assunto);

            ManterLivroAssunto manterLivroAssunto = new ManterLivroAssunto();
            manterLivroAssunto.InserirLivroAssunto(livroAssunto);

            livroAutores livroAutor = new livroAutores();
            livroAutor.CodLivros = livro.CodigoLivro;
            livroAutor.CodAutor = int.Parse(autor);

            ManterLivroAutor mntLivroAutor = new ManterLivroAutor();
            mntLivroAutor.InserirLivroAutor(livroAutor);

        }

        //public bool incluirNovoLivro()
        //{
        //    bool operacaoComSucesso = false;

        //    DataTable dt = new DataTable();
        //    SqlServerHelper sql = SqlServerHelper.New;

        //    try
        //    {
        //        SqlCommand comando = sql.CreateCommand();

        //        comando.CommandText = "USP_VW_LIVRO_INCLUIR";
        //        comando.CommandType = CommandType.StoredProcedure;

        //        comando.Parameters.Add("@pTitulo", SqlDbType.VarChar);
        //        comando.Parameters.Add("@pEditora", SqlDbType.VarChar);
        //        comando.Parameters.Add("@pEdicao", SqlDbType.Int);
        //        comando.Parameters.Add("@pAnoPublicacao", SqlDbType.VarChar);

        //        //comando.Parameters["@pTitulo"].Value = titulo.ToUpper();
        //        //comando.Parameters["@pEditora"].Value = editora;
        //        //comando.Parameters["@pEdicao"].Value = Convert.ToInt32(edicao);
        //        //comando.Parameters["@pAnoPublicacao"].Value = ano;

        //        SqlDataAdapter adapterLivro = new SqlDataAdapter(comando);
        //        adapterLivro.Fill(dt);

        //        if (dt.Rows.Count > 0)
        //        {
        //          ///  hdnCodLivro.Valeu = Convert.ToInt32(dt.Rows[0]["CODL"].ToString());
        //        }

        //    }
        //    catch (Exception excecao)
        //    {
        //        throw excecao;
        //    }
        //    finally
        //    {
        //        sql.CloseConnection();
        //    }

        //    return operacaoComSucesso;
        //}

        /// Retornar Exception como JSON
        private void retornaExceptionAsJSON(HttpContext context, string msgErro, string traceErro = "")
        {
            var jsonSerialiser = new JavaScriptSerializer();
            HttpContext.Current.Response.StatusCode = 500;   // forço 500 = internal server error
            var json = jsonSerialiser.Serialize(new { Message = msgErro, StackTrace = traceErro });
            context.Response.ContentType = "text/json";
            context.Response.Write(json);
        }
    }
}