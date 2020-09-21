using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLivraria.Controller
{
    /*Classe que trata do relacionamento entre livros e seus autores*/
    [Serializable]
    #region get/set
    public class livroAutores
    {
        public Int32 codLivros { get; set; }
        public Int32 codAutor { get; set; }

        public Int32 CodDoLivro_Autor
        {
            get
            {
                return this.codLivros;
            }
            set
            {
                this.codLivros = value;
            }

        }

        public Int32 CodDoAutor
        {
            get
            {
                return this.codAutor;
            }
            set
            {
                this.codAutor = value;
            }
        }

    }

    #endregion

}