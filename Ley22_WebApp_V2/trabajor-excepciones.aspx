<%@ Page Language="C#" Title="" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="trabajor_excepciones" Codebehind="trabajor-excepciones.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Modal -->
    <div class="modal fade" id="modal-Asignar-Cita" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel5">Asignar Excepcion </h5>
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
                             $(document).ready(function () {
                                            $('input[name="<%=TxtHoraInicial.UniqueID %>"]')
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
                                                    defaultHr: '10',         
                                                    defaultMin: '00',
                                                    defaultAmPm: 'AM'
                                                });
                                        });
                                        
                                        $(document).ready(function () {
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
                    <asp:Button ID="btnAsignarCita" runat="server" Text="Completar la Excepcion " CssClass="btn btn-primary" OnClick="btnAsignarCita_Click" />
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
                    <div id="TS"></div>
                    <br />
                </div>
                <div class="modal-footer">
                    <button type="button" id="BtnEliModal" data-toggle="modal" data-target="#modalEliminarCita" class="btn btn-danger btn-lg">Eliminar</button>
                    <%--<asp:Button ID="BtnEliminarCita" runat="server" Text="Eliminar"  class="btn btn-danger btn-lg" OnClientClick="return EliminarCita()"  CausesValidation="false"/>
                    --%><asp:Button ID="BtnAsistioCita" runat="server" Text="Asistio" CssClass="btn btn-success btn-lg" OnClick="BtnAsistioCita_Click" OnClientClick="if (!alertaAsistio()) return false;" CausesValidation="false"/>
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Observaciones -->
    <div class="modal fade" id="modalEliminarCita" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header text-center">
            <h4 class="modal-title w-100 font-weight-bold">Agregar Obeservación</h4>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body mx-3">
            <div class="md-form mb-5">
                <i class="fa fa-inbox"
              <i class="fas fa-envelope prefix grey-text"></i> &nbsp;<label  for="defaultForm-email">Entre la observación</label>
              <textarea cols="1" type="text" id="textObservacion" runat="server" class="md-textarea form-control" rows="6"></textarea>
              
            </div>
              <input id="Hidden2" name="HObservacionCita" type="hidden" runat="server" />
          </div>
          <div class="modal-footer d-flex justify-content-center">
            <asp:Button ID="BtnEnvioObs" runat="server" Text="Enviar"  class="btn btn-danger btn-lg" OnClick="BtnELiminarCita_Click" OnClientClick="return EliminarCita()" CausesValidation="false"/>
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
                    <div id="TSA"></div>
                    <br />
                </div>
                <div class="modal-footer">

                    <asp:Button ID="BtnNoAsistio" runat="server" Text="NO Asistio" CssClass="btn btn-danger btn-lg" OnClick="BtnNoAsistioCita_Click" OnClientClick="if (!alertaNoAsistio()) return false;" CausesValidation="false"/>
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal Excepcion -->

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

    <!-- Modal Excepcion Admin-->

    <div class="modal fade" id="excepciones-info" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Detalle de la Excepcion</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
 
                    <div id="NombreTS"></div>
                    <br /> 
                    <div id="Fecha3"></div>
                    <br />
                    <div id="Horas3"></div>
                    <br />                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary btn-lg" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Orden Judical -->
    <!--
    
    -->

    <!-- Modal Citas Asignadas -->
    <!--
    <div class="modal fade" id="myModalListaCitas">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
    -->
                <!-- Modal Header -->
     <!--
                <div class="modal-header">
                    <h4 class="modal-title">Citas</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
    -->
                <!-- Modal body -->
     <!--
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

    -->
    <!-- Modal Orden Judicial -->
    <!--
    
        -->


    <div class="container-fluid main">

        <div class="row">
             <div class="col-md-3">

                 

                <div class="card mb-3">

                    <div class="card-header">
                        Excepciones
                    </div>

                     <div class="card-block">

                         <div class="form-group">
                            <label for="orden">Centro</label>

                            <asp:DropDownList ID="DdlCentro" runat="server" CssClass="custom-select w-100" AutoPostBack="true" OnSelectedIndexChanged="DdlCentro_SelectedIndexChanged"></asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Requerido" InitialValue="0" ForeColor="Red" ControlToValidate="DdlCentro" Display="Dynamic"></asp:RequiredFieldValidator>--%>

                        </div>

                        <div class="form-group">

                            <div id="DivBtnModalAsignarCita" runat="server">
                                <p class="txt-grey">Seleccione horarios disponibles en el calendario</p>

                                <button type="button" class="btn btn-primary col text-center" data-toggle="modal" data-target="#modal-Asignar-Cita">
                                    Asignar Excepcion
                                </button>
                            </div>
                            <br />
                            <a href="../Dashboard-Usuarios.aspx" class="btn btn-secondary btn-block mb-4">Volver al Dashboard</a>
                        </div>
                    </div>
                </div>

              </div>

                <!-- Card -->

                <!-- Card -->
    <!--
                
    -->
                <!-- Card -->
    <!--
                <div class="card mb-3">
                    <div class="card-header">
                        Citas Asignadas
                    </div>
                    <div class="card-block">
                        <span>
                            <asp:HyperLink ID="HLCitas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCitas"></asp:HyperLink>
                        </span>
                        <br />
 
                        <asp:Button ID="BtnDocumentos" runat="server" Text="Lista de Documentos" CssClass="btn btn-primary btn-block"  CausesValidation="false" />
                        <asp:HyperLink ID="Hyperlink" runat="server" Enable="true" NavigateUrl="~/nuevo-confirmacion.aspx" CssClass="btn btn-link btn-block">Volver al Registro</asp:HyperLink>
                        <asp:HyperLink ID="Hyperlink1" runat="server" Enable="true" NavigateUrl="~/seleccion-proximo-paso.aspx" CssClass="btn btn-link btn-block">Ir a cuenta de Usuario</asp:HyperLink>
                    </div>
                </div>
    -->
                <!-- Card -->
        <!--    </div> -->
            <!-- Contenedor Calendario -->
            <div class="col">

                <div class="card mb-3">
                    <div class="card-header">
                        Calendario de Citas: <asp:Literal ID="LitNombre" runat="server"></asp:Literal>
                     <!--   <uc1:WUCUsuario runat="server" ID="WUCUsuario" /> -->
                    </div>
                    <div class="card-block calendario-opciones">
                        <div class="row">
                            <div class="col">
                                <asp:Button ID="BtnHoy" runat="server" Text="Hoy" class="btn btn-secondary btn-sm" OnClick="BtnHoy_Click" CausesValidation="false" />
                                <asp:LinkButton ID="BtnLeft" runat="server" class="btn btn-secondary btn-sm" Text="<img src='../images/izquierda.png' alt='ASSMCA'>" OnClick="BtnLeft_Click" CausesValidation="false" />
                                <asp:LinkButton ID="BtnRight" runat="server" Text="<img src='../images/derecha.png' alt='ASSMCA'>" class="btn btn-secondary btn-sm" OnClick="BtnRight_Click" CausesValidation="false" />
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
       
                        <a href="#" data-toggle="tooltip" data-html="true" title='A REALIZARSE'><span class="bloque-leyenda realizarse"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='PARTICIPANTE SI ASISTIO'><span class="bloque-leyenda asistio"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='NO ASISTIO (CERRADO)'><span class="bloque-leyenda nohay"></span></a>
                        <a href="#" data-toggle="tooltip" data-html="true" title='HORARIO NO DISPONIBLE'><span class="bloque-leyenda grupo3"></span></a>
                        <%-- &nbsp; &nbsp; &nbsp; <span class="bloque-leyenda nohay"></span>
                        No Asistio (Cerrado)
                        &nbsp; <span class="bloque-leyenda grupo3"></span>
                        Horario No Disponible--%>
     
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

        function changeDivContent(Fecha, Horas, NombreCompleto, TelefonoContacto, NumerodeCita, Programa, TS, activa) {

            if (activa == "False")
            {
                document.getElementById("<%=BtnAsistioCita.ClientID %>").style.visibility = 'hidden';
                document.getElementById("BtnEliModal").style.visibility = 'hidden';
                                    
            }
            else {
                document.getElementById("<%=BtnAsistioCita.ClientID %>").style.visibility = 'visible';
                document.getElementById("BtnEliModal").style.visibility = 'visible';
                                    
            }

            document.getElementById("Programa").innerHTML = "<b>Programa:</b> " + Programa;
            document.getElementById("Fecha").innerHTML = "<b>Cita de Pre-Evaluacion para el día:</b> " + Fecha;
            document.getElementById("Horas").innerHTML = "<b>Hora:</b> " + Horas;
            document.getElementById("NombreCompleto").innerHTML = "<b>Participante:</b> " + NombreCompleto;
            document.getElementById("TelefonoContacto").innerHTML = "<b>Teléfono Contacto:</b> " + TelefonoContacto;
            document.getElementById("TS").innerHTML = "<b>Asistente Psicosocial:</b> " + TS;
            
            document.getElementById("<%= HNroCita.ClientID %>").value = NumerodeCita;
       
        }

        function changeDivContentAsistio(Fecha, Horas, NombreCompleto, TelefonoContacto, NumerodeCita, Programa, TS, activa) {
            if (activa == "False")
            {
                document.getElementById("<%=BtnNoAsistio.ClientID %>").style.visibility = 'hidden';
            }
            else {
                document.getElementById("<%=BtnNoAsistio.ClientID %>").style.visibility = 'visible';
            }

            document.getElementById("ProgramaA").innerHTML = "<b>Programa:</b> " + Programa;
            document.getElementById("FechaA").innerHTML = "<b>Cita de Pre-Evaluacion para el día:</b> " + Fecha;
            document.getElementById("HorasA").innerHTML = "<b>Hora:</b> " + Horas;
            document.getElementById("NombreCompletoA").innerHTML = "<b>Participante:</b> " + NombreCompleto;
             document.getElementById("TelefonoContactoA").innerHTML = "<b>Teléfono Contacto:</b> " + TelefonoContacto;
             document.getElementById("TSA").innerHTML = "<b>Asistente Psicosocial:</b> " + TS;
             
            document.getElementById("<%= HNroCita.ClientID %>").value = NumerodeCita;
       
         }

        function changeDivContent2(Fecha, Horas, NumerodeExcepcion,activa) {
            if (activa == "False")
            {
                document.getElementById("<%=BtnEliminarExcepcion.ClientID %>").style.visibility = 'hidden';
            }
            else {
                document.getElementById("<%=BtnEliminarExcepcion.ClientID %>").style.visibility = 'visible';
            }

            document.getElementById("Fecha2").innerHTML = "<b>Excepcion para el día:</b> " + Fecha;
            document.getElementById("Horas2").innerHTML = "<b>Hora:</b> " + Horas;
            

            document.getElementById("<%= HNroExcepcion.ClientID %>").value = NumerodeExcepcion;

        }

        function excepcionInfo(Fecha, Horas, Nombre) {

            document.getElementById("NombreTS").innerHTML = "<b>Trabajador Social:</b> " + Nombre;
            document.getElementById("Fecha3").innerHTML = "<b>Excepcion para el día:</b> " + Fecha;
            document.getElementById("Horas3").innerHTML = "<b>Hora:</b> " + Horas;
        }

        function alertaAsistio() {
            return confirm("¿Está seguro que el participante SI asistió?");                   
        }

        function alertaNoAsistio() {
             return confirm("¿Está seguro que el participante NO asistió?"); 
        }

        function EliminarCita() {
            document.getElementById("<%= HNroCita.ClientID %>").value = NumerodeCita;            
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

