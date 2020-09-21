using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLivraria.Controller
{
    public class TipoEditora
    {
        Int64? tipSqLivro = null;
        String tipDsEditora = String.Empty;

        public virtual Int64? TipSqLivro
        {
            get { return tipSqLivro; }
            set { tipSqLivro = value; }
        }
        public virtual String TipDsEditora
        {
            get { return tipDsEditora; }
            set { tipDsEditora = value; }
        }
    }
}