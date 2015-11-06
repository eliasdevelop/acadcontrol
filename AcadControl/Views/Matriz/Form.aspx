<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="AcadControl.Views.Matriz.Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Matriz</h3>
            </div>
            <div class="panel-body">  
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
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Periodo" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="periodo" CssClass="form-control"/>
                                <asp:RequiredFieldValidator CssClass="error-message" runat="server"
                                ControlToValidate="periodo" ErrorMessage="Campo obrigatório" EnableClientScript="true"></asp:RequiredFieldValidator>
                            </div>  
                        </div>  
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Disciplinas" runat="server" />
                            <asp:checkboxlist ID="disciplinas" runat="server">
                            </asp:checkboxlist>  
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
