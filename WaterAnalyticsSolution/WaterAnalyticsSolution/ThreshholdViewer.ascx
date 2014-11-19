<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThreshholdViewer.ascx.cs" Inherits="WaterAnalyticsSolution.ThreshholdViewer" %>
<table class="rounded_edges" width="380px"  style="text-align:left; background:#C9EAF3;">
<tr>
<td>
<asp:Label ID="lblLimit" Text="Usage Threshold :" runat="server"  Width="140px"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtThreshhold" runat="server" Width="120px">
</asp:TextBox>
</td>
<td>
<asp:Button runat="server" id="btnUpdate" Text="Update" Width="80px" 
        onclick="btnUpdate_Click" />
</td>
</tr>
</table>
