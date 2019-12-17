<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="balance_pago_solo_saldo" Codebehind="balance-pago-solo-saldo.aspx.cs" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="container-fluid">


        <div class="card mb-5">
            <div class="card-header">
                Balance de Cuenta. Participante: <uc1:WUCUsuario runat="server" ID="WUCUsuario" />
 
            </div>
            <div class="card-block">

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">



                        <div class="row mb-4 bt pt-4">
                            <div class="col-md-6">
                                <strong>Historial Financiero</strong>
                            </div>

                            <div class="col-md-3">
                                    <strong><label for="orden">Caso Criminal</label></strong> 


                                          <div class="row">
                                            <div class="col-10">
                                                 <asp:DropDownList ID="DdlNumeroOrdenJudicial" runat="server" CssClass="custom-select w-100" AutoPostBack="true" OnSelectedIndexChanged="BidGrid"></asp:DropDownList>
                                            </div>                                         
                                          </div>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Requerido" InitialValue="0" ForeColor="Red" ControlToValidate="DdlNumeroOrdenJudicial" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>

                            <div class="col" style="text-align: right; width: 100%;">
                                <asp:Button ID="BtnCancelar" runat="server" Text="Volver al Expediente" CssClass="btn btn-primary mr-3" OnClick="BtnCancelar_Click" CausesValidation="false" />
                            </div>
                         </div>

                        <asp:literal runat="server" id="LitInfo"></asp:literal>

                        <div class="row mb-4 bt pt-4" id="divNav" runat="server">
                              <div class="col-md-4"></div>
                        <div class="col-md-6">
                       <%-- <nav>--%>
                          <ul class="nav">
                              <li class="nav-item">
                              <a id="pagar" class="nav-link" href="#" onclick="Pagar()">Historial de Cargos</a>
                            </li>
                            <li class="nav-item">
                              <a id="historial" class="nav-link" href="#" onclick="Historial()">Historial de Pagos</a>
                            </li>                                                 
                          </ul>
                         <%--</nav>--%>
                            </div>
                            </div>

                       <%-- <asp:gridview id="GvControldePagos" runat="server" autogeneratecolumns="False" cssclass="table table-hover mb-5" datakeynames="Id_ControldePagos" gridlines="None" cellspacing="-1" onrowdatabound="GvControldePagos_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                <asp:BoundField DataField="CantidadAPagar" HeaderText="Costo (USD)" DataFormatString="{0:0.00}">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FormadePago" HeaderText="Forma de Pago" />
                                <asp:BoundField DataField="NumerodeCheque" HeaderText="Número de Cheque"  >
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechadelPago" HeaderText="Fecha del Pago" DataFormatString="{0:MM/dd/yyyy hh:mm tt}" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad Restante (USD)" DataFormatString="{0:0.00}" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Estatus">
   
                                    <ItemTemplate>

                                          <asp:Literal ID="LitColocarEstatus" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
 
                                </asp:TemplateField>
                            </Columns>
                        </asp:gridview>--%>

                        <div id="divPagar">
                            
                            <div class="col-md-6">
                                 <asp:Literal runat="server" ID="LitBalance"></asp:Literal>
                            </div>
                           
                                
                            <br />
                        <asp:GridView ID="GvCargos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover mb-5" DataKeyNames="PK_ControldePago" GridLines="None" CellSpacing="-1" OnRowDataBound="GvPagar_RowDataBound">
                            <Columns>
                               
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Costo (USD)" DataFormatString="{0:0.00}">
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" DataFormatString="{0:MM/dd/yyyy}"/>
                                <asp:BoundField DataField="FechaCita" HeaderText="Fecha de Cita" DataFormatString="{0:MM/dd/yyyy}"/>
                                <asp:BoundField DataField="FechaCharla" HeaderText="Fecha de Charla" DataFormatString="{0:MM/dd/yyyy}"/>                               
                            </Columns>
                            <EmptyDataTemplate>
                        <div class="card-block">
                            <p class="text-center pt-4 pb-4">
                            <asp:Label runat="server" ID="lblCargosEmpty" />
                            </p>
                        </div>

                    </EmptyDataTemplate>
                        </asp:GridView>                          
                        </div>
                           
                         <asp:GridView ID="GvPagos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover mb-5" DataKeyNames="PK_ControldePago" GridLines="None" CellSpacing="-1" OnRowDataBound="GvHistorial_RowDataBound" style="visibility:hidden">
                            <Columns>
                                <asp:BoundField DataField="NumeroRecibo" HeaderText="Número de Recibo" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad de Pago(USD)" DataFormatString="{0:0.00}">
                                    <%--<ItemStyle HorizontalAlign="Center" />--%>
                                </asp:BoundField>
                                <asp:BoundField DataField="FormadePago" HeaderText="Metodo de Pago" />
                                <asp:BoundField DataField="NumerodeCheque" HeaderText="Número de Cheque">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaPago" HeaderText="Fecha de Pago" DataFormatString="{0:MM/dd/yyyy}"/>
                                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Empleado" />    
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Literal ID="LitColocarModal" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                             <EmptyDataTemplate>
                        <div class="card-block">
                            <p class="text-center pt-4 pb-4">El participante no ha realizado ningún pago. </p>
                        </div>

                    </EmptyDataTemplate>
                        </asp:GridView> 

                    </div>
                    <div class="col-lg-1"></div>
                </div>

            </div>
            <!-- card-block -->
        </div>
        <!-- Card -->


    </div>

        <script type="text/javascript">     

            $('li a').click(function (e) {
                e.preventDefault();
                $('a').removeClass('active');
                $(this).addClass('active');
            });

            $(function () {
                var Con = document.getElementById('<%=divNav.ClientID %>');
                var act = Con.getElementsByClassName("active");
                if (document.getElementById('<%=divNav.ClientID %>')) {
                    if (act.length == 0) {
                        $("#pagar").addClass("active");
                    }
                }
                
            });

            function Historial() {    
            //$(".nav").find(".active").removeClass("active");
            //$("#historial").addClass("active");
            document.getElementById("<%=GvPagos.ClientID %>").style.visibility = 'visible';
            document.getElementById("divPagar").style.display = 'none';
        }

        

            function Pagar() {
            //$(".nav").find(".active").removeClass("active");
            //$("#pagar").addClass("active");
            document.getElementById("<%=GvPagos.ClientID %>").style.visibility = 'hidden';
            document.getElementById("divPagar").style.display = 'inline';
        }
        

    </script>

</asp:Content>
