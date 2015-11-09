<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AcadControl.Views.Turma.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
         <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Turmas</h3>
            </div>
            <div class="panel-body">
                <a href="Form.aspx" title="Nova Turma" class="btn btn-primary">Nova Turma</a>
                <br/><br/>
                <asp:GridView ID="TurmasList" runat="server" DataKeyNames="ano, semestre, id_disc"
                    AutoGenerateColumns="false" CssClass="table table-striped" >
                    <Columns>
                        <asp:TemplateField HeaderText="Semestre">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# String.Format("{0}.{1}", Eval("ano"), Eval("semestre")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Disciplina" DataField="disciplina.nom_disc"/>
                        <asp:BoundField HeaderText="Professor" DataField="professor.nom_prof" />
                        <asp:BoundField HeaderText="Vagas" DataField="vagas" />
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
