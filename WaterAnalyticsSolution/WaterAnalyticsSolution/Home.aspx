<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WaterAnalyticsSolution.Login"  MasterPageFile="~/Site1.Master"%>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<%@ Register Src="~/UserRegisteration.ascx" TagPrefix="signup" TagName="signup" %>
<%@ Register Src="~/Login.ascx" TagPrefix="login" TagName="control" %>
 <asp:Content ContentPlaceHolderID="head" runat="server">
 <link rel="Stylesheet" href="Styles/InputStyle.css" type="text/css" media="screen" />
 </asp:Content>
 <asp:content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
   <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
   <table style="width:980px; background-color:#F4FFFF;">
   <tr>
   <td>
    <asp:Panel ID="Panel1" runat="server">
     <div style="float:left; width:45%; min-height:600px;">
     <ajax:Accordion ID="Accordion1" runat="server" HeaderCssClass="accordionHeader" 
            HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContent"  
            SelectedIndex="0" FadeTransitions="true"
            SuppressHeaderPostbacks="true" TransitionDuration="250"  
            FramesPerSecond="40"
            RequireOpenedPane="false" AutoSize="None" >
            <Panes>
     <ajax:AccordionPane ID="AccPaneLogin" runat="server">
     
     <Header>
     Login to View Your Water Consumption Details 
     </Header>
     <Content>
     <login:control runat="server" ID="login" />
     </Content>
     </ajax:AccordionPane>
     </Panes>
    </ajax:Accordion> 
    <ajax:Accordion ID="Accordion2" runat="server" HeaderCssClass="accordionHeader" 
            HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContent"  
            FadeTransitions="true" SelectedIndex="1"
            SuppressHeaderPostbacks="true" TransitionDuration="250"  
            FramesPerSecond="40"
            RequireOpenedPane="false" AutoSize="None" >
            <Panes>
      <ajax:AccordionPane ID="AccPanelSignUp" runat="server">
     <Header>
      New User ? Please sign up here !
     </Header>
     <Content>
     
      <signup:signup runat="server"  ID="signup"/>
    
     </Content>
     </ajax:AccordionPane>
     </Panes>
     </ajax:Accordion>  
    </div>
     </asp:Panel>
   </td>
   <td>
   
   </td>
   </tr>
   
     </table>
       </asp:content>
     
