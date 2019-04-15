<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Ley22_WebApp_V2.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Reportes</h1>
    <div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Tablas URS</h3>
  </div>
  <div class="panel-body" style="padding:0px">
    <table class="table table-striped table-hover table-condensed">
        <tr>
            <th style="width:200px;">Nombre</th>
            <th>Descripción</th>
            <th style="width:50px;">Doc.</th>
        </tr>
        <tr>
            <td>Table 2A-2B</td>
            <td>Profile of persons served, all programs by age, gender and race/ethnicity</td>
            <td><asp:HyperLink ID="ReporteSemanal_l" runat="server" NavigateUrl="ReporteSemanal_l" Text="ver..."/></td>
            </table>
      </div>
        </div>
</asp:Content>
