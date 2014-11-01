<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserRegisteration.ascx.cs" Inherits="WaterAnalyticsSolution.UserRegisteration" %>
<asp:PlaceHolder ID="phForm" runat="server">
<table align="left">
<tr>
<td></td>
<td align="right" >
</td>
<td align="center">
<b>User Registration Form</b>
</td>
</tr>
<tr>
<td></td>
<td align="right">
<asp:Label ID="lblSensorId" runat="server" Text="Sensor ID"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtSensorId" runat="server" CssClass="InpuUsertRegister"></asp:TextBox>
</td>
</tr>
<%--<tr>

<td align="right" >
<asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
</td>
</tr>--%>
<tr>
<td></td>
<td align="right" >
<asp:Label ID="lblpwd" runat="server" Text="Password"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
<asp:Label ID="lblcnfmpwd" runat="server" Text="Confirm Password"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtcnmpwd" runat="server" TextMode="Password"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right">
<asp:Label ID="lblfname" runat="server" Text="FirstName"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right">
<asp:Label ID="lbllname" runat="server" Text="LastName"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right">
<asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
</td>
</tr>
<%--<tr>
<td></td>
<td align="right" >
<asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
<asp:Label ID="lblLocation" runat="server" Text="Location" ></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="txtlocation" runat="server"></asp:TextBox>
</td>
</tr>--%>
<tr>

<td align="left"><asp:Button ID="btnsubmit" runat="server" Text="Submit"/>
</td>
</tr>
<tr>
<td></td>
<td></td>
<td>
<span style= "color:Red; font-weight :bold"> <asp:Label ID="lblErrorMsg" runat="server"></asp:Label></span>
</td>
</tr>
</table>
</asp:PlaceHolder>