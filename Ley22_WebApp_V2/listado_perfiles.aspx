<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="listado_perfiles" Codebehind="listado_perfiles.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/WUC/WUCUsuario.ascx" TagPrefix="uc1" TagName="WUCUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card">
        <div class="card-header">
            Próximo Paso. Usuario:<uc1:WUCUsuario runat="server" ID="WUCUsuario" />

        </div>
        <div class="card-block">

            <div class="row">
                <div class="col-md-3">
                    <div class ="card">

                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">IUP
           
                            <span>
                                <asp:Literal ID="LitIUP" runat="server"></asp:Literal></span>
                        </li>
                        <li class="list-group-item justify-content-between">Episodio
           
                            <span>
                               <%-- <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaEpisodios"></asp:HyperLink>--%>
                               <asp:Literal ID="LitEpisodio" runat="server"></asp:Literal>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">Licencia
           
                            <span>
                                <asp:Literal ID="LitLicencia" runat="server"></asp:Literal></span>
                        </li>

                        <li class="list-group-item justify-content-between">
                            <strong>Estatus</strong>
                            <span><strong>
                                <asp:Literal ID="LitEstatus" runat="server"></asp:Literal></strong></span>
                        </li>

                    </ul>


                    <p class="mb-4">Históricos:</p>


                    <ul class="list-group mb-4 pb-4 slim">
                        <li class="list-group-item justify-content-between">

                            <span>
                                <asp:HyperLink ID="HLCitas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCitas"></asp:HyperLink>
                            </span>
                        </li>
                        <li class="list-group-item justify-content-between">

                            <span>
                                <asp:HyperLink ID="HlCharlas" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModalListaCharlas"></asp:HyperLink>
                            </span>
                        </li>
                    </ul>




                    <a href="entrada.aspx" class="btn btn-secondary btn-block mb-4">Salir del Registro de Usuario</a>
                   </div>
                </div>
           
      

        
               <div class="col-md-9">
               <div class="card">
                <div class="card-header">

                    <div class="row">
                       
                        <div class="col-md-4 text-left">
                            <span>
                                <%--<asp:Literal ID="LitCantidadUsuarios" runat="server"></asp:Literal>--%>
                                Listado de Perfiles</span>
                        </div>
                    </div>

                </div>
                  
                    <asp:GridView ID="gvPerfiles" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False"  GridLines="None" AllowSorting="True" DataMember="SA_PERFILES" ForeColor="Black" DataKeyNames="PK_NR_Perfil">
                        <HeaderStyle BackColor="LightGray"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Perfil">
                            <ItemTemplate>
                            <asp:LinkButton ID="lnkPerfil" runat="server" Text='<%# Bind("PK_NR_Perfil") %>' PostBackUrl='<%# Eval("URL") %>' >
                                <HeaderStyle Width="100px"/>
                            </asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="FE_Perfil" SortExpression="FE_Perfil" HeaderText="Fecha" DataFormatString="{0:d}" HeaderStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="TI_Perfil" SortExpression="TI_Perfil" HeaderText="Tipo de perfil" HeaderStyle-HorizontalAlign="Center"/>
                        </Columns>
                    </asp:GridView>

                  </div>
                </div>                   


     </div>
   </div>
 </div>
</asp:Content>
