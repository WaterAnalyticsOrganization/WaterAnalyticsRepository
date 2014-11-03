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
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (chkList != null && chkList.Items.Count == 0)
                {
                    chkList.Visible = isLocationVisible;
                    chkList.Items.Add("Bellandur");
                    ddlXValue.DataSource = Helper.XValues();
                    ddlXValue.DataBind();
                } 
                txtStartDate.Text = DateTime.Today.ToShortDateString();
                txtEndDate.Text = DateTime.Today.ToShortDateString();



            }
            
            
        }
       
        protected void btnFetch_Click(object sender, EventArgs e)
        {
            if(btnFetchClickHandler!=null)
            btnFetchClickHandler(sender, e);
        
        }
    }
}