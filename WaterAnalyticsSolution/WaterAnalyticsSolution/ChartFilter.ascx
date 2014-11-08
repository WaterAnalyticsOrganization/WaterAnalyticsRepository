<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChartFilter.ascx.cs" Inherits="WaterAnalyticsSolution.ChartFilter" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>

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
<td align="right" >
<asp:Label runat="server" id="lblXAxis" Text="X Axis :" ></asp:Label>
</td>
<td colspan="3">
<asp:DropDownList ID="ddlXValue" runat="server" Width="170px" Height="25px"></asp:DropDownList>
</td>
<td  align="left">
<asp:Button runat="server" ID="btnFetch" Text="Go" OnClick="btnFetch_Click"/>
</td>
</tr>
<tr id="LocationRow">
<td colspan="6" rowspan="2">
<asp:CheckBoxList runat="server" ID="chkList" RepeatDirection="Horizontal" RepeatLayout="Table" RepeatColumns="4"></asp:CheckBoxList>
</td>
</tr>
<tr>
</tr>
</table>