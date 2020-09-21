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
    public partial class FrmAssunto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarListaDeAssuntos();
        }

        protected void btnIncluirAssunto_Click(object sender, EventArgs e)
        {
            string zeraVal = string.Empty;
            LivrosDados AssuntoDados = new LivrosDados();
            AssuntoDados.IncluirAssunto(this.nmAssunto.Text);
            CarregarListaDeAssuntos();

            this.hdnCodAssunto.Value = zeraVal;
            this.nmAssunto.Text = this.hdnCodAssunto.Value;
            this.updListaAssuntos.Update();

        }

        private void CarregarListaDeAssuntos()
        {
            rptAssuntos.DataSource = (new ManterAssunto()).ObterListaAssuntos();
            rptAssuntos.DataBind();
        }

        protected void brnExcluirAssunto_Click(object sender, EventArgs e)
        {
            livroAssunto varLivroAssunto = new livroAssunto();
            ManterLivroAssunto manterLivroAssunto = new ManterLivroAssunto();
            manterLivroAssunto.ObterAssuntoNosLivros(Convert.ToInt32(this.hdnCodAssunto.Value));

            if (manterLivroAssunto.assuntoEncontrado == false )
            {
                string zeraVal = string.Empty;
                LivrosDados assuntoDados = new LivrosDados();
                assuntoDados.ExcluirAssunto(Convert.ToInt32(this.hdnCodAssunto.Value));
                CarregarListaDeAssuntos();

                this.hdnCodAssunto.Value = zeraVal;
                this.nmAssunto.Text = this.hdnCodAssunto.Value;

                this.updListaAssuntos.Update();
            }
        }

        protected void btnRetorno_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLivraria.aspx");
        }
    }
}