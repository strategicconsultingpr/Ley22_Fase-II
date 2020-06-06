<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="seleccion_proximo_paso" Codebehind="seleccion-proximo-paso.aspx.cs" %>

<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Modal Lista de Episodios -->
    <div class="modal fade" id="myModalListaEpisodios">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Episodios</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:GridView ID="GVListadeEpisodios" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                        <Columns>

                            <asp:TemplateField HeaderText="Episodio">
                                <ItemTemplate>
                                   <asp:LinkButton ItemStyle-HorizontalAlign="Right" ID="lnkEpisodio" runat="server" Text='<%# Bind("PK_Episodio") %>'  OnClick="lnkEpisodio_Click" CausesValidation="false" CommandArgument='<%# Eval("PK_Episodio") %>'></asp:LinkButton>
                                </ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="PK_Episodio" HeaderText="Episodio" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />--%>
                            <asp:BoundField DataField="FE_Episodio" HeaderText="Fecha del Episodio" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DE_Programa" HeaderText="Programa" HeaderStyle-HorizontalAlign="Center" />
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Lista de Casos Criminales -->
    <div class="modal fade" id="myModalListaCasos">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Casos Criminales</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:GridView ID="GVListaDeCasos" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Casos">
                                <ItemTemplate>
                                   <asp:LinkButton ItemStyle-HorizontalAlign="Right" ID="lnkCaso" runat="server" Text='<%# Bind("NumeroCasoCriminal") %>'  OnClick="lnkCasoCriminal_Click" CausesValidation="false" CommandArgument='<%# Eval("Id_CasoCriminal") %>'></asp:LinkButton>
                                </ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="PK_Episodio" HeaderText="Episodio" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />--%>
                            <asp:BoundField DataField="FechaSentencia" HeaderText="Fecha de Sentencia" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DE_Programa" HeaderText="Programa" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" HeaderStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Lista de Citas -->
    <div class="modal fade" id="myModalListaCitas">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Citas</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body" style="width: 100%; height: 500px; overflow: scroll">
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

    <!-- Modal Lista de Charlas -->
       <div class="modal fade" id="myModalListaCharlas">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Charlas</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body" style="width: 100%; height: 500px; overflow: scroll">
                    <asp:GridView ID="GVResumenCharlas" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="NumeroCasoCriminal" HeaderText="Caso Criminal" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="NumeroCharla" HeaderText="Nro. Charla" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="FechaHora" HeaderText="Fecha" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                             <asp:BoundField DataField="NombreDelCentro" HeaderText="Centro" HeaderStyle-HorizontalAlign="Center" />
                             <asp:BoundField DataField="TipodeCharla" HeaderText="Tipo de Charla" HeaderStyle-HorizontalAlign="Center" />
                             <asp:BoundField DataField="Nivel" HeaderText="Nivel" HeaderStyle-HorizontalAlign="Center" />
                             <asp:BoundField DataField="AsistioTexto" HeaderText="Asistencia" HeaderStyle-HorizontalAlign="Center" />

                        </Columns>

                    </asp:GridView>
                </div>

                <div class="modal-footer">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

                </div>
            </div>
        </div>
    </div>

    <!-- Pantalla Dashboard de Participante -->
    <div class="card">

        <div class="card-header">
            Tablero de Expediente: <asp:Literal ID="NombreParticipante" runat="server"></asp:Literal> &nbsp &nbsp &nbsp &nbsp Programa: <asp:Literal ID="NombrePrograma" runat="server"></asp:Literal>
        </div>

   <!-- Bloque Principal -->
        <div class="card-block">

            <div class="row">

                <!-- Bloque Izquierdo -->
                <div class="col-md-3">

                    <!-- Informacion general Participante -->
                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">Expediente           
                            <span>
                                <asp:Literal ID="LitExpediente" runat="server"></asp:Literal>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">IUP           
                            <span>
                                <asp:Literal ID="LitIUP" runat="server"></asp:Literal>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">Episodio          
                            <span>
                                <asp:LinkButton ID="LnkBtnEpisodios" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaEpisodios"></asp:LinkButton>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">Casos Criminales         
                            <span>
                                <asp:LinkButton ID="LnkBtnCasos" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCasos"></asp:LinkButton>
                            </span>
                        </li>
                       <%-- <li class="list-group-item justify-content-between">Licencia          
                            <span>
                                <asp:Literal ID="LitLicencia" runat="server"></asp:Literal></span>
                        </li>--%>
                        <li class="list-group-item justify-content-between">
                            <strong>Estatus: </strong><asp:Literal ID="LitEstatus" runat="server"></asp:Literal>                            
                        </li>
                    </ul>

                    <!-- Informacion sobre estadia en Ley 22 Participante -->
                    <p class="mb-4">Históricos:</p>
                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">
                            <span>
                                <asp:LinkButton ID="HLnkCitas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCitas"></asp:LinkButton>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">
                            <span>
                                <asp:LinkButton ID="HLnkCharlas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCharlas"></asp:LinkButton>
                            </span>
                        </li>
                    </ul>

                    <a href="<%=ResolveClientUrl("~/entrada.aspx")%>" class="btn btn-secondary btn-block mb-4">Salir del Tablero de Expediente</a>
                </div>

                <!-- Bloque Interior -->
                <div class="col-md-9">                    
                    <div class="row">
                          <div class="col-md-4">
                                                    <div class="card text-center mb-3 card-menu">
                                                        <div class="card-block">
                                                            <p class="mt-4">
                                                                <a href="<%=ResolveClientUrl("~/ParticipanteNuevo.aspx")%>">
                                                                    <span class="fa-stack fa-3x">
                                                                        <img src="<%=ResolveClientUrl("~/images/editar-usuario-registrado.png")%>" alt="ASSMCA">
                                                                    </span>
                                                                </a>
                                                            </p>                                   
                                                            <h4 class="card-title"><a href="<%=ResolveClientUrl("~/ParticipanteNuevo.aspx")%>">Modificar Participante</a></h4>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- col-4 -->

                                                <div class="col-md-4">
                                                    <div class="card text-center mb-3 card-menu">
                                                        <div class="card-block">
                                                            <p class="mt-4">
                                                                <a ID="ordenImg" runat="server" href="OrdenNuevo.aspx">
                                                                    <span class="fa-stack fa-3x">
                                                                        <img src="<%=ResolveClientUrl("~/images/caso-icon.png")%>" alt="ASSMCA">
                                                                    </span>
                                                                </a>
                                                            </p>                                   
                                                            <h4 class="card-title"><a ID="ordenText" runat="server" href="OrdenNuevo.aspx">Registro de Caso Criminal</a></h4>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="card text-center mb-3 card-menu">
                                                        <div class="card-block">
                                                            <p class="mt-4">
                                                                <a href="<%=ResolveClientUrl("~/cargar-documentos.aspx")%>">
                                                                    <span class="fa-stack fa-3x">
                                                                        <img src="../images/recepcion-documentos.png" alt="ASSMCA" id="inboxImg" runat="server">
                                                                    </span>
                                                                </a>
                                                            </p>
                                                            <h4 class="card-title"><a href="<%=ResolveClientUrl("~/cargar-documentos.aspx")%>">Recibo de Documentos</a></h4>
                                                        </div>
                                                    </div>
                                                </div>
                    <!-- Listado Admin -->
                    
                                                                                  
                                                <!-- col-4 -->

                                                <div class="col-md-4">

                                                    <div class="card  text-center mb-3 card-menu">
                                                        <div class="card-block">
                                                            <p class="mt-4">
                                                                <a href="<%=ResolveClientUrl("~/asignar-citas-individual.aspx")%>">
                                                                    <span class="fa-stack fa-3x">
                                                                        <img src="<%=ResolveClientUrl("~/images/calendario-citas-trabajador-social.png")%>" alt="ASSMCA">
                                                                    </span>
                                                                </a>
                                                            </p>
                                                            <h4 class="card-title"><a href="<%=ResolveClientUrl("~/asignar-citas-individual.aspx")%>">Calendario Citas de Evaluaciones </a></h4>
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- col-4 -->

                                                <div class="col-md-4" id="divCharlas" runat="server" visible="false">
                                                    <div class="card  text-center mb-3 card-menu">
                                                        <div class="card-block">
                                                            <p class="mt-4">
                                                                <a href="<%=ResolveClientUrl("~/charlas-grupales.aspx")%>">
                                                                    <span class="fa-stack fa-3x">
                                                                        <img src="<%=ResolveClientUrl("~/images/calendario-citas-charlas.png")%>" alt="ASSMCA">
                                                                    </span>
                                                                </a>
                                                            </p>
                                                            <h4 class="card-title"><a href="<%=ResolveClientUrl("~/charlas-grupales.aspx")%>">Calendario Charlas Socio-Educativas</a></h4>
                                                        </div>
                                                    </div>
                                                </div>
                                                    

                                                <!-- col-4 -->

                                                <div class="col-md-4">

                                                    <div class="card  text-center mb-3 card-menu">
                                                        <div class="card-block">
                                                            <p class="mt-4">
                                                                <a href="<%=ResolveClientUrl("~/balance-pago-solo-saldo.aspx")%>">
                                                                    <span class="fa-stack fa-3x">
                                                                        <img src="<%=ResolveClientUrl("~/images/recaudos.png")%>" alt="ASSMCA">
                                                                    </span>
                                                                </a>
                                                            </p>
                                                            <h4 class="card-title"><a href="<%=ResolveClientUrl("~/balance-pago-solo-saldo.aspx")%>">Historial Financiero</a></h4>
                                                        </div>
                                                    </div>

                                                </div>

                                                 <!-- col-4 -->

                                                <div class="col-md-4" id="divCertificados" runat="server" visible="false">
                                                    <div class="card  text-center mb-3 card-menu">
                                                        <div class="card-block">
                                                            <p class="mt-4">
                                                                <a href="<%=ResolveClientUrl("~/Certificados_Participante.aspx")%>">
                                                                    <span class="fa-stack fa-3x">
                                                                        <img src="<%=ResolveClientUrl("~/images/certificate_icon_blue.png")%>" alt="ASSMCA">
                                                                    </span>
                                                                </a>
                                                            </p>
                                                            <h4 class="card-title"><a href="<%=ResolveClientUrl("~/Certificados_Participante.aspx")%>">Certificados</a></h4>
                                                        </div>
                                                    </div>

                                                </div> 

                                                <!-- col-4 -->

                                                <div class="col-md-4" id="divCerrarCaso" runat="server" visible="false">
                                                    <div class="card  text-center mb-3 card-menu">
                                                        <div class="card-block">
                                                            <p class="mt-4">
                                                                <a href="<%=ResolveClientUrl("~/cierre-caso.aspx")%>">
                                                                    <span class="fa-stack fa-3x">
                                                                        <img src="<%=ResolveClientUrl("~/images/cerrar-caso.png")%>" alt="ASSMCA">
                                                                    </span>
                                                                </a>
                                                            </p>
                                                            <h4 class="card-title"><a href="<%=ResolveClientUrl("~/cierre-caso.aspx")%>">Cerrar Caso</a></h4>
                                                        </div>
                                                    </div>

                                                </div>                                             
                       
                </div>
                <!-- END Bloque Interior -->

            </div>
            <!-- row -->

        </div>
        <!-- card-block-->
    </div>
    <!-- Card -->

        <script type="text/javascript">
            function ordenNuevo() {

                swal({
                    title: "Registrar Nuevo Caso Criminal",
                    text: "Esta participante contiene un caso criminal activo bajo este programa ¿Esta seguro de querer registrar un nuevo caso criminal para este participante?",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true
                }).then((value) => {
                    if (value) {
                        window.location.href = "OrdenNuevo.aspx";
                    }
                    else {
                    }
                })

            }
            </script>


</asp:Content>

