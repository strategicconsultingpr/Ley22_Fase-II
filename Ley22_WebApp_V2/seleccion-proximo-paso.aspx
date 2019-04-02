<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="seleccion_proximo_paso" Codebehind="seleccion-proximo-paso.aspx.cs" %>

<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- The Modal -->
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
                            <asp:BoundField DataField="FE_Episodio" HeaderText="Fecha del Episodio" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DE_Programa" HeaderText="Programa" HeaderStyle-HorizontalAlign="Center" />
                        </Columns>

                    </asp:GridView>
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


       <div class="modal fade" id="myModalListaCharlas">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Charlas</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:GridView ID="GVResumenCharlas" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Id_CharlaGrupal" HeaderText="Nro. Charla" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
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

    <div class="card">
        <div class="card-header">
            Próximo Paso. Usuario:<uc1:WUCUsuario runat="server" ID="WUCUsuario" /> &nbsp &nbsp &nbsp &nbsp Programa: <asp:Literal ID="NombrePrograma" runat="server"></asp:Literal>

        </div>
        <div class="card-block">

            <div class="row">
                <div class="col-md-3">


                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">Expediente
           
                            <span>
                                <asp:Literal ID="LitExpediente" runat="server"></asp:Literal></span>
                        </li>
                        <li class="list-group-item justify-content-between">IUP
           
                            <span>
                                <asp:Literal ID="LitIUP" runat="server"></asp:Literal></span>
                        </li>
                        <li class="list-group-item justify-content-between">Episodio
           
                            <span>
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaEpisodios"></asp:HyperLink>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">Licencia
           
                            <span>
                                <asp:Literal ID="LitLicencia" runat="server"></asp:Literal></span>
                        </li>

                        <li class="list-group-item justify-content-between">
                            <strong>Estatus: </strong><asp:Literal ID="LitEstatus" runat="server"></asp:Literal>
                            
                        </li>

                    </ul>


                    <p class="mb-4">Históricos:</p>


                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">

                            <span>
                                <asp:HyperLink ID="HLCitas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCitas"></asp:HyperLink>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">

                            <span>
                                <asp:HyperLink ID="HlCharlas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCharlas"></asp:HyperLink>
                            </span>
                        </li>
                    </ul>




                    <a href="entrada.aspx" class="btn btn-secondary btn-block mb-4">Salir del Registro de Usuario</a>

                </div>

                <div class="col-md-9">                    

                    <div class="row">
                        <div class="col-md-4">
                            <div class="card text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="ParticipanteNuevo.aspx">
                                            <span class="fa-stack fa-3x">
                                                <img src="../images/editar-usuario-registrado.png" alt="ASSMCA">
                                            </span>
                                        </a>
                                    </p>                                   
                                    <h4 class="card-title"><a href="ParticipanteNuevo.aspx">Editar Registro de Usuario</a></h4>
                                </div>
                            </div>
                        </div>
                        <!-- col-4 -->

                        <div class="col-md-4">
                            <div class="card text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="OrdenNuevo.aspx">
                                            <span class="fa-stack fa-3x">
                                                <img src="../images/editar-usuario-registrado.png" alt="ASSMCA">
                                            </span>
                                        </a>
                                    </p>                                   
                                    <h4 class="card-title"><a href="OrdenNuevo.aspx">Abrir Caso Criminal</a></h4>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">

                            <div class="card text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="cargar-documentos.aspx">
                                            <span class="fa-stack fa-3x">
                                                <img src="../images/recepcion-documentos.png" alt="ASSMCA" id="inboxImg" runat="server">
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="cargar-documentos.aspx">Recibo de Documentos</a></h4>
                                </div>
                            </div>

                        </div>
                        <!-- col-4 -->

                        <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="asignar-citas-individual.aspx">
                                            <span class="fa-stack fa-3x">
                                                <img src="../images/calendario-citas-trabajador-social.png" alt="ASSMCA">
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="asignar-citas-individual.aspx">Calendario Citas Trabajador Social</a></h4>
                                </div>
                            </div>

                        </div>
                        <!-- col-4 -->

                        <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="charlas-grupales.aspx">
                                            <span class="fa-stack fa-3x">
                                                <img src="../images/calendario-citas-charlas.png" alt="ASSMCA">
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="charlas-grupales.aspx">Calendario Citas Charlas</a></h4>
                                </div>
                            </div>

                        </div>
                        <!-- col-4 -->

                        <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="balance-pago-solo-saldo.aspx">
                                            <span class="fa-stack fa-3x">
                                                <img src="../images/recaudos.png" alt="ASSMCA">
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="balance-pago-solo-saldo.aspx">Recaudos</a></h4>
                                </div>
                            </div>

                        </div>
                        <!-- col-4 -->

                        <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="cierre-caso.aspx">
                                            <span class="fa-stack fa-3x">
                                                <img src="../images/cerrar-caso.png" alt="ASSMCA">
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="cierre-caso.aspx">Cerrar Caso</a></h4>
                                </div>
                            </div>

                        </div>
                        <!-- col-4 -->

                    </div>


                </div>
                <!-- col-9 -->
            </div>
            <!-- row -->

        </div>
        <!-- card-block-->
    </div>
    <!-- Card -->




</asp:Content>

