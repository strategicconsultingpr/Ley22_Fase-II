<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Certificados_Participante.aspx.cs" Inherits="Ley22_WebApp_V2.Certificados_Participante" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <!-- Modal Certificados --> 

     <div class="modal fade" id="modal-certificados" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalabelCertificados">Generar Certificados</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row bb pl-4 pr-4 pb-4 mb-4">
                        <div class="col">
                            <div class="form-group">

                                <label for="fecha-charla">Adiestrador Educativo</label>
                                <div class="input-group">
                                   
                                <asp:DropDownList runat="server" ID="DdlAdiestrador" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlAdiestrador" InitialValue="0"></asp:RequiredFieldValidator>
                            
                                </div>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="fecha-charla">Supervisor de Programa</label>
                                <div class="input-group">
                                    
                                <asp:DropDownList runat="server" ID="DdlSupervisor" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="*Requerido" ForeColor="Red" Display="Dynamic" ControlToValidate="DdlSupervisor" InitialValue="0"></asp:RequiredFieldValidator>
                            
                                </div>

                            </div>
                        </div>

                      
                    </div>
                </div>
                <div class="modal-footer">
                     <asp:LinkButton ID="LnkGenerar" runat="server" Text="Generar Certificados" CssClass="btn btn-primary mr-3" OnClick="BtnGenerarCertificados" />

                  <!--  <button type="button" class="btn btn-secondary" data-dismiss="modal" data-target="#modal-crear-charla">Cancelar</button> -->

                    <a data-dismiss="modal" href="#" class="btn btn-secondary"  runat="server" id="A4">Cancelar</a>
                           
                </div>
            </div>
        </div>
    </div>

     <!-- Pantalla completa -->

      <div class="container-fluid">

        <div class="card">
            <div class="card-header">
                Certificaciones - Participante:  <uc1:WUCUsuario runat="server" ID="WUCUsuario" />
 
            </div>
           
            <div class="card-block">

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col">
                        Caso Criminal                   
                    </div>
                    <%--<div class="col">
                        Tipo de documento                   
                    </div>
                    <div class="col">
                        Documento                   
                    </div>
                    <div class="col">
                    </div>
                    <div class="col-lg-1"></div>--%>
                </div>




                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col">
                        <asp:DropDownList ID="DdlNumeroOrdenJudicial" runat="server" CssClass="custom-select w-100" OnSelectedIndexChanged="DdlNumeroOrdenJudicial_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlNumeroOrdenJudicial" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                  <%--  <div class="col">
                        <asp:DropDownList ID="DdlDocumento" runat="server" CssClass="custom-select w-100" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlDocumento" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>--%>
                    <div class="col">

                    </div>
                    <div class="col">
                        <%--<asp:Button ID="BtnGenerar" runat="server" Text="GENERAR CERTIFICADO"  CssClass="btn btn-primary mr-3" />   --%>
                        <a data-dismiss="modal" href="#" class="btn btn-primary mr-3" data-toggle="modal" data-target="#modal-certificados" data-whatever="@getbootstrap" runat="server" id="lnkCertificados" >GENERAR CERTIFICADO</a>
                    </div>
                    <div class="col">
                        <a id="BtnCancelar" href="seleccion-proximo-paso.aspx" class="btn btn-secondary btn-lg">CANCELAR</a>
                    </div>
                    
                    <div class="col-lg-1"></div>
                </div>

                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10 col-md-12">

                        <asp:GridView ID="GvCertificados" runat="server" AutoGenerateColumns="False" CssClass="table table-hover mb-5" DataKeyNames="Value" GridLines="None" CellSpacing="-1">
                            <Columns>
                                <asp:BoundField DataField="Text" HeaderText="Titulo Certificado" />
                                      

                                <asp:TemplateField>

                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkImprimir" OnClick="lnkImprimir_Click" runat="server" data-toggle="tooltip" CausesValidation="false" CommandArgument='<%#  Bind("Value")%>'> <img src="../images/print.png" alt="ASSMCA"></asp:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>

                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEliminar"  runat="server" data-toggle="tooltip" title="Eliminiar" OnClick="lnkEliminar_Click" OnClientClick="return confirm('Seguro de querer borrar el documento?');" CausesValidation="false" CommandArgument='<%# Bind("Value") %>'> <img src="../images/trash.png" alt="ASSMCA"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="card-block">
                                    <p class="text-center pt-4 pb-4">Certificado de Cumplimiento para este caso criminal no ha sido generado.</p>
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
    <!-- container-fluid -->

    <script type="text/javascript">

        

        function alertaAsistio(sender) {
            
          swal({
             title: "Are you sure?",
                text: "You will not be able to recover this imaginary   file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                cancelButtonText: "No, cancel plx!",
                closeOnConfirm: false,
                closeOnCancel: false
            }).then((willDelete) => {
              if (willDelete) {
                swal("Poof! Your imaginary file has been deleted!", {
                  icon: "success",
                  });
                  return true;
              } else {
                  swal("Your imaginary file is safe!");
                  return false;
              }
            });

            //return confirm("¿Está seguro que el participante SI asistió?");   

       

            //swal({
            //    title: "Are you sure?",
            //    text: "You will not be able to recover this imaginary   file!",
            //    type: "warning",
            //    showCancelButton: true,
            //    confirmButtonColor: "#DD6B55",
            //    confirmButtonText: "Yes, delete it!",
            //    cancelButtonText: "No, cancel plx!",
            //    closeOnConfirm: false,
            //    closeOnCancel: false
            //},
            //    function (isConfirm) {
            //        if (isConfirm) {
            //            swal({ title: "Deleted!", text: "Your imaginary file has been deleted.", type: "success", confirmButtonText: "OK!", closeOnConfirm: false },
            //                function () {
            //                    // RESUME THE DEFAULT LINK ACTION
            //                    // window.location.href = defaultAction;
            //                    return true;
            //                });
            //        } else {
            //            swal("Cancelled", "Your imaginary file is safe :)", "error");
            //            return false;
            //        }
            //    });
        }

        if ( window.history.replaceState ) {
           window.history.replaceState( null, null, window.location.href );
        }
       function sweetAlert(titulo,texto,icono) {
        
             swal({
                 title: titulo,
                 html: texto,
                 icon: icono
             }
             );  
        }
      

    </script>

</asp:Content>
