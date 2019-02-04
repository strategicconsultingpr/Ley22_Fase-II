<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucOtrosDatos.ascx.cs" Inherits="Ley22_WebApp_V2.wucOtrosDatos" %>
<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Otros datos</h3>
  </div>
  <div class="panel-body">
    <div class="row">
    <div class="col-md-12 col-lg-6 SEPSDivsInfo"><%-- Nombre centro / Unidad de servicio --%>
        <span class="SEPSLabel">Nombre del centro / Unidad de servicio:</span>
        <asp:Label ID="lblCentro" runat="server"/>
    </div>
    <div class="col-print-6 col-md-6 col-lg-3 SEPSDivsInfo"><%--Número de Episodio --%>
        <span class="SEPSLabel">Número del episodio:</span>
        <asp:Label ID="lblEpisodio" runat="server"/>
        <asp:Label ID="lblEpisodioNuevo" runat="server" Visible="False">(Sin número asignado)</asp:Label>
    </div>
    <div class="col-print-6 col-md-6 col-lg-3 SEPSDivsInfo"><%-- Número de Perfil --%>
        <span class="SEPSLabel">Número del perfil:</span>
        <asp:Label ID="lblPerfil" runat="server"/>
        <asp:Label ID="lblPerfilNuevo" runat="server" Visible="False">(Sin número asignado)</asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-print-12 col-md-6 SEPSDivs"><%-- Seguro de Salud --%>
        <span class="SEPSLabel">Seguro de salud:</span>
       <div class="expandibleDiv">
            <asp:Label ID="lblSeguroSalud" runat="server"/>
        </div>
    </div>
    <div class="col-print-12 col-md-6 SEPSDivs"><%-- Fuente de pago --%>
        <span class="SEPSLabel">Fuente del pago:</span>
       <div class="expandibleDiv">
            <asp:Label ID="lblFuentePago" runat="server"/>
        </div>
    </div>
</div>
  </div>
</div>