using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLivraria.Controller
{
    public class TipoAssunto
    {
        Int64? tipSqAssunto = null;
        String tipDsAssunto = String.Empty;

        public virtual Int64? TipSqAssunto
        {
            get { return tipSqAssunto; }
            set { tipSqAssunto = value; }
        }
        public virtual String TipDsAssunto
        {
            get { return tipDsAssunto; }
            set { tipDsAssunto = value; }
        }
    }
}