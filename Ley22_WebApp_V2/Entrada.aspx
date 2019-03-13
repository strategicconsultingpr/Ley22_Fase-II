<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Entrada" EnableEventValidation="true" Codebehind="Entrada.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">

        <div class="card mb-4">
            <div class="card-header">
                Búsqueda
            </div>
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
                <div class="row pb-4">
                    <div class="col-md-2">
                        <strong>Buscar Por</strong><br>
                        <small>Escribe un parámetro para tu búsqueda</small>
                    </div>
                    <div class="col-md-10">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="formGroupExampleInput">Seguro Social</label>

                                    <asp:TextBox ID="TxtNroSeguroSocial" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="9" ValidationGroup="ValGroup1"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNroSeguroSocial" ForeColor="Red" Display="Dynamic" ValidationGroup="ValGroup1"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="formGroupExampleInput">Identificación</label>
                                    <asp:TextBox ID="TxtIdentificacion" runat="server" class="form-control" placeholder="Ej. 22222"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="formGroupExampleInput">Fecha de Nacimiento</label>
                                    <asp:TextBox ID="TxtFechaNacimiento" runat="server" class="form-control" placeholder="Ej. mm/dd/yyyy" MaxLength="10" ValidationGroup="ValGroup1"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaNacimiento_CalendarExtender" runat="server" BehaviorID="TxtFechaNacimiento_CalendarExtender" TargetControlID="TxtFechaNacimiento" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFechaNacimiento" ForeColor="Red" Display="Dynamic" ValidationGroup="ValGroup1"></asp:RegularExpressionValidator>


                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="formGroupExampleInput">Nombre y Apellido</label>
                                    <asp:TextBox ID="TxtNombreyApellido" runat="server" class="form-control" placeholder="Ej. John Doe"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--           <div id="form-avanzada">
                    <div class="row pt-4 pb-4 bt">
                        <div class="col-md-2">
                            <strong>Búsqueda Avanzada</strong><br>
                        </div>
                        <div class="col-md-10">
                            <div class="row">
                                 <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="formGroupExampleInput">Expediente</label>
                                    <asp:TextBox ID="TxtExpediente" runat="server" class="form-control" placeholder="Ej. 124567"></asp:TextBox>
                                    </div>
                                </div>
   
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="formGroupExampleInput">Licencia</label>
                                    <asp:TextBox ID="TxtLicencia" runat="server" class="form-control" placeholder="Ej. 124567"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtLicencia" ForeColor="Red"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="formGroupExampleInput">Cliente IUP</label>
                                    <asp:TextBox ID="TxtClienteIUP" runat="server" class="form-control" placeholder="Ej. 124567"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtClienteIUP" ForeColor="Red"></asp:RegularExpressionValidator>
                                         </div>
                                </div>
                                 <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="formGroupExampleInput">Episodio</label>
                                    <asp:TextBox ID="TxtEpisodio" runat="server" class="form-control" placeholder="Ej. 124567"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtEpisodio" ForeColor="Red"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>

                <div class="row">
                    <asp:Label ID="label4" runat="server" Display="Dynamic" CssClass="ui-field-error" ForeColor="Red"></asp:Label>
                    <div class="col-md-10 offset-md-2">

                     

                        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-primary inline mr-4" OnClick="BtnBuscar_Click" OnClientClick="return CheckTextBoxes();" UseSubmitBehavior="true"/>


                        <script type="text/javascript">

                            function CheckTextBoxes(sender, args) {
                                var TxtNroSeguroSocial = document.getElementById("<%=TxtNroSeguroSocial.ClientID %>").value;
                                var TxtIdentificacion = document.getElementById("<%=TxtIdentificacion.ClientID %>").value;
                                var TxtFechaNacimiento = document.getElementById("<%=TxtFechaNacimiento.ClientID %>").value;
                                var TxtNombreyApellido = document.getElementById("<%=TxtNombreyApellido.ClientID %>").value;
                                var DdlPrograma = document.getElementById("<%=DdlPrograma.ClientID %>").value;
                                //
<%--                            var TxtExpediente = document.getElementById("<%=TxtExpediente.ClientID %>").value;
                            var TxtLicencia = document.getElementById("<%=TxtLicencia.ClientID %>").value;
                            var TxtClienteIUP = document.getElementById("<%=TxtClienteIUP.ClientID %>").value;
                            var TxtEpisodio = document.getElementById("<%=TxtEpisodio.ClientID %>").value;--%>

                                if (TxtNroSeguroSocial == "" &&
                                    TxtIdentificacion == "" &&
                                    TxtFechaNacimiento == "" &&
                                    TxtNombreyApellido == "" && DdlPrograma != "0")
                                {
                                    
                                    document.getElementById("<%=label4.ClientID%>").innerHTML = "*Introduzca al menos 1 campo de búsqueda";                             
                                    return false;  
                                }
                                else if(TxtNroSeguroSocial == "" &&
                                    TxtIdentificacion == "" &&
                                    TxtFechaNacimiento == "" &&
                                    TxtNombreyApellido == "" && DdlPrograma == "0")
                                {
                                    document.getElementById("<%=label4.ClientID%>").innerHTML = "*Introduzca al menos 1 campo de búsqueda y seleccione un programa";                             
                                    return false;
                                }
                                else if (DdlPrograma == "0")
                                {
                                    document.getElementById("<%=label4.ClientID%>").innerHTML = "*Seleccione un programa";                             
                                    return false;
                                }
                                else {
                                    document.getElementById("<%=label4.ClientID%>").innerHTML = "";
                                  //  args.IsValid = true;
                                    return true;
                                }
                            }

                        </script>




                        <%--                        <button class="btn btn-secondary inline mr-4" id="btnshowhide">Búsqueda Avanzada</button>--%>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!-- container-fluid -->





    <script type="text/javascript">
        $(document).ready(function () {

            $("#form-avanzada").hide();

            $("#btnshowhide").click(function () {
                $("#form-avanzada").toggle(500);
            });

        });


    </script>
</asp:Content>

