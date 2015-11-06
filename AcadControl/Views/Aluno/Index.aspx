<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AcadControl.Views.Aluno.Index" %>
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
                        <asp:TextBox runat="server" CssClass="form-control" ID="nome_alu" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Matricula" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="mat_alu" />
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
                <div>
                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Pesquisar" OnClick="Pesquisar_Click" UseSubmitBehavior="true" />
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Alunos</h3>
            </div>
            <div class="panel-body">
                <a href="Form.aspx" title="Novo Aluno" class="btn btn-primary">Novo Aluno</a>
                <br/><br/>
                <asp:GridView ID="AlunosList" runat="server" DataKeyNames="mat_alu" OnRowDataBound="AlunosList_RowDataBound"
                    AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField HeaderText="Aluno" DataField="nom_alu" />
                        <asp:BoundField HeaderText="Data Nasc" DataField="dat_nasc" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField HeaderText="Media Geral" DataField="mgp" />
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
