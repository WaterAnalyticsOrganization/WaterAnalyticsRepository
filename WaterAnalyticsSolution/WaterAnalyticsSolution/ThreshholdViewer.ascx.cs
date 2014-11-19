using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WaterAnalyticsSolution
{
    public partial class ThreshholdViewer : System.Web.UI.UserControl
    {
        public event EventHandler btnEditClickHandler;
        public string txtUpdater = "Edit";
        public bool isEditable;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Text = txtUpdater;
            txtThreshhold.ReadOnly = isEditable;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            btnEditClickHandler(sender, e);
        }
    }
}