<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="administrador_charlas_grupales" Codebehind="administrador-charlas-grupales.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <input id="Id_CharlaGrupal" name="Id_CharlaGrupal" type="hidden" runat="server" />
            <asp:HiddenField ID="H_Id_CharlaGrupal" runat="server" />
    <asp:HiddenField ID="H_Id_Participante" runat="server" />
    <asp:HiddenField ID="H_Id_CasoCriminal" runat="server" />
    <div style="display:none"><asp:Button runat="server" ID="BtnPrint" Text="" OnClick="downloadfiles" CausesValidation="false"/></div>
    

    <!-- Modal Crear Excepcion -->
     
                           <%-- function checkDate(sender, args) {
                                if (sender._selectedDate.getDate() != new Date().getDate() && sender._selectedDate < new Date()) {
                                    alert("You cannot select a day earlier than today!");
                                    sender._selectedDate = new Date();
                                    // set the date back to the current date
                                    sender._textbox.set_Value(sender._selectedDate.format(sender._format))--%>
                                    
            

    <!-- Modal Cita De Trabajor Social NO ES PARA ESTO -->

    <div class="modal fade" id="asignar-citas-confirmacion" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Detalle de la Cita</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div id="Fecha"></div>
                    <br />
                    <div id="Horas"></div>
                    <input id="HNroCita" name="HNroCita" type="hidden" runat="server" />
                    <br />
                    <div id="NombreCompleto"></div>
                    <br />
                    <div id="TelefonoContacto"></div>
                    <br />
                </div>
                <div class="modal-footer">

                    <asp:Button ID="BtnELiminarCita" runat="server" Text="Eliminar"  class="btn btn-danger btn-lg" OnClick="BtnELiminarCita_Click"  CausesValidation="false"/>
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>


     <!-- Modal Ver Info De Charla-->
    <div class="modal fade" id="modal-Info-Charla" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel4">
                        <div id="TipoCharlaNivel"></div></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row bb pl-4 pr-4 pb-4 mb-4">
                        <div class="col">
                            <strong>
                                   <div id="FechaHoraCharla"></div></strong>
                            
                            <br>
                        </div>
                        <div class="col">
                             <a data-dismiss="modal" href="#" class="btn btn-primary btn-block" data-toggle="modal" data-target="#modal-crear-charla_2" data-whatever="@getbootstrap" runat="server" id="A1" >Modificar Charla</a>
                            <asp:LinkButton runat="server" ID="BtnEliminarCharla" Text="Eliminar Charla" class="btn btn-primary btn-block" OnClick="BtnEliminarCharla_Click" CausesValidation="false"></asp:LinkButton>
                             <%--<asp:LinkButton runat="server" ID="BtnGetCharla" Text="" Style="display:none;" OnClick="BtnModificarCharla" />
                           --%>
                            <a visible="false" data-dismiss="modal" href="#" class="btn btn-primary btn-block" data-toggle="modal" data-target="#modal-certificados" data-whatever="@getbootstrap" runat="server" id="lnkCertificados" >Generar Certificados</a>
                        </div>
                    </div>
                    <div class="row">
                       <%-- <div class="col-md-4" style="text-align:center">
                            <p><strong>Participantes</strong></p>
                        </div>
                        <div class="col-md-4" style="text-align:center">
                            <p><strong>Asistencia</strong></p>
                        </div>
                        <div class="col-md-4" style="text-align:center">
                            <div class="row">
                            <div class="col-md-4">
                            <strong>Charlas</strong>
                            </div>
                            <div class="col-md-2">
                            <strong>|</strong>
                            </div>   
                            <div class="col-md-4">
                            <strong>Balance</strong>
                            </div>
                            </div>
                        </div>--%>
                        <div class="container">
                            <table class="table table-bordered">
                               <thead class="thead-default">
                                   <tr class="d-flex">
                                    <th class="col-4" style="text-align:center"><h6><strong>Participantes</strong></h6></th>
                                    <th class="col-2" style="text-align:center"><h6><strong>Estatus</strong></h6></th>
                                    <th class="col-2" style="text-align:center"><h6><strong>Charlas</strong></h6></th>
                                    <th class="col-2" style="text-align:center"><h6><strong>Deuda</strong></h6></th>
                                    <th class="col-2" style="text-align:center"><h6><strong>Acción</strong></h6></th>
                                   </tr>
                               </thead>
                               <tbody id="bodyLista">
                                   
                               </tbody>
                           </table>
                        </div>

                                        
                    </div>
                    <div class="row" id="Participantes">
                         
                    </div>

                </div>
                <div class="modal-footer">
<%--                    <button type="button" class="btn btn-primary btn-lg" data-dismiss="modal">Aceptar</button>
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Imprimir</button> --%>
                    <div class="container">
                        <div class="row">
                            <div class="col">
                            <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cancelar</button>
                            </div>
                            <div class="col-5">
                            
                            </div>
                            <div class="col" id="BtnAsistencia">
                            
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Ver y Eliminar Excepcion -->

    <div class="modal fade" id="asignar-excepcion-confirmacion" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Detalle de la Excepcion</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
 

                    <div id="Fecha2"></div>
                    <br />
                    <div id="Horas2"></div>
                    <input id="HNroExcepcion" name="HNroExcepcion" type="hidden" runat="server" />
                    <br />                    
                </div>
                <div class="modal-footer">

                    <asp:Button ID="BtnEliminarExcepcion" runat="server" Text="Eliminar"  class="btn btn-danger btn-lg" OnClick="BtnEliminarExcepcion_Click"  CausesValidation="false"/>
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal Agregar Charla -->

 <div class="modal fade" id="modal-crear-charla" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel3">Crear nueva Charla</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row bb pl-4 pr-4 pb-4 mb-4">
                        <div class="col">
                            <div class="form-group">

                                <label for="fecha-charla">Fecha</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><img src="images/calendar_icon.png" alt="ASSMCA"></div>
                                    <asp:TextBox ID="TxtFechaCrearCharla" runat="server" class="form-control" placeholder="Ej. mm/dd/yyyy" ValidationGroup="VGCrearCharla"  ></asp:TextBox>

                                    <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaNacimiento_CalendarExtender" runat="server" BehaviorID="TxtFechaNacimiento_CalendarExtender" TargetControlID="TxtFechaCrearCharla"/>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFechaCrearCharla" ForeColor="Red" Display="Dynamic" ValidationGroup="VGCrearCharla"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="<br />*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtFechaCrearCharla" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="hora-charla">Hora Inicial</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><img src="images/clock_icon.png" alt="ASSMCA"></div>

                                    <asp:TextBox ID="TxtInicialCrearCharla" runat="server" class="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="TxtInicialCrearCharla" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Requerido" Display="Dynamic" ForeColor="Red" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="TxtInicialCrearCharla" runat="server" ErrorMessage="*Formato hh:mm am/pm" ForeColor="Red" Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))" ValidationGroup="VGCrearCharla"></asp:RegularExpressionValidator>

                                </div>

                            </div>
                        </div>

                        <div class="col">
                            <div class="form-group">
                                <label for="hora-charla">Hora Final</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><img src="images/clock_icon.png" alt="ASSMCA"></div>
                                    <asp:TextBox ID="TxtFinalCrearCharla" runat="server" class="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="TxtFinalCrearCharla" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Requerido" Display="Dynamic" ForeColor="Red" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="TxtFinalCrearCharla" runat="server" ErrorMessage="*Formato hh:mm am/pm" ForeColor="Red" Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))" ValidationGroup="VGCrearCharla"></asp:RegularExpressionValidator>

                                    <script type="text/javascript">
                                        $(document).ready(function () {
                                            $('input[name="<%=TxtInicialCrearCharla.UniqueID %>"]')
                                                .ptTimeSelect({
                                                    containerClass: undefined,
                                                    containerWidth: undefined,
                                                    hoursLabel: 'Hora',
                                                    minutesLabel: 'Minutos',
                                                    setButtonLabel: 'Seleccionar',
                                                    popupImage: undefined,
                                                    onFocusDisplay: true,
                                                    zIndex: 10000,
                                                    onBeforeShow: undefined,
                                                    onClose: undefined,
                                                    defaultHr:      '10',         
                                                    defaultMin:     '00',
                                                    defaultAmPm:    'AM'
                                                });
                                        });
                                        

                                        $(document).ready(function () {
                                            $('input[name="<%=TxtFinalCrearCharla.UniqueID %>"]')
                                                .ptTimeSelect({
                                                    containerClass: undefined,
                                                    containerWidth: undefined,
                                                    hoursLabel: 'Hora',
                                                    minutesLabel: 'Minutos',
                                                    setButtonLabel: 'Seleccionar',
                                                    popupImage: undefined,
                                                    onFocusDisplay: true,
                                                    zIndex: 10000,
                                                    onBeforeShow: undefined,
                                                    onClose: undefined
                                                });
                                        });
                                    </script>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row pl-4 pr-4 pb-4 mb-4">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="tipo-charlas">Tipo Charlas</label>
                                <asp:DropDownList runat="server" ID="DdlTipodeCharla" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlTipodeCharla" InitialValue="0" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="nivel-charlas">Nivel</label>
                                <asp:DropDownList runat="server" ID="DdlNivelCharlas" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlNivelCharlas" InitialValue="0" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="tipo-numero-charla">Nº De Charla</label>
                                <select class="form-control" id="DdlNumeroCharla" runat="server">
                                    <option selected ="0">Seleccione</option>
                                    <option>1</option>
                                    <option>2</option>
                                    <option>3</option>
                                    <option>4</option>
                                    <option>5</option>
                                    <option>6</option>
                                    <option>7</option>
                                    <option>8</option>
                                    <option>9</option>
                                    <option>10</option>
                                </select>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="aforo">Nº Max Participantes</label>

                                <asp:TextBox runat="server" ID="TxtMaxCantParticipantes" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtMaxCantParticipantes" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtMaxCantParticipantes" ForeColor="Red" ValidationGroup="VGCrearCharla"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                      <%--  <div class="col-md-6">
                            <div class="form-group">
                                <label for="aforo">Nº De Charla</label>

                                <asp:TextBox runat="server" ID="TxtNumeroCharla" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtNumeroCharla" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNumeroCharla" ForeColor="Red" ValidationGroup="VGCrearCharla"></asp:RegularExpressionValidator>

                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="modal-footer">
                     <asp:Button ID="btnGuardarCharla" runat="server" Text="Crear" CssClass="btn btn-primary mr-3" OnClick="btnGuardarCharla_Click" ValidationGroup="VGCrearCharla"/>

                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Modificar Charla --> 

     <div class="modal fade" id="modal-crear-charla_2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel_2">Crear nueva Charla</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row bb pl-4 pr-4 pb-4 mb-4">
                        <div class="col">
                            <div class="form-group">

                                <label for="fecha-charla">Fecha</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><img src="images/calendar_icon.png" alt="ASSMCA"></div>
                                    <asp:TextBox ID="TxtFechaModCharla" runat="server" class="form-control" placeholder="Ej. mm/dd/yyyy" ValidationGroup="VGCrearCharla2"  ></asp:TextBox>

                                    <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaNacimiento_CalendarExtender2" runat="server" BehaviorID="TxtFechaNacimiento_CalendarExtender2" TargetControlID="TxtFechaModCharla" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFechaModCharla" ForeColor="Red" Display="Dynamic" ValidationGroup="VGCrearCharla2"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="<br />*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtFechaModCharla" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="hora-charla">Hora Inicial</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><img src="images/clock_icon.png" alt="ASSMCA"></div>

                                    <asp:TextBox ID="TxtIncialModCharla" runat="server" class="form-control" ValidationGroup="VGCrearCharla2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="TxtIncialModCharla" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Requerido" Display="Dynamic" ForeColor="Red" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="TxtIncialModCharla" runat="server" ErrorMessage="*Formato hh:mm am/pm" ForeColor="Red" Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))" ValidationGroup="VGCrearCharla2"></asp:RegularExpressionValidator>

                                </div>

                            </div>
                        </div>

                        <div class="col">
                            <div class="form-group">
                                <label for="hora-charla">Hora Final</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><img src="images/clock_icon.png" alt="ASSMCA"></div>
                                    <asp:TextBox ID="TxtFinalModCharla" runat="server" class="form-control" ValidationGroup="VGCrearCharla2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="TxtFinalModCharla" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Requerido" Display="Dynamic" ForeColor="Red" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="TxtFinalModCharla" runat="server" ErrorMessage="*Formato hh:mm am/pm" ForeColor="Red" Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))" ValidationGroup="VGCrearCharla2"></asp:RegularExpressionValidator>

                                    <script type="text/javascript">
                                        $(document).ready(function () {
                                            $('input[name="<%=TxtIncialModCharla.UniqueID %>"]')
                                                .ptTimeSelect({
                                                    containerClass: undefined,
                                                    containerWidth: undefined,
                                                    hoursLabel: 'Hora',
                                                    minutesLabel: 'Minutos',
                                                    setButtonLabel: 'Seleccionar',
                                                    popupImage: undefined,
                                                    onFocusDisplay: true,
                                                    zIndex: 10000,
                                                    onBeforeShow: undefined,
                                                    onClose: undefined
                                                });
                                        });

                                        $(document).ready(function () {
                                            $('input[name="<%=TxtFinalModCharla.UniqueID %>"]')
                                                .ptTimeSelect({
                                                    containerClass: undefined,
                                                    containerWidth: undefined,
                                                    hoursLabel: 'Hora',
                                                    minutesLabel: 'Minutos',
                                                    setButtonLabel: 'Seleccionar',
                                                    popupImage: undefined,
                                                    onFocusDisplay: true,
                                                    zIndex: 10000,
                                                    onBeforeShow: undefined,
                                                    onClose: undefined
                                                });
                                        });
                                    </script>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row pl-4 pr-4 pb-4 mb-4">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="tipo-charlas">Tipo Charlas</label>
                                <asp:DropDownList runat="server" ID="DdlTipodeCharla2" CssClass="form-control" ValidationGroup="VGCrearCharla2"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlTipodeCharla2" InitialValue="0" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="nivel-charlas">Nivel</label>
                                <asp:DropDownList runat="server" ID="DdlNivelCharlas2" CssClass="form-control" ValidationGroup="VGCrearCharla2"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlNivelCharlas2" InitialValue="0" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="tipo-numero-charla">Nº De Charla</label>
                                <select class="form-control" id="DdlNumeroCharla2" runat="server">
                                    <option selected ="0">Seleccione</option>
                                    <option>1</option>
                                    <option>2</option>
                                    <option>3</option>
                                    <option>4</option>
                                    <option>5</option>
                                    <option>6</option>
                                    <option>7</option>
                                    <option>8</option>
                                    <option>9</option>
                                    <option>10</option>
                                </select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="aforo">Nº Max Participantes</label>

                                <asp:TextBox runat="server" ID="TxtMaxCantParticipantes2" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtMaxCantParticipantes2" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtMaxCantParticipantes2" ForeColor="Red" ValidationGroup="VGCrearCharla2"></asp:RegularExpressionValidator>

                            </div>
                        </div>
                       <%-- <div class="col-md-6">
                            <div class="form-group">
                                <label for="aforo">Nº Mde Charla</label>

                                <asp:TextBox runat="server" ID="TxtNumeroCharla2" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtNumeroCharla2" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNumeroCharla2" ForeColor="Red" ValidationGroup="VGCrearCharla2"></asp:RegularExpressionValidator>

                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="modal-footer">
                     <asp:LinkButton ID="Button1" runat="server" Text="Completar Cambio" CssClass="btn btn-primary mr-3" OnClick=" BtnModificarCharla_2" ValidationGroup="VGCrearCharla2"/>

                  <!--  <button type="button" class="btn btn-secondary" data-dismiss="modal" data-target="#modal-crear-charla">Cancelar</button> -->

                    <a data-dismiss="modal" href="#" class="btn btn-secondary" data-toggle="modal" data-target="#modal-asistencia" data-whatever="@getbootstrap" runat="server" id="A2">Cancelar</a>
                           
                </div>
            </div>
        </div>
    </div>

      <!-- Modal Certificados --> 

     <div class="modal fade" id="modal-certificados" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalabelCertificados">Generar Certificados</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row bb pl-4 pr-4 pb-4 mb-4">
                        <div class="col">
                            <div class="form-group">

                                <label for="fecha-charla">Adiestrador Educativo</label>
                                <div class="input-group">
                                   
                                <asp:DropDownList runat="server" ID="DdlAdiestrador" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlAdiestrador" InitialValue="0"></asp:RequiredFieldValidator>
                            
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="fecha-charla">Supervisor de Programa</label>
                                <div class="input-group">
                                    
                                <asp:DropDownList runat="server" ID="DdlSupervisor" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlSupervisor" InitialValue="0"></asp:RequiredFieldValidator>
                            
                                </div>

                            </div>
                        </div>

                      
                    </div>
                </div>
                <div class="modal-footer">
                     <asp:LinkButton ID="LinkButton1" runat="server" Text="Generar Certificados" CssClass="btn btn-primary mr-3" OnClick="BtnGenerarCertificados" />

                  <!--  <button type="button" class="btn btn-secondary" data-dismiss="modal" data-target="#modal-crear-charla">Cancelar</button> -->

                    <a data-dismiss="modal" href="#" class="btn btn-secondary" data-toggle="modal" data-target="#modal-Info-Charla" data-whatever="@getbootstrap" runat="server" id="A4">Cancelar</a>
                           
                </div>
            </div>
        </div>
    </div>

   
   <!-- Pantalla completa -->
    <div class="container-fluid main">

        <div class="row">

             <!-- Botones de Crear Charlas y Asignar Excepcion -->
             <div class="col-md-3">

                <div class="card mb-3">

                    <div class="card-header">
                       Charlas Socio-Educativas
                    </div>

                     <div class="card-block">
                         <div class="form-group">
                            <label for="orden">Centro</label>

                            <asp:DropDownList ID="DdlCentro" runat="server" CssClass="custom-select w-100" AutoPostBack="true" OnSelectedIndexChanged="DdlCentro_SelectedIndexChanged" ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Requerido" InitialValue="0" ForeColor="Red" ControlToValidate="DdlCentro" Display="Dynamic"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">

                            <div id="DivBtnModalAsignarCita" runat="server">
                                <p class="txt-grey">Seleccione horarios disponibles en el calendario</p>

                                <%--<button type="button" class="btn btn-primary col text-center" data-toggle="modal" data-target="#modal-Asignar-Excepcion">
                                    Asignar Excepcion
                                </button>--%>

                                <div class="form-group" id="Div1" runat="server">
                                
                                <a href="#" class="btn btn-primary btn-block" data-toggle="modal" data-target="#modal-crear-charla" data-whatever="@getbootstrap" runat="server" id="btnCrearCharla">Registrar Charla</a>
                                </div>
                            </div>
                            <br />
                            <a href="<%=ResolveClientUrl("~/Dashboard-Usuarios.aspx")%>" class="btn btn-secondary btn-block mb-4">Volver a mi Tablero</a>
                        </div>
                    </div>
                </div>

              </div>


            <!-- Contenedor Calendario -->
            <div class="col">

                <div class="card mb-3">
                    <div class="card-header">
                        Calendario Adminstrador Charlas Grupales
                     <!--   <uc1:WUCUsuario runat="server" ID="WUCUsuario" /> -->
                    </div>
                    <div class="card-block calendario-opciones">
                        <div class="row">
                            <div class="col">
                                <asp:Button ID="BtnHoy" runat="server" Text="Hoy" class="btn btn-secondary btn-sm" OnClick="BtnHoy_Click" CausesValidation="false" />
                                <asp:LinkButton ID="BtnLeft" runat="server" class="btn btn-secondary btn-sm" Text="<img src='../images/izquierda.png' alt='ASSMCA'>" OnClick="BtnLeft_Click" CausesValidation="false"><img src="<%=ResolveClientUrl("~/images/izquierda.png")%>" alt="ASSMCA"></asp:LinkButton>
                                <asp:LinkButton ID="BtnRight" runat="server" Text="<img src='../images/derecha.png' alt='ASSMCA'>" class="btn btn-secondary btn-sm" OnClick="BtnRight_Click" CausesValidation="false"><img src="<%=ResolveClientUrl("~/images/derecha.png")%>" alt="ASSMCA"></asp:LinkButton>
                                <asp:Literal ID="LiMesAno" runat="server"></asp:Literal>

                            </div>
                            <div class="col">
                            </div>
                            <div class="col text-right">
                            </div>
                        </div>
                    </div>

                    <div class="card-block leyenda">
                        Leyenda: &nbsp; 
       
                        <a href="#" data-toggle="tooltip" data-html="true" title='1era CHARLA'><span class="bloque-leyenda grupo1"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='2da CHARLA'><span class="bloque-leyenda grupo2"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='3era CHARLA'><span class="bloque-leyenda grupo3"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='4ta CHARLA'><span class="bloque-leyenda grupo4"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='5ta CHARLA'><span class="bloque-leyenda grupo5"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='6ta CHARLA'><span class="bloque-leyenda grupo6"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='7ma CHARLA'><span class="bloque-leyenda grupo7"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='8va CHARLA'><span class="bloque-leyenda grupo8"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='9na CHARLA'><span class="bloque-leyenda grupo9"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='10ma CHARLA'><span class="bloque-leyenda grupo10"></span></a>Disponible (Click para asignar) &nbsp; &nbsp; &nbsp; 
                        <a href="#" data-toggle="tooltip" data-html="true" title='NO HAY ESPACIO (CERRADO)'><span class="bloque-leyenda nohay"></span></a>
                        
     
                    </div>

                    <div>


                        <div class="calendario">

                            <div class="card-group">
                                <!-- Semana -->
                                <div class="card dia-libre">
                                    <div class="card-header">
                                        DOM
                                        <br>
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia1" runat="server"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda1" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        LUN
                                        <br>
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia2" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda2" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        MAR
                                        <br>
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia3" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda3" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        MIE
                                        <br>
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia4" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda4" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        JUE
                                        <br>
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia5" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda5" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        VIE
                                        <br>
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia6" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda6" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        SAB
                                        <br>
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia7" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda7" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <!-- Card-Group -->



                            <div class="card-group">
                                <!-- Semana -->
                                <div class="card dia-libre">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia8" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda8" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia9" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda9" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia10" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda10" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia11" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda11" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia12" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda12" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia13" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda13" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia14" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda14" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <!-- Card-Group -->


                            <div class="card-group">
                                <!-- Semana -->
                                <div class="card dia-libre">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia15" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda15" runat="server" EnableViewState="false"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia16" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda16" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia17" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda17" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia18" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda18" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia19" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda19" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia20" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda20" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia21" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda21" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <!-- Card-Group -->

                            <div class="card-group">
                                <!-- Semana -->
                                <div class="card dia-libre">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia22" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda22" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia23" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda23" runat="server"></asp:Literal>

                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia24" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda24" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia25" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda25" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia26" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda26" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia27" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda27" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia28" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda28" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <!-- Card-Group -->


                            <div class="card-group">
                                <!-- Semana -->
                                <div class="card dia-libre">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia29" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda29" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia30" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda30" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia31" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda31" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia32" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda32" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia33" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda33" runat="server"></asp:Literal>

                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia34" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda34" runat="server"></asp:Literal>

                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header">
                                        <span class="dia">
                                            <asp:Literal ID="LitNumDia35" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="card-block">
                                        <asp:Literal ID="LitContCelda35" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <!-- Card-Group -->


                        </div>

                    </div>
                </div>
                <!-- Card -->
            </div>
        </div>


    </div> 
    <!-- container-fluid -->
    <script type="text/javascript">
        if ( window.history.replaceState ) {
           window.history.replaceState( null, null, window.location.href );
        }
        function openModal() {
           
                                $('#modal-Info-Charla').modal({ show: true });
                            }

                            function changeDivContent(Id_CharlaGrupal, userId, activa) {
                                
                                if (activa == "True") {
                                    document.getElementById("<%=A1.ClientID %>").style.visibility = 'hidden';
                                    document.getElementById("<%=BtnEliminarCharla.ClientID %>").style.visibility = 'hidden';
                                    
                                }
                                else {
                                    document.getElementById("<%=A1.ClientID %>").style.visibility = 'visible';
                                    document.getElementById("<%=BtnEliminarCharla.ClientID %>").style.visibility = 'visible';
                                    
                                }
                            document.getElementById("<%=Id_CharlaGrupal.ClientID %>").value = Id_CharlaGrupal;
                            document.getElementById("<%=H_Id_CharlaGrupal.ClientID%>").value = Id_CharlaGrupal;
                       

                          

                           var ajax_data = '{Id_CharlaGrupal:"'  + Id_CharlaGrupal + '", userId:"' + userId + '"}'


                           $.ajax({
                               type: "POST",
                               cache: false,
                               url: "WSCalendarioGrupal.asmx/BindModalParticipantes",
                               data: ajax_data,
                               contentType: "application/json; charset=utf-8",
                               dataType: "json",
                               success: OnGetAllMembersSuccess,
                               error: function (request, status, error) {
                                   alert(request);
                                   alert(status);
                                   alert(error);
                               }
                           });
                                }

                            

                            function OnGetAllMembersSuccess(data, status) {

                                var myData = data.d;
                                $("#bodyLista").empty();
                                $("#TipoCharlaNivel").html(myData.TipoCharlaNivel);
                                $("#FechaHoraCharla").html(myData.FechaHoraCharla);
                                $("#bodyLista").append(myData.Participantes);
                                $("#BtnAsistencia").html(myData.AdcionarParticipante);
                                

                            }

                            function changeDivContent2(Fecha, Horas, NumerodeExcepcion) {

                                document.getElementById("Fecha2").innerHTML = "<b>Excepcion para el día:</b> " + Fecha;
                                document.getElementById("Horas2").innerHTML = "<b>Hora:</b> " + Horas;
            

                                document.getElementById("<%= HNroExcepcion.ClientID %>").value = NumerodeExcepcion;

                            }

                            function modalModificar(Fecha,FechaInicial, FechaFinal, Id_TipoCharla, Id_NiveldeCharla, NrodeParticipantes, NumeroCharla) {

                                document.getElementById("<%=TxtFechaModCharla.ClientID %>").value = Fecha;
                                document.getElementById("<%=TxtIncialModCharla.ClientID %>").value = FechaInicial;
                                document.getElementById("<%=TxtFinalModCharla.ClientID %>").value = FechaFinal;
                                document.getElementById("<%=DdlTipodeCharla2.ClientID %>").value = Id_TipoCharla;
                                document.getElementById("<%=DdlNivelCharlas2.ClientID %>").value = Id_NiveldeCharla;
                                document.getElementById("<%=DdlNumeroCharla2.ClientID %>").value = NumeroCharla;
                                document.getElementById("<%=TxtMaxCantParticipantes2.ClientID %>").value = NrodeParticipantes;
                            }

        function checkDate(sender, args) {
            if (sender._selectedDate.getDate() != new Date().getDate() && sender._selectedDate < new Date()) {
                alert("You cannot select a day earlier than today!");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }

         function sweetAlert(titulo,texto,icono) {
             
             swal({
                 title: titulo,
                 html: texto,
                 icon: icono
             }
             );

             
             $('#modal-Info-Charla').modal({ show: true });
        }

        function asistenciaAlerta(titulo, texto, icono) {
            
            swal({
                
                title: titulo,
                text: texto,
                icon: icono
            }
            );

          //  $('#modal-Info-Charla').modal({ show: true });
        }

        function imprimirCertificado(IdParticipante, IdCasoCriminal) {
            document.getElementById("<%=H_Id_Participante.ClientID %>").value = IdParticipante;
            document.getElementById("<%=H_Id_CasoCriminal.ClientID %>").value = IdCasoCriminal;
            document.getElementById("<%=BtnPrint.ClientID %>").click();
        }

    </script>

</asp:Content>

