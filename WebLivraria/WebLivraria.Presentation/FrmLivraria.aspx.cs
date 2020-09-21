using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebLivraria.Presentation
{
    public partial class FrmLivraria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void OptLivro_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLivros.aspx");
        }

        protected void OptAutor_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmAutores.aspx");
        }

        protected void OptAssunto_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmAssunto.aspx");
        }

        protected void OptRelatorio_Click(object sender, EventArgs e)
        {
          
        }
    }
}