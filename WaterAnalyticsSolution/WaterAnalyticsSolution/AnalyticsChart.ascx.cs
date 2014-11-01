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
    public partial class ChartControl : System.Web.UI.UserControl
    {
        public event EventHandler  ChartBindingHandler;
        public Unit Width;
        public Chart chartControl
        {
        
        get{
        
         return this.chrtAnalytics;
        }
            set
            {
             this.chrtAnalytics = value;
            
            }
        
        }
        Dictionary<DateTime, int> testData = new Dictionary<DateTime, int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
            this.chrtAnalytics.Width = Width;
        }
        protected override void OnDataBinding(EventArgs e)
        {
            EventHandler handler = ChartBindingHandler;
            base.OnDataBinding(e);
            if(handler!=null)
            ChartBindingHandler(this,e);
            // define test data
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 36;i= i+6)
            {
                testData.Add(DateTime.Now.AddMonths(i), rnd.Next(1, 50));
            }
            Series tstSeries = new Series();
            tstSeries.Points.DataBind(testData, "Key", "Value", string.Empty);
            tstSeries.MarkerStyle = MarkerStyle.Circle;
            tstSeries.MarkerSize = 7;


            //chrtAnalytics.Series.Add(tstSeries);
            //chrtAnalytics.Titles.Add("Half Yearly Water Consumption Data");

            //chrtAnalytics.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            //chrtAnalytics.ChartAreas[0].AxisX.Title = "Date";
            //chrtAnalytics.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
            //chrtAnalytics.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
            //chrtAnalytics.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


            //chrtAnalytics.ChartAreas[0].AxisY.Title = "Quantity (Lts)";
            //chrtAnalytics.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
            //chrtAnalytics.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;
            //chrtAnalytics.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
            //chrtAnalytics.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
           

            



        }
    }
}