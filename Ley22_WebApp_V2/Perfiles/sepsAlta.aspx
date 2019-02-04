<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPerfil.master" AutoEventWireup="true" CodeBehind="sepsAlta.aspx.cs" Inherits="Ley22_WebApp_V2.sepsAlta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Perfiles/wucDatosPersonales.ascx" TagPrefix="uc1" TagName="wucDatosPersonales" %>
<%@ Register Src="~/Perfiles/wucOtrosDatosPerfil.ascx" TagPrefix="uc1" TagName="wucOtrosDatosPerfil" %>
<%@ Register Src="~/Perfiles/wucDatosDemograficosPerfil.ascx" TagPrefix="uc1" TagName="wucDatosDemograficosPerfil" %>
<%@ Register Src="~/Perfiles/wucEpisodioPerfil.ascx" TagPrefix="uc1" TagName="wucEpisodioPerfil" %>
<%@ Register Src="~/Perfiles/wucTakeHome.ascx" TagPrefix="uc1" TagName="wucTakeHome" %>
<%@ Register Src="~/Perfiles/wucDatosAlta.ascx" TagPrefix="uc1" TagName="wucDatosAlta" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Content/global.css" type="text/css">
    <%--<script src="Scripts/UIFlujoPerfil.js"></script>--%>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
                <div class="card-header">

                    <div class="row">
                       
                        <div class="col-md-4 text-left">
                            <span>
                                <%--<asp:Literal ID="LitCantidadUsuarios" runat="server"></asp:Literal>--%>
                                Listado de Perfiles</span>
                        </div>
                    </div>

                </div>
                  
                   <div id="page-content-wrapper"> 
                   <h1 style="display:inline">Perfil de alta </h1> <h2 style="display:inline"><asp:Label ID="lblTipoPerfil" runat="server" ></asp:Label></h2>
                    <h1></h1>
                    <input type="hidden" id="hTipoPagina" value="alta" />
                    <div>
                     <%--   <uc1:wucDatosPersonales ID="wucDatosPersonales" runat="server" />--%>
                        <uc1:wucDatosPersonales runat="server" id="wucDatosPersonales" />
                        <br />
                        <uc1:wucOtrosDatosPerfil runat="server" ID="wucOtrosDatosPerfil" />
                        <br />
                        <uc1:wucDatosDemograficosPerfil runat="server" id="wucDatosDemograficosPerfil" />
                        <br />
                        <uc1:wucEpisodioPerfil runat="server" ID="wucEpisodioPerfil" />
                        <br />
                        <uc1:wucTakeHome runat="server" id="wucTakeHome" />
                        <br />
                        <uc1:wucDatosAlta runat="server" id="wucDatosAlta" />
                    </div>
                       </div>


                  </div>


</asp:Content>
