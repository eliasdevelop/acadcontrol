<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="AcadControl.Views.Matricula.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Matricula</h3>
            </div>
            <div class="panel-body">  
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Semestre Letivo" runat="server" />
                            <div>
                                 <asp:DropDownList ID="periodo_letivo" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Selecione</asp:ListItem>
                                 </asp:DropDownList>    
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="periodo_letivo" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator> 
                            </div>
                        </div>
                    </div>                      
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Aluno" runat="server" />
                            <div>
                                 <asp:DropDownList ID="aluno" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Selecione</asp:ListItem>
                                 </asp:DropDownList>    
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="aluno" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator> 
                            </div>
                        </div>
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Disciplina" runat="server" />
                            <div>
                                 <asp:DropDownList ID="disciplina" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Selecione</asp:ListItem>
                                 </asp:DropDownList>    
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                            ControlToValidate="disciplina" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator> 
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
