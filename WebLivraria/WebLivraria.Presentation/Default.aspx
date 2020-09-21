<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="WebLivraria.Presentation.Default" %>


<asp:Content ID="Content1" contentPlaceHolderID="ContentPlaceHolderWebLivraria" runat="server">
    <link href="app/css/bootstrap-extended.min.css" rel="stylesheet">
    <link href="app/css/bootstrap-theme.css" rel="stylesheet" >
    <link href="app/css/bootstrap.css" rel="stylesheet" >
    <link href="app/css/bootstrap.min.css" rel="stylesheet" >

     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <form action="" method="post">
           <div class="col-md-6">
               <label for="menuOpcoes">Menu</label>
               <select id="ListaOpcoes" name="lstOpcoes" class="form-control">
                    <asp:Button ID="OptLivro" runat="server" Text="Livros para venda" OnClick="OptLivro_Click" CssClass="btn btn-primary btn-large"/>
                    <asp:Button ID="OptAutor" runat="server" Text="Espaço dos autores" OnClick="OptAutor_Click" CssClass="btn btn-primary btn-large"/>
                    <asp:Button ID="OptAssunto" runat="server" Text="Assunto dos livros" OnClick="OptAssunto_Click" CssClass="btn btn-primary btn-large"/>
               </select> 
               <div class="select-section-options">

               </div>
           </div>

           <div class="row clearfix">
	          <div class="col-md-12 column" style="/*left: -2147483648px; top: -2147483648px*/">
		          <div class="jumbotron well">
		            <h1>Web Livraria -- Texte de posicionamento</h1>
		          </div>
		       </div>
	       </div>
        </form>
    <script src=""> </script>
</asp:Content>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>
<%--<body>
    <form id="form1" runat="server">
        <div>
            <hi>Cheguei aqui!!!</hi>
        </div>
    </form>
</body>
</html>--%>
