<%@ Page Title="Register" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Ley22_WebApp_V2.Account.Register" %>

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
            <p>
            <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
          <div class="row">
            <div class="col"></div>
            <div class="col-10">
              <div>
                  <div class="form-group text-left">
                    <label for="LabelFirstName">Primer Nombre</label>
                    <asp:TextBox ID="FirstNameInput" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Ingrese su primer nombre"></asp:TextBox>  
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstNameInput" CssClass="text-danger" ErrorMessage="El primer nombre es requerido." />
                  </div>
                  <div class="form-group text-left">
                    <label for="LabelLastName">Primer Apellido</label>
                    <asp:TextBox ID="LastNameInput" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Ingrese su primer apellido" ></asp:TextBox>  
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="LastNameInput" CssClass="text-danger" ErrorMessage="El primer apellido es requerido." />
                  </div>
                  <div class="form-group text-left">
                    <label for="LabelEmail">Email</label>
                    <asp:TextBox ID="EmailInput" runat="server" AutoCompleteType="Email" class="form-control" aria-describedby="emailHelp" placeholder="Ingrese email" TextMode="Email"></asp:TextBox>
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailInput" CssClass="text-danger" ErrorMessage="El email es requerido." />
                  </div>
                  <div class="form-group text-left">
                    <label for="LabelPassword">Contraseña</label>
                    <asp:TextBox ID="PasswordInput" runat="server" class="form-control" placeholder="Ingrese Contraseña" TextMode="Password"></asp:TextBox> 
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailInput" CssClass="text-danger" ErrorMessage="El password es requerido." />
                  </div>
                  <div class="form-group text-left">
                    <label for="LabelPassword">Contraseña</label>
                    <asp:TextBox ID="PasswordConfirmInput" runat="server" class="form-control" placeholder="Confirme Contraseña" TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailInput" CssClass="text-danger" ErrorMessage="El password confirmado es requerido." />
                  </div>
                  <div class="form-group text-left">
                    <label for="LabelRol">Rol</label>
                    <asp:DropDownList ID="DdlRol" runat="server" class="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlRol" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group text-left">
                    <label for="LabelRol">Programa</label>
                    <asp:DropDownList ID="DdlPrograma" runat="server" class="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlPrograma" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                  </div>
                  <div class="row pt-4 pb-4">
                    
                    <div class="col text-right">
                      <asp:Button runat="server" ID="BtnLogin" Text="INGRESAR" OnClick="BtnRegistrar_Click" class="btn btn-primary"/>
                    </div>
                  </div>
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
       
        function sweetAlert(titulo,texto,icono) {
            swal(
              title: titulo,
              text: texto,
              icon: icono
            )            
            window.location.href = 'Register.aspx';
            //this.form.reset();
         
        }
    </script>
</asp:Content>
