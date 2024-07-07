using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string winner = Request.QueryString["Winner"];
            lbl_Winner.Text = "Winner: " + winner;
        }

        protected void btnMatchOver_Click(object sender, EventArgs e)
        {
            CricketApp.TeamServiceReference.TeamServiceClient scorecard_proxy = new TeamServiceReference.TeamServiceClient();
            scorecard_proxy.updateDetails((int)Session["matchId"]);
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}