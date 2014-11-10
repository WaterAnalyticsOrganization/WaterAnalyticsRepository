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
        //private WaterQuantLocation[] quantVsTime = null;
        //private WaterQuantLocation[] quantPerPersonVsTime = null;
       // private ZoneDetails[] quantRegion = null;
        private Int32 quantVsTimeItems = 0;
        private Int32 quantPerPersonVsTimeItems = 0;
        private Int32 quantGroundVsTimeItems = 0;
        private List<Series> lstSeriesChart1 = new List<Series>();
        private List<Series> lstSeriesChart2 = new List<Series>();
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
            ddlStartYear.SelectedIndex = Helper.GetYear().Count - 1;
            ddlEndYear.DataSource = Helper.GetYear();
            ddlEndYear.DataBind();
            ddlEndYear.SelectedIndex = Helper.GetYear().Count - 1;
            txtStartDate.Text = DateTime.Today.ToShortDateString();
            txtEndDate.Text = DateTime.Today.ToShortDateString();
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
                             
             }
           #endregion

         }
        protected void ChartWaterQuantUsageBinding()
        {
            try
            {
                WaterAnalyticsClient client = new WaterAnalyticsClient();
                client.getWaterQuantByLocationCompleted += new EventHandler<getWaterQuantByLocationCompletedEventArgs>(client_getWaterQuantByLocationCompleted);
               
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
                     client.getWaterQuantByLocationAsync(lstLocationQuant[i].Text, ind1, dtFromQuant, dtToQuant);
                 }
                  
            }
            catch (Exception ex)
            { 
            
            
            }
        }
        protected void ChartWaterQuantPerPersonUsageBinding()
        {
            try
            {
                WaterAnalyticsClient client = new WaterAnalyticsClient();
                client.getWaterQuantPerPersonAreaCompleted += new EventHandler<getWaterQuantPerPersonAreaCompletedEventArgs>(client_getWaterQuantPerPersonAreaCompleted);
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
                    client.getWaterQuantPerPersonAreaAsync(lstLocationQuantPerPerson[i].Text, ind2, dtFromQuantPerPerson, dtToQuantPerPerson);
                }
            }
            catch (Exception ex)
            {


            }

        }
        protected void ChartGroundWaterAndUsageBinding()
        {
            try
            {
                WaterAnalyticsClient client = new WaterAnalyticsClient();
                client.getGroundWaterByLocationCompleted += new EventHandler<getGroundWaterByLocationCompletedEventArgs>(client_getGroundWaterByLocationCompleted);

            }
            catch (Exception ex)
            {


            }
        }
        protected void ChartRegionBinding()
        { try {

                WaterAnalyticsClient client = new WaterAnalyticsClient();
                client.getDataByZoneCompleted += new EventHandler<getDataByZoneCompletedEventArgs>(client_getDataByZoneCompleted);
                client.getDataByZoneAsync(Convert.ToDateTime(txtStartDate.Text),  Convert.ToDateTime(txtEndDate.Text));
            
            }

            catch (Exception ex)
            {


            }

        }
        protected void client_getWaterQuantByLocationCompleted(object sender, getWaterQuantByLocationCompletedEventArgs e)
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
              
            }
        
        }
        protected void client_getWaterQuantPerPersonAreaCompleted(object sender, getWaterQuantPerPersonAreaCompletedEventArgs e)
        {
            if (e.Result != null)
            {
               
                BindQuantPerPersonVsTime(e.Result);
               
            }

        }
        protected void BindQuantPerPersonVsTime(WaterQuantLocation[] quantVsTime)
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
        protected void client_getGroundWaterByLocationCompleted(object sender, getGroundWaterByLocationCompletedEventArgs e)
        {


        }
        protected void client_getDataByZoneCompleted(object sender, getDataByZoneCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                BindQuantPerRegion(e.Result);
               
            }
        }
        protected void BindQuantPerRegion(ZoneDetails[] quantRegion)
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
        
        
        }


    }
}