<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmLivraria.aspx.cs" Inherits="WebLivraria.Presentation.FrmLivraria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderWebLivraria" runat="server">
    <link href="app/css/bootstrap-extended.min.css" rel="stylesheet">
    <link href="app/css/bootstrap-theme.css" rel="stylesheet" >
    <link href="app/css/bootstrap.css" rel="stylesheet" >
    <link href="app/css/bootstrap.min.css" rel="stylesheet" >
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager> 
        <form action="" method="post">
           <div class="col-md-6">
                <asp:Button ID="OptLivro" runat="server" Text="Catálogo de livros" OnClick="OptLivro_Click" CssClass="btn btn-primary btn-large"/>
                <asp:Button ID="OptAutor" runat="server" Text="Espaço dos autores" OnClick="OptAutor_Click" CssClass="btn btn-primary btn-large"/>
                <asp:Button ID="OptAssunto" runat="server" Text="Assunto dos livros" OnClick="OptAssunto_Click" CssClass="btn btn-primary btn-large"/>
                <asp:Button ID="OptRelatorio" runat="server" Text="Relatório de livros" OnClick="OptRelatorio_Click"  CssClass="btn btn-primary btn-large"/>
           </div>
           <div class="row clearfix">
	          <div class="col-md-12 column" style="/*left: -2147483648px; top: -2147483648px*/">
		          <div class="jumbotron well">
		            <h1>Web Livraria</h1>
		          </div>
		       </div>
	       </div>
        </form>


</asp:Content>
