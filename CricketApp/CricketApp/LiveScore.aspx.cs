using CricketApp.ScoreUpdateReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketApp
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        CricketApp.ScoreUpdateReference.ScoreUpdateClient scoreUpdate_proxy = new ScoreUpdateReference.ScoreUpdateClient();
        string p1_status = "Batting", p2_status = "Batting";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["matchId"] == null)
            {
                NoLiveMatch.Visible = true;
                LiveScore.Visible = false;
                /* Session["matchId"] = 5001;
                Session["current_id"] = 12;
                Session["innings"] = 1;
                Session["playerId1"] = 1;
                Session["playerId2"] = 12;
                Session["bowlerId"] = 6;
                Session["over"] = 12;
                Session["switched"] = true; */
            }
            else
            {

                NoLiveMatch.Visible = false;
                LiveScore.Visible = true;

                int playerId1 = (int)Session["playerId1"];
                int playerId2 = (int)Session["playerId2"];
                int bowlerId = (int)Session["bowlerId"];
                bool switched = (bool)Session["switched"];

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
            }
            
        }

        protected void btnScoreCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScoreCard.aspx?MatchId=" + (int)Session["matchId"]);
        }
    }
}