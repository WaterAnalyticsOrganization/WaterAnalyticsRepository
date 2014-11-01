<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChartFilter.ascx.cs" Inherits="WaterAnalyticsSolution.ChartFilter" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>

<table class="rounded_edges" width="600px"  style="text-align:left; background:#C9EAF3;">
<tr>
<td align="right">
<asp:Label runat="server" id="lblStartDate" Text="Start Date :" Width="95px" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtStartDate" runat="server" ReadOnly="true" Width="150px" ></asp:TextBox>
</td>
<td>
<asp:ImageButton id="imgStartDatePopUp"  ImageUrl="~/Images/calendar.png" ImageAlign="Middle" runat="server" />   


<ajax:CalendarExtender ID="calStartDate" PopupButtonID="imgStartDatePopUp" runat="server" TargetControlID="txtStartDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
</td>
<td align="right">
<asp:Label runat="server" id="lblEndDate" Text="End Date :" Width="95px" align="right"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtEndDate" runat="server" ReadOnly="true" Width="150px" ></asp:TextBox>
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
<td colspan="1">
<asp:DropDownList ID="ddlXValue" runat="server" Width="170px" Height="25px"></asp:DropDownList>
</td>
<td  align="left">
<asp:Button runat="server" ID="btnFetch" Text="Go" OnClick="btnFetch_Click"/>
</td>
</tr>

</table>