<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/App.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="AcadControl.Views.Matricula.Edit" %>
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
                                <asp:TextBox runat="server" ID="periodo_letivo" CssClass="form-control" ReadOnly="true"/>
                            </div>
                        </div>
                    </div>                      
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Aluno" runat="server" />
                            <div>
                                 <asp:DropDownList ID="aluno" runat="server" CssClass="form-control" Enabled="False">
                                    <asp:ListItem Value="">Selecione</asp:ListItem>
                                 </asp:DropDownList>    
                            </div>
                        </div>
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Disciplina" runat="server" />
                            <div>
                                 <asp:DropDownList ID="disciplina" runat="server" CssClass="form-control" Enabled="False">
                                    <asp:ListItem Value="">Selecione</asp:ListItem>
                                 </asp:DropDownList>    
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Nota 01" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="nota01" CssClass="form-control"/>
                            </div>
                        </div>
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Faltas 01" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="faltas01" CssClass="form-control"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Nota 02" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="nota02" CssClass="form-control"/>
                            </div>
                        </div>
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Faltas 02" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="faltas02" CssClass="form-control"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Nota 03" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="nota03" CssClass="form-control"/>
                            </div>
                        </div>
                    </div> 
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label Text="Faltas 03" runat="server" />
                            <div>
                                <asp:TextBox runat="server" ID="faltas03" CssClass="form-control"/>
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
