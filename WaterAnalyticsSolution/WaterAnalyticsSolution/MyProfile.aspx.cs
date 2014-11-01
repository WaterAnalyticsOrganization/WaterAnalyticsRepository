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
        protected void Page_Load(object sender, EventArgs e)
        {
            filterQuant.btnFetchClickHandler += new EventHandler(btnQuantVsTimeFetch_Click);
            filterQuantPerPeron.btnFetchClickHandler += new EventHandler(btnQuantPerPersonVsTimeFetch_Click);
            chartQntyVsTime.Width = Unit.Pixel(600);
            chartQuantPerPersonVsTime.Width = Unit.Pixel(600);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (chartQntyVsTime.FindControl("chrtAnalytics") != null)
            {
                Chart quantvsTime = (Chart)chartQntyVsTime.FindControl("chrtAnalytics");
                quantvsTime.Series.Add(ChartDataGenerator());
                quantvsTime.Series[0].ChartType = SeriesChartType.Line;
                quantvsTime.Titles.Add("Half Yearly Water Consumption Data");

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
            if (chartQuantPerPersonVsTime.FindControl("chrtAnalytics") != null)
            {
                Chart quantvsTime = (Chart)chartQuantPerPersonVsTime.FindControl("chrtAnalytics");
               quantvsTime.Series.Add(ChartDataGenerator());

            }
              
        }
        protected void btnQuantVsTimeFetch_Click(object sender, EventArgs e)
        { 
        
        
        
        }

        protected void btnQuantPerPersonVsTimeFetch_Click(object sender, EventArgs e)
        { 
        
        
        }
        private Series ChartDataGenerator()
        {
            Dictionary<DateTime, int> testData = new Dictionary<DateTime, int>();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 36; i = i + 6)
            {
                testData.Add(DateTime.Now.AddMonths(i), rnd.Next(1, 50));
            }
            Series tstSeries = new Series();
            tstSeries.Points.DataBind(testData, "Key", "Value", string.Empty);
            tstSeries.MarkerStyle = MarkerStyle.Circle;
            tstSeries.MarkerSize = 7;

            return tstSeries;
        
        }

    }
}