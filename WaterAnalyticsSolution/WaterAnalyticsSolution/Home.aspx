<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WaterAnalyticsSolution.Login"  MasterPageFile="~/Site1.Master"%>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<%@ Register Src="~/UserRegisteration.ascx" TagPrefix="signup" TagName="signup" %>
<%@ Register Src="~/Login.ascx" TagPrefix="login" TagName="control" %>
 <asp:Content ContentPlaceHolderID="head" runat="server">
 <link rel="Stylesheet" href="Styles/InputStyle.css" type="text/css" media="screen" />
 </asp:Content>
 <asp:content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
   <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
   <table style="width:980px; background-color:#F4FFFF; overflow:hidden">
   <tr>
   <td>
    <asp:Panel ID="Panel1" runat="server" ScrollBars="None">
     <div style="float:left; min-height:600px; overflow:hidden">
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
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign ="Left">
          <asp:Label ID="Label1" runat ="server" Text="Login to View Your Water Consumption Details"></asp:Label>
          </asp:Panel>  
      
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
     <asp:Panel runat="server" HorizontalAlign ="Left">
          <asp:Label ID="lblSignup" runat ="server" Text=" New User ? Please sign up here !"></asp:Label>
          </asp:Panel>     
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
     
