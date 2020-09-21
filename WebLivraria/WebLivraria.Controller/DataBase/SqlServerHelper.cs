using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace WebLivraria.Controller
{
    public class SqlServerHelper
    {
        private SqlConnection conexao = null;
        private SqlTransaction transacao;
        private String connectionString = string.Empty;
        private Int32 numeroDeTransacoes = 0;

        public static string usu = "";
        public static string senhaConn = "";
        public static string servidor = "(localdb)\\MSSQLLocalDB";
        public static string caminho = "C:\\Users\\Fernando\\WebLivraria\\WebLivraria.Controller\\DataBase\\Livraria.mdf";

        public static SqlServerHelper New
        {
            get
            {
                return new SqlServerHelper();
            }
        }

        public void Initialize()
        {
            try
            {
                if (conexao == null)
                {


                    connectionString = ("Data Source=" + servidor + ";Initial Catalog=" + caminho + ";Persist Security Info=False;");

                    //+ '  Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                    //connectionString = ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\FERNANDO\\LIVRARIA.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    conexao = new SqlConnection(connectionString);

                    transacao = null;
                }
            }
            catch (Exception excecao)
            {
                throw excecao;
            }
        }

        public SqlCommand CreateCommand()
        {
            return OpenConnection().CreateCommand();
        }

        public SqlConnection OpenConnection()
        {
            Initialize();

            if (conexao.State != ConnectionState.Open)
            {
                conexao.Open();
                numeroDeTransacoes = 0;
            }
            return conexao;
        }

        public void CloseConnection()
        {
            if (conexao.State == ConnectionState.Open)
            {
                if (transacao != null)
                {
                    throw new ExisteTransacaoAtivaException();
                }

                conexao.Close();
                conexao.Dispose();
                conexao = null;
                transacao = null;
                numeroDeTransacoes = 0;
            }
        }

        public void BeginTransaction()
        {
            if (transacao == null)
            {
                transacao = OpenConnection().BeginTransaction();
            }

            numeroDeTransacoes++;
        }

        public void CommitTransaction()
        {
            if (transacao != null)
            {
                if (numeroDeTransacoes > 0)
                {
                    numeroDeTransacoes--;
                }
                if (numeroDeTransacoes == 0)
                {
                    transacao.Commit();
                    transacao.Dispose();
                    transacao = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            if (transacao != null)
            {
                transacao.Rollback();
                transacao.Dispose();
            }

            transacao = null;
            numeroDeTransacoes = 0;
        }
    }
}