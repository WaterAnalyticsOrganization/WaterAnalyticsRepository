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
<asp:Panel runat="server" Wrap="false">
<asp:Label runat="server" id="lblEndDate" Text="End Date :"  align="left"></asp:Label>
</asp:Panel>
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
<td >
<asp:DropDownList ID="ddlXValue" runat="server" Width="120px" Height="25px"></asp:DropDownList>
</td>
<td> </td>
<td  align="left">
<asp:Label runat="server" id="Label2" Text="Location :" Width="75px" align="right" wrap="false"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtLocation" text ="Select " runat="server" CssClass="txtBox" Height="25px" Width="120px"></asp:TextBox>
<asp:Panel ID="pnlLoc" runat="server" CssClass="pnlDesign">
<asp:CheckBoxList ID="chkList" runat="server">
</asp:CheckBoxList>
</asp:Panel>
<ajax:PopupControlExtender ID="PopupControlExtender1" runat="server" TargetControlID="txtLocation" PopupControlID="pnlLoc" Position="Bottom"></ajax:PopupControlExtender>
<%--
<asp:Button runat="server" ID="btnFetch" Text="Go" OnClick="btnFetch_Click"/>--%>
</td>
</tr>
<tr id="LocationRow">
<td colspan="6" align="right">
<asp:Button runat="server" ID="btnFetch" Text="Go" OnClick="btnFetch_Click" />
    &nbsp;</td>
</tr>
</table>