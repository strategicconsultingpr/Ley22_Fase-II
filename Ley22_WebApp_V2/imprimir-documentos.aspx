<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="imprimir_documentos" Codebehind="imprimir-documentos.aspx.cs" %>
           <%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    


    <div class="container-fluid">

        <div class="card">
            <div class="card-header">
                Documentos Impresión: Usuario: <uc1:WUCUsuario runat="server" ID="WUCUsuario" />
                
                <asp:Button ID="BtnCancelar" runat="server" Text="Volver" CssClass="btn btn-primary mr-3" style="position:relative; float:right; margin-right:50px;" OnClick="BtnCancelar_Click" CausesValidation="false" />
            
            </div>
            
            <div class="card-block">

 


                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10 col-md-12">

                        <asp:GridView ID="GvDocumentos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover mb-5" GridLines="None" CellSpacing="-1">
                            <Columns>
                                <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                <asp:BoundField DataField="FechadeRevision" HeaderText="Fecha de Revisión" DataFormatString="{0:MM/dd/yyyy}" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkImprimir" OnClick="lnkImprimir_Click" runat="server" CssClass="fas fa-print fa-lg" data-toggle="tooltip" CausesValidation="false" CommandArgument='<%# Bind("Archivo") %>'></asp:LinkButton>
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

