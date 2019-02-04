<%@ Page Language="C#" MasterPageFile="~/MasterPerfil.master" AutoEventWireup="true" Inherits="sespAdmision" Codebehind="sepsAdmision.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>
<%@ Register Src="~/Perfiles/wucDatosPersonales.ascx" TagPrefix="uc1" TagName="wucDatosPersonales" %>
<%@ Register Src="~/Perfiles/wucOtrosDatos.ascx" TagPrefix="uc1" TagName="wucOtrosDatos" %>
<%@ Register Src="~/Perfiles/wucDatosDemograficos.ascx" TagPrefix="uc1" TagName="wucDatosDemograficos" %>
<%@ Register Src="~/Perfiles/wucEpisodioAdmision.ascx" TagPrefix="uc1" TagName="wucEpisodioAdmision" %>
<%@ Register Src="~/Perfiles/wucDatosAdmision.ascx" TagPrefix="uc1" TagName="wucDatosAdmision" %>






<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
   <%--   <link rel="stylesheet" href="Content/global.css" type="text/css">
    <script src="Scripts/UIFlujoPerfil.js"></script>--%>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    

   <%-- <div class="card">
        <div class="card-header">
            Próximo Paso. Usuario:<uc1:WUCUsuario runat="server" ID="WUCUsuario" />
 
        </div>
        <div class="card-block">

            <div class="row">
                <div class="col-md-3">
                    <div class ="card">

                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">IUP
           
                            <span>
                                <asp:Literal ID="LitIUP" runat="server"></asp:Literal></span>
                        </li>
                        <li class="list-group-item justify-content-between">Episodio
           
                            <span>
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaEpisodios"></asp:HyperLink>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">Licencia
           
                            <span>
                                <asp:Literal ID="LitLicencia" runat="server"></asp:Literal></span>
                        </li>

                        <li class="list-group-item justify-content-between">
                            <strong>Estatus</strong>
                            <span><strong>
                                <asp:Literal ID="LitEstatus" runat="server"></asp:Literal></strong></span>
                        </li>

                    </ul>


                    <p class="mb-4">Históricos:</p>


                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">

                            <span>
                                <asp:HyperLink ID="HLCitas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCitas"></asp:HyperLink>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">

                            <span>
                                <asp:HyperLink ID="HlCharlas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCharlas"></asp:HyperLink>
                            </span>
                        </li>
                    </ul>




                    <a href="entrada.aspx" class="btn btn-secondary btn-block mb-4">Salir del Registro de Usuario</a>
                   </div>
                </div>
           
      

               
               <div class="col-md-9">
               <div class="card">
                <div class="card-header">

                    <div class="row">
                       
                        <div class="col-md-4 text-left">
                            <span>
                               
                                Listado de Perfiles</span>
                        </div>
                    </div>

                </div>
                  
                    
                   <h1 style="display:inline">Perfil de admisión </h1> <h2 style="display:inline"><asp:Label ID="lblTipoPerfil" runat="server" ></asp:Label></h2>
                    <h1></h1>
                    <input type="hidden" id="hTipoPagina" value="admisión" />
                    <div>
                    
                        <uc1:wucDatosPersonales runat="server" id="wucDatosPersonales" />
                    </div>



                  </div>
                </div>                   


     </div>
   </div>
 </div>--%>
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
                   <h1 style="display:inline">Perfil de admisión </h1> <h2 style="display:inline"><asp:Label ID="lblTipoPerfil" runat="server" ></asp:Label></h2>
                    <h1></h1>
                    <input type="hidden" id="hTipoPagina" value="admisión" />
                    <div>
                     <%--   <uc1:wucDatosPersonales ID="wucDatosPersonales" runat="server" />--%>
                        <uc1:wucDatosPersonales runat="server" id="wucDatosPersonales" />
                        <br />
                        <uc1:wucOtrosDatos runat="server" ID="wucOtrosDatos" />
                        <br />
                        <uc1:wucDatosDemograficos runat="server" id="wucDatosDemograficos" />
                        <br />
                        <uc1:wucEpisodioAdmision runat="server" ID="wucEpisodioAdmision" />
                        <br />
                        <uc1:wucDatosAdmision runat="server" id="wucDatosAdmision" />
                    </div>
                       </div>


                  </div>
</asp:Content>
