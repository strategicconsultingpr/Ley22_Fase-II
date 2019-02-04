<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Ley22_WebApp_V2.Account.AssignRole" Codebehind="AssignRole.aspx.cs" %>

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
                    <label for="LabelEmail">Email</label>
                    <asp:DropDownList ID="DdlEmail" runat="server" class="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlEmail" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                  </div>                 
                  <div class="form-group text-left">
                    <label for="LabelRol">Rol</label>
                    <asp:DropDownList ID="DdlRol" runat="server" class="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlRol" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                  </div>
                  <div class="row pt-4 pb-4">
                    
                    <div class="col text-center">
                      <asp:Button runat="server" ID="BtnAddRole" Text="Agregar Rol" OnClick="BtnAddRole_Click" class="btn btn-primary"/>
                      <asp:Button runat="server" ID="BtnDelRole" Text="Borrar Rol" OnClick="BtnDelRole_Click" class="btn btn-primary"/>
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
    <div class="col"></div>
    <div class="col"></div>

    <div class="container-fluid">
        <div class="card mb-2">
    
    <%--<div class="col-md-8">--%>


            <div class="card">
                <div class="card-header">

                    <div class="row">
                       
                        <div class="col-md-4 text-left">
                            <span>
                                <asp:Literal ID="LitCantidadUsuarios" runat="server"></asp:Literal>
                                Usuarios Encontrados</span>
                        </div>
                    </div>

                </div>
                

                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" GridLines="None" CellSpacing="-1" DataKeyNames="Email">
                    <Columns>
                        <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Role" HeaderText="Role" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>                        
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="card-block">
                            <p class="text-center pt-4 pb-4">Ningún usuario.</p>
                        </div>
                     </EmptyDataTemplate>

                    <PagerSettings Visible="False"></PagerSettings>

                </asp:GridView>
            </div>
            <!-- Card -->
            Página #:        
            <asp:DropDownList ID="ddlJumpTo" runat="server" OnSelectedIndexChanged="PageNumberChanged" AutoPostBack="true"></asp:DropDownList>

        </div>
        </div>
        <%--</div>--%>
</asp:Content>