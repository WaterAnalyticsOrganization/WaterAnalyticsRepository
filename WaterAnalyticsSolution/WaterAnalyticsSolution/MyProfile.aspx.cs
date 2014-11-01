using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace WaterAnalyticsSolution
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            filterQuant.btnFetchClickHandler += new EventHandler(btnQuantVsTimeFetch_Click);
            filterQuantPerPeron.btnFetchClickHandler += new EventHandler(btnQuantPerPersonVsTimeFetch_Click);
            chartQntyVsTime.Width = Unit.Pixel(600);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (chartQntyVsTime.FindControl("chrtAnalytics") != null)
            {
                Chart quantvsTime = (Chart)chartQntyVsTime.FindControl("chrtAnalytics");
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