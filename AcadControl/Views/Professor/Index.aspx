<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AcadControl.Views.Professor.Index" %>
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
                    <asp:Label Text="Nome" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="nome_prof" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Matricula" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="mat_alu" />
                    </div>
                </div>
                <div>
                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Pesquisar" OnClick="Pesquisar_Click" UseSubmitBehavior="true" />
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Professores</h3>
            </div>
            <div class="panel-body">
                <a href="Form.aspx" title="Novo Professor" class="btn btn-primary">Novo Professor</a>
                <br/><br/>
                <asp:GridView ID="ProfessoresList" runat="server" DataKeyNames="id" OnRowDataBound="ProfessoresList_RowDataBound"
                    AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField HeaderText="Nome" DataField="nom_prof" />
                        <asp:BoundField HeaderText="Matricula" DataField="mat_prof" />
                        <asp:HyperLinkField Text="Editar" />
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
