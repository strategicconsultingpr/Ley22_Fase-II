<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Ley22_WebApp_V2.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">Reportes</h1>
    <div class="card-block">

            <div class="row mb-4 pb-4 pt-4 bb" id="DivPrograma" runat="server">
                    <div class="col-md-2">
                        <strong>Escoger un Programa: </strong>
                    </div>
                    <div class="col-md-10">
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
            <td>Resumen por Concepto</td>
            <td>Reporte el cual genera un resumen de los cobros divididos por conceptos, d</td>
            <td><asp:HyperLink ID="ReporteSemanal_l" runat="server" NavigateUrl="ReporteSemanal_l" Text="ver..."/></td>
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

    </table>
  </div>

</div>
</asp:Content>
