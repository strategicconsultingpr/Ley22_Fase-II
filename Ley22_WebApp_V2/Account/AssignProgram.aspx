<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AssignProgram.aspx.cs" Inherits="Ley22_WebApp_V2.Account.AssignProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container h-100">
  <div class="row align-items-center h-100">
    <div class="col-lg-6 col-md-8 col-sm-10">
        <div class="card card-login">
        <div class="card-block text-center">
            <div class="logo-login">
                <h3>AGREGAR PROGRAMA A EMPLEADO</h3>
              <img src="../images/assmca-big-logo.png" alt="ASSMCA"> 
                <h6>*Seleccione el email del empleado y programa al cual se desea brindarle acceso*</h6>
            </div>
            <p>
            <asp:Literal runat="server" ID="Literal1" />
            </p>
          <div class="row">
            <div class="col"></div>
            <div class="col-10">
              <div>
                  <div class="form-group text-left">
                    <label for="LabelEmail">Email</label>&nbsp&nbsp<label id="lblEmailA" Style="color:red"></label>
                    <asp:DropDownList ID="DdlEmailA" runat="server" class="form-control" OnSelectedIndexChanged="DdlEmailA_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlEmailA" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>--%>
                  </div>                 
                  <div class="form-group text-left">
                    <label for="LabelRol">Programa</label>&nbsp&nbsp<label id="lblProgramA" Style="color:red"></label>
                    <asp:DropDownList ID="DdlProgramA" runat="server" class="form-control"></asp:DropDownList>
                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlProgramA" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>--%>
                  </div>
                  <div class="row pt-4 pb-4">
                    
                    <div class="col text-center">
                      <asp:Button runat="server" ID="BtnAddProgram" Text="Agregar Programa" OnClick="BtnAddProgram_Click" OnClientClick="return Borrar();" class="btn btn-primary"/>
                      <%--<asp:Button runat="server" ID="Button2" Text="Borrar Programa" OnClick="BtnDelProgram_Click" class="btn btn-primary"/>--%>
                    </div>
                  </div>
              </div>              
            </div>
            <div class="col"></div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-lg-6 col-md-8 col-sm-10">
      <div class="card card-login">
        <div class="card-block text-center">
            <div class="logo-login">
                <h3>BORRAR PROGRAMA A EMPLEADO</h3>
              <img src="../images/assmca-big-logo.png" alt="ASSMCA">
                <h6>*Seleccione el email del empleado y programa al cual se desea quitar acceso*</h6>
            </div>
            <p>
            <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
          <div class="row">
            <div class="col"></div>
            <div class="col-10">
              <div>
                  <div class="form-group text-left">
                    <label for="LabelEmail">Email</label>&nbsp&nbsp<label id="lblEmailD" Style="color:red"></label>
                    <asp:DropDownList ID="DdlEmailD" runat="server" class="form-control" OnSelectedIndexChanged="DdlEmailD_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>                  
                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlEmailD" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>--%>
                  </div>                 
                  <div class="form-group text-left">
                    <label for="LabelRol">Programa</label>&nbsp&nbsp<label id="lblProgramD" Style="color:red" ></label>
                    <asp:DropDownList ID="DdlProgramD" runat="server" class="form-control"></asp:DropDownList>                    
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlProgramD" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>--%>
                  </div>
                  <div class="row pt-4 pb-4">
                    
                    <div class="col text-center">
                      <%--<asp:Button runat="server" ID="BtnAddProgram" Text="Agregar Programa" OnClick="BtnAddProgram_Click" class="btn btn-primary"/>--%>
                      <asp:Button runat="server" ID="BtnDelProgram" Text="Borrar Programa" OnClick="BtnDelProgram_Click" OnClientClick="return Agregar();" class="btn btn-primary"/>
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
    <br />
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
                        <asp:BoundField DataField="Program" HeaderText="Program" HeaderStyle-HorizontalAlign="Center">
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

    <script type="text/javascript">
        function Agregar() {
            var ddlEmail = document.getElementById("<%=DdlEmailD.ClientID %>");
            var Email = ddlEmail.value;
            var ddlPrograma = document.getElementById("<%=DdlProgramD.ClientID %>");
            var Programa = ddlPrograma.value;
            if (Email == "0" || Programa == "0") {
                if (Email == "0") { document.getElementById('lblEmailD').innerHTML = "*Requerido"; }
                if (Programa == "0") { document.getElementById('lblProgramD').innerHTML = "*Requerido"; }
                if (Email != "0") { document.getElementById('lblEmailD').innerHTML = ""; }
                if (Programa != "0") { document.getElementById('lblProgramD').innerHTML = ""; }

                return false;
            }
            else { return true; }
        }

            function Borrar() {
              
            var ddlEmail = document.getElementById("<%=DdlEmailA.ClientID %>");
            var Email = ddlEmail.value;
            var ddlPrograma = document.getElementById("<%=DdlProgramA.ClientID %>");
            var Programa = ddlPrograma.value;
            if (Email == "0" || Programa == "0") {
                if (Email == "0") { document.getElementById('lblEmailA').innerHTML = "*Requerido"; }
                if (Programa == "0") { document.getElementById('lblProgramA').innerHTML = "*Requerido"; }
                if (Email != "0") { document.getElementById('lblEmailA').innerHTML = ""; }
                if (Programa != "0") { document.getElementById('lblProgramA').innerHTML = "";}
                
                return false;
            }
            else { return true;}
        }

        function sweetAlert(titulo,texto,icono) {
            swal({
                title: titulo,
                text: texto,
                icon: icono
            }
            )
        }
    </script>

</asp:Content>
