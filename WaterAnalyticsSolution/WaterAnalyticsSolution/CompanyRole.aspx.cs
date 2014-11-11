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
        #region Declare Variables
        
        private Int32 quantVsTimeItems = 0;
        private Int32 quantPerPersonVsTimeItems = 0;
        
        private List<Series> lstSeriesChart1 = new List<Series>();
        private List<Series> lstSeriesChart2 = new List<Series>();
        private List<Series> lstSeriesChart3 = new List<Series>();
        private bool isUsageFetch;
        private bool isGroundFetch;
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            #region Add Handler
            filterQuantByTime.btnFetchClickHandler+= new EventHandler(btnQuantVsTime_Click);
            filterQuantTimeLocation.btnFetchClickHandler += new EventHandler(btnQuantPerPerson_Click);
            #endregion
            #region Initialiaze controls
            chartGroundVsUsage.Width = Unit.Pixel(480);
            chartQuantVsTime.Width = Unit.Pixel(480);
            filterQuantByTime.isLocationVisible = true;
            chartQuantVsTimeLocs.Width = Unit.Pixel(480);
            filterQuantTimeLocation.isLocationVisible = true;
            regionChart.Width = Unit.Pixel(480);
            ddlStartYear.DataSource = Helper.GetYear();
            ddlStartYear.DataBind();
            ddlStartYear.SelectedIndex = Helper.GetYear().Count - 2;
            ddlEndYear.DataSource = Helper.GetYear();
            ddlEndYear.DataBind();
            ddlEndYear.SelectedIndex = Helper.GetYear().Count - 1 ;
            txtStartDate.Text = DateTime.Today.ToShortDateString();
            txtEndDate.Text = DateTime.Today.ToShortDateString();
            WaterAnalyticsClient client = new WaterAnalyticsClient();
            ddlLocation.DataSource = client.GetAllLocation();
            ddlLocation.DataTextField = "Location_name";
            ddlLocation.SelectedIndex = 0;
            ddlLocation.DataBind();
            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
         { 
            #region DataBind
            if(!IsPostBack)
            {
                ChartWaterQuantUsageBinding();
                ChartWaterQuantPerPersonUsageBinding();
                ChartRegionBinding();
                ChartGroundWaterAndUsageBinding();
                             
             }
           #endregion

         }
        protected void ChartWaterQuantUsageBinding()
        {
            try
            {
                WaterAnalyticsClient client = new WaterAnalyticsClient();
                client.GetWaterQuantByLocationCompleted += new EventHandler<GetWaterQuantByLocationCompletedEventArgs>(client_getWaterQuantByLocationCompleted);
               
                #region Get Parameters
                List<ListItem> lstLocationQuant = new List<ListItem>();
                 DateTime dtFromQuant = DateTime.MinValue;
                 DateTime dtToQuant = DateTime.MinValue;
                 Int32 ind1 = 0;
                 foreach (ListItem item in ((CheckBoxList)filterQuantByTime.FindControl("chkList")).Items)
                 {
                     if (item.Selected == true)
                     {

                         lstLocationQuant.Add(item);
                     }
                 }

                
                 if (filterQuantByTime.FindControl("txtStartDate") != null)
                     dtFromQuant = Convert.ToDateTime(((TextBox)filterQuantByTime.FindControl("txtStartDate")).Text);
                 if (filterQuantByTime.FindControl("txtEndDate") != null)
                     dtToQuant = Convert.ToDateTime(((TextBox)filterQuantByTime.FindControl("txtEndDate")).Text);
                 if (filterQuantByTime.FindControl("ddlXValue") != null)
                     ind1 = Convert.ToInt32(((DropDownList)filterQuantByTime.FindControl("ddlXValue")).SelectedValue);

                 quantVsTimeItems = lstLocationQuant.Count();
                #endregion

                 for (int i = 0; i < lstLocationQuant.Count; i++)
                 {
                     client.GetWaterQuantByLocationAsync(lstLocationQuant[i].Text, ind1, dtFromQuant, dtToQuant);
                 }
                  
            }
            catch (Exception ex)
            {

                ErrorHandler.WriteError(ex.Message);
            }
        }
        protected void ChartWaterQuantPerPersonUsageBinding()
        {
            try
            {
                WaterAnalyticsClient client = new WaterAnalyticsClient();
                client.GetWaterQuantPerPersonAreaCompleted += new EventHandler<GetWaterQuantPerPersonAreaCompletedEventArgs>(client_getWaterQuantPerPersonAreaCompleted);
                #region Get Parameters

                List<ListItem> lstLocationQuantPerPerson = new List<ListItem>();
                DateTime dtFromQuantPerPerson = DateTime.MinValue;
                DateTime dtToQuantPerPerson = DateTime.MinValue;
                Int32 ind2 = 0;

                if (filterQuantTimeLocation.FindControl("txtStartDate") != null)
                    dtFromQuantPerPerson = Convert.ToDateTime(((TextBox)filterQuantTimeLocation.FindControl("txtStartDate")).Text);
                if (filterQuantTimeLocation.FindControl("txtEndDate") != null)
                    dtToQuantPerPerson = Convert.ToDateTime(((TextBox)filterQuantTimeLocation.FindControl("txtEndDate")).Text);
                if (filterQuantTimeLocation.FindControl("ddlXValue") != null)
                    ind2 = Convert.ToInt32(((DropDownList)filterQuantTimeLocation.FindControl("ddlXValue")).SelectedValue);

                foreach (ListItem item in ((CheckBoxList)filterQuantTimeLocation.FindControl("chkList")).Items)
                {
                    if (item.Selected == true)
                    {

                        lstLocationQuantPerPerson.Add(item);
                    }
                }

                quantPerPersonVsTimeItems = lstLocationQuantPerPerson.Count();
                #endregion
                for (int i = 0; i < lstLocationQuantPerPerson.Count; i++)
                {
                    client.GetWaterQuantPerPersonAreaAsync(lstLocationQuantPerPerson[i].Text, ind2, dtFromQuantPerPerson, dtToQuantPerPerson);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex.Message);

            }

        }
        protected void ChartGroundWaterAndUsageBinding()
        {
            try
            {
                
                WaterAnalyticsClient client = new WaterAnalyticsClient();
                client.GetGroundWaterByLocationCompleted += new EventHandler<GetGroundWaterByLocationCompletedEventArgs>(client_getGroundWaterByLocationCompleted);
                client.GetWaterQuantByLocationCompleted +=new EventHandler<GetWaterQuantByLocationCompletedEventArgs>(client_YearlyWaterCompleted);
                client.GetGroundWaterByLocationAsync(ddlLocation.SelectedItem.Text, Convert.ToInt32(ddlStartYear.SelectedItem.Text), Convert.ToInt32(ddlEndYear.SelectedItem.Text));
                client.GetWaterQuantByLocationAsync(ddlLocation.SelectedItem.Text, 4, new DateTime(Convert.ToInt32(ddlStartYear.SelectedItem.Text), 1, 1), new DateTime(Convert.ToInt32(ddlEndYear.SelectedItem.Text), 1, 1));
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex.Message);

            }
        }
        protected void ChartRegionBinding()
        { try {

                WaterAnalyticsClient client = new WaterAnalyticsClient();
                client.GetDataByZoneCompleted += new EventHandler<GetDataByZoneCompletedEventArgs>(client_getDataByZoneCompleted);
                client.GetDataByZoneAsync(Convert.ToDateTime(txtStartDate.Text),  Convert.ToDateTime(txtEndDate.Text));
            
            }

            catch (Exception ex)
            {

                ErrorHandler.WriteError(ex.Message);
            }

        }
        protected void client_getWaterQuantByLocationCompleted(object sender, GetWaterQuantByLocationCompletedEventArgs e)
        {
            try
            {
               
                if (e.Result != null)
                {
                   
                    BindQuantVsTime(e.Result);
                   
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex.Message);
            
            }
        
        }
        protected void BindQuantVsTime(WaterQuantLocation[] quantVsTime)
        {
            try
            {
                
                    
                    Series objSeries = new Series();
                    objSeries.Points.DataBindXY(quantVsTime, "STime", quantVsTime, "Quantity");
                    objSeries.MarkerStyle = MarkerStyle.Circle;
                    objSeries.MarkerSize = 7;
                    objSeries.ToolTip = "Water Usage : #VALY{C0}";
                    objSeries.ChartType = SeriesChartType.Line;
                    objSeries.LegendText = quantVsTime[0].LocationName;
                    lstSeriesChart1.Add(objSeries);

                    quantVsTimeItems--;
                    if (quantVsTimeItems == 0)
                    {
                        Chart quantvsTime = (Chart)chartQuantVsTime.FindControl("chrtAnalytics");
                        quantvsTime.Series.Clear();
                        quantvsTime.Legends.Clear();
                        foreach (Series s in lstSeriesChart1)
                        {
                            quantvsTime.Series.Add(s);
                            Legend lg = new Legend();
                            lg.Docking = Docking.Bottom;
                            lg.LegendStyle = LegendStyle.Row;
                            lg.Name = s.LegendText;
                            quantvsTime.Legends.Add(lg);
                            
                          
                        }
                        quantvsTime.Titles.Clear();
                        quantvsTime.Titles.Add("Water Consumption Data");


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
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex.Message);
            }
        
        }
        protected void client_getWaterQuantPerPersonAreaCompleted(object sender, GetWaterQuantPerPersonAreaCompletedEventArgs e)
        {
            if (e.Result != null)
            {
               
                BindQuantPerPersonVsTime(e.Result);
               
            }

        }
        protected void BindQuantPerPersonVsTime(WaterQuantLocation[] quantVsTime)
        {
            try
            {
                Series objSeries = new Series();
                objSeries.Points.DataBindXY(quantVsTime, "STime", quantVsTime, "Quantity");
                objSeries.MarkerStyle = MarkerStyle.Circle;
                objSeries.MarkerSize = 7;
                objSeries.ToolTip = "Water Usage : #VALY{C0}";
                objSeries.ChartType = SeriesChartType.Line;
                objSeries.LegendText = quantVsTime[0].LocationName;
                lstSeriesChart2.Add(objSeries);
                quantPerPersonVsTimeItems--;


                if (quantPerPersonVsTimeItems == 0)
                {
                    Chart chartQuantvsTimeLocs = (Chart)chartQuantVsTimeLocs.FindControl("chrtAnalytics");
                    chartQuantvsTimeLocs.Series.Clear();
                    chartQuantvsTimeLocs.Legends.Clear();
                    foreach (Series s in lstSeriesChart2)
                    {
                        chartQuantvsTimeLocs.Series.Add(s);
                        Legend lg = new Legend();
                        lg.Docking = Docking.Bottom;
                        lg.LegendStyle = LegendStyle.Row;
                        lg.Name = s.LegendText;
                        chartQuantvsTimeLocs.Legends.Add(lg);


                    }

                    chartQuantvsTimeLocs.Titles.Clear();
                    chartQuantvsTimeLocs.Titles.Add("Water Consumption Data");
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
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex.Message);

            }

        }
        protected void client_getGroundWaterByLocationCompleted(object sender, GetGroundWaterByLocationCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    Series objSeries = new Series();
                    objSeries.Points.DataBindXY(e.Result, "STime", e.Result, "Quantity");
                    objSeries.MarkerStyle = MarkerStyle.Circle;
                    objSeries.MarkerSize = 7;
                    objSeries.ToolTip = "Water Usage : #VALY{C0}";
                    objSeries.ChartType = SeriesChartType.Line;
                    objSeries.LegendText = "Ground Water Level ";
                    lstSeriesChart3.Add(objSeries);
                    isGroundFetch = true;
                }
                if ((isGroundFetch) && (isUsageFetch))
                {
                    BindChartGroungVsUsage();

                }
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex.Message);
            }

        }
        protected void BindChartGroungVsUsage()
        {
          try{

                Chart chartGroundvsUsage = (Chart)chartGroundVsUsage.FindControl("chrtAnalytics");
                chartGroundvsUsage.Series.Clear();
                chartGroundvsUsage.Legends.Clear();
                foreach (Series s in lstSeriesChart3)
                {
                    chartGroundvsUsage.Series.Add(s);
                    Legend lg = new Legend();
                    lg.Docking = Docking.Bottom;
                    lg.LegendStyle = LegendStyle.Row;
                    lg.Name = s.LegendText;
                    chartGroundvsUsage.Legends.Add(lg);


                }
                chartGroundvsUsage.Titles.Clear();
                chartGroundvsUsage.Titles.Add("Water Consumption Data");
                chartGroundvsUsage.ChartAreas[0].AxisX.Title = "Date";
                chartGroundvsUsage.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                chartGroundvsUsage.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
                chartGroundvsUsage.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartGroundvsUsage.ChartAreas[0].AxisY.Title = "Quantity (Lts)";
                chartGroundvsUsage.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
                chartGroundvsUsage.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;
                chartGroundvsUsage.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
                chartGroundvsUsage.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        
          
          }
            catch(Exception ex)
           {
               ErrorHandler.WriteError(ex.Message);
            
            }
          }
        protected void client_YearlyWaterCompleted(object sender, GetWaterQuantByLocationCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    Series objSeries = new Series();
                    objSeries.Points.DataBindXY(e.Result, "STime", e.Result, "Quantity");
                    objSeries.MarkerStyle = MarkerStyle.Circle;
                    objSeries.MarkerSize = 7;
                    objSeries.ToolTip = "Water Usage : #VALY{C0}";
                    objSeries.ChartType = SeriesChartType.Line;
                    objSeries.LegendText = "Yearly water Consumption";
                    lstSeriesChart3.Add(objSeries);
                    isUsageFetch = true;
                }
                if ((isGroundFetch) && (isUsageFetch))
                {
                    BindChartGroungVsUsage();

                }    

            }
            catch (Exception ex)
            {

                ErrorHandler.WriteError(ex.Message);
            }
        }
        protected void client_getDataByZoneCompleted(object sender, GetDataByZoneCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                BindQuantPerRegion(e.Result);
               

            }
        }
        protected void BindQuantPerRegion(ZoneDetails[] quantRegion)
        {
            try
            {
                if (regionChart.FindControl("chrtAnalytics") != null)
                {
                    Chart quantvsTime = (Chart)regionChart.FindControl("chrtAnalytics");
                    quantvsTime.Series.Clear();
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
            catch (Exception ex)
            {
                ErrorHandler.WriteError(ex.Message);
            }
          
        
        }
        protected void btnQuantVsTime_Click(object sender, EventArgs e)
        {
            try
            {
                Session["quantVsTime"] = null;
                lstSeriesChart1.Clear();
                ChartWaterQuantUsageBinding();

            }
            catch (Exception ex)
            {

                ErrorHandler.WriteError(ex.Message);
            }
        }
        protected void btnQuantPerPerson_Click(object sender, EventArgs e)
        {
            lstSeriesChart2.Clear();
            ChartWaterQuantPerPersonUsageBinding();
        }
        protected void btnFetchRegion_Click(object sender, EventArgs e)
        {
            ChartRegionBinding();
        }
        protected void btnGround_Click(object sender, EventArgs e)
        {

            isUsageFetch = false;
            isGroundFetch = false;
            lstSeriesChart3.Clear();
            ChartGroundWaterAndUsageBinding();
        }


    }
}