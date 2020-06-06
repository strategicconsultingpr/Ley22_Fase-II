<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Ley22_WebApp_V2.OrdenNuevo" Codebehind="OrdenNuevo.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="modal fade" id="modal-agregar-tribunal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel3">Agregar Nuevo Tribunal</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">

                    <div class="row bb pl-4 pr-4 pb-4 mb-4">

                       <div class="col-md-6">
                           <div class="form-group">
                               <label for="tribunal-nombre">Nombre</label>
                               <asp:TextBox runat="server" ID="TxtNombreTribunal" CssClass="form-control" ValidationGroup="VGtribunal"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtNombreTribunal" Display="Dynamic" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                           </div>
                       </div>

                        <div class="col-md-6">

                           <div class="row">
                                <label for="tribunal-telefono">Teléfono</label>
                           </div>

                           <div class="row">
                           <div class="col-md-3">
                                   <asp:TextBox runat="server" ID="TxtTelefonoTribunal1" CssClass="form-control" placeholder="787" MaxLength="3" ValidationGroup="VGtribunal"></asp:TextBox>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoTribunal1" ForeColor="Red" ValidationGroup="VGtribunal"></asp:RegularExpressionValidator>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoTribunal1" Display="Dynamic" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                           </div>
                           <div class="col-md-3">
                                   <asp:TextBox runat="server" ID="TxtTelefonoTribunal2" CssClass="form-control" placeholder="555" MaxLength="3" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoTribunal2" ForeColor="Red" ValidationGroup="VGtribunal"></asp:RegularExpressionValidator>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoTribunal2" Display="Dynamic" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4">
                                   <asp:TextBox runat="server" ID="TxtTelefonoTribunal3" CssClass="form-control" placeholder="5555" MaxLength="4" ValidationGroup="VGCrearCharla"></asp:TextBox>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoTribunal3" ForeColor="Red" ValidationGroup="VGtribunal"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoTribunal3" Display="Dynamic" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                            </div>
                            </div>

                       </div>
                        </div>
                    

                    <div class="row pl-4 pr-4 pb-4 mb-4">

                        <div class="col-md-10">
                           <div class="form-group">
                               <label for="tribunal-direccion">Dirección</label>
                               <asp:TextBox runat="server" ID="TxtDireccionTribunal" CssClass="form-control" ValidationGroup="VGtribunal"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtDireccionTribunal" Display="Dynamic" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                           </div>
                       </div>

                        <div class="col-md-2">
                           <div class="form-group">
                               <label for="tribunal-pais">País</label>
                               <asp:DropDownList runat="server" ID="DdlPaisTribunal" CssClass="form-control">
                                   <asp:ListItem Value="1" Selected="True">PR</asp:ListItem>
                                   <asp:ListItem Value="2">US</asp:ListItem>
                               </asp:DropDownList>
                           </div>
                       </div>

                        <div class="col-md-12">
                           <div class="form-group">
                               <label for="tribunal-box">PO Box</label>
                               <asp:TextBox runat="server" ID="TxtBoxTribunal" CssClass="form-control" ValidationGroup="VGtribunal"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtBoxTribunal" Display="Dynamic" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                           </div>
                       </div>

                        <div class="col-md-6">

                           <div class="row">
                               <div class="col" style="text-align:left"><label for="tribunal-categoria">Categoria</label></div>
                               <div class="col" style="text-align:right"><label for="tribunal-newcategoria"><asp:CheckBox ID="ChkCategoria" runat="server" class="form-check-input" OnClick="chkCategoria();"/>Agregar Nueva</label></div>
                           </div>

                            <div class="form-group" id="divDdlCategoria">
                               <asp:DropDownList runat="server" ID="DdlCategoriaTribunal" CssClass="form-control" ValidationGroup="VGtribunal"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqDdlCategoria" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlCategoriaTribunal" Display="Dynamic" InitialValue="0" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                           </div>

                            <div class="form-group" id="divTxtCategoria" style="visibility:hidden">
                               <asp:TextBox runat="server" ID="TxtCategoriaTribunal" CssClass="form-control" ValidationGroup="VGtribunal"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqTxtCategoria" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtCategoriaTribunal" Display="Dynamic" Enabled="false" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                           </div>

                       </div>

                        <div class="col-md-6">

                            <div class="row">
                                <div class="col" style="text-align:left"><label for="tribunal-region">Región</label></div>
                                <div class="col" style="text-align:right"><label for="tribunal-newregion"><asp:CheckBox ID="ChkRegion" runat="server" class="form-check-input" OnClick="chkRegion();"/>Agregar Nueva</label></div>
                            </div>

                           <div class="form-group" id="divDdlRegion">
                               <asp:DropDownList runat="server" ID="DdlRegionTribunal" CssClass="form-control" ValidationGroup="VGtribunal"></asp:DropDownList>
                               <asp:RequiredFieldValidator ID="ReqDdlRegion" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlRegionTribunal" Display="Dynamic" InitialValue="0" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                           </div>

                            <div class="form-group" id="divTxtRegion" style="visibility:hidden">
                               <asp:TextBox runat="server" ID="TxtRegionTribunal" CssClass="form-control" ValidationGroup="VGtribunal"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqTxtRegion" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtRegionTribunal" Display="Dynamic" Enabled="false" ValidationGroup="VGtribunal"></asp:RequiredFieldValidator>
                           </div>


                       </div>

                    </div>

                </div>

                <div class="modal-footer">
                    <asp:Button ID="BtnTribunal" runat="server" Text="Agregar Tribunal" CssClass="btn btn-primary mr-3" OnClick="BtnTribunal_Click" ValidationGroup="VGtribunal"/>

                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                </div>

             </div>
          </div>
    </div>




    <div class="card mb-4">
        <div class="card-header">
           <strong> Nuevo Caso Criminal</strong> &nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp&nbsp &nbsp &nbsp &nbsp Participante: <asp:Literal ID="NombreParticipante" runat="server"></asp:Literal> &nbsp &nbsp &nbsp &nbsp Programa: <asp:Literal ID="NombrePrograma" runat="server"></asp:Literal> 
        </div>
        <div class="card-block">

            <div class="row bb pb-4 mb-4">
                <div class="col-md-2">
                    <div class="row" >
                        <div class="col" style="text-align:right">
                            <strong>Situación Legal</strong>
                        </div>
                    </div>

                    <div class="row" >
                        <br/>
                        <br/>
                        <br/>
                        <br/>
                        <br/>
                        <br/>
                        <br/>
                        <br/>
                        <br/>
                    </div>

                    
                    <div class="row">
                     <div class="col" style="text-align:right">
                            <a data-dismiss="modal" href="#" data-toggle="modal" data-target="#modal-agregar-tribunal" data-whatever="@getbootstrap" runat="server"><img src="<%=ResolveClientUrl("~/images/plus-circle.svg")%>" alt="" width="25" height="25" title="AGREGAR NUEVO TRIBUNAL"></a>
                        </div>
                    </div>
                    
                </div>

                <div class="col-md-10">
                    <div class="row">


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="n-caso-criminal">Núm. Caso Criminal (*)</label>
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="TxtNroCasoCriminal" runat="server" class="form-control" placeholder="Ej. D2TR2030-0000" MaxLength="15"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtNroCasoCriminal" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNroCasoCriminal" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                    </div>
<%--                                    <div class="col-md-1">
                                        <asp:LinkButton ID="lnkBuscar" runat="server" CssClass="fas fa-search fa-lg" CausesValidation="false" OnClick="lnkBuscar_Click"></asp:LinkButton>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="fecha-orden">Fecha de Orden del Tribunal (*)</label>
                                <asp:TextBox ID="TxtFechaOrden" runat="server" CssClass="form-control" placeholder="12/31/2000"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtFechaOrden_CalendarExtender" runat="server" BehaviorID="TxtFechaOrden_CalendarExtender" TargetControlID="TxtFechaOrden" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtFechaOrden" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtFechaOrden" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="fecha-sentencia">Fecha de Sentencia (*)</label>
                                <asp:TextBox ID="TxtSentencia" runat="server" CssClass="form-control" placeholder="12/31/2000"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" ID="TxtSentencia_CalendarExtender" runat="server" BehaviorID="TxtSentencia_CalendarExtender" TargetControlID="TxtSentencia" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtSentencia" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="* la fecha debe estar mm/dd/yyyy" ValidationExpression="(?:(?:(?:04|06|09|11)\/(?:(?:[012][0-9])|30))|(?:(?:(?:0[135789])|(?:1[02]))\/(?:(?:[012][0-9])|30|31))|(?:02\/(?:[012][0-9])))\/(?:19|20|21)[0-9][0-9]" ControlToValidate="TxtSentencia" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="alcohol">Por ciento de alcohol (*)</label>
                                <asp:TextBox ID="Txtalcohol" runat="server" class="form-control" placeholder="Ej. 0.115" MaxLength="5"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="Regex1" runat="server" ForeColor="Red" Display="Dynamic" ValidationExpression="(((\d{1,2}\.\d{1,3})))$" ErrorMessage="Agregar cantidades correcta." ControlToValidate="Txtalcohol" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Requerido" ControlToValidate="Txtalcohol" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                            <div class="row">
                                <div class="col">
                                <h5>
                                <label class="form-check-label">
                                    <asp:CheckBox ID="ChkCaso" runat="server" class="form-check-input" OnClick="combinarCaso();"/>
                                   Combinar Caso Criminal
                                </label>
                                </h5>
                                    </div>
                            </div>
                                </div>
                            </div>

                         <div class="col-md-3">

                            <div class="form-group" id="CasoDos" style="visibility:hidden" runat="server">
                                <label for="n-caso-criminal">Segundo Núm. Caso Criminal</label>
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="TxtNroCasoCriminal2" runat="server" class="form-control" placeholder="Ej. D2TR2030-0000" MaxLength="15"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtNroCasoCriminal" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNroCasoCriminal" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                    </div>
<%--                                    <div class="col-md-1">
                                        <asp:LinkButton ID="lnkBuscar" runat="server" CssClass="fas fa-search fa-lg" CausesValidation="false" OnClick="lnkBuscar_Click"></asp:LinkButton>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

                         <div class="col-md-3">

                            <div class="form-group" id="CasoTres" style="visibility:hidden" runat="server">
                                <label for="n-caso-criminal">Tercer Núm. Caso Criminal (*)</label>
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="TxtNroCasoCriminal3" runat="server" class="form-control" placeholder="Ej. D2TR2030-0000" MaxLength="15"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtNroCasoCriminal" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtNroCasoCriminal" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                    </div>
<%--                                    <div class="col-md-1">
                                        <asp:LinkButton ID="lnkBuscar" runat="server" CssClass="fas fa-search fa-lg" CausesValidation="false" OnClick="lnkBuscar_Click"></asp:LinkButton>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

                        

                        <div class="col-md-3">
                            </div>

                        <!-- col -->

                        <div class="col-md-3">
                           
                            <div class="row">
                            <div class="col-md-4">
                                <div class="form-group" >
                                    <label for="tribunal">País</label>
                                    <asp:DropDownList ID="DdlPais" runat="server" class="form-control">
                                        <asp:ListItem Value="1" Selected="True">PR</asp:ListItem>
                                        <asp:ListItem Value="2">US</asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                            </div>

                            <div class="col-md-8">
                                <div class="form-group" >
                                    <label for="tribunal">Tribunal (*)</label>
                                    <asp:DropDownList ID="DdlTribunal" runat="server" class="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlTribunal" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                                </div>

                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="juez">Juez (*)</label>
                                <asp:TextBox ID="TxtJuez" runat="server" class="form-control" placeholder="Ej. Alejandro Ortiz" MaxLength="30"></asp:TextBox>
                            </div>
                        </div>

                        <!-- col -->

                        
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="iup">IUP</label>
                                <asp:TextBox ID="TxtIUP" runat="server" class="form-control" placeholder="Ej. 999999999" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <!-- col -->


                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="n-seguro-social">Expediente</label>
                                <asp:TextBox ID="TxtExpediente" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="30" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                       
                          <div class="col-md-12">
                               <div class="form-group">
                                   <div class="row bb">
                                        <br />
                                   </div>
                                   <div class="row">
                                        <br />
                                   </div>
                                    <div class="row">
                                        <div class="col-md-5">
                                            <h5><label class="form-intervenido">¿Es la primera vez que es intervenido en este tipo de caso?</label></h5>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:DropDownList ID="DdlIntervenido" runat="server" class="form-control" OnChange="intervenido();">
                                                <asp:ListItem Value="0" Selected="True">-</asp:ListItem>
                                                <asp:ListItem Value="1">Si</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlIntervenido" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-6" id="divSentencias" style="visibility:hidden" runat="server">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <h5><label class="form-sentencias">¿Cuantas veces ha sido sentenciado?</label></h5>
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:TextBox ID="TxtSetencias" runat="server" class="form-control" Text="0" MaxLength="2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqValSentencias" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtSetencias" Display="Dynamic" InitialValue="0" Enabled="false"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtSetencias" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-md-4">

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                   <div class="row bb">
                                        <br />
                                   </div>
                                   <div class="row">
                                        <br />
                                   </div>
                                   <div class="row">
                                        <div class="col-md-11">
                                            <h5><label class="form-evaluado">¿Ha sido evaluado anteriormente por nuestro programa u otra agencia, por un caso de la Ley de Vehículos y Transito de Puerto Rico? (Conducir en estado de embriaguez alcohólica)</label></h5>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:DropDownList ID="DdlEvaluado" runat="server" class="form-control" OnChange="evaluado();">
                                                <asp:ListItem Value="0" Selected="True">-</asp:ListItem>
                                                <asp:ListItem Value="1">Si</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlEvaluado" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                   </div>
                                   <div id="divEvaluado" style="visibility:hidden" runat="server">
                                   <div class="row">
                                        <br />
                                   </div>
                                   <div class="row">
                                        <br />
                                   </div>
                                   <div class="row">
                                       <div class="col-md-1">
                                           <h5><label class="form-sentencias">Oficina:</label></h5>
                                       </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="TxtOficina" runat="server" class="form-control" placeholder="Ej. Oficina de Assmca" Text="No Aplica"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqValOficina" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtOficina" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
                                        </div>
                                       <div class="col-md-1">
                                           <h5><label class="form-sentencias">Año:</label></h5>
                                       </div>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="TxtAno" runat="server" class="form-control" placeholder="Ej. 2020" MaxLength="4" MinLength="4" Text="0000"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqValAno" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtAno" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtAno" ForeColor="Red"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ErrorMessage="*Ingresar cuatro digitos" ValidationExpression="^.{4}.*" ControlToValidate="TxtAno" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </div>
                                   </div>
                                       </div>
                                </div>
                            </div>
                        
                        <!-- col -->

                       <%-- <div class="col-md-3">
                            <div class="form-group">
                                <label for="episodio">Episodio</label>
                                <br />
                                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" data-toggle="modal" data-target="#myModal"></asp:HyperLink>
                            </div>
                        </div>--%>


                        <!-- The Modal -->
                        <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">

                                    <!-- Modal Header -->
                                    <div class="modal-header">
                                        <h4 class="modal-title">Episodios</h4>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>

                                    <!-- Modal body -->
                                    <div class="modal-body">
                                        <asp:GridView ID="GVListadeEpisodios" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="PK_Episodio">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Episodio">
                                                    <ItemTemplate>
                                                        <%--<asp:LinkButton ItemStyle-HorizontalAlign="Right" ID="lnkEpisodio" runat="server" Text='<%# Bind("PK_Episodio") %>'  OnClick="lnkEpisodio_Click" CausesValidation="false" CommandArgument='<%# Eval("PK_Episodio") %>'></asp:LinkButton>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>

                                                <%--<asp:BoundField DataField="PK_Episodio" HeaderText="Episodio" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />--%>
                                                <asp:BoundField DataField="FE_Episodio" HeaderText="Fecha del Episodio" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="DE_Programa" HeaderText="Programa" HeaderStyle-HorizontalAlign="Center" />
                                            </Columns>

                                        </asp:GridView>
                                    </div>



                                </div>
                            </div>
                        </div>


                         <div id="MyPopup" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">
                                            &times;</button>
                                        <h4 class="modal-title">
                                        </h4>
                                    </div>
                                    <div class="modal-body">
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                                            Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                       

                        <!-- col -->

                    </div>
                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->

            <div class="row bb pb-4 mb-4">
                <div class="col-md-2 text-right">
                    <strong>Datos de Identificación</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="licencia">Licencia (*)</label>
                                <asp:TextBox ID="TxtLicencia" runat="server" class="form-control" placeholder="Ej. 999999999" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtLicencia" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpLicencia" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtLicencia" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <!-- col -->

                       <div class="col-md-3">
                            <div class="form-group">
                                <label for="estado-civil">Estado Civil (*)</label>
                                <asp:DropDownList ID="DdlEstadoCivil" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlEstadoCivil" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                                             
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="email">Email</label>
                                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" placeholder="Ej. participante@outlook.com"></asp:TextBox>
                               <!-- <asp:RequiredFieldValidator ID="RequiredFieldValidator122" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtEmail" Display="Dynamic"></asp:RequiredFieldValidator> -->
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator77" runat="server" ErrorMessage="* El correo no se válido " ControlToValidate="TxtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator> 
                            </div>

                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="juez">Lugar De Nacimiento</label>
                                <asp:TextBox ID="TxtNacimiento" runat="server" class="form-control" placeholder="Ej. Hospital Veterano"></asp:TextBox>
                            </div>
                        </div>

                        </div>
                        <!-- col -->
                        
                        <div class="row">

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="tel-celular">Celular </label>
                                <asp:TextBox ID="TxtCelular" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                         
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtCelular" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <!-- col -->


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="tel-hogar">Teléfono Hogar </label>
                                <asp:TextBox ID="TxtTelHogar" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelHogar" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelHogar" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="tel-trabajo">Teléfono Trabajo </label>
                                <asp:TextBox ID="TxtTelefonoFamiliarMasCercano" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <%--                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoFamiliarMasCercano" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoFamiliarMasCercano" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoFamiliarMasCercano" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <asp:CustomValidator ID="valValidateTextBox" runat="server" Display="Dynamic" ErrorMessage="*introduzca al menos 1 campo de búsqueda<br/>" ClientValidationFunction="CheckTextBoxes" ForeColor="Red"/> 
                    <asp:Label ID="label4" runat="server" Display="Dynamic" CssClass="ui-field-error" ForeColor="Red"></asp:Label>

                    
                     <script type="text/javascript">

                         function CheckTextBoxes(sender, args) {
                             var TxtTelefono1 = document.getElementById("<%=TxtCelular.ClientID %>").value;
                                var TxtTelefono2 = document.getElementById("<%=TxtTelHogar.ClientID %>").value;
                                var TxtTelefonoFamiliarMasCercano = document.getElementById("<%=TxtTelefonoFamiliarMasCercano.ClientID %>").value;


                                if (TxtTelefono1 == "" &&
                                    TxtTelefono2 == "" &&
                                    TxtTelefonoFamiliarMasCercano == ""
  
                                ) {
                                   
                                      document.getElementById("<%=label4.ClientID%>").innerHTML =" &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; *Introduzca al menos una de las opciones de Telefono &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; |";                                                                                                    
                                      return false;  
                                }
                                else {
                                    document.getElementById("<%=label4.ClientID%>").innerHTML = "";                              
                                        return true;
                                }
                         }
                       

                        </script>


                    
                    <!-- col -->
                    <%--<div class="row pb-4 mb-4 bb">
                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Telefono Notificar Citas (*)</label>
                                <asp:TextBox ID="TxtTelefonoNotificacion" runat="server" CssClass="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTelefonoNotificacion" Display="Dynamic"></asp:RequiredFieldValidator> 
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoNotificacion" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        <!-- col -->

                    </div>--%>
                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->

            <div class="row pb-4 mb-4 bb">
                <div class="col-md-2 text-right">
                    <strong>Dirección Fisica</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="primer-nombre">Dirección Linea 1 (*)</label>

                                <asp:TextBox ID="TxtDireccionLinea1" runat="server" CssClass="form-control" placeholder="Ej. Urb. Los Paseos  "></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtDireccionLinea1" Display="Dynamic"></asp:RequiredFieldValidator>


                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-nombre">Dirección Linea 2</label>
                                <asp:TextBox ID="TxtDireccionLinea2" runat="server" CssClass="form-control" placeholder="Ej. Calle / Avenida  "></asp:TextBox>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="municipio">Pueblo (*)</label>
                                <asp:DropDownList ID="DdlPueblo" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlPueblo" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <!-- col -->


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Código Postal (*)</label>
                                <asp:TextBox ID="TxtCodigoPostal" runat="server" CssClass="form-control" placeholder="Ej. 00725"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtCodigoPostal" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <!-- col -->



                    </div>
                    <div class="row"><div class="col-md-3"><br /></div></div>
                </div>
                <!-- col-9 -->
                

                <div class="col-md-2 text-right">
                    <strong>Dirección Postal</strong>
                </div>
                 <div class="col-md-10">
                     <div class="row">
                         <div class="col">
                             <div class="form-group">
                               <%-- <p>&nbsp;</p>--%>
                              
                                   <h5>
                               <label class="form-check-label">
                                    <asp:CheckBox ID="ChkPostal" runat="server" class="form-check-input" OnClick="postalDireccion();"/>
                                  Direccón Postal igual que dirección fisica. 
                                </label>
                                       </h5>                               
                            </div>
                         </div>
                     </div>
                    <div class="row">
                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="primer-nombre">Dirección Linea 1 (*)</label>

                                <asp:TextBox ID="TxtPostalLinea1" runat="server" CssClass="form-control" placeholder="Ej. Urb. Los Paseos  "></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPostalLinea1" Display="Dynamic"></asp:RequiredFieldValidator>


                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-nombre">Dirección Linea 2</label>
                                <asp:TextBox ID="TxtPostalLinea2" runat="server" CssClass="form-control" placeholder="Ej. Calle / Avenida  "></asp:TextBox>
                            </div>

                        </div>
                        <!-- col -->

                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="municipio-postal">Pueblo (*)</label>
                                <asp:DropDownList ID="DdlPuebloPostal" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlPuebloPostal" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <!-- col -->


                        <div class="col-md-3">

                            <div class="form-group">
                                <label for="segundo-apellido">Código Postal (*)</label>
                                <asp:TextBox ID="TxtCodigoPostalPostal" runat="server" CssClass="form-control" placeholder="Ej. 00725"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtCodigoPostalPostal" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <!-- col -->



                    </div>
                </div>
                        </div>


             <div class="row pb-4 mb-4 bb">
                <div class="col-md-2 text-right">
                    <strong>Otros datos</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="plan-medico">Plan Médico (*)</label>
                                <asp:DropDownList ID="DdlPlanMedico" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlPlanMedico" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="tratamiento">¿Condición de salud? (*)</label>
                                <asp:DropDownList ID="DdlTratamiento" runat="server" class="form-control">
                                    <asp:ListItem Value="0">No condición de salud</asp:ListItem>
                                    <asp:ListItem Value="1">Mental</asp:ListItem>
                                    <asp:ListItem Value="2">Fisica</asp:ListItem>
                                </asp:DropDownList>
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlTratamiento" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <!-- col -->

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="impedimento">¿Tiene algún impedimento? (*)</label>
                                <asp:DropDownList ID="DdlImpedimento" runat="server" class="form-control">
                                    <asp:ListItem Value="0">No impedimento</asp:ListItem>
                                    <asp:ListItem Value="1">Mental</asp:ListItem>
                                    <asp:ListItem Value="2">Fisica</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlImpedimento" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                         <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="grado">Último grado completado (*)</label>
                                <asp:DropDownList ID="DdlGrado" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlGrado" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                            <!-- col -->
                        <div class="col-md-3">
                            <div class="form-check">
                                <p>&nbsp;</p>
                                <h5>
                                <label class="form-check-label">
                                    <asp:CheckBox ID="ChkNoTrabajo" runat="server" class="form-check-input" OnClick="noTrabajo();"/>
                                   Participante No Trabaja
                                </label>
                                </h5>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="lugar-trabajo">Lugar de trabajo</label>
                                <asp:TextBox ID="TxtTrabajo" runat="server" CssClass="form-control" placeholder="Ej. Assmca"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtTrabajo" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="locupacion">Ocupación</label>
                                <asp:TextBox ID="TxtOcupacion" runat="server" CssClass="form-control" placeholder="Ej. Maestro"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtOcupacion" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>                 

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="desempleado">Motivo de no empleabilidad</label>
                                <asp:DropDownList ID="DdlDesempleado" runat="server" class="form-control" Enabled="false"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="DdlDesempleado" Display="Dynamic" InitialValue="1" Enabled="false"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        </div>
                    </div>
                 </div>


            <div class="row pb-4 mb-4 bb">
                <div class="col-md-2 text-right">
                    <strong>Estructura Familiar</strong>
                </div>

                <div class="col-md-10">
                    <div class="row">

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="composicion-familiar">Composición familiar</label>
                                <asp:TextBox ID="TxtFamiliar" runat="server" CssClass="form-control" placeholder="Cantidad de Miembros"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtFamiliar" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="nombre-pareja">Nombre de esposo(a) o pareja</label>
                                <asp:TextBox ID="TxtPareja" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPareja" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="nombre-padre">Nombre de padre</label>
                                <asp:TextBox ID="TxtPadre" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtPadre" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <!-- col -->
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="nombre-madre">Nombre de madre</label>
                                <asp:TextBox ID="TxtMadre" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ControlToValidate="TxtMadre" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="contacto">Nombre de contacto de emergencia</label>
                                <asp:TextBox ID="TxtContacto" runat="server" class="form-control" placeholder="Ej. Alejandro Ortiz"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="tel-contacto">Teléfono de contacto</label>
                                <asp:TextBox ID="TxtTelefonoContacto" runat="server" class="form-control" placeholder="Ej. 7875559999"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="*Sólo números" ValidationExpression="^[0-9]+$" ControlToValidate="TxtTelefonoContacto" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>

                    </div>

                    </div>
                </div>
           
            <!-- row -->


            <div class="row">
                <div class="col-md-2">
                    
                </div>

                <div class="col-md-10">

                    <asp:Button ID="BtnCrear" runat="server" Text="Crear" CssClass="btn btn-primary btn-lg pr-4 pl-4 mr-4" OnClick="BtnCrear_Click"/>

                    <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary btn-lg pr-4 pl-4 mr-4" OnClick="BtnActualizar_Click" Visible="false"/>
                    
                    <asp:Button ID="BtnReabrir" runat="server" Text="Reabrir Caso" CssClass="btn btn-primary btn-lg pr-4 pl-4 mr-4" OnClick="BtnReabrir_Click" Visible="false"/>

                    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar Caso" CssClass="btn btn-primary btn-lg pr-4 pl-4 mr-4" OnClientClick="eliminar(); return false" Visible="false"/>

                    <asp:Button ID="BtnCancelar" runat="server" Text="Volver al Expediente" CssClass="btn btn-secondary btn-lg" OnClick="BtnCancelar_Click" CausesValidation="false"/>

                </div>
                <!-- col-9 -->

            </div>
            <!-- row -->


        </div>
        <!-- card-block -->
    </div>

      <script type="text/javascript">
          if (window.history.replaceState) {
              window.history.replaceState(null, null, window.location.href);
          }

          function sweetAlertRef(titulo, texto, icono, ref) {

              swal({
                  title: titulo,
                  text: texto,
                  icon: icono
              }).then((value) => { window.location.href = ref; });
          }

          function sweetAlert(titulo, texto, icono) {
              swal({
              title: titulo,
                  text: texto,
                  icon: icono
            })
          }

          function postalDireccion() {
              
              var Check = document.getElementById("<%=ChkPostal.ClientID %>");
              
              var TxtDireccionLinea1 = document.getElementById("<%=TxtDireccionLinea1.ClientID %>").value;
              var TxtDireccionLinea2 = document.getElementById("<%=TxtDireccionLinea2.ClientID %>").value;
              var DdlPueblo = document.getElementById("<%=DdlPueblo.ClientID %>").value;
              var TxtCodigoPostal = document.getElementById("<%=TxtCodigoPostal.ClientID %>").value;

              var TxtPostalLinea1 = document.getElementById("<%=TxtPostalLinea1.ClientID %>").value;
              var TxtPostalLinea2 = document.getElementById("<%=TxtPostalLinea2.ClientID %>").value;
              var DdlPuebloPostal = document.getElementById("<%=DdlPuebloPostal.ClientID %>").value;
              var TxtCodigoPostalPostal = document.getElementById("<%=TxtCodigoPostalPostal.ClientID %>").value;

              var validator5 = document.getElementById("<%=RequiredFieldValidator5.ClientID %>");
              var validator6 = document.getElementById("<%=RequiredFieldValidator6.ClientID %>");
              var validator7 = document.getElementById("<%=RequiredFieldValidator7.ClientID %>");

              if (Check.checked == true && TxtDireccionLinea1 != "" && DdlPueblo != "0" && TxtCodigoPostal != "") {

                  document.getElementById("<%=TxtPostalLinea1.ClientID %>").value = TxtDireccionLinea1;
                  document.getElementById("<%=TxtPostalLinea2.ClientID %>").value = TxtDireccionLinea2;
                  document.getElementById("<%=DdlPuebloPostal.ClientID %>").value = DdlPueblo;
                  document.getElementById("<%=TxtCodigoPostalPostal.ClientID %>").value = TxtCodigoPostal;

              }
              else if (Check.checked == true) {

                  document.getElementById("<%=TxtPostalLinea1.ClientID %>").value = "";
                  document.getElementById("<%=TxtPostalLinea2.ClientID %>").value = "";
                  document.getElementById("<%=DdlPuebloPostal.ClientID %>").value = "0";
                  document.getElementById("<%=TxtCodigoPostalPostal.ClientID %>").value = "";

                  ValidatorValidate(validator5);
                  ValidatorValidate(validator6);
                  ValidatorValidate(validator7);

                  Check.checked = false;
              }

              else {
                  document.getElementById("<%=TxtPostalLinea1.ClientID %>").value = "";
                  document.getElementById("<%=TxtPostalLinea2.ClientID %>").value = "";
                  document.getElementById("<%=DdlPuebloPostal.ClientID %>").value = "0";
                  document.getElementById("<%=TxtCodigoPostalPostal.ClientID %>").value = "";
              }
             
          }

          function noTrabajo() {
              var Check = document.getElementById("<%=ChkNoTrabajo.ClientID %>");
              
              var TxtTrabajo = document.getElementById("<%=TxtTrabajo.ClientID %>").value;
              var TxtOcupacion = document.getElementById("<%=TxtOcupacion.ClientID %>").value;
              var DdlDesempleado = document.getElementById("<%=DdlDesempleado.ClientID %>").value;

              var validator17 = document.getElementById("<%=RequiredFieldValidator17.ClientID %>");

              if (Check.checked == true) {
                  document.getElementById("<%=TxtTrabajo.ClientID %>").value = "No Aplica";
                  document.getElementById("<%=TxtOcupacion.ClientID %>").value = "No Aplica";
                  document.getElementById("<%=DdlDesempleado.ClientID %>").disabled = false;
                  document.getElementById("<%=DdlDesempleado.ClientID %>").className = "form-control";

                  document.getElementById("<%=TxtTrabajo.ClientID %>").readOnly = true;
                  document.getElementById("<%=TxtOcupacion.ClientID %>").readOnly = true;

                  ValidatorEnable(validator17);
              }
              else {
                  document.getElementById("<%=TxtTrabajo.ClientID %>").value = "";
                  document.getElementById("<%=TxtOcupacion.ClientID %>").value = "";
                  document.getElementById("<%=DdlDesempleado.ClientID %>").value = "1";
                  document.getElementById("<%=DdlDesempleado.ClientID %>").className = "";
                  document.getElementById("<%=DdlDesempleado.ClientID %>").disabled = true;

                  document.getElementById("<%=TxtTrabajo.ClientID %>").readOnly = false;
                  document.getElementById("<%=TxtOcupacion.ClientID %>").readOnly = false;

                  ValidatorEnable(validator17,false);
              }

          }

          function combinarCaso() {
              var Check = document.getElementById("<%=ChkCaso.ClientID %>");

             

              if (Check.checked == true) {
                  document.getElementById("<%=CasoDos.ClientID %>").style.visibility = 'visible';
                  document.getElementById("<%=CasoTres.ClientID %>").style.visibility = 'visible';
              }
              else {
                  document.getElementById("<%=CasoDos.ClientID %>").style.visibility = 'hidden';
                  document.getElementById("<%=CasoTres.ClientID %>").style.visibility = 'hidden';
                  document.getElementById("<%=TxtNroCasoCriminal2.ClientID %>").value = "";
                  document.getElementById("<%=TxtNroCasoCriminal3.ClientID %>").value = "";

              }
          }

          function chkCategoria() {
              var Check = document.getElementById("<%=ChkCategoria.ClientID %>");
              var reqDdlCategoria = document.getElementById("<%=ReqDdlCategoria.ClientID %>");
              var reqTxtCategoria = document.getElementById("<%=ReqTxtCategoria.ClientID %>");


              if (Check.checked == true) {
                  document.getElementById("<%=DdlCategoriaTribunal.ClientID %>").value = "0";
                  divDdlCategoria.style.visibility = 'hidden';
                  divTxtCategoria.style.visibility = 'visible';
                  ValidatorEnable(reqDdlCategoria, false);
                  ValidatorEnable(reqTxtCategoria);
                  document.getElementById("<%=DdlCategoriaTribunal.ClientID %>").disabled = true;
              }
              else {
                  document.getElementById("<%=TxtCategoriaTribunal.ClientID %>").value = ""
                  document.getElementById("<%=DdlCategoriaTribunal.ClientID %>").disabled = false;
                  ValidatorEnable(reqTxtCategoria, false);
                  ValidatorEnable(reqDdlCategoria);
                  divDdlCategoria.style.visibility = 'visible';
                  divTxtCategoria.style.visibility = 'hidden';

              }
          }

          function chkRegion() {
              var Check = document.getElementById("<%=ChkRegion.ClientID %>");
              var reqDdlRegion = document.getElementById("<%=ReqDdlRegion.ClientID %>");
              var reqTxtRegion = document.getElementById("<%=ReqTxtRegion.ClientID %>");


              if (Check.checked == true) {
                  document.getElementById("<%=DdlRegionTribunal.ClientID %>").value = "0";
                  divDdlRegion.style.visibility = 'hidden'; 
                  divTxtRegion.style.visibility = 'visible'; 
                  ValidatorEnable(reqDdlRegion, false);
                  ValidatorEnable(reqTxtRegion);
                  document.getElementById("<%=DdlRegionTribunal.ClientID %>").disabled = true;
              }
              else {
                  document.getElementById("<%=DdlRegionTribunal.ClientID %>").value = ""
                  document.getElementById("<%=DdlRegionTribunal.ClientID %>").disabled = false;
                  ValidatorEnable(reqTxtRegion, false);
                  ValidatorEnable(reqDdlRegion);
                  divDdlRegion.style.visibility = 'visible';
                  divTxtRegion.style.visibility = 'hidden'; 

              }
          }

        function intervenido(){
            
            var ddlIntervenido = document.getElementById("<%=DdlIntervenido.ClientID %>");
            var reqValSentencias = document.getElementById("<%=ReqValSentencias.ClientID %>");
            
            if (ddlIntervenido.value == "2") {
                document.getElementById("<%=divSentencias.ClientID %>").style.visibility = 'visible';
                ValidatorEnable(reqValSentencias);
                document.getElementById("<%=TxtSetencias.ClientID %>").value = "";
            }
            else {
                document.getElementById("<%=TxtSetencias.ClientID %>").value = "0";
                ValidatorEnable(reqValSentencias, false);
                document.getElementById("<%=divSentencias.ClientID %>").style.visibility = 'hidden';
            }
          }

          function evaluado() {

              var ddlEvaluado = document.getElementById("<%=DdlEvaluado.ClientID %>");
              var reqValOficina = document.getElementById("<%=ReqValOficina.ClientID %>");
              var reqValAno = document.getElementById("<%=ReqValAno.ClientID %>");

              if (ddlEvaluado.value == "1") {
                  document.getElementById("<%=divEvaluado.ClientID %>").style.visibility = 'visible';
                  document.getElementById("<%=TxtOficina.ClientID %>").value = "";
                  document.getElementById("<%=TxtAno.ClientID %>").value = "";
                  ValidatorEnable(reqValOficina);
                  ValidatorEnable(reqValAno);
              }
              else {
                  document.getElementById("<%=TxtOficina.ClientID %>").value = "No Aplica";
                  document.getElementById("<%=TxtAno.ClientID %>").value = "0000";
                  ValidatorEnable(reqValOficina, false);
                  ValidatorEnable(reqValAno, false);
                  document.getElementById("<%=divEvaluado.ClientID %>").style.visibility = 'hidden';
            }
          }

          function eliminar() {
            
              swal({
                  title: "Eliminar Caso Criminal",
                  text: "¿Esta seguro de querer eliminar este caso criminal?",
                  icon: "warning",
                  buttons: true,
                  dangerMode: true
              }).then((value) => {
                  if (value) {
                      __doPostBack("EliminarCasoCriminal", "");

                  }
                  else {
                      
                  }
              })
              
          }
    </script>
   
</asp:Content>

