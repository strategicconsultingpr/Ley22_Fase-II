<%@ Page Title="Forgot password" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="Ley22_WebApp_V2.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">

     <div class="container h-100">
  <div class="row align-items-center h-100">
    <div class="col">
    </div>
    <div class="col-lg-6 col-md-8 col-sm-10">
      <div class="card card-login">
        <div class="card-block text-center">
            <div class="logo-login">
              <img src="../images/assmca-big-logo.png" alt="ASSMCA">
            </div>
          <div class="row">
              
            <div class="col"></div>
            <div class="col-10">
                Recuperar contraseña
                <hr />
                <asp:PlaceHolder id="loginForm" runat="server">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
              <div>
                  <div class="form-group text-left">
                    <label for="LabelEmail">Email</label>
                    <asp:TextBox ID="Email" runat="server" AutoCompleteType="Email" class="form-control" aria-describedby="emailHelp" placeholder="Ingrese email"></asp:TextBox>  
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                  </div>
                                    
                  <div class="row pt-4 pb-4">
                    
                    <div class="col text-right">
                      <asp:Button runat="server"  Text="Enviar Email" OnClick="Forgot" class="btn btn-primary" />
                  </div>
                  </div>
                  <%--<p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>--%>
              </div>  
                 </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                    <p class="text-info">
                        Favor de verificar su Email para poder crear contraseña.
                    </p>
                     <div class="row pt-4 pb-4">
                    
                    <div class="col text-right">
                      <asp:Button runat="server"  Text="Volver a Login" OnClick="Login" class="btn btn-primary" />
                  </div>
                  </div>
                </asp:PlaceHolder>
            </div>
            <div class="col"></div>                       
          </div>
        </div>
      </div>
    </div>
    <div class="col">
    </div>
  </div>
</div>
</asp:Content>
