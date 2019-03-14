<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="balance_pago" Codebehind="balance-pago.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">


        //Add the function below
        function openPopup() {
            $("#Pagar-modal").modal({ show: true });
            e.preventDefault();
        }

        function closePopup() {
            $("#Pagar-modal").modal('hide');
        }
    </script>




    <input id="IdCP" name="IdCP" type="hidden" runat="server" />
    <input id="IdDesc" name="IdDesc" type="hidden" runat="server" />
    <!-- Modal -->
    <div class="modal fade" id="imprimir-recibo-modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">

            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Recibo</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div class="row bb mb-3">
                        <div class="col-md-2 text-center">
                            <img src="images/logo-gob-puerto-rico.png">
                        </div>

                        <div class="col-md-8">
                            <p>
                                Estado Libre Asociado de Puerto Rico
                Administración de Servicios de Salud 
Mental y Contra la Adicción             Administración Auxiliar de Prevención y Promoción de la Salud Mental
                            </p>
                        </div>

                        <div class="col-md-2 text-center">
                            <img src="images/logo-assmca.png">
                        </div>
                    </div>


                    <ul class="list-unstyled ml-3">
                        <li><strong>
                            <div id="NroRecibo"></div>
                        </strong></li>
                        <li><strong>
                            <div id="Descripcion"></div>
                        </strong></li>
                        <li><strong>
                            <div id="FormadePago"></div>
                        </strong></li>
                        <li><strong>
                            <div id="Fecha"></div>
                        </strong></li>
                        <li><strong>
                            <div id="Cantidad"></div>
                        </strong></li>
                        <li><strong>
                            <div id="NombreCompleto"></div>
                        </strong></li>

                    </ul>

                    <p class="ml-3">
                        P.O Box 600000. Bayamon PR 8989999. Contactos 999999999
              www.assmca.pr.gov ACUSE
                    </p>

                </div>
                <div class="modal-footer">
                    <button type="button" runat="server" class="btn btn-primary mr-3" data-dismiss="modal" OnClick="BtnPrint_Click" UseSubmitBehavior="false">Imprimir</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Orden Judicial Modal -->

    

    <!-- End Orden Judicial Modal -->


    <div class="modal fade" id="Pagar-modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">

            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Pagar</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="col-md-10">
                        <div class="row">


                            <!-- col -->

                            <div class="col-md-3">

                                <div class="form-group">
                                    <label for="sexo">Forma de Pago</label>
                                    <asp:DropDownList ID="DdlFormadePago" runat="server" CssClass="form-control" onchange="javascript:Cheque();">
                                        <asp:ListItem Value="0">-Seleccione-</asp:ListItem>
                                        <asp:ListItem Value="1">Cash</asp:ListItem>
                                        <asp:ListItem Value="2">Cheque Certificado</asp:ListItem>
                                        <asp:ListItem Value="3">Ajustes</asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ControlToValidate="DdlFormadePago" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>

                            </div>
                            <!-- col -->
                            <div class="col-md-3">
                                <label for="fecha-pago">Número del Cheque</label>

                                <asp:TextBox ID="TxtNumeroCheque" runat="server" class="form-control" placeholder="Ej. 200" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVNumeroCheque" runat="server" ErrorMessage="*Requerido" ControlToValidate="TxtNumeroCheque" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


                            </div>

                            <div class="col-md-3">

                                <div class="form-group">
                                    <label for="fecha-pago">Fecha del Pago</label>
                                    <asp:TextBox ID="TxtFechaDelPago" runat="server" class="form-control" placeholder="Ej. mm/dd/yyyy" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaNacimiento_CalendarExtender" runat="server" BehaviorID="TxtFechaNacimiento_CalendarExtender" TargetControlID="TxtFechaDelPago" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFechaDelPago" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" ControlToValidate="TxtFechaDelPago" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>

                            </div>

                            <div class="col">

                                <label for="fecha-pago">Cantidad</label>
                                <asp:TextBox ID="TxtCantidad" runat="server" class="form-control" placeholder="Ej. 200" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Requerido" ControlToValidate="TxtCantidad" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


                            </div>

                            <div class="col">

                                <label for="fecha-pago">Numero de Recibo</label>
                                <asp:TextBox ID="TxtNumeroRecibo" runat="server" class="form-control" placeholder="59456" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Requerido" ControlToValidate="TxtNumeroRecibo" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


                            </div>

                            <div style="margin-left:auto;margin-right:auto;">

                                <label for="fecha-pago">Balance</label>
                                <asp:Label ID="LabelBalance" runat="server"></asp:Label>
                                
                            </div>

                            <!-- col -->

                        </div>
                    </div>

                </div>
                <div class="modal-footer">

                    <asp:Button ID="BtnGuardarPago" runat="server" Text="Registrar Pago" CssClass="btn btn-primary mr-3" OnClick="BtnGuardarPago_Click" UseSubmitBehavior="false" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid">


        <div class="card mb-5">
            <div class="card-header">
                Balance de Cuenta. Usuario:
                <uc1:WUCUsuario runat="server" ID="WUCUsuario" />  &nbsp &nbsp &nbsp &nbsp Programa: <asp:Literal ID="NombrePrograma" runat="server"></asp:Literal>

            </div>
            <div class="card-block">
                
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">



                        <div class="row mb-4 bt pt-4">
                            <div class="col-md-6">
                                <strong>Registrar Pago</strong>
                            </div>
                           
                                <div class="col-md-3">
                                    <strong><label for="orden">Orden Judicial</label></strong> 


                                          <div class="row">
                                            <div class="col-10">
                                                 <asp:DropDownList ID="DdlNumeroOrdenJudicial" runat="server" CssClass="custom-select w-100" AutoPostBack="true" OnSelectedIndexChanged="BidGrid"></asp:DropDownList>
                                            </div>                                         
                                          </div>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Requerido" InitialValue="0" ForeColor="Red" ControlToValidate="DdlNumeroOrdenJudicial" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                

                            <div class="col" style="text-align: right; width: 100%;">
                                <asp:Button ID="BtnCancelar" runat="server" Text="Volver" CssClass="btn btn-primary mr-3" OnClick="BtnCancelar_Click" CausesValidation="false" />
                            </div>
                            <!-- col-9 -->

                        </div>
                        <!-- row -->


                        <!-- row -->

                        <asp:Literal runat="server" ID="LitInfo"></asp:Literal>

                        <asp:GridView ID="GvControldePagos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover mb-5" DataKeyNames="Id_ControldePagos" GridLines="None" CellSpacing="-1" OnRowDataBound="GvControldePagos_RowDataBound">
                            <Columns>
                               
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                <asp:BoundField DataField="CantidadAPagar" HeaderText="Costo (USD)" DataFormatString="{0:0.00}">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FormadePago" HeaderText="Forma de Pago" />
                                <asp:BoundField DataField="NumerodeCheque" HeaderText="Número de Cheque">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechadelPago" HeaderText="Fecha del Pago" DataFormatString="{0:MM/dd/yyyy hh:mm tt}" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad Restante (USD)" DataFormatString="{0:0.00}">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Estatus">
                                    <ItemTemplate>
                                        <asp:Literal ID="LitColocarEstatus" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>

                                    <ItemTemplate>
                                        <asp:Literal ID="LitColocarModal" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>

                                    <ItemTemplate>
                                        <asp:Label DataField="NumeroRecibo" runat="server" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>

                    </div>
                    <div class="col-lg-1"></div>
                </div>

            </div>
            <!-- card-block -->
        </div>
        <!-- Card -->


    </div>
    <!-- container-fluid -->

    <!-- BootStrap and Jquery -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/tether.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {

            $('[data-toggle="tooltip"]').tooltip()

        });


    </script>


    <script>
        function changeDivContent(NroRecibo, Descripcion, FormadePago, Fecha, Cantidad, NombreCompleto) {
            document.getElementById("NroRecibo").innerHTML = "Recibo #: " + NroRecibo;
            document.getElementById("Descripcion").innerHTML = "Descripción: " + Descripcion;

            document.getElementById("FormadePago").innerHTML = "Forma de Pago: " + FormadePago;
            document.getElementById("Fecha").innerHTML = "Fecha: " + Fecha;
            document.getElementById("Cantidad").innerHTML = "Cantidad: $" + Cantidad;
            document.getElementById("NombreCompleto").innerHTML = "Nombre: " + NombreCompleto;
        };

        function ActualizarIdCP(Valor, Cantidad, Descripcion) {
            document.getElementById("<%= IdCP.ClientID %>").value = Valor;
            document.getElementById("<%=LabelBalance.ClientID %>").innerHTML = " &nbsp;&nbsp;&nbsp; $ " + Cantidad;
            document.getElementById("<%= IdDesc.ClientID %>").value = Descripcion;
        };

        function Cheque() {
            var DdlForma = document.getElementById("<%=DdlFormadePago.ClientID %>");
            var TxtCheque = document.getElementById("<%=TxtNumeroCheque.ClientID %>");
            var val = document.getElementById("<%=RFVNumeroCheque.ClientID %>");
           
            var selectedValue = DdlForma.value;
            if (selectedValue == "2") {
                TxtCheque.style.visibility = 'visible';
                ValidatorEnable(val, true);
            }
            else {
                TxtCheque.style.visibility = 'hidden';
                ValidatorEnable(val, false);
            }
               // alert(selectedValue);
            

        };
        

    </script>
</asp:Content>

