using NewCricketHost.ServiceReference2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewCricketHost
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NewCricketHost.ServiceReference2.TeamServiceClient proxy = new ServiceReference2.TeamServiceClient();

            if (!IsPostBack)
            {
                // Assume ds is your DataSet with team names
                DataSet ds = proxy.GetTeams(); // Method to retrieve DataSet

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
    }
}