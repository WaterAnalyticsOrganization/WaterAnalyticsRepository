using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WaterAnalyticsSolution
{
    public partial class ThreshholdViewer : System.Web.UI.UserControl
    {
        public event EventHandler btnEditClickHandler;
      

        protected void Page_Init(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            btnEditClickHandler(sender, e);
            
        }
    }
}