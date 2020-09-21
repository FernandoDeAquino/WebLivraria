using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WebLivraria.Business;
using WebLivraria.Controller;

namespace WebLivraria.Presentation
{
    public partial class FrmLivros : System.Web.UI.Page
    {
        public string mensagemOk; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarListaDeLivros();  
                CarregarListaDeEditoras();
                CarregarListaDeAssuntos();
                CarregarListaDeAutores();
            }
        }

        private void CarregarListaDeLivros()
        {
            this.rptListLivros.DataSource = (new ManterLivro()).ObterLivrosPorAssunto();
            this.rptListLivros.DataBind();
        }

        protected void rptListLivro_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptListDeLivros_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptLivro_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

 

        private void limparCampos()
        {
            this.titulo.Text = string.Empty;
            this.hdnEditora.Value = string.Empty;
            this.listEdita.SelectedIndex = -1;
            this.listEdita.SelectedValue = "Selecione a Editora";

            this.hdnCodAssunto.Value = string.Empty;
            this.listAssuntos.SelectedIndex = -1;
            this.listAssuntos.SelectedValue = "Selecione o Assunto";

            this.listAutores.SelectedIndex = -1;
            this.listAutores.SelectedValue = "Selecione o Autor";
            this.hdnAutor.Value = string.Empty;
            this.anoPublicacao.Text = string.Empty;

            this.btnBotao.Text = "incluir";
        }

        protected void listEdita_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnEditora.Value = listEdita.SelectedValue;
        }

        private void CarregarListaDeEditoras()
        {
            List<TipoEditora> listaEditoras = (new ManterTipoEditora().ObterListaDeEditoras());

            TipoEditora mntLivro = new TipoEditora();
            mntLivro.TipSqLivro = -1;
            mntLivro.TipDsEditora = "Selecione a Editora";

            listaEditoras.Insert(0, mntLivro);

            listEdita.DataSource = listaEditoras;
            listEdita.DataBind();
        }

        protected void listAssuntos_SelectedIndexChanged(object sender, EventArgs e)
        {
            assunto assunto = (new ManterAssunto()).ObterAssunto(listAssuntos.SelectedValue);
            this.hdnCodAssunto.Value =  assunto.CodigoAssunto.ToString();
        }

        private void CarregarListaDeAssuntos()
        {
            List<TipoAssunto> listaAssuntos = (new ManterAssunto().ObterListaAssuntos());
            TipoAssunto mntAssunto = new TipoAssunto();
            mntAssunto.TipSqAssunto = -1;
            mntAssunto.TipDsAssunto = "Selecione o Assunto";
            listaAssuntos.Insert(0, mntAssunto);
            listAssuntos.DataSource = listaAssuntos;
            listAssuntos.DataBind();
        }

        protected void listAutores_SelectedIndexChanged(object sender, EventArgs e)
        {
            autor autor = (new ManterAutor()).ObterAutor(listAutores.SelectedValue);
            hdnAutor.Value = autor.CodigoAutor.ToString();
        }

        private void CarregarListaDeAutores()
        {
            List<TipoAutor> listaAutores = (new ManterAutor().ObterListaDeAutores());
            TipoAutor mntAutor = new TipoAutor();
            mntAutor.TipSqAutor = -1;
            mntAutor.TipDsAutor = "Selecione o Autor";
            listaAutores.Insert(0, mntAutor);
            listAutores.DataSource = listaAutores;
            listAutores.DataBind();
        }

         protected void btnExcluir_Click(object sender, EventArgs e)
        {
            LivrosDados livrosDados = new LivrosDados();
            livrosDados.ExcluirLivro(Convert.ToInt32(this.hdnCodLivro.Value), Convert.ToInt32(this.hdnCodAssunto.Value), Convert.ToInt32(this.hdnAutor.Value));

            CarregarListaDeLivros();

            this.UpdListaLivros.Update();
        }

        protected void btnBotao_Click(object sender, EventArgs e)
        {
            LivrosDados livrosDados = new LivrosDados();

            // Tratamento do comportamento do botão
            if (this.hdnCodLivro.Value != string.Empty)
            {
                livrosDados.AtualizaLivro(Convert.ToInt32(this.hdnCodLivro.Value), this.titulo.Text, this.hdnEditora.Value, Convert.ToInt32(this.edicao.Text), this.anoPublicacao.Text, Convert.ToDecimal(this.ValLivro.Text), Convert.ToInt32(this.hdnCodAssunto.Value), Convert.ToInt32(hdnAutor.Value));

                mensagemOk = "alterado";
            }
            else
            {
                livrosDados.IncluirLivro(this.titulo.Text, this.hdnEditora.Value, Convert.ToInt32(this.edicao.Text), this.anoPublicacao.Text, Convert.ToDecimal(ValLivro.Text), hdnCodAssunto.Value,hdnAutor.Value);

                mensagemOk = "incluído";
            }

            limparCampos();
            CarregarListaDeLivros();

            this.UpdListaLivros.Update();

        }

        protected void btnRetorno_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLivraria.aspx");
        }
    }
}