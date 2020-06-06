<%@ Page Title="Log in" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ley22_WebApp_V2.Account.Login" Async="true" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
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
            VERSIÓN DE PRUEBA
          <div class="row">
            <div class="col"></div>
            <div class="col-10">
                <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
              <div>
                  <div class="form-group text-left">
                    <label for="LabelEmail">Email</label>
                    <asp:TextBox ID="EmailInput" runat="server" AutoCompleteType="Email" class="form-control" aria-describedby="emailHelp" placeholder="Ingrese email"></asp:TextBox>  
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailInput"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                  </div>
                  <div class="form-group text-left">
                    <label for="LabelPassword">Contraseña</label>
                    <asp:TextBox ID="PasswordInput" runat="server" class="form-control" TextMode="Password" placeholder="Ingrese Contraseña"></asp:TextBox>                   
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="PasswordInput" CssClass="text-danger" ErrorMessage="The password field is required." />
                  </div>
                  <div class="form-group text-left">
                      <div class="row">
                            <div class="col text-left">
                                <div class="checkbox">
                                    <label for="ShowPassword">
                                    <input type="checkbox" id="ShowPassword" />
                                    Mostrar Contraseña</label>
                                </div>
                            </div>
                            <div class="col text-right">
                                <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe">¿Recordarme?</asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                  <div class="row pt-4 pb-4">
                    <div class="col text-left">
                      <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled" class="btn btn-link">OLVIDÉ MI CONTRASEÑA</asp:HyperLink>
                
                    </div>
                    <div class="col text-right">
                      <asp:Button runat="server" ID="BtnLogin" Text="INGRESAR" OnClick="BtnLogin_Click" class="btn btn-primary" UseSubmitBehavior="true"/>
                    &nbsp;&nbsp;
                      <asp:Button runat="server" ID="ResendConfirm"  OnClick="SendEmailConfirmationToken" Text="Reenviar Confirmación" Visible="false" CssClass="btn btn-default"/>                     
                    </div>
                  </div>
                  <%--<p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>--%>
              </div>              
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

    <script type="text/javascript">
        $(function () {
            $("#ShowPassword").bind("click", function () {
                var txtPassword = $("[id*=PasswordInput]");
                if ($(this).is(":checked")) {
                    txtPassword.after('<input onchange = "PasswordChanged(this);" id = "txt_' + txtPassword.attr("id") + '" class="form-control" placeholder="Ingrese Contraseña" type = "text" value = "' + txtPassword.val() + '" />');
                    txtPassword.hide();
                } else {
                    txtPassword.val(txtPassword.next().val());
                    txtPassword.next().remove();
                    txtPassword.show();
                }
            });
        });
        function PasswordChanged(txt) {
            $(txt).prev().val($(txt).val());
        }
    </script>

</asp:Content>


