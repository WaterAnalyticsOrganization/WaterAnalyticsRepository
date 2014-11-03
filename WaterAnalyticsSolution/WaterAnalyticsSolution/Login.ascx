<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="WaterAnalyticsSolution.Login1" %>
<br />
<br />

<table>
<tr>
<td align="right">
<asp:Label ID="lblSensorId" runat="server" Text="Sensor ID :"></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="txtSensorId" runat="server"  ></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">
<asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
</td>
</tr>
<tr>
</tr>
<br />
<tr>
<td colspan="2" align="center">
<asp:Button ID="btnSignIn" runat="server" text="Sign In" OnClick="btnSignIn_Click"/>
</td>
</tr>

</table>
<br />
<br />
<br />

