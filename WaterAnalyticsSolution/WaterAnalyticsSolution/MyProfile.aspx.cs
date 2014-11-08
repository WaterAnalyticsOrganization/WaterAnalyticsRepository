using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace WaterAnalyticsSolution
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

            filterQuant.btnFetchClickHandler += new EventHandler(btnQuantVsTimeFetch_Click);
            filterQuantPerPeron.btnFetchClickHandler += new EventHandler(btnQuantPerPersonVsTimeFetch_Click);
               

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
                chartQntyVsTime.Width = Unit.Pixel(600);
                chartQuantPerPersonVsTime.Width = Unit.Pixel(600);
                filterQuant.isLocationVisible = false;
                filterQuantPerPeron.isLocationVisible = false;
            
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {

          
            //if (chartQntyVsTime.FindControl("chrtAnalytics") != null)
            //{
            //    Chart quantvsTime = (Chart)chartQntyVsTime.FindControl("chrtAnalytics");
            //    quantvsTime.Series.Add(ChartDataGenerator());
            //    quantvsTime.Series[0].ChartType = SeriesChartType.Line;
            //    quantvsTime.Titles.Add("Half Yearly Water Consumption Data");

            //    quantvsTime.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            //    quantvsTime.ChartAreas[0].AxisX.Title = "Date";
            //    quantvsTime.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
            //    quantvsTime.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
            //    quantvsTime.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


            //    quantvsTime.ChartAreas[0].AxisY.Title = "Quantity (Lts)";
            //    quantvsTime.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
            //    quantvsTime.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;
            //    quantvsTime.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
            //    quantvsTime.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            //}
            //if (chartQuantPerPersonVsTime.FindControl("chrtAnalytics") != null)
            //{
            //    Chart quantvsTime = (Chart)chartQuantPerPersonVsTime.FindControl("chrtAnalytics");
            //   quantvsTime.Series.Add(ChartDataGenerator());

            //}
              
        }
        protected void btnQuantVsTimeFetch_Click(object sender, EventArgs e)
        {
            try
            {
                //get UserId from Session . HardCoding for test
                Int32 userId = 1;
                Int32 Xvalue = -1;
                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MinValue;

                if (filterQuant.FindControl("txtStartDate") != null)
                    dtFrom = Convert.ToDateTime(((TextBox)filterQuant.FindControl("txtStartDate")).Text);
                if (filterQuant.FindControl("txtEndDate") != null)
                    dtTo = Convert.ToDateTime(((TextBox)filterQuant.FindControl("txtEndDate")).Text);
                if (filterQuant.FindControl("ddlXValue") != null)
                    Xvalue = Convert.ToInt32(((DropDownList)filterQuant.FindControl("ddlXValue")).SelectedValue);

                WaterAnalyticsClient client = new WaterAnalyticsClient();
                client.getWaterQuantByUserIdCompleted += new EventHandler<getWaterQuantByUserIdCompletedEventArgs>(client_getWaterQuantByUserIdCompleted);
                if ((userId != null) && (Xvalue != -1) && (dtFrom != DateTime.MinValue) && (dtTo != DateTime.MinValue))
                {
                    client.getWaterQuantByUserIdAsync(userId, Xvalue, dtFrom, dtTo);
                    
                }

            }
            catch (Exception ex)
            {

            }
        }

        void client_getWaterQuantByUserIdCompleted(object sender , getWaterQuantByUserIdCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (chartQntyVsTime.FindControl("chrtAnalytics") != null)
                    {
                        Chart quantvsTime = (Chart)chartQntyVsTime.FindControl("chrtAnalytics");
                        quantvsTime.DataSource = e.Result.OrderBy(x => x.Stime);
                        quantvsTime.Series.Add(new Series());
                        quantvsTime.Series[0].MarkerStyle = MarkerStyle.Circle;
                        quantvsTime.Series[0].MarkerSize = 7;
                        quantvsTime.Series[0].XValueMember = "STime";
                        quantvsTime.Series[0].YValueMembers = "Quantity";

                        quantvsTime.Series[0].ToolTip = "Data Point Y Value: #VALY{C0}";
                        quantvsTime.Series[0].ChartType = SeriesChartType.Line;
                        
                        quantvsTime.Titles.Add("Water Consumption Data");

                        quantvsTime.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                        quantvsTime.ChartAreas[0].AxisX.Title = "Date";
                        quantvsTime.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                        quantvsTime.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
                        quantvsTime.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                        quantvsTime.ChartAreas[0].AxisY.Title = "Quantity (Lts)";
                        quantvsTime.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                        quantvsTime.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;
                        quantvsTime.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
                        quantvsTime.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        
                    }
                }
            }
            catch (Exception ex)
            { 
              
            
            }
        
        }

        protected void btnQuantPerPersonVsTimeFetch_Click(object sender, EventArgs e)
        { 

        try{

           
            Int32 userId = 1;
            Int32 Xvalue = -1;
            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MinValue;
            
                if ( filterQuantPerPeron.FindControl("txtStartDate") != null)
                    dtFrom = Convert.ToDateTime(((TextBox)filterQuantPerPeron.FindControl("txtStartDate")).Text);
                if (filterQuantPerPeron.FindControl("txtEndDate") != null)
                    dtTo = Convert.ToDateTime(((TextBox)filterQuantPerPeron.FindControl("txtEndDate")).Text);
                if (filterQuantPerPeron.FindControl("ddlXValue") != null)
                    Xvalue = Convert.ToInt32(((DropDownList)filterQuantPerPeron.FindControl("ddlXValue")).SelectedValue);
             WaterAnalyticsClient client = new WaterAnalyticsClient(); 
            client.getWaterQuantPerPersonCompleted += new EventHandler<getWaterQuantPerPersonCompletedEventArgs>(client_getWaterQuantPerPersonCompleted); 
            if ((userId != null) && (Xvalue != -1) && (dtFrom != DateTime.MinValue) && (dtTo != DateTime.MinValue))
                {
                    client.getWaterQuantPerPersonAsync(userId, Xvalue, dtFrom, dtTo);
                  }

             }
            catch(Exception ex)
        {
            
            
            }
        }
        void client_getWaterQuantPerPersonCompleted(object sender, getWaterQuantPerPersonCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (chartQuantPerPersonVsTime.FindControl("chrtAnalytics") != null)
                    {
                        Chart quantperpersonvsTime = (Chart)chartQuantPerPersonVsTime.FindControl("chrtAnalytics");
                        quantperpersonvsTime.DataSource = e.Result.OrderBy(x => x.Stime);
                        quantperpersonvsTime.Series.Add(new Series());
                        quantperpersonvsTime.Series[0].MarkerStyle = MarkerStyle.Circle;
                        quantperpersonvsTime.Series[0].MarkerSize = 7;
                        quantperpersonvsTime.Series[0].XValueMember = "STime";
                        quantperpersonvsTime.Series[0].YValueMembers = "Quantity";

                        quantperpersonvsTime.Series[0].ToolTip = "Data Point Y Value: #VALY{C0}";
                        quantperpersonvsTime.Series[0].ChartType = SeriesChartType.Line;

                        quantperpersonvsTime.Titles.Add("Water Consumption Data");

                        quantperpersonvsTime.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                        quantperpersonvsTime.ChartAreas[0].AxisX.Title = "Date";
                        quantperpersonvsTime.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                        quantperpersonvsTime.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
                        quantperpersonvsTime.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                        quantperpersonvsTime.ChartAreas[0].AxisY.Title = "Quantity (Lts)";
                        quantperpersonvsTime.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                        quantperpersonvsTime.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;
                        quantperpersonvsTime.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
                        quantperpersonvsTime.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    }
                }
            }
            catch (Exception ex)
            {


            }

        }
        
    }
}