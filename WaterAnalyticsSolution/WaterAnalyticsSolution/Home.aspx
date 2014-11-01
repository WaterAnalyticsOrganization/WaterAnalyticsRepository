<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WaterAnalyticsSolution.Login"  MasterPageFile="~/Site1.Master"%>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<%@ Register Src="~/UserRegisteration.ascx" TagPrefix="signup" TagName="signup" %>
 <asp:Content ContentPlaceHolderID="head" runat="server">
 <link rel="Stylesheet" href="Styles/InputStyle.css" type="text/css" media="screen" />
 </asp:Content>
 <asp:content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
    <asp:Panel runat="server">
     <div style="float:left; width:45%;">
     <ajax:Accordion ID="Accordion1" runat="server" HeaderCssClass="accordionHeader" 
            HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContent"  
            SelectedIndex="0" FadeTransitions="true"
            SuppressHeaderPostbacks="true" TransitionDuration="250"  
            FramesPerSecond="40"
            RequireOpenedPane="false" AutoSize="None">
            <Panes>
     <ajax:AccordionPane ID="AccPaneLogin" runat="server">
     
     <Header>
     Login to View Your Water Consumption Details 
     </Header>
     <Content>
     
     </Content>
     </ajax:AccordionPane>
      <ajax:AccordionPane ID="AccPanelSignUp" runat="server">
     <Header>
      New User ? Please sign up here !
     </Header>
     <Content>
     
      <signup:signup runat="server" />
    
     </Content>
     </ajax:AccordionPane>
     </Panes>
     </ajax:Accordion>  
    </div>
    
     </asp:Panel>
       </asp:content>
     
