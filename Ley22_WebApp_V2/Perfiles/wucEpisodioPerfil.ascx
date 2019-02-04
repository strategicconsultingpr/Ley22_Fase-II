<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucEpisodioPerfil.ascx.cs" Inherits="Ley22_WebApp_V2.wucEpisodioPerfil" %>

<input id="CO_Tipo" type="hidden" name="Hidden2" runat="server"/>
<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Nivel de cuidado de este episodio</h3>
  </div>
  <div class="panel-body">
    <div class="row">   
        <div class="col-md-6"><%--Nivel de Cuidado Salud mental--%>
            <span class="SEPSLabel">Nivel de cuidado (Salud mental):</span>
            <div class="expandibleDiv">
            <asp:Label ID="lblNivelCuidadoSaludMental" runat="server"/>
            </div>
        </div>
        <div class="col-md-6"><%--Nivel de Cuidado Abuso de Sustancias--%>
            <span class="SEPSLabel">Nivel de cuidado (Abuso de sustancias):</span>
            <div class="expandibleDiv">
            <asp:Label ID="lblNivelCuidadoSustancias" runat="server" />
            </div> 
        </div>  
    </div>
  </div>
</div>
<br />

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Datos de salud general</h3>
  </div>
  <div class="panel-body">
   <asp:UpdatePanel ID="updCondicionDiagnosticada" runat="server">
    <ContentTemplate>   
        <div class="row" runat="server" id="divLblCondicionesDiagnosticadas">
            <div class="col-md-6">
                <span class="SEPSLabel">Condiciones diagnosticadas:</span>
                <asp:Label ID="lblCondicionesDiagnosticadas" runat="server"/>
            </div>
        </div>
     </ContentTemplate>
    </asp:UpdatePanel>
  </div>
</div>
<br />

<div id="DSMIV_DIV" name="DSMIV_DIV" runat="server">
    <div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Diagnóstico DSM 4</h3>
  </div>
  <div class="panel-body">
      <a class="btn btn-default" data-toggle="collapse" id="dsmiv_showContentButton" href="#dsmiv_content" onclick="dsmivShowHideClick();" aria-expanded="false" aria-controls="dsmiv_content">Mostrar contenido</a>
    <div class="collapse" id="dsmiv_content">
        <h3>I. Transtornos clínicos:</h3>
        <table class="table table-striped table-hover">
            <tr>
                <th></th>
                <th><span class="SEPSLabel">Diagnóstico</span></th>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Primario</span></td>
                <td>
                    <asp:Label ID="lblClinPrim" runat="server" />
                </td>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Secundario</span></td>
                <td>
                    <asp:Label ID="lblClinSec" runat="server" />
                </td>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Terciario</span></td>
                <td>
                    <asp:Label ID="lblClinTerc" runat="server" />
                </td>
            </tr>
        </table>
        <h3>II. Trastornos de la personalidad y RM:</h3>
        <table class="table table-striped table-hover">
            <tr>
                <th></th>
                <th><span class="SEPSLabel">Diagnóstico</span></th>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Primario</span></td>
                <td>
                    <asp:Label ID="lblRMPrim" runat="server" />
                </td>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Secundario</span></td>
                <td>
                    <asp:Label ID="lblRMSec" runat="server" />
                </td>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Terciario</span></td>
                <td>
                    <asp:Label ID="lblRMTerc" runat="server" />
                </td>
            </tr>
        </table>
        <h3>III. Condiciones médicas generales:</h3>
        <table class="table table-striped table-hover">
            <tr>
                <th></th>
                <th><span class="SEPSLabel">Diagnóstico</span></th>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Primario</span></td>
                <td>
                    <asp:Label ID="lblIIIP" runat="server" />
                </td>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Secundario</span></td>
                <td>
                    <asp:Label ID="lblIIIS" runat="server" />
                </td>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Terciario</span></td>
                <td>
                    <asp:Label ID="lblIIIT" runat="server" />
                </td>
            </tr>
        </table>
        <h3>IV. Problemas psicosociales y ambientales:</h3>
        <table class="table table-striped table-hover">
            <tr>
                <th></th>
                <th><span class="SEPSLabel">Diagnóstico</span></th>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Primario</span></td>
                <td>
                    <asp:Label ID="lblIVPrim" runat="server" />
                </td>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Secundario</span></td>
                <td>
                    <asp:Label ID="lblIVSec" runat="server" />
                </td>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Terciario</span></td>
                <td>
                    <asp:Label ID="lblIVTerc" runat="server" />
                </td>
            </tr>
        </table>
        <h3>V. Escala C-GAS / GAF:</h3>
        <table class="table table-striped table-hover">
            <tr>
                <th></th>
                <th><span class="SEPSLabel">Diagnóstico</span></th>
            </tr>
            <tr>
                <td><span class="SEPSLabel">Primario</span></td>
                <td>
                    <asp:Label ID="lblEscalaGAF" runat="server" />
                </td>
            </tr>
        </table>
        <h3>Diagnóstico dual:</h3>
        <table class="table table-striped table-hover">
            <tr>
                <th><span class="SEPSLabel">Diagnóstico dual</span></th>
                <th><asp:Label ID="lblDual" runat="server"></asp:Label></th>
            </tr>
        </table>
    </div>
  </div>
</div>
</div>
<br />


<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Diagnóstico</h3>
  </div>
  <div class="table-panel-body">
    <table class="table table-striped table-hover">
    <tr>
        <th style="width:250px;">&nbsp;</th>
        <th><span class="SEPSLabel">Diagnóstico primario</span></th>
        <th><span class="SEPSLabel">Diagnóstico secundario</span></th>
        <th><span class="SEPSLabel">Diagnóstico terciario</span></th>
    </tr>
    <tr>
        <th><span class="SEPSLabel">Trastornos clínicos</span></th>
        <td> 
           <div class="expandibleDiv">
               <asp:Label ID="lblDSMVClinPrim" runat="server" />
            </div>
        </td>
        <td>
           <div class="expandibleDiv">
               <asp:Label ID="lblDSMVClinSec" runat="server" />
            </div>
        </td>
        <td>
           <div class="expandibleDiv">
               <asp:Label ID="lblDSMVClinTer" runat="server"/>
             </div>
        </td>
    </tr>
    <tr>
        <th><span class="SEPSLabel">Trastornos de la personalidad y RM</span></th>
        <td>

            <div class="expandibleDiv">
                <asp:Label ID="lblDSMVRMPrim" runat="server" />
            </div>
        </td>
        <td>
            <div class="expandibleDiv">
               <asp:Label ID="lblDSMVRMSec" runat="server" />
           </div>
        </td>
        <td>
            <div class="expandibleDiv">
                <asp:Label ID="lblDSMVRMTer" runat="server" />
            </div>
        </td>
    </tr>
    <tr>
        <th><span class="SEPSLabel">Problemas psicosociales y ambientales</span></th>
        <td>
            <asp:Label ID="lblDSMVPsicoAmbiPrim" runat="server" />
        </td>
        <td>
            <asp:Label ID="lblDSMVPsicoAmbiSec" runat="server"/>
        </td>
        <td>
            <asp:Label ID="lblDSMVPsicoAmbiTer" runat="server"/>
        </td>
    </tr>
    <tr>
        <th><span class="SEPSLabel">Comentarios</span></th>
        <td colspan="3">
           <asp:label id="lblDSMVComentarios" runat="server"/>
        </td>
    </tr> 
    <tr>
        <th><span class="SEPSLabel">Diagnósticos concurrentes de salud mental y uso de sustancias</span></th>
        <td colspan="3">
           <asp:label id="lblDSMVDiagDual" runat="server"/>
        </td>
    </tr> 
    <tr>
        <th><span class="SEPSLabel">Funcionamiento global</span></th>
        <td colspan="3">
           <asp:label id="lblDSMVFnGlobal" runat="server"/>
        </td>
    </tr>
    <tr>
        <th><span class="SEPSLabel">Otras observaciones</span></th>
        <td colspan="3">
            <asp:label id="lblDSMVOtrasObs" runat="server"/>
        </td>
    </tr>
    <%--<tr>
        <th><span class="SEPSLabel">Diagnósticos concurrentes de salud mental y uso de sustancias</span></th>
        <td colspan="3">
            <asp:DropDownList CssClass="form-control" ID="ddlDSMVDiagDual2" runat="server">
                <asp:ListItem ></asp:ListItem>
                <asp:ListItem Value="1">Sí</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblDSMVDiagDual2" runat="server" />
        </td>
    </tr>--%>
</table>
  </div>
</div>
<br />

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Abuso de sustancias</h3>
  </div>
  <div class="table-panel-body">
    <table class="table table-striped table-hover">
    <tr>
        <th></th>
        <th><span class="SEPSLabel">Diagnóstico primario</span></th>
        <th><span class="SEPSLabel">Diagnóstico secundario</span></th>
        <th><span class="SEPSLabel">Diagnóstico terciario</span></th>
    </tr>
    <tr>
        <th><span class="SEPSLabel">Droga</span></th>
        <td><%--Diagnóstico Primario--%>
           <div class="expandibleDiv">
               <asp:Label ID="lblDrogaPrim" runat="server" />
            </div>
        </td>
        <td><%--Diagnóstico Secundario--%>
          <div class="expandibleDiv">
                <asp:Label ID="lblDrogaSec" runat="server" />
            </div>
        </td>
        <td><%--Diagnóstico Terciario--%>
           <div class="expandibleDiv">
               <asp:Label ID="lblDrogaTerc" runat="server" />
            </div>
        </td>
    </tr>
    <tr>
        <th><span class="SEPSLabel">Vía de utilización</span></th>
        <td><%--Diagnóstico Primario--%>
           <div class="expandibleDiv">
                <asp:Label ID="lblViaPrim" runat="server" />
            </div>
        </td>
        <td><%--Diagnóstico Secundario--%>
            <div class="expandibleDiv">
                <asp:Label ID="lblViaSec" runat="server" />
            </div>
        </td>
        <td><%--Diagnóstico Terciario--%>
           <div class="expandibleDiv">
                <asp:Label ID="lblViaTerc" runat="server" />
            </div>
        </td>
    </tr>
    <tr>
        <th><span class="SEPSLabel">Frecuencia de uso</span></th>
        <td><%--Diagnóstico Primario--%>
            <div class="expandibleDiv">
               <asp:Label ID="lblFrecPrim" runat="server" />
            </div>
        </td>
        <td><%--Diagnóstico Secundario--%>
            <div class="expandibleDiv">
               <asp:Label ID="lblFrecSec" runat="server" />
            </div>
        </td>
        <td><%--Diagnóstico Terciario--%>
           <div class="expandibleDiv">
                <asp:Label ID="lblFrecTerc" runat="server" />
            </div>
        </td>
    </tr>
    <tr>
        <th><span class="SEPSLabel">Edad de inicio</span></th>
        <td><%--Diagnóstico Primario--%>
           <div class="expandibleDiv">
                <asp:Label ID="lblEdadPrim" runat="server"/>
            </div>
        </td>
        <td><%--Diagnóstico Secundario--%>
           <div class="expandibleDiv">
               <asp:Label ID="lblEdadSec" runat="server"/>
            </div>
        </td>
        <td><%--Diagnóstico Terciario--%>
           <div class="expandibleDiv">
               <asp:Label ID="lblEdadTerc" runat="server"/>
            </div>
        </td>
    </tr>
</table>
  </div>
</div>
<br />

<div id="divPracticasBasadasEnEvidencia" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
        <h3 class="panel-title">Prácticas basadas en evidencia</h3>
        </div>
        <div class="panel-body">
        <h3 id="h3PracticasBasadasEnEvidenciaNinoOAdulto" runat="server">Niños y adolescentes o adultos</h3>
        <asp:UpdatePanel ID="updPracticasBasadasEvidencia" runat="server">
            <ContentTemplate>                                            
            <div class="row" runat="server" id="divLblPracticasBasadasEvidencia">
                <div class="col-md-6">
                <span class="SEPSLabel">Prácticas basadas en evidencia:</span>
                <asp:Label ID="lblPracticasBasadasEvidencia" runat="server"/>
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>  
</div>