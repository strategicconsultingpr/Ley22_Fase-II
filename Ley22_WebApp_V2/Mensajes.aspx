<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Mensajes" Codebehind="Mensajes.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">


        <div class="card mb-4">
            <div class="card-header">
                Mensajes :
            
            </div>

            <div class="card-block">
                <div class="alert alert-success mb-4" role="alert" runat="server" id="ColorBarra">
                    <asp:Literal ID="LitMensaje" runat="server"></asp:Literal>
                </div>
 
                 <a id="Redirect" runat="server" href="Dashboard-Usuarios.aspx" class="btn btn-primary mr-3">Continuar</a>
            </div>
            <!-- container-fluid -->
        </div>
    </div>

</asp:Content>

