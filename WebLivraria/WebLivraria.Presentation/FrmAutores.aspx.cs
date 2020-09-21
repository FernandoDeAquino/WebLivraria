using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLivraria.Business;
using WebLivraria.Controller;

namespace WebLivraria.Presentation
{
    public partial class FrmAutores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarListaDeAutores();
        }

        protected void btnInluirAutor_Click(object sender, EventArgs e)
        {
            LivrosDados autoresDados = new LivrosDados();
            autoresDados.IncluirAutor(this.nomeAutor.Text);
            string zeraAutor = string.Empty;

            CarregarListaDeAutores();
            this.hdnAutores.Value = zeraAutor;
            this.nomeAutor.Text = this.hdnAutores.Value;
            this.UpdListaAutores.Update();

            myModalLabel.InnerText = "Inclusão de autor";
            ScriptManager.RegisterStartupScript(this, GetType(), "Show Modal Popup", "showmodalpoup();", true);
        }

        private void CarregarListaDeAutores()
        {
            rptAutores.DataSource = (new ManterAutor()).ObterListaAutores();
            rptAutores.DataBind();
        }

        protected void btnExcluirAutor_Click(object sender, EventArgs e)
        {
            ManterLivroAutor manterLivroAutor = new ManterLivroAutor();

            manterLivroAutor.ObterAutorDeLivros(Convert.ToInt32(this.hdnAutores.Value));
            if (manterLivroAutor.autorEncontrado == false) {

                LivrosDados autoresDados = new LivrosDados();
                autoresDados.ExcluirAutor(Convert.ToInt32(hdnAutores.Value));

                CarregarListaDeAutores();

                this.UpdListaAutores.Update();

                myModalLabel.InnerText = "Exclusão de autor";
                ScriptManager.RegisterStartupScript(this, GetType(), "Show Modal Popup", "showmodalpoup();", true);
            }
        }

        protected void btnRetorno_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLivraria.aspx");
        }

        protected void btnCancelar_ServerClick(object sender, EventArgs e)
        {

        }
    }
}