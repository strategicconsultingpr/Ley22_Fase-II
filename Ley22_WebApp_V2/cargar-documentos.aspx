<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="cargar_documentos" Codebehind="cargar-documentos.aspx.cs" %>
      <%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 


    <div class="container-fluid">

        <div class="card">
            <div class="card-header">
                Recepción de Documentos. Usuario:  <uc1:WUCUsuario runat="server" ID="WUCUsuario" />
 
            </div>
            <div class="card-menu-mensaje" id="DivDocumentos" runat="server">
              
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" PagerSettings-Visible="false" AllowPaging="True" GridLines="None" CellSpacing="-1" DataKeyNames="Id_Documento">
                    <Columns>
                        <asp:BoundField DataField="Documento1" HeaderText="Documentos requeridos que participante debe" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
                        
                    </Columns>
                    <EmptyDataTemplate>
                        <%--<div class="card-block">
                            <p class="text-center pt-4 pb-4">Ningún usuario coincide con su búsqueda. <a href="nuevo-usuario.aspx">Crear Cuenta Nueva</a></p>
                        </div>--%>
                     </EmptyDataTemplate>

                    <PagerSettings Visible="False"></PagerSettings>

                </asp:GridView>

            </div>
            <div class="card-block">

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col">
                        Orden Judicial                   
                    </div>
                    <div class="col">
                        Tipo de documento                   
                    </div>
                    <div class="col">
                        Documento                   
                    </div>
                    <div class="col">
                    </div>
                    <div class="col-lg-1"></div>
                </div>




                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col">
                        <asp:DropDownList ID="DdlNumeroOrdenJudicial" runat="server" CssClass="custom-select w-100" OnSelectedIndexChanged="DdlNumeroOrdenJudicial_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlNumeroOrdenJudicial" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col">
                        <asp:DropDownList ID="DdlDocumento" runat="server" CssClass="custom-select w-100" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlDocumento" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" aria-describedby="fileHelp" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="FileUpload1" Display="Dynamic"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col">
                        <asp:Button ID="BtnSubirDocumento" runat="server" Text="SUBIR DOCUMENTO" OnClick="BtnSubirDocumento_Click" CssClass="btn btn-primary mr-3" />                       
                    </div>
                    <div class="col">
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary btn-lg" OnClick="BtnCancelar_Click" CausesValidation="false" />
                    </div>
                    <div class="col-lg-1"></div>
                </div>


                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10 col-md-12">

                        <asp:GridView ID="GvRecepcionDocumentos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover mb-5" DataKeyNames="Id_DocumentoPorParticipante , PathNameDocumento" GridLines="None" CellSpacing="-1">
                            <Columns>
                                <asp:BoundField DataField="NumeroCasoCriminal" HeaderText="N# Orden Judicial" />
                                <asp:BoundField DataField="Documento" HeaderText="Tipo de Documento" />
                                <asp:BoundField DataField="PathNameDocumento" HeaderText="Documento" />
                                <asp:BoundField DataField="FechaEntrega" HeaderText="Fecha de Entrega" DataFormatString="{0:MM/dd/yyyy}"/>            
                                <asp:BoundField DataField="AprobadoTexto" HeaderText="Aprobado" />                       

                                <asp:TemplateField>

                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkImprimir" OnClick="lnkImprimir_Click" runat="server"  data-toggle="tooltip" CausesValidation="false" CommandArgument='<%#  Bind("PathNameDocumento")%>'> <img src="../images/print.png" alt="ASSMCA"></asp:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>

                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEliminar" OnClick="lnkEliminar_Click" runat="server" data-toggle="tooltip" title="Eliminiar" CausesValidation="false" CommandArgument='<%# Bind("Id_DocumentoPorParticipante") %>'> <img src="../images/trash.png" alt="ASSMCA"></asp:LinkButton>
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



</asp:Content>

