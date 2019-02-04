<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="cierre_caso" Codebehind="cierre-caso.aspx.cs" %>

<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">


        <div class="card">
            <div class="card-header">
                Cierre de Caso - Usuario:  <uc1:WUCUsuario runat="server" ID="WUCUsuario" />
             </div>
 
            <div class="card-block">
 
                <div class="alert alert-success mb-4" role="alert" runat="server" id="Mensaje" visible="false">
                    La orden judicial se cerro con éxito
                               
                </div>

                 <div class="row">


                    <div class="col-md-12">
                        <div class="row">

                            <div class="col-md-3">

                                <div class="form-group">
                                    <label for="sexo">Orden Judicial</label>
                                    <asp:DropDownList ID="DdlNumeroOrdenJudicial" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="DdlNumeroOrdenJudicial" InitialValue="0" ID="RequiredFieldValidator1" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="*Requerido"></asp:RequiredFieldValidator>

                                </div>

                            </div>
                            <!-- col -->

                            <div class="col-md-3"></div>
                            <!-- col -->

                            <div class="col-md-3"></div>
                            <!-- col -->

                            <div class="col-md-3"></div>

                        </div>
                        <!-- row-->
                    </div>
                    <!-- col-md-12 -->


                    <div class="col-md-12">
                        <div class="row">

                            <div class="col-md-3">

                                <div class="form-group">
                                    <label for="sexo">Motivo de Cierre</label>
                                    <asp:DropDownList ID="DdlMotivoCierre" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ControlToValidate="DdlMotivoCierre" InitialValue="0" ID="RequiredFieldValidator2" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="*Requerido"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <!-- col -->

                            <div class="col-md-3">

                                <div class="form-group">
                                    <label for="adjuntar-documento-aprobacion">Adjuntar Documento de Aprobación</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" aria-describedby="fileHelp" />
                                </div>

                            </div>
                            <!-- col -->

                            <div class="col-md-3"></div>
                            <!-- col -->

                            <div class="col-md-3"></div>

                        </div>
                        <!-- row-->
                    </div>
                    <!-- col-md-12 -->


                    <div class="col-md-12">
                        <div class="row">

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label for="comentarios">Comentarios</label>
                                    <asp:TextBox ID="TxtCometarios" runat="server" class="form-control" TextMode="MultiLine" placeholder="Ingrese aquí el motivo del cierre" MaxLength="4096"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="TxtCometarios"  ID="RequiredFieldValidator3" Display="Dynamic" ForeColor="Red" runat="server" ErrorMessage="*Requerido"></asp:RequiredFieldValidator>

                                        </div>

                            </div>
                            <!-- col -->

                            <div class="col-md-6"></div>
                            <!-- col -->

                        </div>
                        <!-- row-->
                    </div>
                    <!-- col-md-12 -->

                    <div class="col-md-12">
                        <asp:Button ID="BtnGuardar" runat="server" Text="Cerrar Caso" CssClass="btn btn-primary btn-lg" OnClick="BtnGuardar_Click" />
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary btn-lg" OnClick="BtnCancelar_Click" CausesValidation="false" />

                    </div>
                    <!-- col-12 -->
                </div>
                <!-- row -->

            </div>
            <!-- container-fluid -->

        </div>
    </div>
</asp:Content>

