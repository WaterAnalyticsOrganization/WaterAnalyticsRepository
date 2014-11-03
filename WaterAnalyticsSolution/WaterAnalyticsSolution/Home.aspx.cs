using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WaterAnalyticsSolution
{
    public partial class Login : System.Web.UI.Page
    {
        WaterAnalyticsService.WaterAnalyticsClient client = new WaterAnalyticsService.WaterAnalyticsClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            login.btnSignInClick += new EventHandler(btnSignIn_Clicked);
            
        }

        protected void Page_Init(object sender, EventArgs e)
        { 
        
        
         

        }
        protected void btnSignIn_Clicked(object sender, EventArgs e)
        {
            int isAuthenticated;
            TextBox txtSensorId = (TextBox)login.FindControl("txtSensorId");
            TextBox txtPassword = (TextBox)login.FindControl("txtPassword");
            if (txtSensorId != null && txtPassword != null)
            {
                isAuthenticated = client.isAuthenticated(Convert.ToInt32(txtSensorId.Text), txtPassword.Text);
            }

            
           
        }
    }
}