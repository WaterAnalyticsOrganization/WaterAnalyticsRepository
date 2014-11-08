using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WaterAnalyticsSolution
{
    public partial class UserRegisteration : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sample Code for making async call
            WaterAnalyticsClient abc = new WaterAnalyticsClient();
            abc.isAuthenticatedCompleted += new EventHandler<isAuthenticatedCompletedEventArgs>(IsAuthCallback);
            abc.isAuthenticatedAsync(1, "dss");           
        }
        static void IsAuthCallback(object sender, isAuthenticatedCompletedEventArgs e)
        {
            //Sample Code for making async call
            // get code here from "e.Result"
        }

    }
}