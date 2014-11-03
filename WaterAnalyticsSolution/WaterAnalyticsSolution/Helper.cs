using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WaterAnalyticsSolution
{
    public static class Helper
     {

        public static List<ListItem> XValues()
        {
            List<ListItem> lstValues = new List<ListItem>();
            lstValues.Add(new ListItem() { Text = "Hourly", Value = "0" });
            lstValues.Add(new ListItem() { Text = "Daily", Value = "0" });
            lstValues.Add(new ListItem() { Text = "Weekly", Value = "0" });
            lstValues.Add(new ListItem() { Text = "Monthly", Value = "0" });
            lstValues.Add(new ListItem() { Text = "Yearly", Value = "0" });

            return lstValues;
        }
    }

}