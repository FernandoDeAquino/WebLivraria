<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAssunto.aspx.cs" Inherits="WebLivraria.Presentation.FrmAssunto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderWebLivraria" runat="server">
   <link href="app/css/bootstrap-extended.min.css" rel="stylesheet">
    <link href="app/css/bootstrap-theme.css" rel="stylesheet" >
    <link href="app/css/bootstrap.css" rel="stylesheet" >
    <link href="app/css/bootstrap.min.css" rel="stylesheet" >
    <link href="app-assets/css/app.mn.css" rel="stylesheet" >
    <link href="app-assets/css/bootstrap.min.css" rel="Stylesheet" />
    <link href="app-assets/css/font-awesome.min.css" rel="stylesheet" >


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering ="true">
    </asp:ScriptManager>	
        <script type="text/javascript" language="javascript">
            function showmodalpopup() {
                $('#modalbtnAdicionar').modal('show');
            }
        </script>
    <div class="col-md-12 column">
        <asp:UpdatePanel ID="UpdCrud" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div class="form-actions">
                    <div class="form-group">
                        <asp:HiddenField ID="hdnCodAssunto" runat="server" Value="" /> 
                        <div>
                            <label for="data">Assunto</label>
                            <asp:TextBox ID="nmAssunto" CssClass="form-control" Width="50%" runat="server"></asp:TextBox>
                        </div>
                    </div> 
                    <!-- Botões -->
                    <footer class="footer-controls">
                        <div class="col-md-6 table-column">
                        <asp:UpdatePanel ID="updRodape" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div>
                                    <div class="btn-group btn-group-sm">
                                        <asp:Button ID="btnIncluirAssunto" runat="server" CssClass="brn btn-primary btn-large" OnClick="btnIncluirAssunto_Click" Text="Inclusão" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                        <div class="col-md-6 table-column">
                            <div class="fonticon-classname">
                                <asp:LinkButton ID="btnRetorno"  CssClass="fa fa-reply" BorderStyle="Solid" ToolTip="Retorna ao menu principal" runat="server" OnClick="btnRetorno_Click"></asp:LinkButton>
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
                <asp:UpdatePanel ID="updListaAssuntos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" >
                    <ContentTemplate>
			            <table id="gridAssuntos" class="table table-bordered table-hover table-condensed">
				            <thead>
					            <th>
						            Código
					            </th>
                                <th>
                                    Assuntos abordados
                                </th>                
                                <th>
                                </th>
				            </thead>
				            <tbody>
                                <asp:Repeater runat="server" ID="rptAssuntos">
                                    <ItemTemplate>
                                        <input id="hdnCodAssunto" type="hidden" />
	                                    <tr class="chkCodAssunto" id="CdAssunto_<%# Eval("TipSqAssunto") %>+ " >
                                            <td>
                                                <%# Eval("TipSqAssunto") %> 
                                            </td>
                                            <td>
                                                <%# Eval("TipDsAssunto") %> 
                                            </td>
                                            <td>
                                                <div class="fonticon-wrap">
                                                    <asp:LinkButton id="brnExcluirAssunto" runat="server"  CssClass="fa fa-trash-o" ToolTip="Exclusão" OnClick="brnExcluirAssunto_Click" ></asp:LinkButton>
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

      <asp:UpdatePanel ID="UpdAvisos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div aria-hidden="true" id="modalApresentacao" class="modal fade" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button aria-hidden="true" type="button" data-dismiss="modal">X</button>
                            <h4 id="myModalLabel" runat="server" class="modal-title">Inclusão de assunto</h4>
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
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
