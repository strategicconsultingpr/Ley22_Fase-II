<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Dashboard-Usuarios.aspx.cs" Inherits="Ley22_WebApp_V2.Dashboard_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <div class="card">
        <div class="card-header">
            Tablero del Usuario: <asp:Literal ID="LitNombre" runat="server"></asp:Literal>

        </div>
        <div class="card-block">

            <div class="row">
                <div class="col-md-3">

                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">Nombre:           
                            <span><asp:Literal ID="LitPrimerNombre" runat="server"></asp:Literal></span>
                        </li>
                        <li class="list-group-item justify-content-between">Apellido:           
                            <span><asp:Literal ID="LitPrimerApellido" runat="server"></asp:Literal></span>
                        </li>
                        <li class="list-group-item justify-content-between">Email:           
                            <span><asp:Literal ID="LitEmail" runat="server"></asp:Literal></span>
                        </li> 
                        <li class="list-group-item justify-content-between">Roles:           
                            <span><asp:Literal ID="LitRoles" runat="server"></asp:Literal></span>
                        </li>
                    </ul>
 
                 <%--<a href="entrada.aspx" class="btn btn-secondary btn-block mb-4">Salir del Dashboard</a>--%>
                 <asp:LoginStatus runat="server" class="btn btn-secondary btn-block mb-4" LogoutAction="Redirect" LogoutText="Cerrar Sesión" LogoutPageUrl="~/Account/Login" OnLoggingOut="Unnamed_LoggingOut" />
                </div>

<%--Dashboard de Usuario--%>
                <div class="col-md-9">
                        <div class="row"> 
                            
                            <div class="col-md-4" id="divExpediente" runat="server" visible="false">
                                <div class="card text-center mb-3 card-menu">
                                    <div class="card-block">
                                        <p class="mt-4">
                                            <a href="<%=ResolveClientUrl("~/Entrada.aspx")%>">
                                                <span class="fa-stack fa-3x">
                                                    <img src="<%=ResolveClientUrl("~/images/editar-usuario-registrado.png")%>" alt="ASSMCA">
                                                </span>
                                            </a>
                                        </p>
                                        <h4 class="card-title"><a href="<%=ResolveClientUrl("~/Entrada.aspx")%>">Búsqueda de Expediente</a></h4>
                                    </div>
                                </div>
                            </div> 

                            <div class="col-md-4" id="divCitas" runat="server" visible="false">
                                <div class="card text-center mb-3 card-menu">
                                    <div class="card-block">
                                        <p class="mt-4">
                                            <a href="<%=ResolveClientUrl("~/trabajor-excepciones.aspx")%>">
                                                <span class="fa-stack fa-3x">
                                                    <img src="<%=ResolveClientUrl("~/images/calendario-citas-trabajador-social.png")%>" alt="ASSMCA">
                                                </span>
                                            </a>
                                        </p>                                   
                                        <h4 class="card-title"><a href="<%=ResolveClientUrl("~/trabajor-excepciones.aspx")%>">Calendario de Citas</a></h4>
                                    </div>
                                </div>
                            </div>  

                            <div class="col-md-4" id="divCharlas" runat="server" visible="false">
                                <div class="card text-center mb-3 card-menu">
                                    <div class="card-block">
                                        <p class="mt-4">
                                            <a href="<%=ResolveClientUrl("~/administrador-charlas-grupales.aspx")%>">
                                                <span class="fa-stack fa-3x">
                                                    <img src="<%=ResolveClientUrl("~/images/calendario-citas-charlas.png")%>" alt="ASSMCA">
                                                </span>
                                            </a>
                                        </p>                                   
                                        <h4 class="card-title"><a href="<%=ResolveClientUrl("~/administrador-charlas-grupales.aspx")%>">Calendario de Charlas</a></h4>
                                    </div>
                                </div>
                            </div> 

                           

                           <div class="col-md-4" id="divRecaudos" runat="server" visible="false">
                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="<%=ResolveClientUrl("~/recaudos-busqueda-usuario.aspx")%>">
                                            <span class="fa-stack fa-3x">
                                                <img src="<%=ResolveClientUrl("~/images/recaudos.png")%>" alt="ASSMCA">
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="<%=ResolveClientUrl("~/recaudos-busqueda-usuario.aspx")%>">Recaudos</a></h4>
                                </div>
                            </div>
                        </div>

                           <div class="col-md-4" id="divReportes" runat="server" visible="false">
                            <div class="card text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="<%=ResolveClientUrl("~/Reportes.aspx")%>">
                                            <span class="fa-stack fa-3x">
                                                <img src="<%=ResolveClientUrl("~/images/recaudos.png")%>" alt="ASSMCA">
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="<%=ResolveClientUrl("~/Reportes.aspx")%>">Reportes</a></h4>
                                </div>
                            </div>
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
