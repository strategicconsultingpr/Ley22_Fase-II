<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="nuevo_confirmacion" Codebehind="nuevo-confirmacion.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card mb-4">
        <div class="card-header">
            <asp:Literal ID="Header_Amarillo" runat="server" Text="Registro de nueva cuenta" />
        </div>
        <div class="card-block">
                <div class="alert alert-success mb-4" role="alert">
                    <asp:Literal ID="Header_Azul" runat="server" Text="El usuario ha sido registrado con éxito" />
      
        </div>

            <div class="row bb pb-4 mb-4">
                <div class="col-md-2 text-right">
                    <strong>Documentos</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="n-seguro-social">Número de Seguro Social</label>
                                <br />
                                <%=du.NR_SeguroSocial %>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="pasaporte">Identificación</label>
                                <br />
                                <%=du.Identificacion %>
                            </div>
                        </div>
                        <!-- col -->
                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="pasaporte">Pasaporte</label>
                                <br />
                                <%=du.Pasaporte%>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="licencia">Licencia</label>
                                <br />
                                <%=du.Licencia %>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="iup">IUP</label>
                                <br />
                                <%=du.IUP%>
                            </div>
                        </div>
                        <!-- col -->


                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="n-seguro-social">Expediente</label>
                                <br />
                                <%=du.Expediente%>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="episodio">Episodio</label>
                            </div>
                        </div>


                        <!-- The Modal -->

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
                                <label for="primer-nombre">Primer Nombre</label>
                                <br />
                                <%=du.NB_Primero %>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="segundo-nombre">Segundo Nombre</label>
                                <br />
                                <%=du.NB_Segundo %>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="primer-apellido">Apellido Paterno</label>
                                <br />
                                <%=du.AP_Primero %>
                            </div>
                        </div>
                        <!-- col -->


                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="segundo-apellido">Apellido Materno</label>
                                <br />
                                <%=du.AP_Segundo%>
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
                                <label for="fecha-nacimiento">Fecha de Nacimiento</label>
                                <br />
                                <%=du.FE_Nacimiento.ToString("MM/dd/yyyy")%>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="sexo">Sexo</label>
                                <br />
                                <%=du.SexoDescripcion %>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="grupo-etnico">Grupo Étnico</label>
                                <br />
                                <%=du.GrupoEtnicoDescripcion %>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-check">
                                <p>&nbsp;</p>
                                <label class="form-check-label">
                                    <asp:CheckBox ID="ChkVeterano" runat="server" class="form-check-input" enable="false"/>
                                    Veterano
                                </label>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="email">Email</label>
                                <br />
                                <%=du.Correo %>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Teléfono 1</label>
                                <br />
                                <%=du.Telefono1 %>
                            </div>

                        </div>
                        <!-- col -->


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Teléfono 2</label>
                                <br />
                                <%=du.Telefono2 %>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="segundo-apellido">Tlf Famliar más cercano</label>
                                <br />
                                <%=du.TelefonoFamiliaraMasCercano  %>
                            </div>
                        </div>
                    </div>
                    <!-- col -->
                    <div class="row pb-4 mb-4 bb">
                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Tlf Notificar Citas</label>
                                <br />
                                <%=du.TelefonoCitas %>
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
                                <label for="primer-nombre">Dirección Linea 1</label>

                                <br />
                                <%=du.DireccionLinea1 %>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-nombre">Dirección Linea 2</label>
                                <br />
                                <%=du.DireccionLinea2  %>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="primer-apellido">Municipio</label>
                                <br />
                                <%=du.Municipio %>
                            </div>

                        </div>
                        <!-- col -->


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Código Postal</label>
                                <br />
                                <%=du.CodigoPostal %>
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

                    <asp:Button ID="BtnAsignarCita" runat="server" Text="Asignar Cita" CssClass="btn btn-primary btn-lg pr-4 pl-4 mr-4" OnClick="BtnAsignarCita_Click" />

                    <asp:Button ID="BtnCorregir" runat="server" Text="Corregir" CssClass="btn btn-secondary btn-lg" OnClick="BtnCorregir_Click" />

                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary btn-lg" OnClick="BtnCancelar_Click" />

                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->


        </div>
        <!-- card-block -->
    </div>
      
</asp:Content>



