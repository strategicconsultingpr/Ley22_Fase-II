<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Ley22_WebApp_V2.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Reportes</h1>
    <div class="card-block">

            <div class="row mb-4 pb-4 pt-4 bb" id="DivPrograma" runat="server">
                    <div class="col-md-2">
                        <strong>Escoger un Programa: </strong>
                    </div>
                    <div class="col-md-8">
                        <div class="row">

                            <div class="col-md-10">
                                <div class="form-check">
                                    <label class="form-check-label">

                                        <asp:DropDownList ID="DdlPrograma" runat="server" class="form-control" OnSelectedIndexChanged="DdlPrograma_Changed" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ValidatorPrograma" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlPrograma" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>

                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                       <a href="../Dashboard-Usuarios.aspx" class="btn btn-secondary btn-lg">Volver a mi Tablero</a>
                    </div>
                </div> 
        </div>
<div class="panel panel-default" id="Div" runat="server">

  <div class="panel-heading">
    <h3 class="panel-title">Reportes LEY 22</h3>
  </div>

  <div class="panel-body" style="padding:0px">
    <table class="table table-striped table-hover table-condensed">
        <tr>
            <th style="width:200px;">Nombre</th>
            <th>Descripción</th>
            <th style="width:50px;">Doc.</th>
        </tr>
        <tr>
            <td>Detalle de Ingresos</td>
            <td>Reporte el cual genera los ingresos por transaccion en detalle.</td>
            <td><asp:HyperLink ID="DetalleIngresos" runat="server" NavigateUrl="DetalleIngresos_" Text="ver..."/></td>
        </tr>
        <tr>
            <td>Información Diarios</td>
            <td>Reporte el cual genera los ingresos por dia de los servicios cobrados en detalle.</td>
            <td><asp:HyperLink ID="ServiciosDiarios" runat="server" NavigateUrl="ServiciosDiariosCobrados_" Text="ver..."/></td>
        </tr>
        <tr>
            <td>Ageing Report</td>
            <td>Reporte el cual genera deudas de participantes.</td>
            <td><asp:HyperLink ID="AgeingReport" runat="server" NavigateUrl="AgeingReport&Programa=" Text="ver..."/></td>
        </tr>
        <tr>
            <td>Reporte de Participantes por Programa Seleccionado</td>
            <td>Reporte el cual genera estatus de casos criminales de los participantes.</td>
            <td><asp:HyperLink ID="ParticipantesPrograma" runat="server" NavigateUrl="ReporteParticipantePrograma&FK_Programa=" Text="ver..."/></td>
        </tr>
        <asp:LoginView runat="server" ViewStateMode="Disabled">
                                    <RoleGroups>
                                        <asp:RoleGroup Roles="SuperAdmin">
                                            <ContentTemplate>
        <tr>
            <td>Reporte de Participantes para todos los Programas</td>
            <td>Reporte el cual genera estatus de casos criminales de los participantes para todos los programas.</td>
            <td><asp:HyperLink ID="Participantes" runat="server" NavigateUrl="http://vhermes/ReportServer?/Informes Sistema Ley 22/ReporteParticipante" Text="ver..."/></td>
        </tr>
                                                </ContentTemplate>
                                        </asp:RoleGroup>

                                    </RoleGroups>
                                </asp:LoginView>

    </table>
  </div>

</div>
</asp:Content>
