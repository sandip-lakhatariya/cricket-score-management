using CricketApp.ScoreUpdateReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace CricketApp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        CricketApp.ScoreUpdateReference.ScoreUpdateClient scoreUpdate_proxy = new ScoreUpdateReference.ScoreUpdateClient();

        string p1_status = "Batting", p2_status = "Batting";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["username"] == null)
                {
                    Response.Redirect("login.aspx");
                }

               int playerId1 = (int)Session["playerId1"];
               int playerId2 = (int)Session["playerId2"];

               Session["current_id"] = playerId1;

               /*  if (Session["current_id"] == null)
                {
                    Session["matchId"] = 5001;
                    Session["current_id"] = 12;
                    Session["innings"] = 1;
                    Session["playerId1"] = 1;
                    Session["playerId2"] = 12;
                    Session["bowlerId"] = 6;
                    Session["over"] = 12;
                    Session["switched"] = true;
                } */
                UpdateLabels(false);
            }
        }

        private void UpdateLabels(bool extra = false)
        {
            int playerId1 = (int)Session["playerId1"];
            int playerId2 = (int)Session["playerId2"];
            int bowlerId = (int)Session["bowlerId"];
            bool switched = (bool)Session["switched"];

            // int playerId1 = 6;
            // int playerId2 = 8;
            // bool switched = true;

            Score score = scoreUpdate_proxy.GetScore((int)Session["matchId"], playerId1, playerId2, bowlerId, (int)Session["innings"]);

            lbl_TeamARuns.Text = score.TeamARuns.ToString() + "/" + score.TeamAWickets.ToString();
            int ballsA = score.TeamABalls;
            int oversA = ballsA / 6;
            int lballsA = ballsA % 6;
            lbl_TeamABalls.Text = "Overs: " + oversA + "." + lballsA;
            lbl_TeamAExtra.Text = "Extra: " + score.TeamAExtra.ToString();
            lbl_TeamBRuns.Text = score.TeamBRuns.ToString() + "/" + score.TeamBWickets.ToString();
            int ballsB = score.TeamBBalls;
            int oversB = ballsB / 6;
            int lballsB = ballsB % 6;
            lbl_TeamBBalls.Text = "Overs: " + oversB + "." + lballsB;
            lbl_TeamBExtra.Text = "Extra: " + score.TeamBExtra.ToString();

            int bowler_overs = score.BowlerBalls / 6;
            int bowler_balls = score.BowlerBalls % 6;

            if (!switched && !extra && bowler_balls == 0)
            {
                // Response.Redirect("SelectNewBowler.aspx");
                Session["switched"] = true;
                SwitchBatsman();
            }

            if(bowler_balls != 0)
            {
                Session["switched"] = false;
            }

            // Batsman Details
            if ((int)Session["current_id"] == playerId1)
            {
                lbl_Player1.Text = score.Player1 + "*";
                lbl_Player2.Text = score.Player2.ToString();
            }
            else
            {
                lbl_Player1.Text = score.Player1.ToString();
                lbl_Player2.Text = score.Player2 + "*";
            }
            
            lbl_Player1Status.Text = p1_status;
            lbl_Player1Run.Text = score.Player1Runs.ToString();
            lbl_Player1Ball.Text = score.Player1balls.ToString();
            lbl_Player2Status.Text = p2_status.ToString();
            lbl_Player2Run.Text = score.Player2Runs.ToString();
            lbl_Player2Ball.Text = score.Player2balls.ToString();

            // Bowler Details
            lbl_bowler.Text = score.Bowler.ToString();
            lbl_bowlerOvers.Text = bowler_overs + "." + bowler_balls;
            lbl_bowler_runs.Text = score.BowlerRuns.ToString();
            lbl_bowler_wickets.Text = score.BowlerWickets.ToString();

            if ((int)Session["innings"] == 2)
            {
                if (score.TeamBWickets < 10 && score.TeamBRuns > score.TeamARuns)
                {
                    scoreUpdate_proxy.UpdateWinner((int)Session["matchId"], "TeamB");
                    Response.Redirect("SecondInnings.aspx?Winner=" + "TeamB");
                }
                else if (score.TeamBBalls == ((int)Session["over"] * 6) || score.TeamBWickets == 10)
                {
                    scoreUpdate_proxy.UpdateWinner((int)Session["matchId"], "TeamA");
                    Response.Redirect("SecondInnings.aspx?Winner=" + "TeamA");
                }
            }

            if((int)Session["innings"] == 1 && score.TeamABalls == ((int)Session["over"] * 6))
            {
                Session["innings"] = 2;
                Response.Redirect("FirstInnings.aspx?Target=" + (score.TeamARuns + 1));
            }
            else if((int)Session["innings"] == 1 && score.TeamAWickets == 10)
            {
                Session["innings"] = 2;
                Response.Redirect("FirstInnings.aspx?Target=" + (score.TeamARuns + 1));
            }


            if (!switched && bowler_balls == 0)
            {
                Response.Redirect("SelectNewBowler.aspx");
            }
        }

        private void SwitchBatsman()
        {
            if((int)Session["current_id"] == (int)Session["playerId1"])
            {
                Session["current_id"] = (int)Session["playerId2"];
            }
            else
            {
                Session["current_id"] = (int)Session["playerId1"];
            }
        }

        protected void btnDot_Click(object sender, EventArgs e)
        {
            scoreUpdate_proxy.ScoreUpdate((int)Session["matchId"], (int)Session["current_id"], (int)Session["bowlerId"], 0, 0, true, false, (int)Session["innings"]);
            UpdateLabels(false);
        }
        protected void btnOneRun_Click(object sender, EventArgs e)
        {
            scoreUpdate_proxy.ScoreUpdate((int)Session["matchId"], (int)Session["current_id"], (int)Session["bowlerId"], 1, 0, false, false, (int)Session["innings"]);
            SwitchBatsman();
            UpdateLabels(false);
        }

        protected void btnTwoRun_Click(object sender, EventArgs e)
        {
            scoreUpdate_proxy.ScoreUpdate((int)Session["matchId"], (int)Session["current_id"], (int)Session["bowlerId"], 2, 0, false, false, (int)Session["innings"]);
            UpdateLabels(false);
        }

        protected void btnFourRun_Click(object sender, EventArgs e)
        {
            scoreUpdate_proxy.ScoreUpdate((int)Session["matchId"], (int)Session["current_id"], (int)Session["bowlerId"], 4, 0, false, false, (int)Session["innings"]);
            UpdateLabels(false);
        }

        protected void btnSixRun_Click(object sender, EventArgs e)
        {

            scoreUpdate_proxy.ScoreUpdate((int)Session["matchId"], (int)Session["current_id"], (int)Session["bowlerId"], 6, 0, false, false, (int)Session["innings"]);
            UpdateLabels(false);
        }

        protected void btnExtra_Click(object sender, EventArgs e)
        {
            scoreUpdate_proxy.ScoreUpdate((int)Session["matchId"], (int)Session["current_id"], (int)Session["bowlerId"], 0, 1, false, false, (int)Session["innings"]);
            UpdateLabels(true);
        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            scoreUpdate_proxy.ScoreUpdate((int)Session["matchId"], (int)Session["current_id"], (int)Session["bowlerId"], 0, 0, false, true, (int)Session["innings"]);
            scoreUpdate_proxy.UpdateStatus((int)Session["matchId"], (int)Session["current_id"], "out", (int)Session["innings"]);
            Score score = scoreUpdate_proxy.GetScore((int)Session["matchId"], (int)Session["playerId1"], (int)Session["playerId1"], (int)Session["bowlerId"], (int)Session["innings"]);

            if((int)Session["innings"] == 1 && score.TeamAWickets == 10)
            {
                UpdateLabels(false);
            }
            else if ((int)Session["innings"] == 2 && score.TeamAWickets == 10)
            {
                UpdateLabels(false);
            }
            else
            {
                Response.Redirect("SelectNextPlayer.aspx");
            }
            
        }
    }
}