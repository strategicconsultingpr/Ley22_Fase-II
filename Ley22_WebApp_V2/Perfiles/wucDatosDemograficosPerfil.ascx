<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDatosDemograficosPerfil.ascx.cs" Inherits="Ley22_WebApp_V2.wucDatosDemograficosPerfil" %>

<input type="hidden" id="edadPerfil" runat="server" name="Hidden2"/>
<div class="panel panel-default">
<%-- <asp:Button ID="btnEdadAdmision" runat="server" CausesValidation="False"  style="display:none;" OnClick="edadAdmisionF"  />--%>
    <div class="panel-heading">
        <h3 class="panel-title">Datos demográficos</h3>
    </div>
    <div class="panel-body">
        <div class="row">
            <div class="col-md-6 SEPSDivs">
                <%-- Estado marital --%>
                <span class="SEPSLabel">Estado marital:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblEstadoMarital" runat="server" />
                </div>
            </div>
            <div class="col-md-6 SEPSDivs">
                <%-- Condicion laboral --%>
                <span class="SEPSLabel">Condición laboral:</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblCondLaboral" runat="server" />
                </div>
            </div>
            <div class="col-md-6 SEPSDivs">
                <%-- Si es varon --%>
                <span class="SEPSLabel">Si no participa en la fuerza laboral:</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblNoFueraLaboral" runat="server" />
                </div>
            </div>
            <div class="col-md-6 SEPSDivs">
                <%-- Número de hijos --%>
                <span class="SEPSLabel">Número de hijos:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblNumNinos" runat="server"></asp:Label>
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
            <div class="col-md-6 SEPSDivs">
                <%-- Ultimo grado completado --%>
                <span class="SEPSLabel">Último grado completado:</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblGrado" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Es desertor escolar --%>
                <span class="SEPSLabel">Es desertor escolar:</span>
                <div class="expandibleDiv">                    
                    <asp:Label ID="lblDesertorEscolar" runat="server" />
                </div>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs">
                <%-- Ha recibido eduacion especial --%>
                <span class="SEPSLabel">Ha recibido educación especial:</span>
               <div class="expandibleDiv">
                    <asp:Label ID="lblEducacionEspecial" runat="server" />
                </div>
            </div>
            <div class="col-md-6 SEPSDivs">
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
        <asp:UpdatePanel ID="updPN" runat="server">
            <ContentTemplate>
                
                <div class="row" runat="server" id="divLblCompFamiliar">
                    <div class="col-md-6"><span class="SEPSLabel">Composición familiar:</span>
                        <asp:Label ID="lblCompFamiliar" runat="server" /></div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col-md-6 SEPSDivs">
                <%-- Tamaño familia --%>
                <span class="SEPSLabel">Tamaño familia:</span>
                <div class="expandibleDiv"><asp:Label ID="lblNumFamilia" runat="server" />
                </div>
            </div>
            <div class="col-md-6 SEPSDivs">
                <%-- Fuente de ingreso --%>
                <span class="SEPSLabel">Residencia:</span>
                <div class="expandibleDiv">
                    <asp:Label ID="lblResidencia" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 SEPSDivs">
                <%-- Residencia --%>
                <span class="SEPSLabel">¿Cuántas veces ha participado de reuniones de grupo de apoyo, de auto-ayuda, religiosos o ha buscado ayuda de familiares, amigos u otros durante los pasados 30 días como apoyo a su proceso de recuperación?</span>
              </div>
             <div class="col-md-6 SEPSDivs">
                <div class="expandibleDiv">
                   <asp:Label ID="lblFreq_AutoAyuda" runat="server" />
                </div>
            </div>           
        </div>
        <div class="row">
            <div class="col-lg-6 SEPSDivs">
                <%-- Residencia --%>
                <span class="SEPSLabel">¿Ha sido arrestado durante los pasados 30 días?</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblArrestado" runat="server" />
                </div>
            </div> 
            <div class="col-lg-6 SEPSDivs">
                <%-- Residencia --%>
                <span class="SEPSLabel">Número de arrestos en tratamiento o en últimos 30 días:</span>
                <div class="expandibleDiv">
                   <asp:Label ID="lblArrestos30" runat="server" />
                </div>
            </div> 
        </div>
    </div>
</div>
