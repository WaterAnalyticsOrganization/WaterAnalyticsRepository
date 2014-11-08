<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnalyticsChart.ascx.cs" Inherits="WaterAnalyticsSolution.ChartControl" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<div>
   <asp:Chart runat="server"   ID= "chrtAnalytics"  BackColor="#D3DFF0" BackGradientStyle="TopBottom" BackSecondaryColor="White" BorderlineColor="26,59,105" BorderlineDashStyle="Solid" BorderlineWidth="1" Palette="BrightPastel">
   
			<ChartAreas>
				<asp:ChartArea Name="ChartArea1">
					<Area3DStyle />
				</asp:ChartArea>
			</ChartAreas>
   </asp:Chart>
</div>
