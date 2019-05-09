<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Ley22_WebApp_V2.ParticipanteNuevo" Codebehind="ParticipanteNuevo.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card mb-4">
        <div class="card-header">
            Información Básica del Participante
        </div>
        <div class="card-block">

            <div class="row bb pb-4 mb-4">
                <div class="col-md-2 text-right">
                    <%--<strong>Información Básica del Participante</strong>--%>
                </div>

                <div class="col-md-10">
                    <div class="row">
                         <div class="col-md-3">
                            <div class="form-group">
                                <label for="iup">IUP</label>
                                <asp:TextBox ID="TxtIUP" runat="server" class="form-control" placeholder="Ej. 999999999" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                         <div class="col-md-3">
                            <div class="form-group">
                                <label for="n-seguro-social">Expediente</label>
                                <asp:TextBox ID="TxtExpediente" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtExpediente" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtExpediente" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="n-seguro-social">Número de Seguro Social (*)</label>
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="TxtNroSeguroSocial" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="9"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtNroSeguroSocial" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNroSeguroSocial" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
<%--                                    <div class="col-md-1">
                                        <asp:LinkButton ID="lnkBuscar" runat="server" CssClass="fas fa-search fa-lg" CausesValidation="false" OnClick="lnkBuscar_Click"></asp:LinkButton>
                                    </div>--%>
                                </div>
                            </div>
                        </div>                                                                  

                    </div>

                    <div class="row">

                         <div class="col-md-3">
                            <div class="form-group">
                                <label for="primer-nombre">Primer Nombre (*)</label>
                                <asp:TextBox ID="TxtPrimerNombre" runat="server" CssClass="form-control" placeholder="Ej. John"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPrimerNombre" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="segundo-nombre">Segundo Nombre</label>
                                <asp:TextBox ID="TxtSegundoNombre" runat="server" CssClass="form-control" placeholder="Ej. John"></asp:TextBox>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="primer-apellido">Apellido Paterno (*)</label>
                                <asp:TextBox ID="TxtPrimerApellido" runat="server" CssClass="form-control" placeholder="Ej. Perez"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPrimerApellido" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <!-- col -->


                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="segundo-apellido">Apellido Materno (*)</label>
                                <asp:TextBox ID="TxtSegundoApellido" runat="server" CssClass="form-control" placeholder="Ej. Perez"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtSegundoApellido" Display="Dynamic"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                      </div>
                     <br />
                     <div class="row">
                         

                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="fecha-nacimiento">Fecha de Nacimiento (*)</label>
                                <asp:TextBox ID="TxtFechaNacimiento" runat="server" CssClass="form-control" placeholder="12/31/2000"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaNacimiento_CalendarExtender" runat="server" BehaviorID="TxtFechaNacimiento_CalendarExtender" TargetControlID="TxtFechaNacimiento" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtFechaNacimiento" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFechaNacimiento" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="sexo">Sexo (*)</label>
                                <asp:DropDownList ID="DdlSexo" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlSexo" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="grupo-etnico">Grupo Étnico (*)</label>
                                <asp:DropDownList ID="DdlGrupoEtnico" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlGrupoEtnico" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-check">
                                <p>&nbsp;</p>
                                <label class="form-check-label">
                                    <asp:CheckBox ID="ChkVeterano" runat="server" class="form-check-input" />
                                    Veterano
                                </label>
                            </div>

                        </div>
                     </div>

                </div>
                <!-- col-9 -->

                
                    
                 

            </div>
            <!-- row -->




            

            <div class="row">
                <div class="col-md-2">
                </div>

                <div class="col-md-10">

                    <asp:Button ID="BtnCrear" runat="server" Text="Crear" CssClass="btn btn-primary btn-lg pr-4 pl-4 mr-4" OnClick="BtnCrear_Click"/>

                    <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary btn-lg pr-4 pl-4 mr-4" OnClick="BtnActualizar_Click" Visible="false"/>

                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary btn-lg" OnClick="BtnCancelar_Click" CausesValidation="false"/>

                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->


        </div>
        <!-- card-block -->
    </div>

    <script type="text/javascript">

        if ( window.history.replaceState ) {
           window.history.replaceState( null, null, window.location.href );
        }
        function sweetAlertRef(titulo, texto, icono, ref) {
           
            swal({
                    title: titulo,
                    text: texto,
                    icon: icono
            }).then((value) => { window.location.href=ref; });   
        }

        function sweetAlert(titulo, texto, icono) {
           
            swal({
                    title: titulo,
                    text: texto,
                    icon: icono
            })  
        }
    </script>
   
</asp:Content>

