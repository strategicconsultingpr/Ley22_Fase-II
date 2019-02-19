<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="charlas_grupales" Codebehind="charlas-grupales.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <input id="Id_CharlaGrupal" name="Id_CharlaGrupal" type="hidden" runat="server" />
            <asp:HiddenField ID="H_Id_CharlaGrupal" runat="server" />
            

    <!-- Modal -->
    <div class="modal fade" id="modal-crear-charla" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Crear nueva Charla</h5>
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
                                    <div class="input-group-addon"><span class="far fa-calendar-alt"></span></div>
                                    <asp:TextBox ID="TxtFechaCrearCharla" runat="server" class="form-control" placeholder="Ej. mm/dd/yyyy" ValidationGroup="VGCrearCharla"  ></asp:TextBox>

                                    <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaNacimiento_CalendarExtender" runat="server" BehaviorID="TxtFechaNacimiento_CalendarExtender" TargetControlID="TxtFechaCrearCharla" OnClientDateSelectionChanged="checkDate" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFechaCrearCharla" ForeColor="Red" Display="Dynamic" ValidationGroup="VGCrearCharla"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="<br />*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtFechaCrearCharla" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="hora-charla">Hora Inicial</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><span class="far fa-clock"></span></div>

                                    <asp:TextBox ID="TxtInicialCrearCharla" runat="server" class="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="TxtInicialCrearCharla" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" Display="Dynamic" ForeColor="Red" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="TxtInicialCrearCharla" runat="server" ErrorMessage="*Formato hh:mm am/pm" ForeColor="Red" Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))" ValidationGroup="VGCrearCharla"></asp:RegularExpressionValidator>

                                </div>

                            </div>
                        </div>

                        <div class="col">
                            <div class="form-group">
                                <label for="hora-charla">Hora Final</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><span class="far fa-clock"></span></div>
                                    <asp:TextBox ID="TxtFinalCrearCharla" runat="server" class="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="TxtFinalCrearCharla" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" Display="Dynamic" ForeColor="Red" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="TxtFinalCrearCharla" runat="server" ErrorMessage="*Formato hh:mm am/pm" ForeColor="Red" Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))" ValidationGroup="VGCrearCharla"></asp:RegularExpressionValidator>

                                    <script type="text/javascript">
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
                                                onClose: undefined
                                            });


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

                                        function checkDate(sender, args) {
                                            if (sender._selectedDate.getDate() != new Date().getDate() && sender._selectedDate < new Date()) {
                                                alert("You cannot select a day earlier than today!");
                                                sender._selectedDate = new Date();
                                                // set the date back to the current date
                                                sender._textbox.set_Value(sender._selectedDate.format(sender._format))

                                            }

                                        }
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
                            <%--<div class="form-group">
                                <label for="tipo-numero-charla">Tipo Charla</label>
                                <select class="form-control" id="tipo-numero-charla">
                                    <option selected>Seleccione</option>
                                    <option>1</option>
                                    <option>2</option>
                                    <option>3</option>
                                    <option>4</option>
                                    <option>5</option>
                                </select>
                            </div>--%>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="aforo">Nº Max Participantes</label>

                                <asp:TextBox runat="server" ID="TxtMaxCantParticipantes" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtMaxCantParticipantes" ValidationGroup="VGCrearCharla"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtMaxCantParticipantes" ForeColor="Red" ValidationGroup="VGCrearCharla"></asp:RegularExpressionValidator>

                            </div>
                        </div>
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
                                    <div class="input-group-addon"><span class="far fa-calendar-alt"></span></div>
                                    <asp:TextBox ID="TxtFecha2" runat="server" class="form-control" placeholder="Ej. mm/dd/yyyy" ValidationGroup="VGCrearCharla2"  ></asp:TextBox>

                                    <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaNacimiento_CalendarExtender2" runat="server" BehaviorID="TxtFechaNacimiento_CalendarExtender" TargetControlID="TxtFecha2"  />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFecha2" ForeColor="Red" Display="Dynamic" ValidationGroup="VGCrearCharla2"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="<br />*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtFecha2" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="hora-charla">Hora Inicial</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><span class="far fa-clock"></span></div>

                                    <asp:TextBox ID="TxtHoraInicial2" runat="server" class="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="TxtHoraInicial2" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Requerido" Display="Dynamic" ForeColor="Red" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="TxtHoraInicial2" runat="server" ErrorMessage="*Formato hh:mm am/pm" ForeColor="Red" Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))" ValidationGroup="VGCrearCharla2"></asp:RegularExpressionValidator>

                                </div>

                            </div>
                        </div>

                        <div class="col">
                            <div class="form-group">
                                <label for="hora-charla">Hora Final</label>
                                <div class="input-group">
                                    <div class="input-group-addon"><span class="far fa-clock"></span></div>
                                    <asp:TextBox ID="TxtHoraFinal2" runat="server" class="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="TxtHoraFinal2" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Requerido" Display="Dynamic" ForeColor="Red" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="TxtHoraFinal2" runat="server" ErrorMessage="*Formato hh:mm am/pm" ForeColor="Red" Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))" ValidationGroup="VGCrearCharla2"></asp:RegularExpressionValidator>

                                    <script type="text/javascript">
                                        $('input[name="<%=TxtHoraInicial2.UniqueID %>"]')
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


                                        $('input[name="<%=TxtHoraFinal2.UniqueID %>"]')
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
                                    </script>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row pl-4 pr-4 pb-4 mb-4">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="tipo-charlas">Tipo Charlas</label>
                                <asp:DropDownList runat="server" ID="DdlTipodeCharla2" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlTipodeCharla2" InitialValue="0" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="nivel-charlas">Nivel</label>
                                <asp:DropDownList runat="server" ID="DdlNivelCharlas2" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlNivelCharlas2" InitialValue="0" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <%--<div class="form-group">
                                <label for="tipo-numero-charla">Tipo Charla</label>
                                <select class="form-control" id="tipo-numero-charla">
                                    <option selected>Seleccione</option>
                                    <option>1</option>
                                    <option>2</option>
                                    <option>3</option>
                                    <option>4</option>
                                    <option>5</option>
                                </select>
                            </div>--%>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="aforo">Nº Max Participantes</label>

                                <asp:TextBox runat="server" ID="TxtMaxCantParticipantes2" CssClass="form-control" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="TxtMaxCantParticipantes2" ValidationGroup="VGCrearCharla2"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtMaxCantParticipantes2" ForeColor="Red" ValidationGroup="VGCrearCharla2"></asp:RegularExpressionValidator>

                            </div>
                        </div>
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


    <!-- Modal -->
    <div class="modal fade" id="modal-asistencia" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">
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
                             <a data-dismiss="modal" href="#" class="btn btn-primary btn-block" data-toggle="modal" data-target="#modal-crear-charla_2" data-whatever="@getbootstrap" runat="server" id="A1" visible="false" >Modificar Charla</a>
                            <asp:LinkButton runat="server" ID="BtnEliminarCharla" Text="Eliminar Charla" class="btn btn-primary btn-block" OnClick="BtnEliminar_Click" visible="false" ></asp:LinkButton>
                             <asp:LinkButton runat="server" ID="BtnGetCharla" Text="" Style="display:none;" OnClick="BtnModificarCharla" />
                        </div>
                    </div>
                    <div class="row pl-4 pr-4">
                        <div class="col-md-6">
                            <p><strong>Asistentes</strong></p>
                            <div id="Participantes"></div>

                        </div>

                        <div class="col-md-6">
                             <div id="AdcionarParticipante"></div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
<%--                    <button type="button" class="btn btn-primary btn-lg" data-dismiss="modal">Aceptar</button>
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Imprimir</button> --%>
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="modal-orden-jucicial" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Asignar Número de Orden Judicial</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>
                        Este usuario <strong>Tiene
                        <asp:Literal ID="LitCantidadOrdenesJudiciales" runat="server"></asp:Literal>
                        </strong>Órdenes Judiciales Activas
                    </p>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="ingresar-orden-judicial">Ingresar Nueva Orden Judicial</label>
                                <asp:TextBox ID="TxtNumeroOrdenJudicial" runat="server" CssClass="form-control" MaxLength="50" ValidationGroup="VGNuevaOrdenJudicial"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Requerido" ControlToValidate="TxtNumeroOrdenJudicial" Display="Dynamic" ForeColor="Red" ValidationGroup="VGNuevaOrdenJudicial"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="BtnGuardarOrdenJudicial" runat="server" Text="Guardar" CssClass="btn btn-primary btn-lg" OnClick="BtnGuardarOrdenJudicial_Click" ValidationGroup="VGNuevaOrdenJudicial" />
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Ver y Eliminar Excepcion -->

    <div class="modal fade" id="asignar-excepcion-confirmacion" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel3">Detalle de la Excepcion</h5>
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
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid main">

        <div class="row">

            <div class="col-md-3">
                <div class="card mb-3">
                    <div class="card-header">

              
                        Orden Judicial
                    </div>
                    <div class="card-block">
                        <label for="orden">Número asocialdo a la cita</label>


                        <div class="row">
                            <div class="col-10">
                                <asp:DropDownList ID="DdlNumeroOrdenJudicial" runat="server" CssClass="custom-select w-100" AutoPostBack="true" OnSelectedIndexChanged="DdlNumeroOrdenJudicial_Selected"></asp:DropDownList>
                            </div>
                            <div class="col-2">
                                <a href="#" data-toggle="modal" data-target="#modal-orden-jucicial" data-whatever="@getbootstrap"><span class="fas  fa-plus-circle fa-lg" data-toggle="tooltip" title="Agregar Orden Judicial"></span></a>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Requerido" InitialValue="0" ForeColor="Red" ControlToValidate="DdlNumeroOrdenJudicial" Display="Dynamic"></asp:RequiredFieldValidator>

                    </div>
                </div>


                <div class="card mb-3">



                    <div class="card-header">
                        Región
     
                    </div>
                    <div class="card-block">
                        <p>Seleccione la región y haga clic en el calendario para ver la lista de asistentes.</p>
                        <%--<div class="form-group">
                            <label for="orden">Región</label>
                            <asp:DropDownList ID="DdlRegion" runat="server" CssClass="custom-select w-100" AutoPostBack="true" OnSelectedIndexChanged="DdlRegion_SelectedIndexChanged"></asp:DropDownList>

                        </div>--%>
                        <div class="form-group">
                            <label for="orden">Centro</label>
                            <asp:DropDownList ID="DdlCentro" runat="server" CssClass="custom-select w-100" AutoPostBack="true" OnSelectedIndexChanged="DdlCentro_SelectedIndexChanged"></asp:DropDownList>

                        </div>

                        <div class="form-group" id="DivBtnModalAsignarCita" runat="server" visible="false">
                            <p class="txt-grey">Seleccione horarios disponibles en el calendario</p>
                            <a href="#" class="btn btn-primary btn-block" data-toggle="modal" data-target="#modal-crear-charla" data-whatever="@getbootstrap" runat="server" id="btnCrearCharla" visible="false">Crear Charla</a>

                        </div>
                        <asp:Button ID="BtnDocumentos" runat="server" Text="Lista de Documentos" CssClass="btn btn-primary btn-block" OnClick="BtnDocumentos_Click" CausesValidation="false" />
                        <asp:HyperLink ID="Hyperlink1" runat="server" Enable="true" NavigateUrl="~/seleccion-proximo-paso.aspx" CssClass="btn btn-link btn-block">Ir a cuenta de Usuario</asp:HyperLink>
                    </div>
                </div>
                <!-- Card -->
            </div>
            <!-- Contenedor Calendario -->
            <div class="col">
                <div class="card mb-3 card-outline-primary">
                    <div class="card-header card-header-primary">
                        Calendario Charlas Grupales :
                        <uc1:WUCUsuario runat="server" ID="WUCUsuario" />

                    </div>
                    <div class="card-block calendario-opciones">
                        <div class="row">
                            <div class="col">

                                <asp:Button ID="BtnHoy" runat="server" Text="Hoy" class="btn btn-secondary btn-sm" OnClick="BtnHoy_Click" CausesValidation="false" />
                                <asp:LinkButton ID="BtnLeft" runat="server" class="btn btn-secondary btn-sm" Text="<span class='fas fa-chevron-left'></span>" OnClick="BtnLeft_Click" CausesValidation="false" />
                                <asp:LinkButton ID="BtnRight" runat="server" Text="<span class='fas fa-chevron-right'></span>" class="btn btn-secondary btn-sm" OnClick="BtnRight_Click" CausesValidation="false" />
                                <asp:Literal ID="LiMesAno" runat="server"></asp:Literal>

                            </div>
                            <div class="col text-right">
                                <%--                                <button class="btn btn-link active">MES</button>
                                <button class="btn btn-link">SEMANA</button>
                                <button class="btn btn-link">DIA</button>--%>
                            </div>
                        </div>
                    </div>
                    <div class="card-block leyenda">
                        Leyenda: &nbsp; 
       
                        <a href="#" data-toggle="tooltip" data-html="true" title='Alcoholismo <br><span class="bloque-leyenda grupo1"></span> Nivel 1 <br><span class="bloque-leyenda grupo1 nvl2"></span> Nivel 2 <br><span class="bloque-leyenda grupo1 nvl3"></span> Nivel 3 <br><span class="bloque-leyenda grupo1 nvl4"></span> Nivel 4 <br><span class="bloque-leyenda grupo1 nvl5"></span> Nivel 5 <br>'><span class="bloque-leyenda grupo1"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='Abuso de Substancias <br><span class="bloque-leyenda grupo2"></span> Nivel 1 <br><span class="bloque-leyenda grupo2 nvl2"></span> Nivel 2 <br><span class="bloque-leyenda grupo2 nvl3"></span> Nivel 3 <br><span class="bloque-leyenda grupo2 nvl4"></span> Nivel 4 <br><span class="bloque-leyenda grupo2 nvl5"></span> Nivel 5 <br>'><span class="bloque-leyenda grupo2"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='Grupo 3 <br><span class="bloque-leyenda grupo3"></span> Nivel 1 <br><span class="bloque-leyenda grupo3 nvl2"></span> Nivel 2 <br><span class="bloque-leyenda grupo3 nvl3"></span> Nivel 3 <br><span class="bloque-leyenda grupo3 nvl4"></span> Nivel 4 <br><span class="bloque-leyenda grupo3 nvl5"></span> Nivel 5 <br>'><span class="bloque-leyenda grupo3"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='Grupo 4 <br><span class="bloque-leyenda grupo4"></span> Nivel 1 <br><span class="bloque-leyenda grupo4 nvl2"></span> Nivel 2 <br><span class="bloque-leyenda grupo4 nvl3"></span> Nivel 3 <br><span class="bloque-leyenda grupo4 nvl4"></span> Nivel 4 <br><span class="bloque-leyenda grupo4 nvl5"></span> Nivel 5 <br>'><span class="bloque-leyenda grupo4"></span></a>Disponible (Click para asignar) &nbsp; &nbsp; &nbsp; <span class="bloque-leyenda nohay"></span>
                        No hay Plazas (Cerrado)
     
                    </div>
                    <div>
                        <!-- comienzo calendario -->

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

         <asp:Button runat="server" ID="btnSample" Text="" style="display:none;" OnClick="btnPrueba" />
    </div>
               <script type="text/javascript">

                  <%-- function region()
                   {
                       document.getElementById('<%=DdlRegion.ClientID%>')
                       
                   }--%>
                   function changeDivContent4(Id_CharlaGrupal) {
                       $.ajax({
                           type: "POST",
                           url: '/WSCalendarioCharlas.asmx/hello',
                           data: "{ }",
                           contentType: "application/json; charset=utf-8",
                           dataType: "json",
                           success: function (msg) { alert(msg.d); },
                           error: function (request, status, error) {
                               alert(request);
                               alert(status.toString());
                               alert(error.toString());
                           }

                           });
                   }
                   function changeDivContent3(Id_CharlaGrupal) {
                      <%-- alert(Id_CharlaGrupal);
                       alert(<%=Session["Id_Participante"].ToString()%>);
                       alert('<%=Session["NombreParticipante"]%>');--%>
                       if (<%=Session["Id_Participante"].ToString()%> != null) {

                           document.getElementById("<%=Id_CharlaGrupal.ClientID %>").value = Id_CharlaGrupal;
                           document.getElementById("<%=H_Id_CharlaGrupal.ClientID%>").value = Id_CharlaGrupal;

                         //  var btn = document.getElementById('<%=BtnGetCharla.ClientID%>');
                         //  btn.click();
                            
                           // $("Id_CharlaGrupal").value = Id_CharlaGrupal; 

                           var Id_Participante = <%=Session["Id_Participante"].ToString()%>;
                           var NombreParticipante = '<%=Session["NombreParticipante"].ToString()%>';
                           alert(Id_Participante);
                           var ajax_data = '{Id_CharlaGrupal:"' + Id_CharlaGrupal + '" }';
                           


                           $.ajax({
                               type: "POST",
                               cache: false,
                               url: "WSCalendarioCharlas.asmx/HelloWorld",
                               data: ajax_data,
                               contentType: "application/json; charset=utf-8",
                               dataType: "json",
                               success: suc,
                               error: function (request, status, error) {
                                   alert(request);
                                   alert(status.toString());
                                   alert(error.toString());
                               }
                           });
                       }

                   }

                   function suc(data) {
                      
                       alert(data);
                   }

                 function changeDivContent(Id_CharlaGrupal) {
                      
                       if (<%=Session["Id_Participante"].ToString()%> != null) {

                           document.getElementById("<%=Id_CharlaGrupal.ClientID %>").value = Id_CharlaGrupal;
                           document.getElementById("<%=H_Id_CharlaGrupal.ClientID%>").value = Id_CharlaGrupal;

                 

                           var Id_Participante = <%=Session["Id_Participante"].ToString()%>;
                           var NombreParticipante = '<%=Session["NombreParticipante"].ToString()%>';
                           
                           var ajax_data = '{Id_CharlaGrupal:"' + Id_CharlaGrupal + '",Id_Participante:"' + Id_Participante + '",NombreParticipante:"' + NombreParticipante + '" }';
                           

                          
                           $.ajax({
                               type: "POST",
                               cache: false,
                               url: "/WSCalendarioGrupal.asmx/BindModalAsistencia",
                               data: ajax_data,
                               contentType: "application/json; charset=utf-8",
                               dataType: "json",
                               success: OnGetAllMembersSuccess,
                               error: function (request, status, error) {
                                   alert(request);
                                   alert(status.toString());
                                   alert(error.toString());
                               }
                               
                           });
                       }

                   }

                   

                   function OnGetAllMembersSuccess(data, status) { 
                       
                       var myData = data.d;
                       $("#TipoCharlaNivel").html(myData.TipoCharlaNivel);
                       $("#FechaHoraCharla").html(myData.FechaHoraCharla);
                       $("#Participantes").html(myData.Participantes);
                       $("#AdcionarParticipante").html(myData.AdcionarParticipante);
                       

                   }

                   function changeDivContent2(Fecha, Horas, NumerodeExcepcion) {

                       document.getElementById("Fecha2").innerHTML = "<b>Excepcion para el día:</b> " + Fecha;
                       document.getElementById("Horas2").innerHTML = "<b>Hora:</b> " + Horas;


                       document.getElementById("<%= HNroExcepcion.ClientID %>").value = NumerodeExcepcion;

                    }

    </script>
</asp:Content>

