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
                        <li class="list-group-item justify-content-between">Nombre:           
                            <span><asp:Literal ID="LitPrimerNombre" runat="server"></asp:Literal></span>
                        </li>
                        <li class="list-group-item justify-content-between">Apellido:           
                            <span><asp:Literal ID="LitPrimerApellido" runat="server"></asp:Literal></span>
                        </li>
                        <li class="list-group-item justify-content-between">Email:           
                            <span><asp:Literal ID="LitEmail" runat="server"></asp:Literal></span>
                        </li>                                               
                    </ul>

                 <a href="entrada.aspx" class="btn btn-secondary btn-block mb-4">Salir del Dashboard</a>
                </div>

<%--SuperAdmin Dashboard--%>

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
                                        <h4 class="card-title"><a href="../trabajor-excepciones.aspx">Calendario de Citas</a></h4>
                                    </div>
                                </div>
                            </div>  
                            <div class="col-md-4">
                                <div class="card text-center mb-3 card-menu">
                                    <div class="card-block">
                                        <p class="mt-4">
                                            <a href="../administrador-charlas-grupales.aspx">
                                                <span class="fa-stack fa-3x">
                                                    <i class="fas fa-circle fa-stack-2x"></i>
                                                    <i class="fas fa-calendar-alt fa-stack-1x fa-inverse"></i>
                                                </span>
                                            </a>
                                        </p>                                   
                                        <h4 class="card-title"><a href="../administrador-charlas-grupales.aspx">Calendario de Charlas</a></h4>
                                    </div>
                                </div>
                            </div> 
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
                             <div class="col-md-4">

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
                                    <h4 class="card-title"><a href="../recaudos-busqueda-usuario.aspx">Recaudos</a></h4>
                                </div>
                            </div>

                        </div>
                        </div>
                    </div>              
              <%--  </div>
            </div>--%>
                                                </ContentTemplate>
                                              </asp:RoleGroup>
                                        </RoleGroups>
                                    </asp:LoginView>

<%--Director Dashboard--%>

            <asp:LoginView runat="server" ViewStateMode="Disabled">
                                        <RoleGroups>
                                            <asp:RoleGroup Roles="Director">
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
                                        <h4 class="card-title"><a href="../trabajor-excepciones.aspx">Calendario de Citas</a></h4>
                                    </div>
                                </div>
                            </div>  
                            <div class="col-md-4">
                                <div class="card text-center mb-3 card-menu">
                                    <div class="card-block">
                                        <p class="mt-4">
                                            <a href="../administrador-charlas-grupales.aspx">
                                                <span class="fa-stack fa-3x">
                                                    <i class="fas fa-circle fa-stack-2x"></i>
                                                    <i class="fas fa-calendar-alt fa-stack-1x fa-inverse"></i>
                                                </span>
                                            </a>
                                        </p>                                   
                                        <h4 class="card-title"><a href="../administrador-charlas-grupales.aspx">Calendario de Charlas</a></h4>
                                    </div>
                                </div>
                            </div> 
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
                             <div class="col-md-4">

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
                                    <h4 class="card-title"><a href="../recaudos-busqueda-usuario.aspx">Recaudos</a></h4>
                                </div>
                            </div>

                        </div>
                        </div>
                    </div>              
              <%--  </div>
            </div>--%>
                                                </ContentTemplate>
                                              </asp:RoleGroup>
                                        </RoleGroups>
                                    </asp:LoginView>

<%--Trabajador Social Dashboard--%>

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
                    </div>   
                    </div>  
                                                 </ContentTemplate>
                                            </asp:RoleGroup>
                                    </RoleGroups>
                                </asp:LoginView>

                <%--Trabajador Social Dashboard--%>

         <asp:LoginView runat="server" ViewStateMode="Disabled">
                                    <RoleGroups>
                                        <asp:RoleGroup Roles="CoordinadorCharlas">
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
                                    <h4 class="card-title"><a href="../administrador-charlas-grupales.aspx">Calendario de Charlas</a></h4>
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
