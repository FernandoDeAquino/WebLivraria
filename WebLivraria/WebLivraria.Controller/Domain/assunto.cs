using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLivraria.Controller
{
    #region get/set
    [Serializable]
    public class assunto
    {
        public Int32 Cod { get; set; }
        public string Desc { get; set; }
        public string MsgErroAssunto { get; set; }

        public Int32 CodigoAssunto
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

        public string DescAssunto
        {
            get
            {
                return this.Desc;
            }
            set
            {
                this.Desc = value;
            }
        }

    }

    #endregion
}