using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLivraria.Controller
{
    #region get/set
    [Serializable]
    public class livro
    {

        public int Cod { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string Ano { get; set; }
        public string MsgErroLivros { get; set; }
        public string Assunto { get; set; }
        public string Autor { get; set; }
        public Decimal Preco { get; set; }
 
        public Int32 CodigoLivro
        {
            get
            {
                return this.Cod;
            }
            set
            {
                this.Cod = value;
            }
        }

        public string TitLivro
        {
            get
            {
                return this.Titulo;
            }
            set
            {
                this.Titulo = value;
            }
        }

        public string EditaLivro
        {
            get
            {
                return this.Editora;
            }
            set
            {
                this.Editora = value;
            }
        }

        public Int32 EdicaoLivro
        {
            get
            {
                return this.Edicao;
            }
            set
            {
                this.Edicao = value;
            }
        }

        public string AnoPublicacao
        {
            get
            {
                return this.Ano;
            }
            set
            {
                this.Ano = value;
            }
        }

        public string AssuntoLivro
        {
            get
            {
                return this.Assunto;
            }
            set
            {
                this.Assunto = value;
            }
        }

        public string AutorLivro
        {
            get
            {
                return this.Autor;
            }
            set
            {
                this.Autor = value;
            }
        }

        public virtual Decimal PrecoLivro
        {
            get
            {
                return this.Preco;
            }
            set
            {
                this.Preco = value;

            }
        }
    }

    #endregion
}