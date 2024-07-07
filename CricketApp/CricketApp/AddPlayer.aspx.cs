using CricketApp.PlayerServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CricketApp.TeamServiceReference.TeamServiceClient team_proxy = new TeamServiceReference.TeamServiceClient();

            if (!IsPostBack)
            {
                // Assume ds is your DataSet with team names
                DataSet ds = team_proxy.GetTeams(); // Method to retrieve DataSet

                // Clear existing items (if any)
                inputTeamName.Items.Clear();

                // Add a default item
                inputTeamName.Items.Add(new ListItem("Choose...", ""));

                // Check if DataSet and DataTable are not null
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable teamsDataTable = ds.Tables[0]; // Assuming the team names are in the first DataTable

                    // Iterate over the DataTable and add team names to the DropDownList
                    foreach (DataRow row in teamsDataTable.Rows)
                    {
                        string teamName = row["team_name"].ToString(); // Assuming the column name in your DataTable is "team_name"
                        inputTeamName.Items.Add(new ListItem(teamName, teamName));
                    }
                }
            }
        }

        protected void btnAddPlayer_Click(object sender, EventArgs e)
        {
            Player player = new Player();

            player.PlayerName = inputPlayerName.Text;
            player.MatchesPlayed = int.Parse(inputMatchesPlayed.Text);
            player.TotalRuns = int.Parse(inputTotalRuns.Text);
            player.TotalWickets = int.Parse(inputTotalWickets.Text);

            CricketApp.TeamServiceReference.TeamServiceClient team_proxy = new TeamServiceReference.TeamServiceClient();
            int teamid = team_proxy.GetTeamId(inputTeamName.Text);

            CricketApp.PlayerServiceReference.PlayerInterfaceClient player_proxy = new PlayerServiceReference.PlayerInterfaceClient();
            player_proxy.AddPlayer(player, teamid);
        }
    }
}