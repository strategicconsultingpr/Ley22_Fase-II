<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucTakeHome.ascx.cs" Inherits="Ley22_WebApp_V2.wucTakeHome" %>

<div id="divTakeHome" runat="server">
    <div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Take Home</h3>
  </div>
  <div class="panel-body">

            <div class="row">
                <div class="col-lg-6 SEPSDivs"><%--Participa actualmente en el programa "Take Home"--%>
                    <span class="SEPSLabel">Participa actualmente en el programa "Take Home":</span>
                    <div class="expandibleDiv">                        
                        <asp:Label ID="lblTHBelong" runat="server"/>
                    </div>
                </div>
        <div class="col-lg-6 SEPSDivs Participa"><%--Etapa--%>
            <span class="SEPSLabel">Fase:</span>
            <div class="expandibleDiv">
                <asp:Label ID="lblTHEtapa" runat="server"/>
            </div>
        </div>            
            </div>
            <%--<div style="height:160px;" class="NoParticipa" runat="server" id="divRazon">
                          <asp:UpdatePanel ID="updTH" runat="server">
                            <ContentTemplate>
                            <div class="multipleLeft">  
                            <span class="SEPSLabel">Listado de razones (Disponibles)</span>     
                            <asp:ListBox CssClass="form-control"  ID="lbxRazonSeleccion" runat="server" EnableViewState ="true" Height="130px"/>
                            </div>               
               <div class="multipleRight">  
                    <span class="SEPSLabel">Listado de razones (Seleccionadas)</span>                

                    <asp:ListBox CssClass="form-control"  ID="lbxRazonSeleccionado" runat="server" EnableViewState ="true" CausesValidation="true" Height="130px" DataValueField="PK_" DataTextField="DE_"/>       
                </div>
                        </ContentTemplate>
            </asp:UpdatePanel>
            </div> --%>
            <div class="row NoParticipa" runat="server" id="divLblRazon">
                <div class="col-md-6 SEPSDivsInfo">
                    <span class="SEPSLabel">Razón de no participar:</span>
                    <asp:Label ID="lblRazon" runat="server"/>
                </div>
            </div>      

    <div class="row Participa" runat="server" id="divParticipa">
        <div class="col-lg-12 SEPSDivs"><%--Fecha de Entrada--%>
            <span class="SEPSLabel">Fecha de comienzo TH:</span>
                       
            <div class="leftFloat">
                <asp:Label ID="lblFE_In" runat="server"/>
            </div>
        </div>        
        <div class="col-lg-12 SEPSDivs"><%--Fecha de Salida--%>
            <span class="SEPSLabel">Fecha de terminación en TH:</span>                       
            <div class="leftFloat">
                <asp:Label ID="lblFE_Out" runat="server"/>
            </div>
        </div>


        <div class="col-md-6 SEPSDivs"><%--Número de botellas--%>
            <span class="SEPSLabel">Cantidad de botellas:</span>
            <div class="expandibleDiv">
                <asp:Label ID="lblCantidadBotellas" runat="server"/>
            </div>
        </div>
        <div class="col-md-6 SEPSDivs"><%--Frecuencia de botellas--%>
            <span class="SEPSLabel">Frecuencia de botellas:</span>
            <div class="expandibleDiv">
                <asp:Label ID="lblFrecuenciaBotellas" runat="server"/>
            </div>
        </div>
    </div>
  </div>
</div>

</div>