<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="recepcion_busquedaUsuario" EnableEventValidation="false" ValidateRequest="false" Codebehind="recepcion-busquedaUsuario.aspx.cs" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }
    </style>

    <div class="row">

        <div class="col-md-8">


            <div class="card">
                <div class="card-header">

                    <div class="row">
                        <div class="col-md-8">
                            <strong>Búsqueda | Usuario con
                                <asp:Literal ID="LitBusquedaCon" runat="server"></asp:Literal></strong>
                        </div>
                        <div class="col-md-4 text-right">
                            <span>
                                <asp:Literal ID="LitCantidadUsuarios" runat="server"></asp:Literal>
                                Participantes Encontrados</span>
                        </div>
                    </div>

                </div>
                <div class="card-subheader">
                    Parámetros de Búsqueda:
                    <asp:Literal ID="LitParametrodeBusqueda" runat="server"></asp:Literal>
                </div>

                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" GridLines="None" CellSpacing="-1" DataKeyNames="PK_Persona">
                    <Columns>
                        <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="Pasaporte" HeaderText="Pasaporte" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Licencia" HeaderText="Licencia" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>--%>
 
                        <asp:TemplateField HeaderText="Nombre">

                            <ItemTemplate>
                                <asp:LinkButton ID="lnkNombre1" runat="server" Text='<%# Bind("NB_Primero") %>'  OnClick="lnkNombre_Click" CausesValidation="false" CommandArgument='<%# Eval("Pk_Persona")  +","+ Eval("Pk_Persona")   %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
 
                        <asp:TemplateField HeaderText="Primero Apellido">

                            <ItemTemplate>
                                <asp:LinkButton ID="lnkNombre2" runat="server" Text='<%# Bind("AP_Primero") %>' OnClick="lnkNombre_Click" CausesValidation="false" CommandArgument='<%# Eval("Pk_Persona") +","+ Eval("Pk_Persona")    %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Segundo Apellido">

                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSegundoApellido" runat="server" Text='<%# Bind("AP_Segundo") %>' OnClick="lnkNombre_Click" CausesValidation="false" CommandArgument='<%# Eval("Pk_Persona") +","+ Eval("Pk_Persona")    %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:BoundField DataField="FE_Nacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:MM/dd/yyyy}" SortExpression="FE_Nacimiento" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="FE_Edicion" HeaderText="Fecha Registro" DataFormatString="{0:MM/dd/yyyy}" SortExpression="FE_Edicion" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="card-block">
                            <p class="text-center pt-4 pb-4">Ningún usuario coincide con su búsqueda. <a href="ParticipanteNuevo.aspx">Crear Cuenta Nueva</a></p>
                        </div>
                     </EmptyDataTemplate>

                    <PagerSettings Visible="False"></PagerSettings>

                </asp:GridView>
            </div>
            <!-- Card -->
            Página #:        
            <asp:DropDownList ID="ddlJumpTo" runat="server" OnSelectedIndexChanged="PageNumberChanged" AutoPostBack="true"></asp:DropDownList>

        </div>

        <div class="col-md-4">


            <asp:Button ID="BtnCrearNuevaCuenta" runat="server" Text="Registrar Nuevo Participante" class="btn btn-secondary btn-lg btn-block mb-4" OnClick="BtnCrearNuevaCuenta_Click" CausesValidation="false" />


            <div class="card mb-4">
                <div class="card-header">
                    Nueva Búsqueda
 
                </div>
                <div class="card-block">

                 <!--   <fieldset class="form-group bb pb-4 mb-4">
                        <p><strong>Iniciar Búsqueda</strong></p>
                        <div class="form-check">
                            <label class="form-check-label">
                                <asp:RadioButtonList ID="RBLDocumentos" runat="server" RepeatDirection="Vertical" RepeatLayout="Table" CssClass="form-check-input">
                                    <asp:ListItem Value="1">&nbsp;Documento Requerido</asp:ListItem>
                                    <asp:ListItem Value="2">&nbsp;Cita </asp:ListItem>
                                    <asp:ListItem Value="3">&nbsp;Orden Tribunal</asp:ListItem>
                                </asp:RadioButtonList>


                            </label>
                        </div>
                        <div class="form-check">
                            <label class="form-check-label">
                            </label>
                        </div>
                    </fieldset> -->


                    <div class="row mb-4">
                        <div class="col-md-4">
                            <strong>Buscar por</strong>
                        </div>
                        <div class="col-md-8 text-right">
                            <span class="small">Escribe un parámetro para tu búsqueda</span>
                        </div>
                    </div>

                    <div class="form-group">
                                    <label for="formGroupExampleInput">Expediente</label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtExpediente" ForeColor="Red" Display="Dynamic" ValidationGroup="ValGroup1"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="TxtExpediente" runat="server" class="form-control" placeholder="Ej. 593912684"></asp:TextBox>
                                </div>

                    

                    
                     
                                <div class="form-group">
                                    <label for="formGroupExampleInput">Nombre</label>
                                    <asp:TextBox ID="TxtNombre" runat="server" class="form-control" placeholder="Ej. Luis"></asp:TextBox>
                                </div>
                           
                             
                                <div class="form-group">
                                    <label for="formGroupExampleInput">Apellido</label>
                                    <asp:TextBox ID="TxtApellido" runat="server" class="form-control" placeholder="Ej. Lopez"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label for="formGroupExampleInput">Segundo Apellido</label>
                                    <asp:TextBox ID="TxtSegundoApellido" runat="server" class="form-control" placeholder="Ej. Vazquez"></asp:TextBox>
                                </div>
                            
                            <div class="form-group">
                        <label for="formGroupExampleInput">Seguro Social</label>
                        <asp:TextBox ID="TxtNroSeguroSocial" runat="server" class="form-control"></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNroSeguroSocial" ForeColor="Red"></asp:RegularExpressionValidator>

                    </div>

                   <%-- <div class="form-group">
                        <label for="formGroupExampleInput">Identificación</label>
                        <asp:TextBox ID="TxtIdentificacion" runat="server" class="form-control"></asp:TextBox>
                    </div>--%>

                    <div class="form-group">
                        <label for="formGroupExampleInput">Fecha de Nacimiento</label>
                        <asp:TextBox ID="TxtFechaNacimiento" runat="server" class="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaNacimiento_CalendarExtender" runat="server" BehaviorID="TxtFechaNacimiento_CalendarExtender" TargetControlID="TxtFechaNacimiento" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFechaNacimiento" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                <!--    <asp:CustomValidator ID="valValidateTextBox" runat="server" ValidateEmptyText="true" Display="Dynamic" ErrorMessage="*introduzca al menos 1 campo de búsqueda<br/>" ClientValidationFunction="CheckTextBoxes" ForeColor="Red" /> -->
                    <asp:Label ID="label4" runat="server" Display="Dynamic" CssClass="ui-field-error" ForeColor="Red"></asp:Label>
                <!--    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Seleccione algun tipo de documento<br/>" ControlToValidate="RBLDocumentos" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator> -->

                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-primary inline mr-4" OnClick="BtnBuscar_Click" OnClientClick="return CheckTextBoxes();" UseSubmitBehavior="true"/> 

                    <script type="text/javascript">

                        var TxtSeguro = document.getElementById("<%=TxtNroSeguroSocial.ClientID %>");
                        TxtSeguro.addEventListener("keyup", function (event) {
                            if (event.keyCode === 13) {
                                event.preventDefault();

                                document.getElementById("<%=BtnBuscar.ClientID %>").click();
                            }
                        });

                        function CheckTextBoxes(sender, args) {
                            var TxtNroSeguroSocial = document.getElementById("<%=TxtNroSeguroSocial.ClientID %>").value;
                          
                            var TxtFechaNacimiento = document.getElementById("<%=TxtFechaNacimiento.ClientID %>").value;
                            var TxtNombre = document.getElementById("<%=TxtNombre.ClientID %>").value;
                            var TxtApellido = document.getElementById("<%=TxtApellido.ClientID %>").value;
                            var TxtSegundoApellido = document.getElementById("<%=TxtSegundoApellido.ClientID %>").value;
                            var TxtExpediente = document.getElementById("<%=TxtExpediente.ClientID %>").value

                            if (TxtNroSeguroSocial == "" && TxtFechaNacimiento == "" && TxtNombre == "" && TxtApellido == "" && TxtSegundoApellido == "" && TxtExpediente == "") {
                              //  args.IsValid = false;
                                
                               document.getElementById("<%=label4.ClientID%>").innerHTML = "*introduzca al menos 1 campo de búsqueda";
                               return false;
                            }
                            else

                             //   args.IsValid = true;
                                document.getElementById("<%=label4.ClientID%>").innerHTML = "";
                                return true;
                        }

                    </script>


                </div>

            </div>
        </div>


    </div>
    <!-- container-fluid -->

</asp:Content>

