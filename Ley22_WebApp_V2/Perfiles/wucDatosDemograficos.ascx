<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDatosDemograficos.ascx.cs" Inherits="Ley22_WebApp_V2.wucDatosDemograficos" %>

<input type="hidden" id="edadAdmision" runat="server" name="Hidden2"/>
<div class="panel panel-default">
<%-- <asp:Button ID="btnEdadAdmision" runat="server" CausesValidation="False"  style="display:none;" OnClick="edadAdmisionF"  />--%>
    <div class="panel-heading">
        <h3 class="panel-title">Datos demográficos</h3>
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Estado marital --%>
                <span class="SEPSLabel">Estado marital:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblEstadoMarital" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Si es femina --%>
                <span class="SEPSLabel">Si es fémina:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblFemina" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Si es varon --%>
                <span class="SEPSLabel">Si es varón:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblVaron" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Número de hijos --%>
                <span class="SEPSLabel">Número de hijos:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblNumNinos" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-print-12 col-md-6 SEPSDivs">
                <%-- Condicion laboral --%>
                <span class="SEPSLabel">Condición laboral:</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblCondLaboral" runat="server" />
                </div>
            </div>
            <div class="col-print-12 col-md-6 SEPSDivs">
                <%-- Si no participa en la fuerza laboral --%>
                <span class="SEPSLabel">Si no participa en la fuerza laboral:</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblNoFueraLaboral" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>
<br />

<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title">Escolaridad</h3>
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-print-12 col-xs-12 col-lg-6 SEPSDivs">
                <%-- Ultimo grado completado --%>
                <span class="SEPSLabel">Último grado completado:</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblGrado" runat="server" />
                </div>
            </div>
            <div class="col-print-12 col-xs-12 col-md-6 SEPSDivs">
                <%-- Es desertor escolar --%>
                <span class="SEPSLabel">Es desertor escolar:</span>
                <div class="expandibleDiv">                    
                    <asp:Label ID="lblDesertorEscolar" runat="server" />
                </div>
            </div>
            <div class="col-print-12 col-md-6 SEPSDivs">
                <%-- Ha recibido eduacion especial --%>
                <span class="SEPSLabel">Ha recibido educación especial:</span>
               <div class="expandibleDiv">
                    <asp:Label ID="lblEducacionEspecial" runat="server" />
                </div>
            </div>
            <div class="col-print-12 col-xs-12 col-lg-12 SEPSDivs">
                <%-- Situacion Escolar--%>
                <span class="SEPSLabel">Situación escolar:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblSituacionEscolar" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>
<br />

<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title">Estructura familiar</h3>
    </div>
    <div class="panel-body">
        <asp:UpdatePanel ID="updCompFam" runat="server">
            <ContentTemplate>
                
                <div class="row" runat="server" id="divLblCompFamiliar">
                    <div class="col-md-6"><span class="SEPSLabel">Composición familiar:</span>
                        <asp:Label ID="lblCompFamiliar" runat="server" /></div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Tamaño familia --%>
                <span class="SEPSLabel">Tamaño familia:</span>
                <div class="expandibleDiv"><asp:Label ID="lblNumFamilia" runat="server" />
                </div>
            </div>
            <div class="col-print-12 col-md-6 SEPSDivs">
                <%-- Fuente de ingreso --%>
                <span class="SEPSLabel">Fuente de ingresos:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblFuenteIngreso" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Residencia --%>
                <span class="SEPSLabel">Residencia:</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblResidencia" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Tiempo en residencia --%>
                <span class="SEPSLabel">Tiempo en residencia:</span>
               <div class="expandibleDiv">
                    <asp:Label ID="lblTiempoResidencia" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Municipio --%>
                <span class="SEPSLabel">Municipio de residencia:</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblMunicipio" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-3 SEPSDivs">
                <%-- Zona Geografica --%>
                <span class="SEPSLabel">Zona geográfica:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblZonaGeografia" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-3 SEPSDivs">
                <%-- Codigo Postal --%>
                <span class="SEPSLabel">Código postal:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblZipCode" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>
