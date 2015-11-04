<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="AcadControl.Views.PeriodoLetivo.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Período Letivo</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-6">
                        <asp:HiddenField ID="id" runat="server" />
                        <div class="form-group">
                            <asp:Label Text="Ano" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="ano" CssClass="form-control"/>
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="ano" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                            </div>  
                         </div>  
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Semestre" runat="server"/>
                            <div>
                                <asp:TextBox runat="server" ID="semestre" CssClass="form-control"/>
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="semestre" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Data Inicio" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="dat_ini" CssClass="form-control"/>
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="dat_ini" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                            </div>  
                         </div>  
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Data Fim" runat="server"/>
                            <div>
                                <asp:TextBox runat="server" ID="dat_fim" CssClass="form-control"/>
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="dat_fim" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
             
                <div>
                    <asp:Button CssClass="btn btn-success" runat="server" Text="Salvar" OnClick="Save_Click" UseSubmitBehavior="true" />
                    <a href="Index.aspx" title="Cancelar" class="btn btn-default">Cancelar</a>
                </div>
            </div>
        </div>
     </div>
</asp:Content>
