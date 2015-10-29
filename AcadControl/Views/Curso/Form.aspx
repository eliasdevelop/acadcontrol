<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="AcadControl.Views.Curso.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Curso</h3>
            </div>
            <div class="panel-body">
                <asp:HiddenField ID="id" runat="server" />
                
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Nome" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="nom_curso" CssClass="form-control"/>
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="nom_curso" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                            </div>  
                         </div>  
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Creditos" runat="server"/>
                            <div>
                                <asp:TextBox runat="server" ID="tot_cred" CssClass="form-control"/>
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="tot_cred" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Prof Responsável" runat="server" />
                            <div>
                                <asp:DropDownList ID="professor" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Selecione</asp:ListItem>
                                </asp:DropDownList>              
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
