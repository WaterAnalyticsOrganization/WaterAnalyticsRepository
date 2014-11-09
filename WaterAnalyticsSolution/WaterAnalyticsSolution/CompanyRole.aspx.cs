using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using WaterAnalyticsService;
using System.Drawing;

namespace WaterAnalyticsSolution
{
    public partial class CompanyRole : System.Web.UI.Page
    {
        private WaterQuantLocation[] quantVsTime = null;
        private WaterQuantLocation[] quantPerPersonVsTime = null;
        private ZoneDetails[] quantRegion = null;

        protected void Page_Init(object sender, EventArgs e)
        {
            filterQuantByTime.btnFetchClickHandler+= new EventHandler(btnQuantVsTime_Click);
            filterQuantTimeLocation.btnFetchClickHandler += new EventHandler(btnQuantPerPerson_Click);

        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Initialiaze controls
            chartGroundVsUsage.Width = Unit.Pixel(480);
            chartQuantVsTime.Width = Unit.Pixel(480);
            filterQuantByTime.isLocationVisible = true;
            chartQuantVsTimeLocs.Width = Unit.Pixel(480);
            filterQuantTimeLocation.isLocationVisible = true;
            regionChart.Width = Unit.Pixel(480);
            ddlStartYear.DataSource = Helper.GetYear();
            ddlStartYear.DataBind();
            ddlStartYear.SelectedIndex = Helper.GetYear().Count-1;
            ddlEndYear.DataSource = Helper.GetYear();
            ddlEndYear.DataBind();
            ddlEndYear.SelectedIndex = Helper.GetYear().Count-1;
            txtStartDate.Text = DateTime.Today.ToShortDateString();
            txtEndDate.Text = DateTime.Today.ToShortDateString();
            #endregion

          

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
         { 
            #region DataBind
            if(!IsPostBack)
            {
            WaterAnalyticsClient client = new WaterAnalyticsClient();
            client.getWaterQuantByLocationCompleted += new EventHandler<getWaterQuantByLocationCompletedEventArgs>(client_getWaterQuantByLocationCompleted); 
            client.getWaterQuantPerPersonAreaCompleted +=new EventHandler<getWaterQuantPerPersonAreaCompletedEventArgs>(client_getWaterQuantPerPersonAreaCompleted);
            client.getGroundWaterByLocationCompleted +=new EventHandler<getGroundWaterByLocationCompletedEventArgs>(client_getGroundWaterByLocationCompleted);
            client.getDataByZoneCompleted +=new EventHandler<getDataByZoneCompletedEventArgs>(client_getDataByZoneCompleted);

            string strLocationQuant = string.Empty;
            string strLocationQuantPerPerson = string.Empty;
           // string strLocationGround string.Empty;
            DateTime dtFromQuant = DateTime.MinValue;
            DateTime dtToQuant=DateTime.MinValue;
            DateTime dtFromQuantPerPerson=DateTime.MinValue;
            DateTime dtToQuantPerPerson=DateTime.MinValue;
            DateTime dtFromRegion =Convert.ToDateTime(txtStartDate.Text);
            DateTime dtToRegion = Convert.ToDateTime(txtStartDate.Text);
            Int32 startYear = Convert.ToInt32(ddlStartYear.SelectedItem.Text);
            Int32 endYear = Convert.ToInt32(ddlEndYear.SelectedItem.Text);
            Int32 ind1 = 0;
            Int32 ind2 = 0;
             

            if(filterQuantByTime.FindControl("chkList")!=null)
            {
              strLocationQuant = ((CheckBoxList)filterQuantByTime.FindControl("chkList")).SelectedItem.Text;
            }
            if(filterQuantTimeLocation.FindControl("chkList")!=null)
            {
              strLocationQuantPerPerson = ((CheckBoxList)filterQuantTimeLocation.FindControl("chkList")).SelectedItem.Text;
            }
            
                 if (filterQuantByTime.FindControl("txtStartDate") != null)
                    dtFromQuant = Convert.ToDateTime(((TextBox)filterQuantByTime.FindControl("txtStartDate")).Text);
                if (filterQuantByTime.FindControl("txtEndDate") != null)
                    dtToQuant = Convert.ToDateTime(((TextBox)filterQuantByTime.FindControl("txtEndDate")).Text);
                if (filterQuantByTime.FindControl("ddlXValue") != null)
                    ind1 = Convert.ToInt32(((DropDownList)filterQuantByTime.FindControl("ddlXValue")).SelectedValue);


                
                 if (filterQuantTimeLocation.FindControl("txtStartDate") != null)
                    dtFromQuantPerPerson = Convert.ToDateTime(((TextBox)filterQuantTimeLocation.FindControl("txtStartDate")).Text);
                if (filterQuantTimeLocation.FindControl("txtEndDate") != null)
                    dtToQuantPerPerson = Convert.ToDateTime(((TextBox)filterQuantTimeLocation.FindControl("txtEndDate")).Text);
                if (filterQuantTimeLocation.FindControl("ddlXValue") != null)
                    ind2 = Convert.ToInt32(((DropDownList)filterQuantTimeLocation.FindControl("ddlXValue")).SelectedValue);
            
            client.getWaterQuantByLocationAsync(strLocationQuant, ind1, dtFromQuant, dtToQuant);
            
            client.getWaterQuantPerPersonAreaAsync(strLocationQuantPerPerson, ind2, dtFromQuantPerPerson, dtToQuantPerPerson);
            
            //client.getGroundWaterByLocationAsync();
            
            client.getDataByZoneAsync(dtFromRegion,dtToRegion);
            }
            #endregion
    

            
        }
        protected void client_getWaterQuantByLocationCompleted(object sender, getWaterQuantByLocationCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    Session["quantVsTime"] = e.Result;
                    quantVsTime = e.Result;
                    BindQuantVsTime(quantVsTime);
                    if (Page.IsPostBack && Session["quantVsTime"] != null)
                    {
                        quantVsTime = Session["quantVsTime"] as WaterQuantLocation[];
                        BindQuantVsTime(quantVsTime);
                    }
                }

            }
            catch (Exception ex)
            { 
             
            
            }
        
        }
        protected void BindQuantVsTime(WaterQuantLocation[] quantVsTime)
        {
            if (chartQuantVsTime.FindControl("chrtAnalytics") != null)
            {
                Chart quantvsTime = (Chart)chartQuantVsTime.FindControl("chrtAnalytics");
                quantvsTime.DataSource = quantVsTime.OrderBy(x => x.Stime);
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
        protected void client_getWaterQuantPerPersonAreaCompleted(object sender, getWaterQuantPerPersonAreaCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                Session["quantPerPersonVsTime"] = e.Result;
                quantPerPersonVsTime = e.Result;
                BindQuantPerPersonVsTime(quantPerPersonVsTime);
                if (Page.IsPostBack && Session["quantPerPersonVsTime"] != null)
                {
                    quantPerPersonVsTime = Session["quantPerPersonVsTime"] as WaterQuantLocation[];
                    BindQuantPerPersonVsTime(quantPerPersonVsTime);
                }
            }

        }
        protected void BindQuantPerPersonVsTime(WaterQuantLocation[] quantVsTime)
        {
            if (chartQuantVsTimeLocs.FindControl("chrtAnalytics") != null)
                
            {
                Chart chartQuantvsTimeLocs = (Chart)chartQuantVsTimeLocs.FindControl("chrtAnalytics");
                chartQuantvsTimeLocs.DataSource = quantVsTime.OrderBy(x => x.Stime);
                chartQuantvsTimeLocs.Series.Add(new Series());
                chartQuantvsTimeLocs.Series[0].MarkerStyle = MarkerStyle.Circle;
                chartQuantvsTimeLocs.Series[0].MarkerSize = 7;
                chartQuantvsTimeLocs.Series[0].XValueMember = "STime";
                chartQuantvsTimeLocs.Series[0].YValueMembers = "Quantity";

                chartQuantvsTimeLocs.Series[0].ToolTip = "Water Usage : #VALY{C0}";
                chartQuantvsTimeLocs.Series[0].ChartType = SeriesChartType.Line;

                chartQuantvsTimeLocs.Titles.Clear();
                chartQuantvsTimeLocs.Titles.Add("Water Consumption Data");

                chartQuantvsTimeLocs.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chartQuantvsTimeLocs.ChartAreas[0].AxisX.Title = "Date";
                chartQuantvsTimeLocs.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                chartQuantvsTimeLocs.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
                chartQuantvsTimeLocs.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


                chartQuantvsTimeLocs.ChartAreas[0].AxisY.Title = "Quantity (Lts)";
                chartQuantvsTimeLocs.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                chartQuantvsTimeLocs.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;
                chartQuantvsTimeLocs.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
                chartQuantvsTimeLocs.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            }

        }

        protected void client_getGroundWaterByLocationCompleted(object sender, getGroundWaterByLocationCompletedEventArgs e)
        {


        }
        protected void client_getDataByZoneCompleted(object sender, getDataByZoneCompletedEventArgs e)
        {


            if (e.Result != null)
            {
                Session["quantRegion"] = e.Result;
                quantRegion = e.Result;
                BindQuantPerRegion(quantRegion);
                if (Page.IsPostBack && Session["quantPerPersonVsTime"] != null)
                {
                    quantPerPersonVsTime = Session["quantPerPersonVsTime"] as WaterQuantLocation[];
                    BindQuantPerPersonVsTime(quantPerPersonVsTime);
                }
            }
        }

        protected void BindQuantPerRegion(ZoneDetails[] quantRegion)
        {
            if (regionChart.FindControl("chrtAnalytics") != null)
            {
                Chart quantvsTime = (Chart)regionChart.FindControl("chrtAnalytics");
                quantvsTime.DataSource = quantRegion;
                quantvsTime.Series.Add(new Series());

              
                quantvsTime.Series[0].Points.DataBindXY(quantRegion, "Region", quantRegion, "Quantity");
                quantvsTime.Series[0].ToolTip = "Water Usage : #VALY{C0}";
                quantvsTime.Series[0].ChartType = SeriesChartType.Pie;
                quantvsTime.ChartAreas[0].BackColor = Color.Transparent;
                quantvsTime.Titles.Clear();
                quantvsTime.Titles.Add("Regional Water Consumption Data");
                

                

            }
          
        
        }
        protected void btnQuantVsTime_Click(object sender, EventArgs e)
        { 
        
        }

        protected void btnQuantPerPerson_Click(object sender, EventArgs e)
        { 
        
        }
        protected void btnFetchRegion_Click(object sender, EventArgs e)
        { 
        
        }

        protected void btnGround_Click(object sender, EventArgs e)
        { 
        
        
        }


    }
}