using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WaterAnalyticsSolution
{
    public static class Helper
     {

        public static List<ListItem> GetXValues()
        {
            List<ListItem> lstValues = new List<ListItem>();
            lstValues.Add(new ListItem() { Text = "Hourly", Value = "0" });
            lstValues.Add(new ListItem() { Text = "Daily", Value = "1" });
            lstValues.Add(new ListItem() { Text = "Weekly", Value = "2" });
            lstValues.Add(new ListItem() { Text = "Monthly", Value = "3" });
            lstValues.Add(new ListItem() { Text = "Yearly", Value = "4" });

            return lstValues;
        }

        public static List<Int32> GetYear()
        {
            int year = DateTime.Today.Year;
            List<Int32> lstYears = Enumerable.Range(1998, DateTime.Today.Year - 1998 + 1).ToList<Int32>();
            return lstYears;

        }
    }

}