<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmLivros.aspx.cs" Inherits="WebLivraria.Presentation.FrmLivros" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderWebLivraria" runat="server">
   <link href="app/css/bootstrap-extended.min.css" rel="stylesheet">
    <link href="app/css/bootstrap-theme.css" rel="stylesheet" >
    <link href="app/css/bootstrap.css" rel="stylesheet" >
    <link href="app/css/bootstrap.min.css" rel="stylesheet" >
    <link href="app-assets/css/app.mn.css" rel="stylesheet" >
    <link href="app-assets/css/bootstrap.min.css" rel="Stylesheet" />
    <link href="app-assets/css/colors.min.css" rel="Stylesheet" />
    <link href="app-assets/css/font-awesome.min.css" rel="stylesheet" >
        
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering ="true"></asp:ScriptManager>	
        <script type="text/javascript">
            function showmodalpopup() {
                $("#modalVoltaParaListagem").modal('show');
            };

            function showmodalpopup() {
                $("#modalVoltaParaListagem").modal('hide');
            };
        </script>
        <div class="col-md-12 column">
        <asp:UpdatePanel ID="updCRUD" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div class="form-actions">
                    <div class="form-group">
                        <asp:HiddenField ID="hdnCodLivro" runat="server" Value="" /> 
                        <div>
                            <label for="data">Título</label>
                            <asp:TextBox ID="titulo" CssClass="form-control" Width="80%" runat="server"></asp:TextBox>
                        </div>
                    </div> 
                    <div class="col-md-6 table-column">
                        <div>
                            <label for="editara">Editora</label>
                            <asp:HiddenField ID="hdnEditora" runat="server" Value="" />
                            <asp:DropDownList ID="listEdita" AutoPostBack="true" runat="server" DataTextField="TipDsEditora" DataValueField="TipDsEditora" CssClass="form-control" Width="50%" OnSelectedIndexChanged="listEdita_SelectedIndexChanged">
                            </asp:DropDownList> 
                        </div>
                        <div>
                            <label for="assunto">Assunto</label>
                            <asp:HiddenField ID="hdnCodAssunto" runat="server" Value="" />
                            <asp:DropDownList ID="listAssuntos" AutoPostBack="true" runat="server" DataTextField="TipDsAssunto" DataValueField="TipDsAssunto" CssClass="form-control" Width="50%" OnSelectedIndexChanged="listAssuntos_SelectedIndexChanged">
                            </asp:DropDownList> 
                        </div>
                        <div>
                            <label for="assunto">Ano de publicação</label>
                            <asp:TextBox ID="anoPublicacao" CssClass="form-control" Width="20%" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 table-column">
                        <div>
                            <label for="edicao">Edição</label>
                            <asp:TextBox ID="edicao" CssClass="form-control" Width="5%" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <label for="assunto">Autor</label>
                            <asp:HiddenField ID="hdnAutor" runat="server" Value="" />
                            <asp:DropDownList ID="listAutores" AutoPostBack="true" runat="server" DataTextField="TipDsAutor" DataValueField="TipDsAutor" CssClass="form-control" Width="45%" OnSelectedIndexChanged="listAutores_SelectedIndexChanged">
                            </asp:DropDownList> 
                        </div>

                        <div>
                            <label for="assunto">Preço</label>
                            <asp:TextBox ID="ValLivro" CssClass="form-control" Width="40%" runat="server"></asp:TextBox>
                         </div>
                    </div>
                    <!-- Botões -->
                    <div class="col-md-12 table-column"></div>
                        <div class="col-md-6 table-column">
                            <footer class="footer-controls">
                                <asp:UpdatePanel ID="updRodape" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div>
                                            <div class="btn-group btn-group-sm">
                                                <asp:Button ID="btnBotao" runat="server" CssClass="btn btn-primary btn-large" Text="incluir" OnClick="btnBotao_Click" ClientIDMode="Static" UseSubmitBehavior="false" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </footer>
                        </div>
                        <div class="col-md-6 table-column">
                            <div class="fonticon-classname">
                                <asp:LinkButton ID="btnRetorno" CssClass="fa fa-reply" BorderStyle="Solid" ToolTip="Retorna ao menu principal" runat="server" OnClick="btnRetorno_Click"></asp:LinkButton>
                            </div>
                        </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel> 
        </div>
        <div class="container">
            <div class="row clearfix">
                <div class="col-md-12 column">
                    <asp:UpdatePanel ID="UpdListaLivros" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
			                <table id="gridLivro" class="table table-bordered table-hover table-condensed">
				                <thead>
					                <th>
						                Código
					                </th>
                                    <th>
                                        Titulo
                                    </th>                          					
                                    <th>
                                        Editora
                                    </th>
                                    <th>
                                        Edição
                                    </th>		
                                    <th>
                                        Assunto abordado
                                    </th>
                                    <th>
                                        Autores
                                    </th>
                                    <th>
                                        Publicação
                                    </th>
                                    <th>
                                        Preço
                                    </th>
                                    <th>
                                    </th>
                                    <th>
                                    </th>
				                </thead>
				                <tbody>
                                    <asp:Repeater runat="server" ID="rptListLivros">
                                        <ItemTemplate>
                                            <input id="hdnCodLivro" type="hidden" />
	                                        <tr class="chkDoLivro" id="CdLivro_<%# Eval("CodigoLivro") %>+ " >
                                                <td id="codigo" >
                                                    <%# Eval("CodigoLivro") %> 
                                                </td>
                                                <td>
                                                    <%# Eval("TitLivro") %> 
                                                </td>
                                                <td>
                                                    <%# Eval("EditaLivro") %> 
                                                </td>
                                                <td id="edicao">
                                                    <%# Eval("EdicaoLivro") %> 
                                                </td>
                                                <td id="assunto" >
						                            <%# Eval("AssuntoLivro")%> 
                                                </td>
                                                <td id="autor">
                                                    <%# Eval("AutorLivro")%>
                                                </td>
                                                 <td id="publicacao">
                                                    <%# Eval("AnoPublicacao")%>
                                                </td>
                                                <td id="preco">
                                                    <%# Eval("PrecoLivro")%>
                                                </td>
                                                <td>
                                                    <div class="fonticon-wrap">
                                                        <button id="btnAltera" class="fa fa-pencil-square-o" onclick="return false;"></button>
                                                    </div>                            
                                                </td> 
                                                <td>
                                                    <div class="fonticon-wrap">
                                                        <asp:LinkButton id="btnExcluir" runat="server"  CssClass="fa fa-trash-o" ToolTip="Exclusão" OnClick="btnExcluir_Click"></asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
				                </tbody>
			                </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <script type="text/javascript" src="js/MenuLivraria.js"></script>
</asp:Content>


