<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="MyProfile.aspx.cs" Inherits="WaterAnalyticsSolution.MyProfile" MasterPageFile="~/Site1.Master" %>
<%@ Register Src="~/ChartFilter.ascx" TagName="chartfilter" TagPrefix="filter" %>
<%@ Register Src="~/AnalyticsChart.ascx" TagName="chart" TagPrefix="chartcontrol" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="Styles/InputStyle.css" type="text/css" media="screen" />
</asp:Content>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
<ajax:toolkitscriptmanager ID="toolkit1" runat="server" EnablePartialRendering="true"></ajax:toolkitscriptmanager>
    <table style="width:980px; background-color:#F4FFFF;">
<tr>
<td valign="top" style ="width:40%;" >
<table style="width:100%;vertical-align:top; text-align:left;">
<tr>
<td colspan="2"> 
<h1>My Profile </h1>
</td>
</tr>
<tr>
<td>
<asp:Label runat="server" id="lblNameField" Text="Name :" ></asp:Label>
</td>
<td>
<asp:Label runat="server" id="lblName" ></asp:Label>
</td>
</tr>
<tr>
<td>
<asp:Label runat="server" id="lblEmailIdField" Text="EmailId :"></asp:Label>
</td>
<td>
<asp:Label runat="server" id="lblEmailId" ></asp:Label>
</td>
</tr>
<tr>
<td>
<asp:Label runat="server" id="lblNumberOfPeopleField" Text="No of People :"></asp:Label>
</td>
<td>
<asp:Label runat="server" id="lblNoOfPeople" ></asp:Label>
</td>
</tr>
<tr>
<td>
<asp:Label runat="server" id="lblAddressField" Text="Address :"></asp:Label>
</td>
<td>
<asp:Label runat="server" id="lblAddress" ></asp:Label>
</td>
</tr>
</table>

</td>
<td  style ="width:60%;">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table style="width:100%;vertical-align:top; text-align:left;">
<tr>
<td>
<h1>Water Consumption Details </h1>
</td>
</tr>
<tr>
<td>
<filter:chartfilter ID="filterQuant" runat="server" />
</td>
</tr>
<tr>
<td align="left">
<chartcontrol:chart runat="server" ID="chartQntyVsTime"/>
</td>
</tr>
<tr>
<td align="left">
<asp:UpdateProgress ID="UpdateProgress1"  runat="server" AssociatedUpdatePanelID="UpdatePanel1">
     <ProgressTemplate>
                Processing...
            </ProgressTemplate>
    </asp:UpdateProgress>
    </td>
    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
    
    
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<table style="width:100%;vertical-align:top; text-align:left;">
<tr>
<td>
<filter:chartfilter ID="filterQuantPerPeron" runat="server" />
</td>
</tr>
<tr>
<td align="left">
<chartcontrol:chart runat="server" ID="chartQuantPerPersonVsTime" />
</td>
</tr>
<tr>
<td>
 <asp:UpdateProgress ID="UpdateProgress2"  runat="server" AssociatedUpdatePanelID="UpdatePanel2">
  <ProgressTemplate>
                Processing...
            </ProgressTemplate>
    </asp:UpdateProgress>
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

</td>
</tr>
</table>
</asp:Content>
