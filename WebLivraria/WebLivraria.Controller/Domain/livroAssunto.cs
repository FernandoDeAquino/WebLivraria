using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLivraria.Controller
{
    /*Classe que trata do relacionamento entre livros e os seus assuntos*/
    [Serializable]
    public class livroAssunto
    {
        #region get/set

        public Int32 codLivro { get; set; }

        public Int32 codAssunto { get; set; }

        public bool assuntoEncontrado { get; set; }

        public Int32 CodDoLivro_Assunto
        {
            get
            {
                return this.codLivro; 
            }
            set
            {
                this.codLivro = value;
            }

        }

        public Int32 CodDoAssunto
        {
            get
            {
                return this.codAssunto;
            }
            set
            {
                this.codAssunto = value;
            }
        }

        public Boolean AssuntoEncontrado
        {
            get { return assuntoEncontrado; }
            set { assuntoEncontrado = value; }
        }

        #endregion
    }
}