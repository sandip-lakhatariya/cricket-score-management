using CricketApp.PlayerServiceReference;
using CricketApp.ScoreUpdateReference;
using CricketApp.TeamServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        static int matchId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mID = Request.QueryString["MatchId"];
                matchId = int.Parse(mID);

                btnShowTable1.Style["background-color"] = "#007bff";
                btnShowTable1.Style["color"] = "#ffffff";
                btnShowTable2.Style["background-color"] = "#ffffff";
                btnShowTable2.Style["color"] = "#000000";

                // Call method to generate the table
                GenerateTable1();
            }

            CricketApp.TeamServiceReference.TeamServiceClient scorecard_proxy = new TeamServiceReference.TeamServiceClient();
            DataSet scoreCard = scorecard_proxy.GetTotalScore(matchId);

            if (scoreCard != null && scoreCard.Tables.Count > 0)
            {
                DataTable teamsDataTable = scoreCard.Tables[0]; // Assuming the team names are in the first DataTable

                // Iterate over the DataTable and add team names to the DropDownList
                foreach (DataRow row in teamsDataTable.Rows)
                {
                    row["TeamAExtra"].ToString();
                    lbl_TeamARuns.Text = row["TeamARuns"].ToString() + "/" + row["TeamAWickets"].ToString();
                    int ballsA = int.Parse(row["TeamABalls"].ToString());
                    int oversA = ballsA / 6;
                    int lballsA = ballsA % 6;
                    lbl_TeamABalls.Text = "Overs: " + oversA + "." + lballsA;
                    lbl_TeamAExtra.Text = "Extra: " + row["TeamAExtra"].ToString();
                    lbl_TeamBRuns.Text = row["TeamBRuns"].ToString() + "/" + row["TeamBWickets"].ToString();
                    int ballsB = int.Parse(row["TeamBBalls"].ToString());
                    int oversB = ballsB / 6;
                    int lballsB = ballsB % 6;
                    lbl_TeamBBalls.Text = "Overs: " + oversB + "." + lballsB;
                    lbl_TeamBExtra.Text = "Extra: " + row["TeamBExtra"].ToString();

                }
            }           
        }

        protected void btnShowTable1_Click(object sender, EventArgs e)
        {
            // Show Table 1 and hide Table 2
            litTable1.Visible = true;
            litTable3.Visible = true;
            litTable2.Visible = false;
            litTable4.Visible = false;

            btnShowTable1.Style["background-color"] = "#007bff";
            btnShowTable1.Style["color"] = "#ffffff";
            btnShowTable2.Style["background-color"] = "#ffffff";
            btnShowTable2.Style["color"] = "#000000";

            // Generate Table 1 content
            GenerateTable1();
        }

        protected void btnShowTable2_Click(object sender, EventArgs e)
        {
            // Show Table 2 and hide Table 1
            litTable1.Visible = false;
            litTable3.Visible = false;
            litTable2.Visible = true;
            litTable4.Visible = true;

            btnShowTable2.Style["background-color"] = "#007bff";
            btnShowTable2.Style["color"] = "#ffffff";
            btnShowTable1.Style["background-color"] = "#ffffff";
            btnShowTable1.Style["color"] = "#000000";

            // Generate Table 2 content
            GenerateTable2();
        }

        private void GenerateTable1()
        {
            // Create a StringBuilder to hold the HTML for the table
            StringBuilder sb = new StringBuilder();

            // Start building the table
            sb.Append("<table class='table'>");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th scope='col'>#</th>");
            sb.Append("<th scope='col'>Player</th>");
            sb.Append("<th scope='col'>Runs</th>");
            sb.Append("<th scope='col'>Balls Played</th>");
            sb.Append("<th scope='col'>Status</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");

            // Example data - you can replace this with data from your database
            CricketApp.TeamServiceReference.TeamServiceClient scorecard_proxy = new TeamServiceReference.TeamServiceClient();
            DataSet scoreCardA = scorecard_proxy.GetScoreCardA(matchId);


            int rowCount = 1;

            if (scoreCardA != null && scoreCardA.Tables.Count > 0)
            {
                DataTable teamsDataTable = scoreCardA.Tables[0]; // Assuming the team names are in the first DataTable

                // Iterate over the DataTable and add team names to the DropDownList
                foreach (DataRow row in teamsDataTable.Rows)
                {
                    string PlayerName = row["PlayerName"].ToString();
                    string Runs = row["PlayerRuns"].ToString();
                    string Balls = row["PlayerBalls"].ToString();
                    string status = row["status"].ToString();

                    sb.Append("<tr>");
                    sb.Append("<th scope='row'>" + rowCount + "</th>");
                    sb.Append("<td>" + PlayerName + "</td>");
                    sb.Append("<td>" + Runs + "</td>");
                    sb.Append("<td>" + Balls + "</td>");
                    sb.Append("<td>" + status + "</td>");
                    sb.Append("</tr>");
                    rowCount++;
                }
            }

            // Close the table
            sb.Append("</tbody>");
            sb.Append("</table>");

            // Set the generated HTML to the Literal control
            litTable1.Text = sb.ToString();

            DataSet scoreCardB = scorecard_proxy.GetScoreCardB(matchId);
            StringBuilder sb2 = new StringBuilder();

            // Start building the table
            sb2.Append("<table class='table'>");
            sb2.Append("<thead>");
            sb2.Append("<tr>");
            sb2.Append("<th scope='col'>#</th>");
            sb2.Append("<th scope='col'>Bowler</th>");
            sb2.Append("<th scope='col'>Overs</th>");
            sb2.Append("<th scope='col'>Runs</th>");
            sb2.Append("<th scope='col'>Wickets</th>");
            sb2.Append("</tr>");
            sb2.Append("</thead>");
            sb2.Append("<tbody>");

            rowCount = 1;

            if (scoreCardB != null && scoreCardB.Tables.Count > 0)
            {
                DataTable teamsDataTable = scoreCardB.Tables[0]; // Assuming the team names are in the first DataTable

                // Iterate over the DataTable and add team names to the DropDownList
                foreach (DataRow row in teamsDataTable.Rows)
                {
                    if (int.Parse(row["BowlingBalls"].ToString()) > 0)
                    {
                        string PlayerName = row["PlayerName"].ToString();
                        string Runs = row["BowlingRuns"].ToString();
                        int Balls = int.Parse(row["BowlingBalls"].ToString());
                        int overs = Balls / 6;
                        int lballs = Balls % 6;
                        string Wickets = row["BowlingWickets"].ToString();

                        sb2.Append("<tr>");
                        sb2.Append("<th scope='row'>" + rowCount + "</th>");
                        sb2.Append("<td>" + PlayerName + "</td>");
                        sb2.Append("<td>" + overs + "." + lballs + "</td>");
                        sb2.Append("<td>" + Runs + "</td>");
                        sb2.Append("<td>" + Wickets + "</td>");
                        sb2.Append("</tr>");
                        rowCount++;
                    }
                }
            }

            // Close the table
            sb2.Append("</tbody>");
            sb2.Append("</table>");

            litTable3.Text = sb2.ToString();
        }

        private void GenerateTable2()
        {
            // Create a StringBuilder to hold the HTML for the table
            StringBuilder sb = new StringBuilder();

            // Start building the table
            sb.Append("<table class='table'>");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th scope='col'>#</th>");
            sb.Append("<th scope='col'>Player</th>");
            sb.Append("<th scope='col'>Runs</th>");
            sb.Append("<th scope='col'>Balls Played</th>");
            sb.Append("<th scope='col'>Status</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");

            // Example data - you can replace this with data from your database
            CricketApp.TeamServiceReference.TeamServiceClient scorecard_proxy = new TeamServiceReference.TeamServiceClient();
            DataSet scoreCardB = scorecard_proxy.GetScoreCardB(matchId);


            int rowCount = 1;

            if (scoreCardB != null && scoreCardB.Tables.Count > 0)
            {
                DataTable teamsDataTable = scoreCardB.Tables[0]; // Assuming the team names are in the first DataTable

                // Iterate over the DataTable and add team names to the DropDownList
                foreach (DataRow row in teamsDataTable.Rows)
                {
                    string PlayerName = row["PlayerName"].ToString();
                    string Runs = row["PlayerRuns"].ToString();
                    string Balls = row["PlayerBalls"].ToString();
                    string status = row["status"].ToString();

                    sb.Append("<tr>");
                    sb.Append("<th scope='row'>" + rowCount + "</th>");
                    sb.Append("<td>" + PlayerName + "</td>");
                    sb.Append("<td>" + Runs + "</td>");
                    sb.Append("<td>" + Balls + "</td>");
                    sb.Append("<td>" + status + "</td>");
                    sb.Append("</tr>");
                    rowCount++;
                }
            }

            // Close the table
            sb.Append("</tbody>");
            sb.Append("</table>");

            // Set the generated HTML to the Literal control
            litTable2.Text = sb.ToString();

            DataSet scoreCardA = scorecard_proxy.GetScoreCardA(matchId);
            StringBuilder sb2 = new StringBuilder();

            // Start building the table
            sb2.Append("<table class='table'>");
            sb2.Append("<thead>");
            sb2.Append("<tr>");
            sb2.Append("<th scope='col'>#</th>");
            sb2.Append("<th scope='col'>Bowler</th>");
            sb2.Append("<th scope='col'>Overs</th>");
            sb2.Append("<th scope='col'>Runs</th>");
            sb2.Append("<th scope='col'>Wickets</th>");
            sb2.Append("</tr>");
            sb2.Append("</thead>");
            sb2.Append("<tbody>");

            rowCount = 1;

            if (scoreCardA != null && scoreCardA.Tables.Count > 0)
            {
                DataTable teamsDataTable = scoreCardA.Tables[0]; // Assuming the team names are in the first DataTable

                // Iterate over the DataTable and add team names to the DropDownList
                foreach (DataRow row in teamsDataTable.Rows)
                {
                    if (int.Parse(row["BowlingBalls"].ToString()) > 0)
                    {
                        string PlayerName = row["PlayerName"].ToString();
                        string Runs = row["BowlingRuns"].ToString();
                        int Balls = int.Parse(row["BowlingBalls"].ToString());
                        int overs = Balls / 6;
                        int lballs = Balls % 6;
                        string Wickets = row["BowlingWickets"].ToString();

                        sb2.Append("<tr>");
                        sb2.Append("<th scope='row'>" + rowCount + "</th>");
                        sb2.Append("<td>" + PlayerName + "</td>");
                        sb2.Append("<td>" + overs + "." + lballs + "</td>");
                        sb2.Append("<td>" + Runs + "</td>");
                        sb2.Append("<td>" + Wickets + "</td>");
                        sb2.Append("</tr>");
                        rowCount++;
                    }
                }
            }


            // Close the table
            sb2.Append("</tbody>");
            sb2.Append("</table>");

            litTable4.Text = sb2.ToString();
        }
    }
}