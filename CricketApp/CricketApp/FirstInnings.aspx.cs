using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string target = Request.QueryString["Target"];
            lbl_Target.Text = "Target: " + target;
        }

        protected void btnSelectNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectOpener.aspx");
        }
    }
}