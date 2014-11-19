using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WaterAnalyticsSolution
{
    public partial class ViewAlerts : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            
        
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            filterForAlerts.isXAxisVisible = false;
            filterForAlerts.isLocationVisible = true;

        }
    }
}