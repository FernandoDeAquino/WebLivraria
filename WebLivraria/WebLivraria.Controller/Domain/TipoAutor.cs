using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLivraria.Controller
{
    public class TipoAutor
    {
        Int64? tipSqAutor = null;
        String tipDsAutor = String.Empty;

        public virtual Int64? TipSqAutor
        {
            get { return tipSqAutor; }
            set { tipSqAutor = value; }
        }
        public virtual String TipDsAutor
        {
            get { return tipDsAutor; }
            set { tipDsAutor = value; }
        }

    }
}