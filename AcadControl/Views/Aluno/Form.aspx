<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="AcadControl.Views.Aluno.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Aluno</h3>
            </div>
            <div class="panel-body">
                <asp:HiddenField ID="mat_alu" runat="server" />
                
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Nome" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="nom_alu" CssClass="form-control"/>
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="nom_alu" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                            </div>  
                         </div>  
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Data Nasc" runat="server"/>
                            <div>
                                <asp:TextBox runat="server" ID="dat_nasc" CssClass="form-control"/>
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="dat_nasc" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Curso" runat="server" />
                            <div>
                                 <asp:DropDownList ID="curso" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Selecione</asp:ListItem>
                                 </asp:DropDownList>    
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="curso" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator> 
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="MGP" runat="server" />
                            <div>
                                <asp:Label id="mgp" Text="" runat="server" />
                            </div>  
                         </div>  
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Total Creditos Cursados" runat="server" />
                            <div>
                                <asp:Label id="tot_cred" Text="" runat="server" />
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
