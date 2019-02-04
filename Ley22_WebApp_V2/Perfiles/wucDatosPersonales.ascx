﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="wucDatosPersonales" Codebehind="wucDatosPersonales.ascx.cs" %>

<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Datos generales</h3>
  </div>
  <div class="panel-body">

      <%--<asp:Repeater ID="datospersonalesInfo" runat="server">
          <ItemTemplate>--%>
    <div class="row">
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- IUP --%>
        <span class="SEPSLabel" title='Identificador Único de Persona. Código único para cada persona registrada en el sistema. Toda persona tiene un número global diferente que lo identifica univocamente dentro del sistema, y lo diferencia de todos las otras personas registradas. Este código de obiene luego de registrar una persona por medio de la funcionalidad "Registrar" del menú "Persona".'>IUP:</span>
        <asp:Label ID="lblUID" runat="server" />
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Expediente --%>
        <span class="SEPSLabel" title='Número entero que identifica una persona para un programa particular. Toda persona debe puede tener mas de un número de expediente diferente dado que haya participado en más de un programa.'>Expediente:</span>
        <%-- <asp:RequiredFieldValidator ID="valExpediente" runat="server" CssClass="rightFloatAsterisk" ErrorMessage="El Expediente en un campo requerido." ControlToValidate="txtExpediente" Display="Dynamic" Text="*"/>
        <asp:RangeValidator ID="valExpedienteRango" runat="server" CssClass="rightFloatAsterisk" ControlToValidate="txtExpediente" Display="Dynamic" ErrorMessage="El expediente tiene que se un número entero entre 1 y 999.999.999" MaximumValue="999999999999" MinimumValue="000000000001" Text="*"/>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  CssClass="rightFloatAsterisk"  ControlToValidate="txtExpediente" Display="Dynamic" ErrorMessage="El expediente tiene que ser un número. No puede contener letras." ValidationExpression="(\d{1})?(\d{1})?(\d{1})?(\d{1})?(\d{1})?(\d{1})?(\d{1})?(\d{1})?(\d{1})?(\d{1})?(\d{1})?(\d{1})?" Text="*" />--%>
        <div class="expandibleDiv">
            <%--<asp:TextBox  CssClass="form-control" ID="txtExpediente" runat="server" ToolTip="Escriba un número de expediente válido para el programa en que esta usted registrado. Este atributo es requerido para crear un nuevo registro de persona." MaxLength="12"/> --%>       
            <asp:Label ID="lblExpediente" runat="server" />
        </div>
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Seguro Social --%>
        <span class="SEPSLabel">Seguro social:</span>
        <asp:Label ID="lblNSS" runat="server" />
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Sexo --%>
        <span class="SEPSLabel">Sexo:</span>
        <asp:Label ID="lblSexo" runat="server" />
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Primer apellido --%>
        <span class ="SEPSLabel">Primer apellido:</span>
        <asp:Label ID="lblPrimerApellido" runat="server" />
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Segundo apellido --%>
        <span class="SEPSLabel">Segundo apellido:</span>
        <asp:Label ID="lblSegundoApellido" runat="server" />
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Primer nombre --%>
        <span class="SEPSLabel">Primer nombre:</span>
        <asp:Label ID="lblPrimerNombre" runat="server" />
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Segundo nombre--%>
        <span class="SEPSLabel">Segundo nombre:</span>
        <asp:Label ID="lblSegundoNombre" runat="server" />
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Fecha de Nacimiento --%>
        <span class="SEPSLabel">Fecha de nacimiento:</span>
        <asp:Label ID="lblFENacimiento" runat="server" />
        <input id="lblFENacimientoHidden" runat="server" type="hidden" />
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Edad --%>
        <span class="SEPSLabel">Edad:</span>
        <asp:Label ID="lblEdad" runat="server"  OnLoad="lblEdad_Load"/>
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Veterano --%>
        <span class="SEPSLabel">Veterano:</span>
        <asp:Label ID="lblVeterano" runat="server" />
    </div>
    <div class="col-print-6 col-sm-6 col-lg-3 SEPSDivsInfo"><%-- Grupo Etnico --%>
        <span class="SEPSLabel">Grupo étnico:</span>
        <asp:Label ID="lblGrupoEtnico" runat="server" />
  </div>
</div>
              <%--</ItemTemplate>
      </asp:Repeater>--%>

        <div class="row">
            <div class="col-lg-6 SEPSDivs"><%-- Fecha de Admision  --%>
                <span class="SEPSLabel">Fecha de admisión:</span>
                <div class="leftFloat">
                    <asp:DropDownList  CssClass="form-control" Width="120px" ID="ddlMes" runat="server" >
                        <asp:ListItem Value="1">Enero</asp:ListItem>
                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                        <asp:ListItem Value="4">Abril</asp:ListItem>
                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                        <asp:ListItem Value="6">Junio</asp:ListItem>
                        <asp:ListItem Value="7">Julio</asp:ListItem>
                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="leftFloat">
                    <asp:DropDownList  CssClass="form-control" Width="65px"  ID="ddlDía" runat="server" >
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="26">26</asp:ListItem>
                        <asp:ListItem Value="27">27</asp:ListItem>
                        <asp:ListItem Value="28">28</asp:ListItem>
                        <asp:ListItem Value="29">29</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="31">31</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="leftFloat">
                    <asp:TextBox  CssClass="form-control"  ID="txtAño" runat="server" autocomplete="off" />
                </div>
                <asp:RequiredFieldValidator ID="rfvFechaAdmision"  CssClass="leftFloatAsterisk" runat="server" ControlToValidate="txtAño" Display="Dynamic" ErrorMessage="Fecha de admisión" Text="*"/>
                <asp:RangeValidator ID="rvAño" runat="server"  CssClass="leftFloatAsterisk" ControlToValidate="txtAño" Display="Dynamic" ErrorMessage="Fecha admisión" Text="*"/>
                <asp:Label ID="lblFechaAdmision" runat="server"/>
                <input id="ddlMesHidden" runat="server" type="hidden"/>
                <input id="ddlDíaHidden" runat="server" type="hidden"/>
                <input id="txtAñoHidden" runat="server" type="hidden"/>
                <asp:Label ID="lblFechaError" runat="server" ForeColor="Red"/>
            </div>
            <div class="col-lg-6 SEPSDivs" id="divMesesDesdeAdmision" runat="server"><%-- Meses desde Admision  --%>
                <span class="SEPSLabel">Meses desde admisión:</span>
                <asp:Label ID="lblMesesDesdeAdmision" runat="server"/>
                <asp:HiddenField ID = "hiddenFechaUltimaEvaluacion" runat="server" />
            </div>
            <div id="divFechaConvenio" runat="server" class="col-md-6 SEPSDivs"><%-- Fecha de Convenio --%>
                <span class="SEPSLabel">Fecha de convenio:</span>
                <div class="leftFloat">
                    <asp:DropDownList  CssClass="form-control" ID="ddlFechaConvenioMes"  runat="server">
                        <asp:ListItem Value="1">Enero</asp:ListItem>
                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                        <asp:ListItem Value="4">Abril</asp:ListItem>
                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                        <asp:ListItem Value="6">Junio</asp:ListItem>
                        <asp:ListItem Value="7">Julio</asp:ListItem>
                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="leftFloat">
                <asp:DropDownList  CssClass="form-control"  ID="ddlFechaConvenioDía" runat="server" >
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                    <asp:ListItem Value="19">19</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="21">21</asp:ListItem>
                    <asp:ListItem Value="22">22</asp:ListItem>
                    <asp:ListItem Value="23">23</asp:ListItem>
                    <asp:ListItem Value="24">24</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                    <asp:ListItem Value="26">26</asp:ListItem>
                    <asp:ListItem Value="27">27</asp:ListItem>
                    <asp:ListItem Value="28">28</asp:ListItem>
                    <asp:ListItem Value="29">29</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="31">31</asp:ListItem>
                </asp:DropDownList>
                </div>
                <div class="leftFloat">
                    <asp:TextBox  CssClass="form-control"  ID="txtFechaConvenioAño" runat="server" MaxLength="4" Width="80px" AutoPostBack="True"/>
                </div>
                <asp:HiddenField ID="hProgramaAdultos" runat="server" Value=""/>
                <asp:Label ID="lblFechaConvenio" runat="server"/>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs" id="divMilitar" runat="server"><%-- Militar --%>
                <span class="SEPSLabel">Militar:</span>
                <asp:RequiredFieldValidator ID="rfvMilitar" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Militar" ControlToValidate="ddlMilitar" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                    <asp:DropDownList CssClass="form-control" ID="ddlMilitar" runat="server" />
                    <asp:Label ID="lblMilitar" runat="server"/>
                </div>
                
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs" id="divFamiliaMilitar" runat="server"><%-- Familia de Militar--%>
                <span class="SEPSLabel">Familiar de militar:</span>
                <asp:RequiredFieldValidator ID="rfvFamiliaMilitar" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Familia militar" ControlToValidate="ddlFamiliaMilitar" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                    <asp:DropDownList CssClass="form-control" ID="ddlFamiliaMilitar" runat="server">
                        <asp:ListItem Value="1">Sí</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                        <asp:ListItem Value="3">No informo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblFamMilitar" runat="server"/>
                </div>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs"><%-- Genero --%>
                <span class="SEPSLabel">Género:</span> 
                <asp:RequiredFieldValidator ID="rfvGenero" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Género" ControlToValidate="ddlGenero" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                    <asp:DropDownList CssClass="form-control" ID="ddlGenero" runat="server"/>
                    <asp:Label ID="lblGenero" runat="server"/>
                </div>
            </div>
            <div class="col-print-6 col-md-6 SEPSDivs" id="divTipoDeAdmision" runat="server"><%--Tipo de admisión--%>
                <span class="SEPSLabel">Tipo de admisión:</span>
                <asp:RequiredFieldValidator ID="rfvTipoDeAdmision" runat="server" CssClass="rightFloatAsterisk" Display="Dynamic" ToolTip="Seleccione un valor de la lista. Este campo es requerido." ErrorMessage="Tipo de admisión" ControlToValidate="ddlTipoDeAdmision" InitialValue="0" Text="*"/>
                <div class="expandibleDiv">
                    <asp:DropDownList CssClass="form-control" ID="ddlTipoDeAdmision" runat="server" />
                    <asp:Label ID="lblTipoDeAdmision" runat="server"/>
                </div>
            </div>
        </div>
  </div>
</div>
