<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucEpisodioAdmision.ascx.cs" Inherits="Ley22_WebApp_V2.wucEpisodioAdmision" %>

<input id="CO_Tipo" type="hidden" name="Hidden2" runat="server"/>
<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Nivel de cuidado de este episodio</h3>
  </div>
  <div class="panel-body">
    <div class="row">
    <div class="col-md-12 SEPSDivs">
        <span class="SEPSLabel">Diagnósticos concurrentes de salud mental y uso de sustancias</span>
        <div class="expandibleDiv">
            <asp:Label ID="lblDSMVDiagDual" runat="server" />
        </div>

    </div>
    <div class="col-md-12 SEPSDivs"><%--Etapa del servicio--%>
        <span class="SEPSLabel">Etapa del servicio:</span>
          <div class="expandibleDiv">
         <asp:Label ID="lblEtapaServicio" runat="server" />
      
        </div>
    </div>
    <div class="col-md-7 SEPSDivs"><%--Nivel de Cuidado Abuso de Sustancias--%>
        <span class="SEPSLabel">Nivel de cuidado (Abuso de sustancias):</span>
        <div class="expandibleDiv">
       <asp:Label ID="lblNivelCuidadoSustancias" runat="server" />
     
            </div> 
    </div>
    <div class="col-md-5 SEPSDivs"><%--Días de espera para entrar a tratamiento--%>
        <span class="SEPSLabel">Días de espera para entrar a tratamiento:</span>
        <div class="expandibleDiv">
        <asp:Label ID="lblDíasSustancias" runat="server"/>
    
            </div>
    </div>
    <div class="col-md-12 SEPSDivs"><%--Usa metadona como parte del tratamiento?--%>
        <span class="SEPSLabel">¿Usa medicamento como parte del tratamiento contra la dependencia de opiáceos?:</span>
         <div class="expandibleDiv">
        <asp:Label ID="lblMetadona" runat="server" />
      
            </div>
    </div>
    <div class="col-md-12 SEPSDivs"><%--Co- dependiente?--%>
        <span class="SEPSLabel">¿Co-dependiente?:</span>
         <div class="expandibleDiv">
        <asp:Label ID="lblCodependiente" runat="server"/>
     
            </div>
    </div>
    <div class="col-md-7 SEPSDivs"><%--Nivel de Cuidado Salud mental--%>
        <span class="SEPSLabel">Nivel de cuidado (Salud mental):</span>
        <div class="expandibleDiv">
       <asp:Label ID="lblNivelCuidadoSaludMental" runat="server"/>
            </div>
    </div>
    <div class="col-md-5 SEPSDivs"><%--Días de espera para entrar a tratamiento--%>  
        <span class="SEPSLabel">Días de espera para entrar a tratamiento:</span>
        <div class="expandibleDiv">
        <asp:Label ID="lblDíasMental" runat="server"/>
               
            </div>
    </div>
</div>
  </div>
</div>
<br />
<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Otros</h3>
  </div>
  <div class="panel-body">
   <div class="row">
    <div class="col-md-6 SEPSDivs"><%--Fuente del referido--%>
        <span class="SEPSLabel">Fuente del referido:</span>
        <div class="expandibleDiv">
        <<asp:Label ID="lblFuenteReferido" runat="server"/>
       
    </div>
    </div>
    <div class="col-md-6 SEPSDivs"><%--Estado legal del referido--%>
        <span class="SEPSLabel">Estado legal del referido:</span>
       <div class="expandibleDiv">
        <asp:Label ID="lblEstadoLegal" runat="server"/>
            </div>
    </div>
    <div class="col-md-6 SEPSDivs"><%--Ha sido arrestado anteriormente--%>
        <span class="SEPSLabel">¿Ha sido arrestado anteriormente?:</span>
       <div class="expandibleDiv">
            <asp:Label ID="lblArrestado" runat="server"/>
        </div>
    </div>
    <div class="col-md-6 SEPSDivs"><%--Ha sido arrestado en los últ. 30 días--%>
        <span class="SEPSLabel">¿Ha sido arrestado en los pasados 30 días?</span>
        <div class="expandibleDiv">
            <asp:Label ID="lblArrestado30" runat="server"/>       
        </div>
    </div>    
    <div class="col-md-6 SEPSDivs"><%--Núm. de arrestos en tratamiento o en últimos 30 días--%>
        <span class="SEPSLabel">Número de arrestos en los pasados 30 días:</span>
            <div class="expandibleDiv">
                <asp:Label ID="lblArrestos30" runat="server"/>
            </div>
    </div>
</div>
<asp:UpdatePanel ID="updCompFam" runat="server">
    <ContentTemplate>       
        <div class="row" runat="server" id="divLblProbJusticia">
            <div class="col-md-6">
                <span class="SEPSLabel">Problemas de justicia:</span>
                <asp:Label ID="lblProbJusticia" runat="server"/>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
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

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Información del episodio anterior de servicio de abuso de sustancias</h3>
  </div>
  <div class="panel-body">
    <div class="row">
    <div class="col-md-12 SEPSDivs"><%--Episodios previos al tratamiento--%>
        <span class="SEPSLabel">Episodios previos al tratamiento:</span>
         <div class="expandibleDiv">
       <asp:Label ID="lblPreviosSustancias" runat="server"/>
      
    </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12 SEPSDivs"><%--Duracion del ultimo episodio de servicio de abuso de sustancias--%>
        <span class="SEPSLabel">Duración del último episodio de servicio de abuso de sustancias:</span>
        <div class="expandibleDiv">
       <asp:Label ID="lblUltSustancias" runat="server"/>

    </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12 SEPSDivs"><%--Tiempo desde la ultima alta de servicio para abuso de sustancias--%>
        <span class="SEPSLabel">Tiempo desde la última alta de servicio para abuso de sustancias:</span>
        <div class="leftFloat">
           <asp:Label ID="lblDíasSustUlt" runat="server"/>
        </div>
        <div class="leftFloat">
            <span>días</span>
        </div>
        <div class="leftFloat">
        <asp:Label ID="lblMesesSustUlt" runat="server"/>
         </div>
        <div class="leftFloat">
        <span>meses</span>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12 SEPSDivs"><%--Nivel de cuidado--%>
        <span class="SEPSLabel">Nivel de cuidado:</span>
        <div class="expandibleDiv">
        <asp:Label ID="lblNivelSustancias" runat="server"/>
    </div>
    </div>
</div>
  </div>
</div>
<br />

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Información del episodio anterior de servicio de salud mental</h3>
  </div>
  <div class="panel-body">
    <div class="row">
    <div class="col-md-12 SEPSDivs"><%--Episodios previos al tratamiento--%>
        <span class="SEPSLabel">Episodios previos al tratamiento:</span>
        <div class="expandibleDiv">
        <asp:Label ID="lblPreviosMental" runat="server"/>
    </div>
  </div>
</div>
<div class="row">
    <div class="col-md-12 SEPSDivs"><%--Duración del último episodio de servicio de salud mental--%>
        <span class="SEPSLabel">Duración del último episodio de servicio de salud mental:</span>
         <div class="expandibleDiv">
         <asp:Label ID="lblUltMental" runat="server"/>
       
    </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12 SEPSDivs"><%--Tiempo desde la última alta de servicio para salud mental--%>
        <span class="SEPSLabel">Tiempo desde la última alta de servicio para salud mental:</span>
        <div class="leftFloat">
        <asp:Label ID="lblDíasMentUlt" runat="server"/>
            </div>
        <div class="leftFloat">
            <span>días</span>
        </div>
        <div class="leftFloat">
        <asp:Label ID="lblMesesMentUlt" runat="server"/>
                 </div>
        <div class="leftFloat">
            <span>meses</span>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12 SEPSDivs"><%--Nivel de cuidado--%>
        <span class="SEPSLabel">Nivel de cuidado:</span>
       <div class="expandibleDiv">
       <asp:Label ID="lblNivelMental" runat="server" />
    
    </div>
    </div>
</div>
  </div>
</div>
<br />

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Violencia doméstica</h3>
  </div>
  <div class="panel-body">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-6 SEPSDivs"><%--Existe historial de ideas suicidas?--%>
                <span class="SEPSLabel">¿Existe historial de ideas suicidas?:</span>
                <asp:Label ID="lblIdeaSuicida" runat="server" />
               <div class="expandibleDiv">
                
    </div>
            </div>
            <div class="col-md-6 SEPSDivs"><%--Existe historial de intentos de suicidios?--%>
                <span class="SEPSLabel">¿Existe historial de intentos de suicidios?:</span>
                <div class="expandibleDiv">                
                <asp:Label ID="lblSuicidios" runat="server" />
               
                    </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 SEPSDivs"><%--Existe historial de maltrato en la niñez?--%>
                <span class="SEPSLabel">¿Existe historial de maltrato en la niñez?:</span>
                <div class="expandibleDiv">
                
                <asp:Label ID="lblMaltratoNinez" runat="server" />
               
        </div>
            </div>
        </div>             
        <div class="row" runat="server" id="divLblMaltrato">
            <div class="col-md-6">
                <span class="SEPSLabel">Tipos de maltrato:</span>
                <asp:Label ID="lblMaltrato" runat="server"/>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<div class="row">
    <div class="col-md-12 SEPSDivs"><%--Ha sido victima de violencia doméstica?--%>
        <span class="SEPSLabel">¿Ha sido victima de violencia doméstica?:</span>
       <div class="expandibleDiv">
        <asp:Label ID="lblVioDomestic" runat="server" />
            </div>
    </div>
</div>
<div class="row">
    <div class="col-md-6 SEPSDivs">
        <span class="SEPSLabel">¿Ha participado en reuniones de grupos de apoyo, auto-ayuda, religiosas o ha buscado ayuda a su tratamiento de familiares, amigos u otros durante los pasados 30 días?:</span>
    </div>
    <div class="clearfix visible-xs-block"></div>
    <div class="clearfix visible-sm-block"></div>    
    <div class="col-md-6 SEPSDivs"><%--Ha participado en reuniones de grupos de apoyo, auto-ayuda, religiosas o ha buscado ayuda a su tratamiento de familiares, amigos u otros durante los pasados 30 días?--%>
        <div class="expandibleDiv">
        <asp:Label ID="lblReunionesGrupos" runat="server" />
        </div>
       
    </div>
</div>
<div class="row">
    <div class="col-md-6 SEPSDivs">
        <span class="SEPSLabel">¿Cuántas veces ha participado de reuniones de grupo de apoyo, de auto-ayuda, religiosos o ha buscado ayuda de familiares, amigos u otros durante los pasados 30 días como apoyo a su proceso de recuperación?</span>
    </div>
    <div class="clearfix visible-xs-block"></div>
    <div class="clearfix visible-sm-block"></div>
    <div class="col-md-6 SEPSDivs"><%--¿Cuántas veces ha participado de reuniones de grupo de apoyo, de auto-ayuda, religiosos o ha buscado ayuda de familiares, amigos u otros durante los pasados 30 días como apoyo a su proceso de recuperación?--%>
       <div class="expandibleDiv">
           <asp:Label ID="lblFreq_AutoAyuda" runat="server" />
        </div>
    </div>
</div>
  </div>
</div>
<br />

<div id="DSMIV_DIV" name="DSMIV_DIV" runat="server">
    <div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Diagnóstico DSM 4</h3>
  </div>
  <div class="table-panel-body">
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