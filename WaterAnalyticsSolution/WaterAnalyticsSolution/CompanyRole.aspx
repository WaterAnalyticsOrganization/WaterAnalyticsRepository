<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="CompanyRole.aspx.cs" Inherits="WaterAnalyticsSolution.CompanyRole"  MasterPageFile="~/Site1.Master" %>
<%@ Register Src="~/ChartFilter.ascx" TagName="chartfilter" TagPrefix="filter" %>
<%@ Register Src="~/AnalyticsChart.ascx" TagName="chart" TagPrefix="chartcontrol" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="Styles/InputStyle.css" type="text/css" media="screen" />

</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
<asp:UpdatePanel ID="updPanel" runat="server">
    <ContentTemplate>
    <table style="width:980px; background-color:#F4FFFF;">
    <tr>
     <td  style="text-align:left; width:980px;">
     <asp:LinkButton runat="server" Text="View Alerts" ID="lnkViewAlerts" onclick="lnkViewAlerts_Click"></asp:LinkButton>
     </td>
    </tr>
<tr>
<td>
<filter:chartfilter ID="filterQuantByTime" runat="server" />
</td>
<td>
<filter:chartfilter ID="filterQuantTimeLocation" runat="server" />
</td>
</tr>
<tr>
<td>
<chartcontrol:chart runat="server" ID="chartQuantVsTime" />
</td>
<td>
<chartcontrol:chart runat="server" ID="chartQuantVsTimeLocs" />
</td>
</tr>
<tr>
<td>
<table  class="rounded_edges" width="480px"  style="text-align:left; background:#C9EAF3;">
<tr>
<td align="right">
<asp:Label ID="lblStartYear" runat="server" text="From :"></asp:Label>
</td>   
<td align="left">
<asp:DropDownList ID="ddlStartYear" runat="server" Width="170px" Height="25px"></asp:DropDownList>
</td>
<td>
<asp:Label ID="lblEndYear" runat="server" text="To :"></asp:Label>
</td>
<td>
<asp:DropDownList ID="ddlEndYear" runat="server" Width="170px" Height="25px"></asp:DropDownList>
</td>
</tr>
<tr>
<td align="right">
<asp:Label ID="lblLocation" Text="Location :" runat="server"></asp:Label>
</td>
<td colspan="2" align="left">
<asp:DropDownList ID="ddlLocation" runat="server" Width="170px"></asp:DropDownList>
</td>
</tr>
<tr>
<td colspan="2">
<asp:Button runat="server" ID="btnGrndVsUsageFetch" Text="Go" OnClick="btnGround_Click"/>
</td>
</tr>
</table>
</td>
<td align="left">
<table class="rounded_edges" width="480px"  style="text-align:left; background:#C9EAF3;">
<tr>
<td align="right">
<asp:Label runat="server" id="lblStartDate" Text="Start Date :" Width="100px" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtStartDate" runat="server" Width="100px"></asp:TextBox>
</td>
<td>
<asp:ImageButton id="imgStartDatePopUp"  ImageUrl="~/Images/calendar.png" ImageAlign="Middle" runat="server" />   
<ajax:CalendarExtender ID="calStartDate" PopupButtonID="imgStartDatePopUp" runat="server" TargetControlID="txtStartDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
</td>
<td align="right">
<asp:Label runat="server" id="lblEndDate" Text="End Date :" Width="75px" align="right"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtEndDate" runat="server" Width="100px" ></asp:TextBox>
</td>
<td>
<asp:ImageButton id="imgEndDatePopUp" ImageUrl="~/Images/calendar.png" ImageAlign="Middle" runat="server" />
<ajax:CalendarExtender ID="calEndDate" PopupButtonID="imgEndDatePopUp" runat="server" TargetControlID="txtEndDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
</td>
</tr>
<tr>
<td colspan="2" >
<asp:Button runat="server" ID="btnFetchRegion" Text="Go" OnClick="btnFetchRegion_Click"/>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
<chartcontrol:chart runat="server" ID="chartGroundVsUsage" />
</td>
<td>
<chartcontrol:chart runat="server" ID="regionChart" />
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
