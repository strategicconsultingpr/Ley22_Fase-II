﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="nuevo_usuario" Codebehind="nuevo-usuario.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card mb-4">
        <div class="card-header">
            Registro de nueva cuenta
        </div>
        <div class="card-block">

            <div class="row bb pb-4 mb-4">
                <div class="col-md-2 text-right">
                    <strong>Documentos</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">


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

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="pasaporte">Identificación</label>
                                <asp:TextBox ID="TxtIdentificacion" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="30"></asp:TextBox>
                            </div>
                        </div>
                        <!-- col -->
                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="pasaporte">Pasaporte</label>
                                <asp:TextBox ID="Txtpasaporte" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="30"></asp:TextBox>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="licencia">Licencia (*)</label>
                                <asp:TextBox ID="TxtLicencia" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtLicencia" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="iup">IUP</label>
                                <asp:TextBox ID="TxtIUP" runat="server" class="form-control" placeholder="Ej. 999999999" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <!-- col -->


                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="n-seguro-social">Expediente</label>
                                <asp:TextBox ID="TxtExpediente" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="30"></asp:TextBox>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="episodio">Episodio</label>
                                <br />
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModal"></asp:HyperLink>
                            </div>
                        </div>


                        <!-- The Modal -->
                        <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">

                                    <!-- Modal Header -->
                                    <div class="modal-header">
                                        <h4 class="modal-title">Episodios</h4>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>

                                    <!-- Modal body -->
                                    <div class="modal-body">
                                        <asp:GridView ID="GVListadeEpisodios" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="PK_Episodio">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Episodio">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ItemStyle-HorizontalAlign="Right" ID="lnkEpisodio" runat="server" Text='<%# Bind("PK_Episodio") %>'  OnClick="lnkEpisodio_Click" CausesValidation="false" CommandArgument='<%# Eval("PK_Episodio") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>

                                                <%--<asp:BoundField DataField="PK_Episodio" HeaderText="Episodio" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />--%>
                                                <asp:BoundField DataField="FE_Episodio" HeaderText="Fecha del Episodio" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="DE_Programa" HeaderText="Programa" HeaderStyle-HorizontalAlign="Center" />
                                            </Columns>

                                        </asp:GridView>
                                    </div>



                                </div>
                            </div>
                        </div>


                         <div id="MyPopup" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">
                                            &times;</button>
                                        <h4 class="modal-title">
                                        </h4>
                                    </div>
                                    <div class="modal-body">
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                                            Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                       

                        <!-- col -->

                    </div>
                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->




            <div class="row pb-4 mb-4 bb">
                <div class="col-md-2 text-right">
                    <strong>Identificación</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="primer-nombre">Primer Nombre (*)</label>
                                <asp:TextBox ID="TxtPrimerNombre" runat="server" CssClass="form-control" placeholder="Ej. John"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPrimerNombre" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <!-- col -->

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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPrimerApellido" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <!-- col -->


                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="segundo-apellido">Apellido Materno (*)</label>
                                <asp:TextBox ID="TxtSegundoApellido" runat="server" CssClass="form-control" placeholder="Ej. Perez"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtSegundoApellido" Display="Dynamic"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <!-- col -->
                    </div>
                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->



            <div class="row bb pb-4 mb-4">
                <div class="col-md-2 text-right">
                    <strong>Otros Datos</strong>
                </div>

                <div class="col-md-10">
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
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="email">Email</label>
                                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Ej. assmca@assmca.com"></asp:TextBox>
                               <!-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtEmail" Display="Dynamic"></asp:RequiredFieldValidator> -->
                               <!-- <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="* El correo no se válido " ControlToValidate="TxtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator> -->
                            </div>

                        </div>
                        <!-- col -->

                        

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Teléfono Movil </label>
                                <asp:TextBox ID="TxtTelefono1" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                          <!--      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefono1" Display="Dynamic"></asp:RequiredFieldValidator> -->
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefono1" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <!-- col -->


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Teléfono Hogar </label>
                                <asp:TextBox ID="TxtTelefono2" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="CustomValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefono2" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefono2" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="segundo-apellido">Teléfono Famliar </label>
                                <asp:TextBox ID="TxtTelefonoFamiliarMasCercano" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <%--                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoFamiliarMasCercano" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="CustomValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoFamiliarMasCercano" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoFamiliarMasCercano" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <asp:CustomValidator ID="valValidateTextBox" runat="server" Display="Dynamic" ErrorMessage="*introduzca al menos 1 campo de búsqueda<br/>" ClientValidationFunction="CheckTextBoxes" ForeColor="Red"/> 
                    <asp:Label ID="label4" runat="server" Display="Dynamic" CssClass="ui-field-error" ForeColor="Red"></asp:Label>

                    
                     <script type="text/javascript">

                         function CheckTextBoxes(sender, args) {
                             var TxtTelefono1 = document.getElementById("<%=TxtTelefono1.ClientID %>").value;
                                var TxtTelefono2 = document.getElementById("<%=TxtTelefono2.ClientID %>").value;
                                var TxtTelefonoFamiliarMasCercano = document.getElementById("<%=TxtTelefonoFamiliarMasCercano.ClientID %>").value;


                                if (TxtTelefono1 == "" &&
                                    TxtTelefono2 == "" &&
                                    TxtTelefonoFamiliarMasCercano == ""
  
                                ) {
                                   
                                      document.getElementById("<%=label4.ClientID%>").innerHTML =" &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; *Introduzca al menos una de las opciones de Telefono &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; |";                                                                                                    
                                      return false;  
                                }
                                else {
                                    document.getElementById("<%=label4.ClientID%>").innerHTML = "";                              
                                        return true;
                                }
                         }
                       

                        </script>


                    
                    <!-- col -->
                    <div class="row pb-4 mb-4 bb">
                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Telefono Notificar Citas (*)</label>
                                <asp:TextBox ID="TxtTelefonoNotificacion" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoNotificacion" Display="Dynamic"></asp:RequiredFieldValidator> 
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoNotificacion" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <!-- col -->

                    </div>
                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->

            <div class="row pb-4 mb-4 bb">
                <div class="col-md-2 text-right">
                    <strong>Dirección</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="primer-nombre">Dirección Linea 1 (*)</label>

                                <asp:TextBox ID="TxtDireccionLinea1" runat="server" CssClass="form-control" placeholder="Ej. Calle / Avenida  "></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtDireccionLinea1" Display="Dynamic"></asp:RequiredFieldValidator>


                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-nombre">Dirección Linea 2</label>
                                <asp:TextBox ID="TxtDireccionLinea2" runat="server" CssClass="form-control" placeholder="Ej. Calle / Avenida  "></asp:TextBox>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="primer-apellido">Municipio (*)</label>
                                <asp:TextBox ID="TxtMunicipio" runat="server" CssClass="form-control" placeholder="Ej. San Juan"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtMunicipio" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <!-- col -->


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Código Postal (*)</label>
                                <asp:TextBox ID="TxtCodigoPostal" runat="server" CssClass="form-control" placeholder="Ej. 00725"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtCodigoPostal" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <!-- col -->



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

                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary btn-lg" OnClick="BtnCancelar_Click"/>

                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->


        </div>
        <!-- card-block -->
    </div>

    
   
</asp:Content>

