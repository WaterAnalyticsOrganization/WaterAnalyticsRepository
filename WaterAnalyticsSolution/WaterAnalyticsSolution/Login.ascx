<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="WaterAnalyticsSolution.Login1" %>
<br />
<br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table>
<tr>
<td align="right">
<asp:Label ID="lblSensorId" runat="server" Text="Sensor ID :"></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="txtSensorId" runat="server" Width="145px"  ></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">
<asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  Width="155px"></asp:TextBox>
</td>
</tr>
<tr>
</tr>
<br />
<tr>
<td colspan="2" align="right">
<asp:Button ID="btnSignIn" runat="server" text="Sign In" OnClick="btnSignIn_Click"/>
<br />
    <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
</td>
</tr>

</table>
</ContentTemplate>
</asp:UpdatePanel>
<br />
<br />
<br />

