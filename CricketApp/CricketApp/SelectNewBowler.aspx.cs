using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CricketApp.ScoreUpdateReference.ScoreUpdateClient score_update_proxy = new ScoreUpdateReference.ScoreUpdateClient();

            if (!IsPostBack)
            {
                DataSet ds;
                // Assume ds is your DataSet with team names
                if ((int)Session["innings"] == 1)
                {
                    ds = score_update_proxy.GetPlayerName((int)Session["matchId"], 2);
                }
                else
                {
                    ds = score_update_proxy.GetPlayerName((int)Session["matchId"], 1);
                }

                // Clear existing items (if any)
                NewBowler.Items.Clear();

                // Check if DataSet and DataTable are not null
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable teamsDataTable = ds.Tables[0]; // Assuming the team names are in the first DataTable

                    // Iterate over the DataTable and add team names to the DropDownList
                    foreach (DataRow row in teamsDataTable.Rows)
                    {
                        string playerName = row["PlayerName"].ToString();
                        string playerId = row["PlayerId"].ToString();
                        if (Session["bowlerId"].ToString() != playerId)
                        {
                            NewBowler.Items.Add(new ListItem(playerName, playerId));
                        }
                    }
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int PlayerId = int.Parse(NewBowler.SelectedValue);

            Session["bowlerId"] = PlayerId;

            Response.Redirect("UpdateScore.aspx");
        }
    }
}