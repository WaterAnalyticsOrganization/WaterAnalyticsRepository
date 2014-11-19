<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAlerts.aspx.cs" Inherits="WaterAnalyticsSolution.ViewAlerts"  MasterPageFile="~/Site1.Master" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<%@ Register Src="~/ChartFilter.ascx" TagName="chartfilter" TagPrefix="filter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="Styles/InputStyle.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
     <asp:UpdatePanel ID="updPanel" runat="server" >
    <ContentTemplate>
    <table style="width:980px; background-color:#F4FFFF;" >
    <tr>
    <td style="text-align:left;">
    <h1>View Alerts Sent </h1>
    </td>
    </tr>
    <tr>
    <td>
        <filter:chartfilter ID="filterForAlerts" runat="server" />
    </td>
    <tr>
    <asp:GridView runat="server" ID="grdAlerts" HeaderStyle-Font-Bold="true" AutoGenerateColumns="true">
    
    </asp:GridView>
    </tr>
   </table>
    
    </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

