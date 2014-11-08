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
         
           

        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
            this.chrtAnalytics.Width = Width;
        }
        protected override void OnDataBinding(EventArgs e)
        {
            EventHandler handler = ChartBindingHandler;
            base.OnDataBinding(e);
            


        }
    }
}