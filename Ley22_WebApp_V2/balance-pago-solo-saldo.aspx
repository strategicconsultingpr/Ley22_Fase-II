<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="balance_pago_solo_saldo" Codebehind="balance-pago-solo-saldo.aspx.cs" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="container-fluid">


        <div class="card mb-5">
            <div class="card-header">
                Balance de Cuenta. Usuario: <uc1:WUCUsuario runat="server" ID="WUCUsuario" />
 
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
                         </div>

                        <asp:literal runat="server" id="LitInfo"></asp:literal>
                        <asp:gridview id="GvControldePagos" runat="server" autogeneratecolumns="False" cssclass="table table-hover mb-5" datakeynames="Id_ControldePagos" gridlines="None" cellspacing="-1" onrowdatabound="GvControldePagos_RowDataBound">
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
                        </asp:gridview>

                    </div>
                    <div class="col-lg-1"></div>
                </div>

            </div>
            <!-- card-block -->
        </div>
        <!-- Card -->


    </div>



</asp:Content>
