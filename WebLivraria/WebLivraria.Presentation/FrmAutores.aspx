<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAutores.aspx.cs" Inherits="WebLivraria.Presentation.FrmAutores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderWebLivraria" runat="server">
   <link href="app/css/bootstrap-extended.min.css" rel="stylesheet">
    <link href="app/css/bootstrap-theme.css" rel="stylesheet" >
    <link href="app/css/bootstrap.css" rel="stylesheet" >
    <link href="app/css/bootstrap.min.css" rel="stylesheet" >
    <link href="app-assets/css/app.mn.css" rel="stylesheet" >
    <link href="app-assets/css/bootstrap.min.css" rel="Stylesheet" />
    <link href="app-assets/css/font-awesome.min.css" rel="stylesheet" >


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering ="true"></asp:ScriptManager>	
        <script type="text/javascript">
            function showmodalpoup() {
                $('#modalApresentacao').modal("show");
            };

            function fecharmodalpoup() {
                  $('#modalApresentacao').modal("hide");
            };
        </script>
        
    <div class="col-md-12 column">
        <asp:UpdatePanel ID="Updcrud" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div class="form-actions">
                    <div class="form-group">
                    <asp:HiddenField ID="hdnAutores" runat="server" Value="" /> 
                        <div>
                            <label for="data">Autor</label>
                            <asp:TextBox ID="nomeAutor" CssClass="form-control" Width="50%" runat="server"></asp:TextBox>
                        </div>
                    </div> 
                    <!-- Botões -->
                    <footer class="footer-controls">
                        <div class="col-md-6 table-column">
                        <asp:UpdatePanel id="updRodape" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div>
                                    <div class="btn-group btn-group-sm">
                                        <asp:Button ID="btnInluirAutor" runat="server" CssClass="brn btn-primary btn-large" OnClick="btnInluirAutor_Click" Text="inclusão" />
<%--                                        <asp:Button ID="btnExcluirAutor" runat="server" CssClass="brn btn-primary btn-large" OnClick="btnExcluirAutor_Click" Text="Exclusão de autor" />--%>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                        <div class="col-md-6 table-column">
                            <div class="fonticon-classname">
                                <asp:LinkButton ID="btnRetorno" CssClass="fa fa-reply" BorderStyle="Solid" ToolTip="Retorna ao menu principal" runat="server" OnClick="btnRetorno_Click"></asp:LinkButton>
                            </div>
                        </div>
                    </footer>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel> 
    </div>
    <div class="container">
        <div class="row clearfix">
            <div class="col-md-12 column">
                <asp:UpdatePanel ID="UpdListaAutores" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" >
                    <ContentTemplate>
			            <table id="gridAutores" class="table table-bordered table-hover table-condensed">
				            <thead>
					            <th>
						            Código
					            </th>
                                <th>
                                    Autores
                                </th>                          					
                                <th>
                                </th>
				            </thead>
				            <tbody>
                                <asp:Repeater runat="server" ID="rptAutores">
                                    <ItemTemplate>
                                        <input id="hdnAutores"  type="hidden"/> 
	                                    <tr class="chkDoAutor" id="CdAutor_<%# Eval("CodigoAutor") %>+ " >
                                            <td>
                                                <%# Eval("CodigoAutor") %> 
                                            </td>
                                            <td>
                                                <%# Eval("NomeAutor") %> 
                                            </td>
                                            <td>
                                                <div class="fonticon-wrap">
                                                    <asp:LinkButton ID="btnExcluirAutor" runat="server" CssClass="fa fa-trash-o" OnClick="btnExcluirAutor_Click" ToolTip="Exclusão"></asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdAvisos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div aria-hidden="true" id="modalApresentacao" class="modal fade" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button aria-hidden="true" type="button" data-dismiss="modal">X</button>
                            <h4 id="myModalLabel" runat="server" class="modal-title">Inclusão de autor</h4>
                        </div>
                    </div>
                    <div class="modal-body">
                         <div class="form-group">
                            <div class="row clearfix">
                                <div class="col-md-6 column">

                                </div>
                            </div>
                         </div>
                     </div>
                    <div class="modal-footer">
                        <div class="row clearfix">
                              <button id="btnCancelar" onserverclick="btnCancelar_ServerClick" runat="server"  class="btn btn-default" type="button">Retornar</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   <script type="text/javascript" src="js/MenuLivraria.js"></script>
</asp:Content>
