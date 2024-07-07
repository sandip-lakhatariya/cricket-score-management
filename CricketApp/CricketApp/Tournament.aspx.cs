using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateTable1();
        }

        private void GenerateTable1()
        {
            CricketApp.TeamServiceReference.TeamServiceClient teams_proxy = new TeamServiceReference.TeamServiceClient();
            DataSet matches = teams_proxy.GetTournament();

            if (matches != null && matches.Tables.Count > 0)
            {
                DataTable teamsDataTable = matches.Tables[0]; // Assuming the team names are in the first DataTable

                // Clear existing rows if any
                dynamicTable.Rows.Clear();

                // Create header row
                HtmlTableRow headerRow = new HtmlTableRow();

                // Add header cells
                HtmlTableCell headerCell1 = new HtmlTableCell();
                headerCell1.InnerText = "#";
                headerCell1.Attributes["style"] = " font-weight: bold; border-bottom: 1px solid #ddd; padding: 8px 64px;";
                headerRow.Cells.Add(headerCell1);

                HtmlTableCell headerCell2 = new HtmlTableCell();
                headerCell2.InnerText = "Match";
                headerCell2.Attributes["style"] = " font-weight: bold; border-bottom: 1px solid #ddd; padding: 8px 64px;";
                headerRow.Cells.Add(headerCell2);

                HtmlTableCell headerCell3 = new HtmlTableCell();
                headerCell3.InnerText = "Winner";
                headerCell3.Attributes["style"] = " font-weight: bold; border-bottom: 1px solid #ddd; padding: 8px 64px;";
                headerRow.Cells.Add(headerCell3);

                HtmlTableCell headerCell4 = new HtmlTableCell();
                headerCell4.InnerText = "ScoreCard";
                headerCell4.Attributes["style"] = " font-weight: bold; border-bottom: 1px solid #ddd; padding: 8px 64px;";
                headerRow.Cells.Add(headerCell4);

                // Add header row to the table
                dynamicTable.Rows.Add(headerRow);

                // Assuming you have a DataTable named 'teamsDataTable' containing your data
                foreach (DataRow row in teamsDataTable.Rows)
                {
                    int t1 = int.Parse(row["TeamA"].ToString());
                    int t2 = int.Parse(row["TeamB"].ToString());
                    string teamA = teams_proxy.GetTeamById(t1);
                    string teamB = teams_proxy.GetTeamById(t2);

                    string Match = teamA + " vs " + teamB;
                    string Winner = row["Winner"].ToString();
                    if (Winner == "TeamA")
                    {
                        Winner = teamA;
                    }
                    else if (Winner == "TeamB")
                    {
                        Winner = teamB;
                    }

                    // Create cells for data
                    HtmlTableCell cell1 = new HtmlTableCell();
                    cell1.InnerText = (dynamicTable.Rows.Count).ToString(); // Row number
                    cell1.Attributes["style"] = " border-bottom: 1px solid #ddd; padding: 8px 64px;";

                    HtmlTableCell cell2 = new HtmlTableCell();
                    cell2.InnerText = Match;
                    cell2.Attributes["style"] = " border-bottom: 1px solid #ddd; padding: 8px 64px;";

                    HtmlTableCell cell3 = new HtmlTableCell();
                    cell3.InnerText = Winner;
                    cell3.Attributes["style"] = " border-bottom: 1px solid #ddd; padding: 8px 64px;";

                    HtmlTableCell cell4 = new HtmlTableCell();
                    Button button = new Button();
                    button.Text = "Score";
                    int matchId = int.Parse(row["MatchId"].ToString());
                    button.PostBackUrl = "ScoreCard.aspx?MatchId=" + matchId;
                    cell4.Controls.Add(button);
                    cell4.Attributes["style"] = " border-bottom: 1px solid #ddd; padding: 8px 64px;";

                    // Create row and add cells
                    HtmlTableRow row1 = new HtmlTableRow();
                    row1.Cells.Add(cell1);
                    row1.Cells.Add(cell2);
                    row1.Cells.Add(cell3);
                    row1.Cells.Add(cell4);

                    // Add the row to the table
                    dynamicTable.Rows.Add(row1);
                }
            }
        }
    }
}