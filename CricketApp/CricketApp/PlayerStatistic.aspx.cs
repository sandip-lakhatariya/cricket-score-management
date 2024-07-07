using CricketApp.TeamServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CricketApp.ScoreUpdateReference.ScoreUpdateClient score_update_proxy = new ScoreUpdateReference.ScoreUpdateClient();

            if (!IsPostBack)
            {
                // Assume ds is your DataSet with team names
                DataSet ds = score_update_proxy.GetTeamName(); // Method to retrieve DataSet

                // Clear existing items (if any)
                Team.Items.Clear();

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
                        Team.Items.Add(new ListItem(teamName, teamId));
                    }
                }
            }

            int firstValue = int.Parse(Team.Items[0].Value);
            GenerateTable(firstValue);
        }

        protected void Team_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlayerId = Team.SelectedValue;
            int tID = int.Parse(selectedPlayerId);

            GenerateTable(tID);
        }

        private void GenerateTable(int tID)
        {
            StringBuilder sb = new StringBuilder();

            // Start building the table
            sb.Append("<table class='table'>");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th scope='col'>#</th>");
            sb.Append("<th scope='col'>Player</th>");
            sb.Append("<th scope='col'>Matches</th>");
            sb.Append("<th scope='col'>Total Runs</th>");
            sb.Append("<th scope='col'>Total Wickets</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");

            // Example data - you can replace this with data from your database
            CricketApp.PlayerServiceReference.PlayerInterfaceClient players_proxy = new PlayerServiceReference.PlayerInterfaceClient();
            DataSet players = players_proxy.GetPlayersByTeam(tID);


            int rowCount = 1;

            if (players != null && players.Tables.Count > 0)
            {
                DataTable teamsDataTable = players.Tables[0]; // Assuming the team names are in the first DataTable

                // Iterate over the DataTable and add team names to the DropDownList
                foreach (DataRow row in teamsDataTable.Rows)
                {
                    string PlayerName = row["player_name"].ToString();
                    string Runs = row["matches_played"].ToString();
                    string Balls = row["total_runs"].ToString();
                    string Wickets = row["total_wickets"].ToString();

                    sb.Append("<tr>");
                    sb.Append("<th scope='row'>" + rowCount + "</th>");
                    sb.Append("<td>" + PlayerName + "</td>");
                    sb.Append("<td>" + Runs + "</td>");
                    sb.Append("<td>" + Balls + "</td>");
                    sb.Append("<td>" + Wickets + "</td>");
                    sb.Append("</tr>");
                    rowCount++;
                }
            }

            // Close the table
            sb.Append("</tbody>");
            sb.Append("</table>");

            // Set the generated HTML to the Literal control
            litTable.Text = sb.ToString();
        }

        protected void btnAddPlayer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPlayer.aspx");
        }
    }
}