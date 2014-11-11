using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;

namespace WaterAnalyticsSolution
{
    public static class Helper
     {
        /// <summary>
        /// Return list of X - Axis Values
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ListItem> GetXValues()
        {
            ObservableCollection<ListItem> lstValues = new ObservableCollection<ListItem>();
            lstValues.Add(new ListItem() { Text = "Hourly", Value = "0" });
            lstValues.Add(new ListItem() { Text = "Daily", Value = "1" });
            lstValues.Add(new ListItem() { Text = "Weekly", Value = "2" });
            lstValues.Add(new ListItem() { Text = "Monthly", Value = "3" });
            lstValues.Add(new ListItem() { Text = "Yearly", Value = "4" });

            return lstValues;
        }

        /// <summary>
        /// Return list of Years
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Int32> GetYear()
        {
            int year = DateTime.Today.Year;
            ObservableCollection<Int32> lstYears = new ObservableCollection<Int32>(Enumerable.Range(1998, DateTime.Today.Year - 1998 + 1));
            return lstYears;

        }
    }

}