﻿using System;
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
        public bool isLocationVisible;

        protected void Page_Init(object sender, EventArgs e)
        {
            txtStartDate.Text = DateTime.Today.ToShortDateString();
            txtEndDate.Text = DateTime.Today.ToShortDateString();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (chkList != null && chkList.Items.Count == 0)
                {

                    chkList.Visible = isLocationVisible;
                    if (isLocationVisible)
                    {
                        WaterAnalyticsClient client = new WaterAnalyticsClient();
                        chkList.DataSource = client.GetAllLocation();
                        if (chkList.DataSource != null)
                        {
                            chkList.DataTextField = "Location_name";
                            chkList.DataValueField = "Location_Id";
                            chkList.SelectedIndex = 0;
                            chkList.DataBind();
                        
                        }


                    }

                }

                ddlXValue.DataSource = Helper.GetXValues();
                ddlXValue.DataTextField = "Text";
                ddlXValue.DataValueField = "Value";
                ddlXValue.SelectedIndex = 0;
                ddlXValue.DataBind();
            }
        }
       







        protected void btnFetch_Click(object sender, EventArgs e)
        {

            btnFetchClickHandler(sender, e);

        }
    }
}