<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyRole.aspx.cs" Inherits="WaterAnalyticsSolution.CompanyRole"  MasterPageFile="~/Site1.Master" %>
<%@ Register Src="~/ChartFilter.ascx" TagName="chartfilter" TagPrefix="filter" %>
<%@ Register Src="~/AnalyticsChart.ascx" TagName="chart" TagPrefix="chartcontrol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="Styles/InputStyle.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<table style="width:980px; background-color:#F4FFFF;">
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
<filter:chartfilter ID="filterGroundVsUsage" runat="server" />
</td>
<td align="left" class="rounded_edges" style="text-align:left; background:#C9EAF3;">
<h1 style=" vertical-align:top;">
Select An Year to View the Total Usage
</h1>
<asp:DropDownList ID="ddlYear" runat="server" Width="150px"></asp:DropDownList>
<asp:Button ID="btnFetchRegionVsTime" runat="server" Width="50px" Height="25px" Text="Go" />
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
</asp:Content>
