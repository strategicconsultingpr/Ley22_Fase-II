<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="asignar_citas_individual"  Codebehind="asignar-citas-individual.aspx.cs" %>

 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Modal -->
    <div class="modal fade" id="modal-Asignar-Cita" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel5">Asignar Cita </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col">Fecha:</div>
                            <div class="col">

                                <asp:TextBox ID="TxtFecha" runat="server" class="form-control" placeholder="Ej. mm/dd/yyyy" MaxLength="10"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFecha_CalendarExtender" runat="server" BehaviorID="TxtFecha_CalendarExtender" TargetControlID="TxtFecha" OnClientDateSelectionChanged="checkDate"/>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFecha" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtFecha" Display="Dynamic"> </asp:RequiredFieldValidator>

                            </div>


                        </div>

                        <div class="row">
                            <div class="col">Hora inicial:</div>
                            <div class="col">
                                <asp:TextBox ID="TxtHoraInicial" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="TxtHoraInicial"  ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:regularexpressionvalidator ControlToValidate="TxtHoraInicial" runat="server" errormessage="*Formato hh:mm am/pm" ForeColor ="Red"  Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))"></asp:regularexpressionvalidator>

                           </div>

                        </div>
                        <div class="row">
                            <div class="col">Hora Final:</div>
                            <div class="col">
                                <asp:TextBox ID="TxtHoraFinal" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="TxtHoraFinal" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido"  Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:regularexpressionvalidator ControlToValidate="TxtHoraFinal" runat="server" errormessage="*Formato hh:mm am/pm" ForeColor ="Red"  Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))"></asp:regularexpressionvalidator>
                             </div>

                        </div>


                        <script type="text/javascript">
                            var $ele = $('input[name="<%=TxtHoraInicial.UniqueID %>"]');
                                $ele.ptTimeSelect({
                                    containerClass: undefined,
                                    containerWidth: undefined,
                                    hoursLabel: 'Hora',
                                    minutesLabel: 'Minutos',
                                    setButtonLabel: 'Seleccionar',
                                    popupImage: undefined,
                                    onFocusDisplay: true,
                                    zIndex: 10000,
                                    onBeforeShow: undefined,
                                    onClose: undefined /*function (selectedTime) {


                                        var re = /([0-9]{1,2}).*:.*([0-9]{2}).*(PM|AM)/i;
                                        var match = re.exec(selectedTime);
                                        alert(re.exec(selectedTime));
                                      //  alert(String(match[3]));
                                        

                                            var hr = parseInt(match[1]),
                                                min = parseInt(match[2]),
                                                tm = String(match[3]).toLowerCase()

                                            if (tm === "am" && hr < 9) {

                                                alert("Error: Time is prior to 9AM");
                                                $ele.val("");
                                                return;

                                            } else if (tm === "pm" && (hr > 5 || (hr === 5 && min !== 0))) {

                                                alert("Error: Time is after 5PM");
                                                $ele.val("");
                                                return;

                                            }

                                        

                                    } */

                                    
                                });
 
                            $('input[name="<%=TxtHoraFinal.UniqueID %>"]')
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

                <div class="modal-footer">
                    <asp:Button ID="btnAsignarCita" runat="server" Text="Asignar Cita" CssClass="btn btn-primary" OnClick="btnAsignarCita_Click" />
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cancelar</button>
                </div>




            </div>
        </div>
    </div>

    <!-- Modal -->

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
 
                    <div id="Programa"></div>
                    <br />
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

                 
                  
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

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

     <!-- Modal Asistio-->

    <div class="modal fade" id="asistio-cita" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Detalle de la Cita</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
 
                    <h2 style="color:green; align-self:center" >Cita Completada</h2>
                    <div id="ProgramaA"></div>
                    <br />
                    <div id="FechaA"></div>
                    <br />
                    <div id="HorasA"></div>
                    <input id="Hidden1" name="HNroCita" type="hidden" runat="server" />
                    <br />
                    <div id="NombreCompletoA"></div>
                    <br />
                    <div id="TelefonoContactoA"></div>
                    <br />
                </div>
                <div class="modal-footer">              
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>



    <div class="modal fade" id="myModalListaCitas">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Citas</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:GridView ID="GVListadeCitas" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Id_Calendario" HeaderText="Nro. Cita" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="FechaHora" HeaderText="Fecha" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="TrabajadorSocial" HeaderText="Trabajador Social" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NombreDelCentro" HeaderText="Centro" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="AsistioTexto" HeaderText="Asistencia" HeaderStyle-HorizontalAlign="Center" />

                        </Columns>

                    </asp:GridView>
                </div>

                <div class="modal-footer">
                    <asp:Literal ID="LitResumenCitas" runat="server"></asp:Literal>

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
                <!-- Card -->

                <!-- Card -->
                <div class="card mb-3">
                    <div class="card-header">
                        Región
                    </div>
                    <div class="card-block">
                        <%--<div class="form-group">
                            <label for="orden">Región</label>
                            <asp:DropDownList ID="DdlRegion" runat="server" CssClass="custom-select w-100" AutoPostBack="true" OnSelectedIndexChanged="DdlRegion_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Requerido" InitialValue="0" ForeColor="Red" ControlToValidate="DdlRegion" Display="Dynamic"></asp:RequiredFieldValidator>

                        </div>--%>
                        <div class="form-group">
                            <label for="orden">Centro</label>

                            <asp:DropDownList ID="DdlCentro" runat="server" CssClass="custom-select w-100" AutoPostBack="true" OnSelectedIndexChanged="DdlCentro_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Requerido" InitialValue="0" ForeColor="Red" ControlToValidate="DdlCentro" Display="Dynamic"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label for="orden">Trabajador Social</label>
                            <asp:DropDownList ID="DdlTrabajadorSocial" runat="server" CssClass="custom-select w-100" OnSelectedIndexChanged="DdlTrabajadorSocial_SelectedIndexChanged" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Requerido" InitialValue="0" ForeColor="Red" ControlToValidate="DdlTrabajadorSocial" Display="Dynamic"></asp:RequiredFieldValidator>

                        </div>

                        <div class="form-group">
                            <div id="DivBtnModalAsignarCita" runat="server" visible="false">
                                <p class="txt-grey">Seleccione horarios disponibles en el calendario</p>

                                <button type="button" class="btn btn-primary col text-center" data-toggle="modal" data-target="#modal-Asignar-Cita">
                                    Asignar Cita
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Card -->
                <div class="card mb-3">
                    <div class="card-header">
                        Citas Asignadas
                    </div>
                    <div class="card-block">
                        <span>
                            <asp:HyperLink ID="HLCitas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCitas"></asp:HyperLink>
                        </span>
                        <br />
 
                        <asp:Button ID="BtnDocumentos" runat="server" Text="Lista de Documentos" CssClass="btn btn-primary btn-block" OnClick="BtnDocumentos_Click" CausesValidation="false" />
                        <asp:HyperLink ID="Hyperlink" runat="server" Enable="true" NavigateUrl="~/nuevo-confirmacion.aspx" CssClass="btn btn-link btn-block">Volver al Registro</asp:HyperLink>
                        <asp:HyperLink ID="Hyperlink1" runat="server" Enable="true" NavigateUrl="~/seleccion-proximo-paso.aspx" CssClass="btn btn-link btn-block">Ir a cuenta de Usuario</asp:HyperLink>
                    </div>
                </div>
                <!-- Card -->
            </div>
            <!-- Contenedor Calendario -->
            <div class="col">

                <div class="card mb-3">
                    <div class="card-header">
                        Calendario Cita Trabajador Social : 
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
                            <div class="col">
                            </div>
                            <div class="col text-right">
                            </div>
                        </div>
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
    <script>

        function changeDivContent(Fecha, Horas, NombreCompleto, TelefonoContacto, NumerodeCita, Programa) {

            document.getElementById("Programa").innerHTML = "<b>Programa:</b> " + Programa;
            document.getElementById("Fecha").innerHTML = "<b>Cita de Pre-Evaluación para el día:</b> " + Fecha;
            document.getElementById("Horas").innerHTML = "<b>Hora:</b> " + Horas;
            document.getElementById("NombreCompleto").innerHTML = "<b>Usuario:</b> " + NombreCompleto;
            document.getElementById("TelefonoContacto").innerHTML = "<b>Teléfono Contacto:</b> " + TelefonoContacto;
             
            document.getElementById("<%= HNroCita.ClientID %>").value = NumerodeCita;
       
                            }

        function changeDivContent2(Fecha, Horas, NumerodeExcepcion) {

            document.getElementById("Fecha2").innerHTML = "<b>Excepcion para el día:</b> " + Fecha;
            document.getElementById("Horas2").innerHTML = "<b>Hora:</b> " + Horas;


            document.getElementById("<%= HNroExcepcion.ClientID %>").value = NumerodeExcepcion;

        }
        function changeDivContentAsistio(Fecha, Horas, NombreCompleto, TelefonoContacto, NumerodeCita,Programa) {

            document.getElementById("ProgramaA").innerHTML = "<b>Programa:</b> " + Programa;
            document.getElementById("FechaA").innerHTML = "<b>Cita de Pre-Evaluacion para el día:</b> " + Fecha;
            document.getElementById("HorasA").innerHTML = "<b>Hora:</b> " + Horas;
            document.getElementById("NombreCompletoA").innerHTML = "<b>Participante:</b> " + NombreCompleto;
            document.getElementById("TelefonoContactoA").innerHTML = "<b>Teléfono Contacto:</b> " + TelefonoContacto;
             
            document.getElementById("<%= HNroCita.ClientID %>").value = NumerodeCita;
       
         }

    </script>

</asp:Content>

