using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using WaterAnalyticsService;

namespace WaterAnalyticsSolution
{
    public partial class MyProfile : System.Web.UI.Page
    {

        private WaterQuant[] quantVsTime = null;
        private WaterQuant[] quantPerPersonVsTime = null;
        WaterAnalyticsClient client = null;

        protected void Page_Init(object sender, EventArgs e)
        {

            filterQuant.btnFetchClickHandler += new EventHandler(btnQuantVsTimeFetch_Click);
            filterQuantPerPeron.btnFetchClickHandler += new EventHandler(btnQuantPerPersonVsTimeFetch_Click);
               

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
                Response.Redirect("Home.aspx");
            else
            {
                chartQntyVsTime.Width = Unit.Pixel(600);
                chartQuantPerPersonVsTime.Width = Unit.Pixel(600);
                filterQuant.isLocationVisible = false;
                filterQuantPerPeron.isLocationVisible = false;
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetQuantVsTime();
                GetQuantPerPersonVsTime();
                BindProfileData();
            }      
        }
        protected void btnQuantVsTimeFetch_Click(object sender, EventArgs e)
        {
            GetQuantVsTime();
        }

        private void GetQuantVsTime()
        {
            try
            {
                //get UserId from Session . HardCoding for test
                Int32 userId = 1;
                Int32 Xvalue = -1;
                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MinValue;

                if (filterQuant.FindControl("txtStartDate") != null)
                    dtFrom = Convert.ToDateTime(((TextBox)filterQuant.FindControl("txtStartDate")).Text);
                if (filterQuant.FindControl("txtEndDate") != null)
                    dtTo = Convert.ToDateTime(((TextBox)filterQuant.FindControl("txtEndDate")).Text);
                if (filterQuant.FindControl("ddlXValue") != null)
                    Xvalue = Convert.ToInt32(((DropDownList)filterQuant.FindControl("ddlXValue")).SelectedValue);

                client = new WaterAnalyticsClient();
                client.GetWaterQuantByUserIdCompleted += new EventHandler<GetWaterQuantByUserIdCompletedEventArgs>(client_getWaterQuantByUserIdCompleted);
                if ((userId != null) && (Xvalue != -1) && (dtFrom != DateTime.MinValue) && (dtTo != DateTime.MinValue))
                {
                    client.GetWaterQuantByUserIdAsync(userId, Xvalue, dtFrom, dtTo);

                }

            }
            catch (Exception ex)
            {

            }
        }

        private void BindProfileData()
        {
            try
            {
                if (Session["userid"] != null)
                {
                    client.GetDetailsAsync(Convert.ToInt32(Session["userid"]));
                    client.GetDetailsCompleted += new EventHandler<GetDetailsCompletedEventArgs>(client_getDetailsCompleted);
                }
            }
            catch { }
        }

        void client_getDetailsCompleted(object sender, GetDetailsCompletedEventArgs e)
        {
            if(e.Result!=null)
            {
                IndividualAddress profileData = e.Result as IndividualAddress;
                lblName.Text = profileData.Name;
                lblEmailId.Text = profileData.Email;
                lblNoOfPeople.Text =Convert.ToString(profileData.NoOfPeople);
                lblAddress.Text = profileData.LocationName;
            }
        }

        void client_getWaterQuantByUserIdCompleted(object sender , GetWaterQuantByUserIdCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    Session["quantVsTime"] = e.Result;
                    quantVsTime = e.Result;
                    BindQuantVsTime(quantVsTime);
                    if (Page.IsPostBack && Session["quantPerPersonVsTime"]!=null)
                    {
                        quantPerPersonVsTime = Session["quantPerPersonVsTime"] as WaterQuant[];
                        BindQuantPerPersonVsTime(quantPerPersonVsTime);
                    }
                }
            }
            catch (Exception ex)
            { 
              
            
            }
        
        }

        private void BindQuantVsTime(WaterQuant[] result)
        {
            if (chartQntyVsTime.FindControl("chrtAnalytics") != null)
            {
                Chart quantvsTime = (Chart)chartQntyVsTime.FindControl("chrtAnalytics");
                quantvsTime.DataSource = result.OrderBy(x => x.Stime);
                quantvsTime.Series.Add(new Series());
                quantvsTime.Series[0].MarkerStyle = MarkerStyle.Circle;
                quantvsTime.Series[0].MarkerSize = 7;
                quantvsTime.Series[0].XValueMember = "STime";
                quantvsTime.Series[0].YValueMembers = "Quantity";

                quantvsTime.Series[0].ToolTip = "Water Usage : #VALY{C0}";
                quantvsTime.Series[0].ChartType = SeriesChartType.Line;

                quantvsTime.Titles.Clear();
                quantvsTime.Titles.Add("Water Consumption Data");

                quantvsTime.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                quantvsTime.ChartAreas[0].AxisX.Title = "Date";
                quantvsTime.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                quantvsTime.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
                quantvsTime.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                quantvsTime.ChartAreas[0].AxisY.Title = "Quantity (Lts)";
                quantvsTime.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                quantvsTime.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;
                quantvsTime.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
                quantvsTime.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            }
        }

        protected void btnQuantPerPersonVsTimeFetch_Click(object sender, EventArgs e)
        {

            GetQuantPerPersonVsTime();
        }

        private void GetQuantPerPersonVsTime()
        {
            try
            {


                Int32 userId = 1;
                Int32 Xvalue = -1;
                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MinValue;

                if (filterQuantPerPeron.FindControl("txtStartDate") != null)
                    dtFrom = Convert.ToDateTime(((TextBox)filterQuantPerPeron.FindControl("txtStartDate")).Text);
                if (filterQuantPerPeron.FindControl("txtEndDate") != null)
                    dtTo = Convert.ToDateTime(((TextBox)filterQuantPerPeron.FindControl("txtEndDate")).Text);
                if (filterQuantPerPeron.FindControl("ddlXValue") != null)
                    Xvalue = Convert.ToInt32(((DropDownList)filterQuantPerPeron.FindControl("ddlXValue")).SelectedValue);
                client = new WaterAnalyticsClient();
                client.GetWaterQuantPerPersonCompleted += new EventHandler<GetWaterQuantPerPersonCompletedEventArgs>(client_getWaterQuantPerPersonCompleted);
                if ((userId != null) && (Xvalue != -1) && (dtFrom != DateTime.MinValue) && (dtTo != DateTime.MinValue))
                {
                    client.GetWaterQuantPerPersonAsync(userId, Xvalue, dtFrom, dtTo);
                }

            }
            catch (Exception ex)
            {


            }
        }
        void client_getWaterQuantPerPersonCompleted(object sender, GetWaterQuantPerPersonCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    Session["quantPerPersonVsTime"] = e.Result;
                    quantPerPersonVsTime = e.Result;
                    BindQuantPerPersonVsTime(quantPerPersonVsTime);
                    if (Page.IsPostBack && Session["quantVsTime"]!=null)
                    {
                        quantVsTime = Session["quantVsTime"] as WaterQuant[];
                        BindQuantVsTime(quantVsTime);
                    }
                }
            }
            catch (Exception ex)
            {


            }

        }

        private void BindQuantPerPersonVsTime(WaterQuant[] result)
        {
            if (chartQuantPerPersonVsTime.FindControl("chrtAnalytics") != null)
            {
                Chart quantperpersonvsTime = (Chart)chartQuantPerPersonVsTime.FindControl("chrtAnalytics");
                quantperpersonvsTime.DataSource = result.OrderBy(x => x.Stime);
                quantperpersonvsTime.Series.Add(new Series());
                quantperpersonvsTime.Series[0].MarkerStyle = MarkerStyle.Circle;
                quantperpersonvsTime.Series[0].MarkerSize = 7;
                quantperpersonvsTime.Series[0].XValueMember = "STime";
                quantperpersonvsTime.Series[0].YValueMembers = "Quantity";

                quantperpersonvsTime.Series[0].ToolTip = "Water Usage : #VALY{C0}";
                quantperpersonvsTime.Series[0].ChartType = SeriesChartType.Line;

                quantperpersonvsTime.Titles.Clear();
                quantperpersonvsTime.Titles.Add("Water Consumption Data");

                quantperpersonvsTime.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                quantperpersonvsTime.ChartAreas[0].AxisX.Title = "Date";
                quantperpersonvsTime.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                quantperpersonvsTime.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
                quantperpersonvsTime.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                quantperpersonvsTime.ChartAreas[0].AxisY.Title = "Quantity (Lts)";
                quantperpersonvsTime.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                quantperpersonvsTime.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;
                quantperpersonvsTime.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
                quantperpersonvsTime.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            }
        }
        
    }
}