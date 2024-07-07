using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CricketApp.ScoreUpdateReference.ScoreUpdateClient score_update_proxy = new ScoreUpdateReference.ScoreUpdateClient();

            if (!IsPostBack)
            {
                // Assume ds is your DataSet with team names
                DataSet ds1 = score_update_proxy.GetPlayerName((int)Session["matchId"], (int)Session["innings"]);

                // Clear existing items (if any)
                NewPlayer.Items.Clear();

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
                            NewPlayer.Items.Add(new ListItem(playerName, playerId));
                        }
                    }
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int PlayerId = int.Parse(NewPlayer.SelectedValue);

            if((int)Session["current_id"] == (int)Session["playerId1"])
            {
                Session["playerId1"] = PlayerId;
                Session["current_id"] = PlayerId;
            }
            else
            {
                Session["playerId2"] = PlayerId;
                Session["current_id"] = PlayerId;
            }

            CricketApp.ScoreUpdateReference.ScoreUpdateClient score_update_proxy = new ScoreUpdateReference.ScoreUpdateClient();
            score_update_proxy.UpdateStatus((int)Session["matchId"], (int)Session["current_id"], "batting", (int)Session["innings"]);

            Response.Redirect("UpdateScore.aspx");
        }
    }
}