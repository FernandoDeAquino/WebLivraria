using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebLivraria.Controller
{
    public class ExisteTransacaoAtivaException : ApplicationException
    {
        private const string MENSAGEM = "Existe transação ativa na conexão com o Banco de Dados.";

        public ExisteTransacaoAtivaException()
            : base(MENSAGEM)
        {
        }
    }
}

