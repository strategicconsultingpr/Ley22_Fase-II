<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Ley22_WebApp_V2.OrdenNuevo" Codebehind="OrdenNuevo.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card mb-4">
        <div class="card-header">
           <strong> Nuevo Caso Criminal</strong> &nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp Participante: <asp:Literal ID="NombreParticipante" runat="server"></asp:Literal> &nbsp &nbsp &nbsp &nbsp Programa: <asp:Literal ID="NombrePrograma" runat="server"></asp:Literal> 
        </div>
        <div class="card-block">

            <div class="row bb pb-4 mb-4">
                <div class="col-md-2 text-right">
                    <strong>Situación Legal</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="n-caso-criminal">Núm. Caso Criminal (*)</label>
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="TxtNroCasoCriminal" runat="server" class="form-control" placeholder="Ej. D2TR2030-0000" MaxLength="15"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtNroCasoCriminal" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNroCasoCriminal" ForeColor="Red"></asp:RegularExpressionValidator>--%>
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
                                <label for="fecha-orden">Fecha de Orden del Tribunal (*)</label>
                                <asp:TextBox ID="TxtFechaOrden" runat="server" CssClass="form-control" placeholder="12/31/2000"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaOrden_CalendarExtender" runat="server" BehaviorID="TxtFechaOrden_CalendarExtender" TargetControlID="TxtFechaOrden" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtFechaOrden" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFechaOrden" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="fecha-sentencia">Fecha de Sentencia (*)</label>
                                <asp:TextBox ID="TxtSentencia" runat="server" CssClass="form-control" placeholder="12/31/2000"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtSentencia_CalendarExtender" runat="server" BehaviorID="TxtSentencia_CalendarExtender" TargetControlID="TxtSentencia" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtSentencia" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtSentencia" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="alcohol">Por ciento de alcohol (*)</label>
                                <asp:TextBox ID="Txtalcohol" runat="server" class="form-control" placeholder="Ej. 0.115" MaxLength="5"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="Regex1" runat="server" ForeColor="Red" Display="Dynamic" ValidationExpression="(((\d{1,2}\.\d{1,3})))$" ErrorMessage="Agregar cantidades correcta." ControlToValidate="Txtalcohol" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Requerido" ControlToValidate="Txtalcohol" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-md-3">

                            <div class="form-check">
                                <p>&nbsp;</p>
                                <h5>
                                <label class="form-check-label">
                                    <asp:CheckBox ID="ChkCaso" runat="server" class="form-check-input" OnClick="combinarCaso();"/>
                                   Combinar Caso Criminal
                                </label>
                                </h5>
                            </div>

                            </div>

                         <div class="col-md-3">

                            <div class="form-group" id="CasoDos" style="visibility:hidden" runat="server">
                                <label for="n-caso-criminal">Segundo Núm. Caso Criminal</label>
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="TxtNroCasoCriminal2" runat="server" class="form-control" placeholder="Ej. D2TR2030-0000" MaxLength="15"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtNroCasoCriminal" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNroCasoCriminal" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                    </div>
<%--                                    <div class="col-md-1">
                                        <asp:LinkButton ID="lnkBuscar" runat="server" CssClass="fas fa-search fa-lg" CausesValidation="false" OnClick="lnkBuscar_Click"></asp:LinkButton>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

                         <div class="col-md-3">

                            <div class="form-group" id="CasoTres" style="visibility:hidden" runat="server">
                                <label for="n-caso-criminal">Tercer Núm. Caso Criminal (*)</label>
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="TxtNroCasoCriminal3" runat="server" class="form-control" placeholder="Ej. D2TR2030-0000" MaxLength="15"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtNroCasoCriminal" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNroCasoCriminal" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                    </div>
<%--                                    <div class="col-md-1">
                                        <asp:LinkButton ID="lnkBuscar" runat="server" CssClass="fas fa-search fa-lg" CausesValidation="false" OnClick="lnkBuscar_Click"></asp:LinkButton>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

                        

                        <div class="col-md-3">
                            </div>

                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="tribunal">Tribunal (*)</label>
                                <asp:DropDownList ID="DdlTribunal" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlTribunal" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="juez">Juez (*)</label>
                                <asp:TextBox ID="TxtJuez" runat="server" class="form-control" placeholder="Ej. Alejandro Ortiz" MaxLength="30"></asp:TextBox>
                            </div>
                        </div>

                        <!-- col -->

                        
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
                                <asp:TextBox ID="TxtExpediente" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="30" ReadOnly="true"></asp:TextBox>
                                
                            </div>
                        </div>
                        <!-- col -->

                       <%-- <div class="col-md-3">
                            <div class="form-group">
                                <label for="episodio">Episodio</label>
                                <br />
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModal"></asp:HyperLink>
                            </div>
                        </div>--%>


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
                                                        <%--<asp:LinkButton ItemStyle-HorizontalAlign="Right" ID="lnkEpisodio" runat="server" Text='<%# Bind("PK_Episodio") %>'  OnClick="lnkEpisodio_Click" CausesValidation="false" CommandArgument='<%# Eval("PK_Episodio") %>'></asp:LinkButton>--%>
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




<%--            <div class="row pb-4 mb-4 bb">
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

            </div>--%>
            <!-- row -->



            <div class="row bb pb-4 mb-4">
                <div class="col-md-2 text-right">
                    <strong>Datos de Identificación</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="licencia">Licencia (*)</label>
                                <asp:TextBox ID="TxtLicencia" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtLicencia" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpLicencia" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtLicencia" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <!-- col -->

                       <div class="col-md-3">
                            <div class="form-group">
                                <label for="estado-civil">Estado Civil (*)</label>
                                <asp:DropDownList ID="DdlEstadoCivil" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlEstadoCivil" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                                             
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="email">Email</label>
                                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Ej. participante@outlook.com"></asp:TextBox>
                               <!-- <asp:RequiredFieldValidator ID="RequiredFieldValidator122" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtEmail" Display="Dynamic"></asp:RequiredFieldValidator> -->
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator77" runat="server" ErrorMessage="* El correo no se válido " ControlToValidate="TxtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator> 
                            </div>

                        </div>
                        </div>
                        <!-- col -->
                        
                        <div class="row">

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="tel-celular">Celular </label>
                                <asp:TextBox ID="TxtCelular" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                         
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtCelular" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <!-- col -->


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="tel-hogar">Teléfono Hogar </label>
                                <asp:TextBox ID="TxtTelHogar" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelHogar" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelHogar" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="tel-trabajo">Teléfono Trabajo </label>
                                <asp:TextBox ID="TxtTelefonoFamiliarMasCercano" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <%--                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoFamiliarMasCercano" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoFamiliarMasCercano" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoFamiliarMasCercano" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <asp:CustomValidator ID="valValidateTextBox" runat="server" Display="Dynamic" ErrorMessage="*introduzca al menos 1 campo de búsqueda<br/>" ClientValidationFunction="CheckTextBoxes" ForeColor="Red"/> 
                    <asp:Label ID="label4" runat="server" Display="Dynamic" CssClass="ui-field-error" ForeColor="Red"></asp:Label>

                    
                     <script type="text/javascript">

                         function CheckTextBoxes(sender, args) {
                             var TxtTelefono1 = document.getElementById("<%=TxtCelular.ClientID %>").value;
                                var TxtTelefono2 = document.getElementById("<%=TxtTelHogar.ClientID %>").value;
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
                    <%--<div class="row pb-4 mb-4 bb">
                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Telefono Notificar Citas (*)</label>
                                <asp:TextBox ID="TxtTelefonoNotificacion" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoNotificacion" Display="Dynamic"></asp:RequiredFieldValidator> 
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoNotificacion" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <!-- col -->

                    </div>--%>
                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->

            <div class="row pb-4 mb-4 bb">
                <div class="col-md-2 text-right">
                    <strong>Dirección Fisica</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="primer-nombre">Dirección Linea 1 (*)</label>

                                <asp:TextBox ID="TxtDireccionLinea1" runat="server" CssClass="form-control" placeholder="Ej. Urb. Los Paseos  "></asp:TextBox>
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
                                <label for="municipio">Pueblo (*)</label>
                                <asp:DropDownList ID="DdlPueblo" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlPueblo" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
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
                    <div class="row"><div class="col-md-3"><br /></div></div>
                </div>
                <!-- col-9 -->
                

                <div class="col-md-2 text-right">
                    <strong>Dirección Postal</strong>
                </div>
                 <div class="col-md-10">
                     <div class="row">
                         <div class="col">
                             <div class="form-group">
                               <%-- <p>&nbsp;</p>--%>
                              
                                   <h5>
                               <label class="form-check-label">
                                    <asp:CheckBox ID="ChkPostal" runat="server" class="form-check-input" OnClick="postalDireccion();"/>
                                  Direccón Postal igual que dirección fisica. 
                                </label>
                                       </h5>                               
                            </div>
                         </div>
                     </div>
                    <div class="row">
                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="primer-nombre">Dirección Linea 1 (*)</label>

                                <asp:TextBox ID="TxtPostalLinea1" runat="server" CssClass="form-control" placeholder="Ej. Urb. Los Paseos  "></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPostalLinea1" Display="Dynamic"></asp:RequiredFieldValidator>


                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-nombre">Dirección Linea 2</label>
                                <asp:TextBox ID="TxtPostalLinea2" runat="server" CssClass="form-control" placeholder="Ej. Calle / Avenida  "></asp:TextBox>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="municipio-postal">Pueblo (*)</label>
                                <asp:DropDownList ID="DdlPuebloPostal" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlPuebloPostal" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <!-- col -->


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Código Postal (*)</label>
                                <asp:TextBox ID="TxtCodigoPostalPostal" runat="server" CssClass="form-control" placeholder="Ej. 00725"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtCodigoPostalPostal" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <!-- col -->



                    </div>
                </div>
                        </div>


             <div class="row pb-4 mb-4 bb">
                <div class="col-md-2 text-right">
                    <strong>Otros datos</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="plan-medico">Plan Médico (*)</label>
                                <asp:DropDownList ID="DdlPlanMedico" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlPlanMedico" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="tratamiento">¿Condición de salud? (*)</label>
                                <asp:DropDownList ID="DdlTratamiento" runat="server" class="form-control">
                                    <asp:ListItem Value="0">No condición de salud</asp:ListItem>
                                    <asp:ListItem Value="1">Mental</asp:ListItem>
                                    <asp:ListItem Value="2">Fisica</asp:ListItem>
                                </asp:DropDownList>
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlTratamiento" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="impedimento">¿Tiene algún impedimento? (*)</label>
                                <asp:DropDownList ID="DdlImpedimento" runat="server" class="form-control">
                                    <asp:ListItem Value="0">No impedimento</asp:ListItem>
                                    <asp:ListItem Value="1">Mental</asp:ListItem>
                                    <asp:ListItem Value="2">Fisica</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlImpedimento" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                         <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="grado">Último grado completado (*)</label>
                                <asp:DropDownList ID="DdlGrado" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlGrado" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                            <!-- col -->
                        <div class="col-md-3">
                            <div class="form-check">
                                <p>&nbsp;</p>
                                <h5>
                                <label class="form-check-label">
                                    <asp:CheckBox ID="ChkNoTrabajo" runat="server" class="form-check-input" OnClick="noTrabajo();"/>
                                   Participante No Trabaja
                                </label>
                                </h5>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="lugar-trabajo">Lugar de trabajo</label>
                                <asp:TextBox ID="TxtTrabajo" runat="server" CssClass="form-control" placeholder="Ej. Assmca"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTrabajo" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="locupacion">Ocupación</label>
                                <asp:TextBox ID="TxtOcupacion" runat="server" CssClass="form-control" placeholder="Ej. Maestro"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtOcupacion" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>                 

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="desempleado">Motivo de no empleabilidad</label>
                                <asp:DropDownList ID="DdlDesempleado" runat="server" class="form-control" Enabled="false"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlDesempleado" Display="Dynamic" InitialValue="1" Enabled="false"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        </div>
                    </div>
                 </div>


            <div class="row pb-4 mb-4 bb">
                <div class="col-md-2 text-right">
                    <strong>Estructura Familiar</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="composicion-familiar">Composición familiar</label>
                                <asp:TextBox ID="TxtFamiliar" runat="server" CssClass="form-control" placeholder="Cantidad de Miembros"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtFamiliar" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="nombre-pareja">Nombre de esposo(a) o pareja</label>
                                <asp:TextBox ID="TxtPareja" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPareja" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="nombre-padre">Nombre de padre</label>
                                <asp:TextBox ID="TxtPadre" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPadre" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="nombre-madre">Nombre de madre</label>
                                <asp:TextBox ID="TxtMadre" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtMadre" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        </div>
                    </div>
                </div>
           
            <!-- row -->


            <div class="row">
                <div class="col-md-2">
                    
                </div>

                <div class="col-md-10">

                    <asp:Button ID="BtnCrear" runat="server" Text="Crear" CssClass="btn btn-primary btn-lg pr-4 pl-4 mr-4" OnClick="BtnCrear_Click"/>

                    <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary btn-lg pr-4 pl-4 mr-4" OnClick="BtnActualizar_Click" Visible="false"/>

                    <asp:Button ID="BtnCancelar" runat="server" Text="Volver al Expediente" CssClass="btn btn-secondary btn-lg" OnClick="BtnCancelar_Click" CausesValidation="false"/>

                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->


        </div>
        <!-- card-block -->
    </div>

      <script type="text/javascript">
          if (window.history.replaceState) {
              window.history.replaceState(null, null, window.location.href);
          }

          function sweetAlertRef(titulo, texto, icono, ref) {

              swal({
                  title: titulo,
                  text: texto,
                  icon: icono
              }).then((value) => { window.location.href = ref; });
          }

          function sweetAlert(titulo, texto, icono) {
              swal({
              title: titulo,
                  text: texto,
                  icon: icono
            })
          }

          function postalDireccion() {
              
              var Check = document.getElementById("<%=ChkPostal.ClientID %>");
              
              var TxtDireccionLinea1 = document.getElementById("<%=TxtDireccionLinea1.ClientID %>").value;
              var TxtDireccionLinea2 = document.getElementById("<%=TxtDireccionLinea2.ClientID %>").value;
              var DdlPueblo = document.getElementById("<%=DdlPueblo.ClientID %>").value;
              var TxtCodigoPostal = document.getElementById("<%=TxtCodigoPostal.ClientID %>").value;

              var TxtPostalLinea1 = document.getElementById("<%=TxtPostalLinea1.ClientID %>").value;
              var TxtPostalLinea2 = document.getElementById("<%=TxtPostalLinea2.ClientID %>").value;
              var DdlPuebloPostal = document.getElementById("<%=DdlPuebloPostal.ClientID %>").value;
              var TxtCodigoPostalPostal = document.getElementById("<%=TxtCodigoPostalPostal.ClientID %>").value;

              var validator5 = document.getElementById("<%=RequiredFieldValidator5.ClientID %>");
              var validator6 = document.getElementById("<%=RequiredFieldValidator6.ClientID %>");
              var validator7 = document.getElementById("<%=RequiredFieldValidator7.ClientID %>");

              if (Check.checked == true && TxtDireccionLinea1 != "" && DdlPueblo != "0" && TxtCodigoPostal != "") {

                  document.getElementById("<%=TxtPostalLinea1.ClientID %>").value = TxtDireccionLinea1;
                  document.getElementById("<%=TxtPostalLinea2.ClientID %>").value = TxtDireccionLinea2;
                  document.getElementById("<%=DdlPuebloPostal.ClientID %>").value = DdlPueblo;
                  document.getElementById("<%=TxtCodigoPostalPostal.ClientID %>").value = TxtCodigoPostal;

              }
              else if (Check.checked == true) {

                  document.getElementById("<%=TxtPostalLinea1.ClientID %>").value = "";
                  document.getElementById("<%=TxtPostalLinea2.ClientID %>").value = "";
                  document.getElementById("<%=DdlPuebloPostal.ClientID %>").value = "0";
                  document.getElementById("<%=TxtCodigoPostalPostal.ClientID %>").value = "";

                  ValidatorValidate(validator5);
                  ValidatorValidate(validator6);
                  ValidatorValidate(validator7);

                  Check.checked = false;
              }

              else {
                  document.getElementById("<%=TxtPostalLinea1.ClientID %>").value = "";
                  document.getElementById("<%=TxtPostalLinea2.ClientID %>").value = "";
                  document.getElementById("<%=DdlPuebloPostal.ClientID %>").value = "0";
                  document.getElementById("<%=TxtCodigoPostalPostal.ClientID %>").value = "";
              }
             
          }

          function noTrabajo() {
              var Check = document.getElementById("<%=ChkNoTrabajo.ClientID %>");
              
              var TxtTrabajo = document.getElementById("<%=TxtTrabajo.ClientID %>").value;
              var TxtOcupacion = document.getElementById("<%=TxtOcupacion.ClientID %>").value;
              var DdlDesempleado = document.getElementById("<%=DdlDesempleado.ClientID %>").value;

              var validator17 = document.getElementById("<%=RequiredFieldValidator17.ClientID %>");

              if (Check.checked == true) {
                  document.getElementById("<%=TxtTrabajo.ClientID %>").value = "No Aplica";
                  document.getElementById("<%=TxtOcupacion.ClientID %>").value = "No Aplica";
                  document.getElementById("<%=DdlDesempleado.ClientID %>").disabled = false;
                  document.getElementById("<%=DdlDesempleado.ClientID %>").className = "form-control";

                  document.getElementById("<%=TxtTrabajo.ClientID %>").readOnly = true;
                  document.getElementById("<%=TxtOcupacion.ClientID %>").readOnly = true;

                  ValidatorEnable(validator17);
              }
              else {
                  document.getElementById("<%=TxtTrabajo.ClientID %>").value = "";
                  document.getElementById("<%=TxtOcupacion.ClientID %>").value = "";
                  document.getElementById("<%=DdlDesempleado.ClientID %>").value = "1";
                  document.getElementById("<%=DdlDesempleado.ClientID %>").className = "";
                  document.getElementById("<%=DdlDesempleado.ClientID %>").disabled = true;

                  document.getElementById("<%=TxtTrabajo.ClientID %>").readOnly = false;
                  document.getElementById("<%=TxtOcupacion.ClientID %>").readOnly = false;

                  ValidatorEnable(validator17,false);
              }

          }

          function combinarCaso() {
              var Check = document.getElementById("<%=ChkCaso.ClientID %>");

             

              if (Check.checked == true) {
                  document.getElementById("<%=CasoDos.ClientID %>").style.visibility = 'visible';
                  document.getElementById("<%=CasoTres.ClientID %>").style.visibility = 'visible';
              }
              else {
                  document.getElementById("<%=CasoDos.ClientID %>").style.visibility = 'hidden';
                  document.getElementById("<%=CasoTres.ClientID %>").style.visibility = 'hidden';
                  document.getElementById("<%=TxtNroCasoCriminal2.ClientID %>").value = "";
                  document.getElementById("<%=TxtNroCasoCriminal3.ClientID %>").value = "";

              }
          }
    </script>
   
</asp:Content>

