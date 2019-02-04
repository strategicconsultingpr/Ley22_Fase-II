<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucOtrosDatosPerfil.ascx.cs" Inherits="Ley22_WebApp_V2.wucOtrosDatosPerfil" %>

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Otros datos</h3>
  </div>
  <div class="panel-body">
    <div class="row">   
    <div class="col-print-6 col-md-6 SEPSDivsInfo"><%--Número de Episodio --%>
        <span class="SEPSLabel">Número del episodio:</span>
        <asp:Label ID="lblEpisodio" runat="server"/>
        <%--<asp:Label ID="lblEpisodioNuevo" runat="server" Visible="False">(Sin número asignado)</asp:Label>--%>
    </div>
    <div class="col-print-6 col-md-6 SEPSDivsInfo"><%-- Número de Perfil --%>
        <span class="SEPSLabel">Número del perfil:</span>
        <asp:Label ID="lblPerfil" runat="server"/>
        <asp:Label ID="lblPerfilNuevo" runat="server" Visible="False">(Sin número asignado)</asp:Label>
    </div>
        <div class="col-md-6 SEPSDivsInfo"><%-- Administración auxiliar --%>
        <span class="SEPSLabel">Administración auxiliar de:</span>       
            <asp:Label ID="lblAdministracion" runat="server"/>        
    </div>
    <div class="col-md-6 SEPSDivsInfo"><%-- Nombre del centro / Unidad de servicio --%>
        <span class="SEPSLabel">Nombre del centro / Unidad de servicio:</span>      
            <asp:Label ID="lblCentro" runat="server"/>        
    </div>
   </div>
<div class="row">
    <div class="col-lg-6 SEPSDivs"><%--Fecha de Perfil--%>
        <span class="SEPSLabel" id="fechaPerfil">Fecha del perfil:</span>
        <div class="leftFloat">
            <asp:Label ID="lblFechaPerfil" runat="server"></asp:Label>
        </div>
    </div>

    <div class="col-lg-6 SEPSDivs"><%--Fecha de Perfil--%>
        <span class="SEPSLabel">Fecha de último contacto:</span>
        <div class="leftFloat">
            <asp:Label ID="lblFechaContacto" runat="server"></asp:Label>
        </div>
    </div>

</div>


  </div>
</div>