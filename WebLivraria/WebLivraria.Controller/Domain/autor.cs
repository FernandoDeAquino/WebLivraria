using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLivraria.Controller
{
    #region get/set
    [Serializable]
    public class autor
    {
        public Int32 Cod { get; set; }
        public string Nome { get; set; }
        public string MsgErroAutor { get; set; }

        public Int32 CodigoAutor
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

        public string NomeAutor
        {
            get
            {
                return this.Nome;
            }
            set
            {
                this.Nome = value;
            }
        }

    }

    #endregion
}