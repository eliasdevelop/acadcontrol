<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AcadControl.Views.Matriz.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Filtro</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <asp:Label Text="Periodo" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="periodo" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Curso" runat="server" />
                    <div>
                         <asp:DropDownList ID="curso" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">Selecione</asp:ListItem>
                         </asp:DropDownList>     
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Disciplina" runat="server" />
                    <div>
                         <asp:DropDownList ID="disciplina" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">Selecione</asp:ListItem>
                         </asp:DropDownList>     
                    </div>
                </div>
                <div>
                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Pesquisar" OnClick="Pesquisar_Click" UseSubmitBehavior="true" />
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Matriz</h3>
            </div>
            <div class="panel-body">
                <a href="Form.aspx" title="Nova Matriz" class="btn btn-primary">Nova Matriz</a>
                <br/><br/>
                <asp:GridView ID="MatrizList" runat="server" DataKeyNames="id_curso, id_disc" AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField HeaderText="Curso" DataField="curso.nom_curso" />
                        <asp:BoundField HeaderText="Periodo" DataField="periodo" />
                        <asp:BoundField HeaderText="Disciplina" DataField="disciplina.nom_disc" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="Remover" runat="server" Text="Remover"
                                    OnClick="Delete_Click" CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
