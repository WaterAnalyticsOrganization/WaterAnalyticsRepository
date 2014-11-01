using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WaterAnalyticsSolution
{
    public partial class ChartFilter : System.Web.UI.UserControl
    {
        public Unit Width;
        public event EventHandler btnFetchClickHandler;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnFetch_Click(object sender, EventArgs e)
        {
            btnFetchClickHandler(sender, e);
        
        }
    }
}