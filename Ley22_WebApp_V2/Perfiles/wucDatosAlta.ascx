<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDatosAlta.ascx.cs" Inherits="Ley22_WebApp_V2.wucDatosAlta" %>
    <div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Razón de alta</h3>
  </div>
  <div class="panel-body">
        <div class="row">
        <div class="col-md-12 SEPSDivs"><%--Razón de Alta--%>
            <span class="SEPSLabel SEPSDivs">Razón de alta:</span>
            <div class="expandibleDiv">
                <asp:label id="lblRazonAlta" runat="server"/>
            </div>
        </div>
        <div class="col-md-6 SEPSDivs"><%--Centro Traslado--%>
            <span class="SEPSLabel">Centro de traslado:</span>
            <div class="expandibleDiv">
               <asp:label id="lblCentroReferido" runat="server"/>
            </div>
        </div>
        <div class="col-md-6 SEPSDivs"><%--Categoría de centro privado--%>
            <span class="SEPSLabel">Categoría de centro privado:</span>
            <div class="expandibleDiv">
                <asp:label id="lblCategoriaDeCentroPrivado" runat="server"/>
            </div>
        </div>
    </div>
  </div>
</div>

    <div class="panel panel-default" id="divComentarios" runat="server">
  <div class="panel-heading">
    <h3 class="panel-title">Comentarios</h3>
  </div>
  <div class="panel-body">
        <div class="row">
        <div class="col-xs-12"><%--Comentarios--%>
          <asp:Label ID="lblComentario" runat="server" Width="100%"/>
        </div>
    </div>
  </div>
</div>