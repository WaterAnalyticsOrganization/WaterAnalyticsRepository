using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WaterAnalyticsSolution
{
    public partial class CompanyRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            filterQuantByTime.Width = Unit.Pixel(480);
        }
    }
}