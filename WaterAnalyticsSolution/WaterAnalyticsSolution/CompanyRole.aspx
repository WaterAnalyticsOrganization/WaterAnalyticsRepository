<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyRole.aspx.cs" Inherits="WaterAnalyticsSolution.CompanyRole"  MasterPageFile="~/Site1.Master" %>
<%@ Register Src="~/ChartFilter.ascx" TagName="chartfilter" TagPrefix="filter" %>
<%@ Register Src="~/AnalyticsChart.ascx" TagName="chart" TagPrefix="chartcontrol" %>
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

</td>
<td>
</td>
</tr>
<tr>
<td>
</td>
<td>
</td>
</tr>
<tr>
<td>
</td>
<td>
</td>
</tr>
</table>
</asp:Content>
