<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AcadControl.Views.PeriodoLetivo.Index" %>
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
                    <asp:Label Text="Ano" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="ano" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Semestre" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="semestre" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Data Inicio" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="dat_ini" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Data Fim" runat="server" />
                    <div>
                        <asp:TextBox runat="server" CssClass="form-control" ID="dat_fim" />
                    </div>
                </div>
                <div>
                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Pesquisar" OnClick="Pesquisar_Click" UseSubmitBehavior="true" />
                </div>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Período Letivo</h3>
            </div>
            <div class="panel-body">
                <a href="Form.aspx" title="Novo Periodo Letivo" class="btn btn-primary">Novo Periodo Letivo</a>
                <br/><br/>
                <asp:GridView ID="PeriodoLetivoList" runat="server" DataKeyNames="ano, semestre" OnRowDataBound="PeriodoLetivoList_RowDataBound"
                    AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:BoundField HeaderText="Semestre" DataField="ano" />
                        <asp:BoundField HeaderText="Data Inicio" DataField="dat_ini" />
                        <asp:BoundField HeaderText="Data Fim" DataField="dat_fim" />
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
