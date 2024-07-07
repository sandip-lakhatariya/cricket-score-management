using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CricketApp.ScoreUpdateReference.ScoreUpdateClient score_update_proxy = new ScoreUpdateReference.ScoreUpdateClient();

            if (!IsPostBack)
            {
                // Assume ds is your DataSet with team names
                DataSet ds1, ds2;
                if ((int)Session["innings"] == 1)
                {
                    ds1 = score_update_proxy.GetPlayerName((int)Session["matchId"], 1); // Method to retrieve DataSet
                    ds2 = score_update_proxy.GetPlayerName((int)Session["matchId"], 2);
                }
                else
                {
                    ds1 = score_update_proxy.GetPlayerName((int)Session["matchId"], 2); // Method to retrieve DataSet
                    ds2 = score_update_proxy.GetPlayerName((int)Session["matchId"], 1);
                }

                // Clear existing items (if any)
                PlayerName1.Items.Clear();
                PlayerName2.Items.Clear();
                Bowler.Items.Clear();

                // Check if DataSet and DataTable are not null
                if (ds1 != null && ds1.Tables.Count > 0)
                {
                    DataTable teamsDataTable = ds1.Tables[0]; // Assuming the team names are in the first DataTable

                    // Iterate over the DataTable and add team names to the DropDownList
                    foreach (DataRow row in teamsDataTable.Rows)
                    {
                        if (row["Status"].ToString() == "YetToBat")
                        {
                            string playerName = row["PlayerName"].ToString();
                            string playerId = row["PlayerId"].ToString();
                            PlayerName1.Items.Add(new ListItem(playerName, playerId));
                            PlayerName2.Items.Add(new ListItem(playerName, playerId));

                        }
                    }
                }

                if (ds2 != null && ds2.Tables.Count > 0)
                {
                    DataTable teamsDataTable = ds2.Tables[0]; // Assuming the team names are in the first DataTable

                    // Iterate over the DataTable and add team names to the DropDownList
                    foreach (DataRow row in teamsDataTable.Rows)
                    {
                        string playerName = row["PlayerName"].ToString();
                        string playerId = row["PlayerId"].ToString();
                        Bowler.Items.Add(new ListItem(playerName, playerId));
                    }
                }
            }
        }

        protected void PlayerName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected player ID
            string selectedPlayerId = PlayerName1.SelectedValue;
            // Display the selected player ID in the console
            Debug.WriteLine("Selected Player ID: " + selectedPlayerId);
            // Store the selected player ID in the hidden field
            Player1IdHidden.Value = selectedPlayerId;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int PlayerId1 = int.Parse(PlayerName1.SelectedValue);
            int PlayerId2 = int.Parse(PlayerName2.SelectedValue);
            int BowlerId = int.Parse(Bowler.SelectedValue);

            Session["playerId1"] = PlayerId1;
            Session["playerId2"] = PlayerId2;
            Session["bowlerId"] = BowlerId;
            Session["switched"] = true;

            CricketApp.ScoreUpdateReference.ScoreUpdateClient score_update_proxy = new ScoreUpdateReference.ScoreUpdateClient();
            score_update_proxy.UpdateStatus((int)Session["matchId"], (int)Session["playerId1"], "batting", (int)Session["innings"]);
            score_update_proxy.UpdateStatus((int)Session["matchId"], (int)Session["playerId2"], "batting", (int)Session["innings"]);

            Response.Redirect("UpdateScore.aspx");
        }
    }
}