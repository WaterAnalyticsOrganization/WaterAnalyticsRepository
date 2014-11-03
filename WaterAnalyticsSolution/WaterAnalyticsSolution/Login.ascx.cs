using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WaterAnalyticsSolution
{
    public partial class Login1 : System.Web.UI.UserControl
    {
        public event EventHandler btnSignInClick;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            btnSignInClick(sender, e);
        
        }
    }
}