using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace WaterAnalyticsSolution
{
    public partial class CompanyRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            chartGroundVsUsage.Width = Unit.Pixel(480);
            
                 
            chartQuantVsTime.Width = Unit.Pixel(480);
            filterQuantByTime.isLocationVisible = true;
            chartQuantVsTimeLocs.Width = Unit.Pixel(480);
            filterQuantTimeLocation.isLocationVisible = true;
            regionChart.Width = Unit.Pixel(480);
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
         {
    
            if (regionChart.FindControl("chrtAnalytics") != null)
            {
                Chart chartRegionWiseUsage = (Chart)regionChart.FindControl("chrtAnalytics");
                chartRegionWiseUsage.Series.Add(ChartDataGenerator());
                chartRegionWiseUsage.Series[0].ChartType = SeriesChartType.Pie;
                
            }
            if (chartQuantVsTime.FindControl("chrtAnalytics") != null)
            { 
                Chart chartQuantVsTime1 = (Chart)chartQuantVsTime.FindControl("chrtAnalytics");
                chartQuantVsTime1.Series.Add(ChartDataGenerator());
                chartQuantVsTime1.Series[0].ChartType = SeriesChartType.Line;
            
            }
           
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