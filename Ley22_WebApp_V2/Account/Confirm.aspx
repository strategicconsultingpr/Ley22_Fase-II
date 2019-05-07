<%@ Page Title="Confirme su Cuenta" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="Ley22_WebApp_V2.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container h-100">
  <div class="row align-items-center h-100">

       <div class="col">
    </div>
    <div class="col-lg-6 col-md-8 col-sm-10">
      <div class="card card-login">
        <div class="card-block text-center">
            <div class="logo-login">
             
            
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Gracias por confirmar su cuenta. Presione <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aqui</asp:HyperLink>  para accesar al CMS LEY 22             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                An error has occurred.
            </p>
        </asp:PlaceHolder>
    </div>
        </div>
        </div>
          
        </div>
        </div>
      <div class="col">
    </div>
      </div>
        </div>
</asp:Content>
