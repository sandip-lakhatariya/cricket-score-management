using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CricketApp.ScoreUpdateReference.ScoreUpdateClient score_update_proxy = new ScoreUpdateReference.ScoreUpdateClient();

            if (!IsPostBack)
            {
                // Assume ds is your DataSet with team names
                DataSet ds = score_update_proxy.GetTeamName(); // Method to retrieve DataSet

                // Clear existing items (if any)
                TeamA.Items.Clear();
                TeamB.Items.Clear();

                // Check if DataSet and DataTable are not null
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable teamsDataTable = ds.Tables[0]; // Assuming the team names are in the first DataTable

                    // Iterate over the DataTable and add team names to the DropDownList
                    foreach (DataRow row in teamsDataTable.Rows)
                    {
                        string teamName = row["team_name"].ToString();
                        string teamId = row["team_id"].ToString();
                        // PlayerName1.Items.Add(new ListItem(teamName, teamName));
                        TeamA.Items.Add(new ListItem(teamName, teamId));
                        TeamB.Items.Add(new ListItem(teamName, teamId));
                    }
                }
            }
        }
        protected void PlayerName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected player ID
            string selectedPlayerId = TeamA.SelectedValue;
            // Display the selected player ID in the console
            Debug.WriteLine("Selected Player ID: " + selectedPlayerId);
        }

        protected void btnCreateTeam_Click(object sender, EventArgs e)
        {
            int matchId = int.Parse(matchNumber.Text);
            int teamAId = int.Parse(TeamA.SelectedValue);
            int teamBId = int.Parse(TeamB.SelectedValue);
            int over = int.Parse(Over.Text);

            CricketApp.ScoreUpdateReference.ScoreUpdateClient scoreUpdate_proxy = new ScoreUpdateReference.ScoreUpdateClient();
            scoreUpdate_proxy.CreateTeam(matchId, teamAId, teamBId, over);

            Session["matchId"] = matchId;
            Session["over"] = over;
            Session["innings"] = 1;

            Response.Redirect("SelectOpener.aspx");
        }
    }
}