<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Dashboard-Usuarios.aspx.cs" Inherits="Ley22_WebApp_V2.Dashboard_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <div class="card">
        <div class="card-header">
            Usuario:<asp:Literal ID="LitNombre" runat="server"></asp:Literal>

        </div>
        <div class="card-block">

            <div class="row">
                <div class="col-md-3">

                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">Email           
                            <span>
                                <asp:Literal ID="LitEmail" runat="server"></asp:Literal></span>
                        </li>                  
                    </ul>

                 <a href="entrada.aspx" class="btn btn-secondary btn-block mb-4">Salir del Dashboard</a>
                </div>


        <asp:LoginView runat="server" ViewStateMode="Disabled">
                                    <RoleGroups>
                                        <asp:RoleGroup Roles="SuperAdmin">
                                            <ContentTemplate>
        
                <div class="col-md-9">

                    <div class="row">
                        <div class="col-md-4">
                            <div class="card text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="../trabajor-excepciones.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="fas fa-calendar-alt fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>                                   
                                    <h4 class="card-title"><a href="../trabajor-excepciones.aspx">Mi Calendario de Citas</a></h4>
                                </div>
                            </div>
                        </div>
                        <!-- col-4 -->

                        <%--<div class="col-md-4">

                            <div class="card text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="../Entrada.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x" id="iCircleDoc" runat="server"></i>
                                                <i class="fas fa-users fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="../Entrada.aspx">Buscar Participante</a></h4>
                                </div>
                            </div>

                        </div>--%>
                        <!-- col-4 -->

<%--                        <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="asignar-citas-individual.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="far fa-calendar-alt fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="asignar-citas-individual.aspx">Calendario Citas Trabajador Social</a></h4>
                                </div>
                            </div>

                        </div>--%>
                        <!-- col-4 -->

                       <%-- <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="charlas-grupales.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="far fa-calendar fa-stack-1x fa-inverse"></i>
                                                <i class="fas fa-users fa-stack fa-fix-sm fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="charlas-grupales.aspx">Calendario Citas Charlas</a></h4>
                                </div>
                            </div>

                        </div>--%>
                        <!-- col-4 -->

                       <%-- <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="balance-pago-solo-saldo.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="far fa-list-alt fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="balance-pago-solo-saldo.aspx">Recaudos</a></h4>
                                </div>
                            </div>

                        </div>--%>
                        <!-- col-4 -->

                       <%-- <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="cierre-caso.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="far fa-check-square fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="cierre-caso.aspx">Cerrar Caso</a></h4>
                                </div>
                            </div>

                        </div>--%>
                        <!-- col-4 -->

                    </div>


                </div>
                <!-- col-9 -->
            </div>
            <!-- row -->

        </div>
        <!-- card-block-->

        </ContentTemplate>
                                            </asp:RoleGroup>
                                    </RoleGroups>
                                </asp:LoginView>

         <asp:LoginView runat="server" ViewStateMode="Disabled">
                                    <RoleGroups>
                                        <asp:RoleGroup Roles="TrabajadorSocial">
                                            <ContentTemplate>
            
              
                <div class="col-md-9">

                    <div class="row">
                        <div class="col-md-4">
                            <div class="card text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="../trabajor-excepciones.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="fas fa-calendar-alt fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>                                   
                                    <h4 class="card-title"><a href="../trabajor-excepciones.aspx">Mi Calendario de Citas</a></h4>
                                </div>
                            </div>
                        </div>
                        <!-- col-4 -->

                        <div class="col-md-4">

                            <div class="card text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="../Entrada.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x" id="iCircleDoc" runat="server"></i>
                                                <i class="fas fa-users fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="../Entrada.aspx">Buscar Participante</a></h4>
                                </div>
                            </div>

                        </div>
                        <!-- col-4 -->

<%--                        <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="asignar-citas-individual.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="far fa-calendar-alt fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="asignar-citas-individual.aspx">Calendario Citas Trabajador Social</a></h4>
                                </div>
                            </div>

                        </div>--%>
                        <!-- col-4 -->

                       <%-- <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="charlas-grupales.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="far fa-calendar fa-stack-1x fa-inverse"></i>
                                                <i class="fas fa-users fa-stack fa-fix-sm fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="charlas-grupales.aspx">Calendario Citas Charlas</a></h4>
                                </div>
                            </div>

                        </div>--%>
                        <!-- col-4 -->

                       <%-- <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="balance-pago-solo-saldo.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="far fa-list-alt fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="balance-pago-solo-saldo.aspx">Recaudos</a></h4>
                                </div>
                            </div>

                        </div>--%>
                        <!-- col-4 -->

                       <%-- <div class="col-md-4">

                            <div class="card  text-center mb-3 card-menu">
                                <div class="card-block">
                                    <p class="mt-4">
                                        <a href="cierre-caso.aspx">
                                            <span class="fa-stack fa-3x">
                                                <i class="fas fa-circle fa-stack-2x"></i>
                                                <i class="far fa-check-square fa-stack-1x fa-inverse"></i>
                                            </span>
                                        </a>
                                    </p>
                                    <h4 class="card-title"><a href="cierre-caso.aspx">Cerrar Caso</a></h4>
                                </div>
                            </div>

                        </div>--%>
                        <!-- col-4 -->

                    </div>


            

                                                 </ContentTemplate>
                                            </asp:RoleGroup>
                                    </RoleGroups>
                                </asp:LoginView>
            </div>
                <!-- col-9 -->
            </div>
            <!-- row -->

        </div>
        <!-- card-block-->

    </div>
    <!-- Card -->

</asp:Content>
