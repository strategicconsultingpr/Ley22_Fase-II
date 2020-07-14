<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="imprimir_documentos" Codebehind="imprimir-documentos.aspx.cs" %>
           <%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    


    <div class="container-fluid">
        <div class="card" id="divUpload" runat="server" visible="false">
            <div class="card-header">
                Agregar Documento:
            </div>
            <div class="card-block">
                 <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col">
                          
                        <label class="form-check-label">
                                    <asp:CheckBox ID="ChkImportante" runat="server" class="form-check-input"/>
                                  Requerido
                                </label>
                    </div>
                    <div class="col">
                        <label class="form-check-label">
                                    <asp:CheckBox ID="ChkRecurrente" runat="server" class="form-check-input"/>
                                  Reusable
                                </label>                                           
                    </div>
                    <div class="col">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" aria-describedby="fileHelp" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="FileUpload1" Display="Dynamic"></asp:RequiredFieldValidator>                   
                    </div>
                    <div class="col">
                        <asp:Button ID="BtnSubirDocumento" runat="server" Text="SUBIR DOCUMENTO" OnClick="BtnSubirDocumento_Click" CssClass="btn btn-primary mr-3" />
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </div>
        </div>
        <br />
        <div class="card">
            <div class="card-header">
                Documentos para Imprimir
                
                <asp:Button ID="BtnCancelar" runat="server" Text="Volver a mi Tablero" CssClass="btn btn-primary mr-3" style="position:relative; float:right; margin-right:50px;" OnClick="BtnCancelar_Click" CausesValidation="false" />
            
            </div>
            
            <div class="card-block">

 


                <div class="row" style="width: 100%; height: 500px; overflow: scroll">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10 col-md-12">

                        <asp:GridView ID="GvDocumentos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover mb-5" GridLines="None" CellSpacing="-1" PageSize="30" OnPreRender="GvDocumentos_RowDataBound" DataKeyNames="Id_Documento, Archivo">
                            <Columns>
                                <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                <asp:BoundField DataField="FechadeRevision" HeaderText="Fecha de Revisión" DataFormatString="{0:MM/dd/yyyy}" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkImprimir" OnClick="lnkImprimir_Click" runat="server" data-toggle="tooltip" CausesValidation="false" CommandArgument='<%# Bind("Archivo") %>'><img src="<%=ResolveClientUrl("~/images/print.png")%>" alt="ASSMCA"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEliminar"  runat="server" data-toggle="tooltip" title="Eliminiar" OnClientClick="return confirm('Esta seguro de querer borrar este documento?');" OnClick="lnkEliminar_Click" CausesValidation="false" CommandArgument='<%# Bind("Id_Documento") %>'> <img src="<%=ResolveClientUrl("~/images/trash.png")%>" alt="ASSMCA"></asp:LinkButton>
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
     <script type="text/javascript">

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

         function alertaBorrar() {

             swal({
                 title: "Are you sure?",
                 text: "Once deleted, you will not be able to recover this imaginary file!",
                 icon: "warning",
                 buttons: true,
                 dangerMode: true,
             })
                 .then((willDelete) => {
                     if (willDelete) {
                         swal("Poof! Your imaginary file has been deleted!", {
                             icon: "success",
                         });

                         return true;
                         alert("true");
                     } else {
                         swal("Your imaginary file is safe!");
                         return false;
                         alert("false");
                     }
                 });
             alert("final");
             //return false;
             
         }

    </script>


</asp:Content>

