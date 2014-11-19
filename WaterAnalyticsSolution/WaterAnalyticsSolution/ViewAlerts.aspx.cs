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

        #region Private Properties

        Decimal limitThreshold = 0;
        WaterAnalyticsClient client = null;

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            filterForAlerts.btnFetchClickHandler += new EventHandler(filterForAlerts_btnFetchClickHandler);
            threshhold.btnEditClickHandler += new EventHandler(threshhold_btnEditClickHandler);
        }

        void threshhold_btnEditClickHandler(object sender, EventArgs e)
        {           
            string limit = ((threshhold.FindControl("txtThreshhold") as TextBox)).Text;
            client = new WaterAnalyticsClient();
            int result = client.UpdateWaterLimit(Convert.ToDecimal(limit));                                  
        }

        void filterForAlerts_btnFetchClickHandler(object sender, EventArgs e)
        {
            BindDefaulters();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            filterForAlerts.isXAxisVisible = false;
            filterForAlerts.isLocationVisible = true;

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ((CheckBoxList)filterForAlerts.FindControl("chkList")).SelectedIndex = -1;
                GetWaterLimit();
                BindDefaulters();
            }
        }

        private void BindDefaulters()
        {
            client = new WaterAnalyticsClient();
            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MinValue;
            string location = string.Empty;
            if (filterForAlerts.FindControl("txtStartDate") != null)
                dtFrom = Convert.ToDateTime(((TextBox)filterForAlerts.FindControl("txtStartDate")).Text);
            if (filterForAlerts.FindControl("txtEndDate") != null)
                dtTo = Convert.ToDateTime(((TextBox)filterForAlerts.FindControl("txtEndDate")).Text);
            location = string.Empty;
            foreach (ListItem item in ((CheckBoxList)filterForAlerts.FindControl("chkList")).Items)
            {
                if (item.Selected == true)
                {
                    location = item.Text;
                    break;                    
                }
            }
            client.GetDefaultedUsersAsync(location,dtFrom,dtTo);
            client.GetDefaultedUsersCompleted += new EventHandler<GetDefaultedUsersCompletedEventArgs>(client_GetDefaultedUsersCompleted);
        }

        void client_GetDefaultedUsersCompleted(object sender, GetDefaultedUsersCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                grdAlerts.DataSource = e.Result;
                grdAlerts.DataBind();
            }
        }

        private void GetWaterLimit()
        {
            client = new WaterAnalyticsClient();
            client.GetWaterLimitAsync();
            client.GetWaterLimitCompleted += new EventHandler<GetWaterLimitCompletedEventArgs>(client_GetWaterLimitCompleted);
        }

        void client_GetWaterLimitCompleted(object sender, GetWaterLimitCompletedEventArgs e)
        {
            if(e.Result!=null)
            {
                (threshhold.FindControl("txtThreshhold") as TextBox).Text = Convert.ToString(e.Result);
            }
        }
    }
}