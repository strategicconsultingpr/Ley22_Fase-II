<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="pruebas" Codebehind="pruebas.aspx.cs" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       
    <asp:TextBox ID="TxtHoraInicial" runat="server"  ></asp:TextBox>
    <ajaxToolkit:MaskedEditExtender ID="TxtHoraInicial_MaskedEditExtender" runat="server" BehaviorID="TxtHoraInicial_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" TargetControlID="TxtHoraInicial">
    </ajaxToolkit:MaskedEditExtender>
    <asp:RequiredFieldValidator ControlToValidate="TxtHoraInicial" ID="RequiredFieldValidator1" ForeColor="Red"  Display="Dynamic" runat="server" ErrorMessage="*Requerido"></asp:RequiredFieldValidator>
    <asp:regularexpressionvalidator ControlToValidate="TxtHoraInicial" runat="server" errormessage="*Formato hh:mm am/pm" ForeColor ="Red"  Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))"></asp:regularexpressionvalidator>
    
    <asp:TextBox ID="TxtHoraFinal" runat="server" ></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="TxtHoraFinal" ID="RequiredFieldValidator2" ForeColor="Red"  Display="Dynamic" runat="server" ErrorMessage="*Requerido"></asp:RequiredFieldValidator>

    <asp:regularexpressionvalidator ControlToValidate="TxtHoraFinal" runat="server" errormessage="*Formato hh:mm am/pm" ForeColor ="Red"  Display="Dynamic" ValidationExpression="\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))"></asp:regularexpressionvalidator>
<%--    <asp:CompareValidator runat="server" ErrorMessage="La hora Final debe ser mayor a la hora inicial" ControlToCompare="HoraFinal" ControlToValidate="HoraInicial"  Display="Dynamic" ForeColor="Red" Operator="GreaterThan" Type="Date"></asp:CompareValidator>--%>
      
       <script type="text/javascript">

        $('input[name="<%=TxtHoraInicial.UniqueID %>"]')
            .ptTimeSelect({
                containerClass: undefined,
                containerWidth: undefined,
                hoursLabel: 'Hora',
                minutesLabel: 'Minutos',
                setButtonLabel: 'Seleccionar',
                popupImage: undefined,
                onFocusDisplay: true,
                zIndex: 10,
                onBeforeShow: undefined,
                onClose: undefined
            });

        $('input[name="<%=TxtHoraFinal.UniqueID %>"]')
            .ptTimeSelect({
                containerClass: undefined,
                containerWidth: undefined,
                hoursLabel: 'Hora',
                minutesLabel: 'Minutos',
                setButtonLabel: 'Seleccionar',
                popupImage: undefined,
                onFocusDisplay: true,
                zIndex: 10,
                onBeforeShow: undefined,
                onClose: undefined
            });
        </script>

<asp:Button runat="server" Text="Button"></asp:Button>

</asp:Content>

