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


        WaterAnalyticsClient client = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            login.btnSignInClick += new EventHandler(btnSignIn_Clicked);
            
        }

        protected void Page_Init(object sender, EventArgs e)
        { 
        
        
         

        }
        protected void btnSignIn_Clicked(object sender, EventArgs e)
        {
            try
            {             
                int isAuthenticated = 0;
                client = new WaterAnalyticsClient();               
                TextBox txtSensorId = (TextBox)login.FindControl("txtSensorId");
                TextBox txtPassword = (TextBox)login.FindControl("txtPassword");
                if (string.IsNullOrEmpty(txtSensorId.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    ((Label)login.FindControl("lblErrorMessage")).Text = "Invalid Credentials!!!";
                    return;
                }
                Session["userid"] = null;
                if (txtSensorId != null && txtPassword != null)
                {
                    isAuthenticated = client.IsAuthenticated(Convert.ToInt32(txtSensorId.Text), txtPassword.Text);
                }
                if (isAuthenticated == 1)
                {
                    Session["userid"] = isAuthenticated;
                    Response.Redirect("MyProfile.aspx");
                }
                else if (isAuthenticated == 2)
                {
                    Session["userid"] = isAuthenticated;
                    Response.Redirect("CompanyRole.aspx");
                }
                else
                {
                    Session["userid"] = null;
                    ((Label)login.FindControl("lblErrorMessage")).Text = "Invalid Credentials!!!";
                }

            }
            catch { }
        }

       

        
    }
}