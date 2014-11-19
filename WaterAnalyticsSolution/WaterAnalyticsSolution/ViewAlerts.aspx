<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAlerts.aspx.cs" Async="true" Inherits="WaterAnalyticsSolution.ViewAlerts"  MasterPageFile="~/Site1.Master" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<%@ Register Src="~/ChartFilter.ascx" TagName="chartfilter" TagPrefix="filter" %>
<%@ Register Src="~/ThreshholdViewer.ascx" TagName="threshholdviewer" TagPrefix="threshhold" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="Styles/InputStyle.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
     <asp:UpdatePanel ID="updPanel" runat="server" >
    <ContentTemplate>
    <table style="width:980px; background-color:#F4FFFF;" >
    <tr>
    <td style="text-align:left;" colspan="3" >
    <h1>View Alerts Sent </h1>
    </td>
    </tr>
    <tr>
    <td style="width:480px;">
        <filter:chartfilter ID="filterForAlerts" runat="server" />
    </td>
    <td valign="top">
     
    <threshhold:threshholdviewer ID="threshhold" runat="server" />  
    </td>
    <tr>
    <td colspan="3">
    <asp:GridView runat="server" ID="grdAlerts" HeaderStyle-Font-Bold="true" AutoGenerateColumns="false">
     <Columns>
    <asp:BoundField DataField="UserId" HeaderText="User Id" />
    <asp:BoundField DataField="Name" HeaderText="Name" />
    <asp:BoundField DataField="LocationName" HeaderText="Location" />
    <asp:BoundField DataField="DefaultedCount" HeaderText="Defaulted Count" />
    </Columns>
    </asp:GridView>
    </td>
    </tr>
   </table>
    
    </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

