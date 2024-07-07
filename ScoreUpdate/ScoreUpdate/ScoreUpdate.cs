using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScoreUpdate
{
    public class ScoreUpdate : IScoreUpdate
    {
        public string connectionString = "Data Source=LAPTOP-SANDIP\\MSSQLSERVER01;Initial Catalog=CMS;Integrated Security=True";

        string IScoreUpdate.CreateTeam(int matchId, int teamAId, int teamBId, int overs)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update Score
                string insertCommand = $"INSERT INTO Tournament VALUES ({matchId}, {teamAId}, {teamBId}, {overs}, 'ToBeAnnounced')";

                // Create a command object
                using (SqlCommand command = new SqlCommand(insertCommand, connection))
                {
                    // Execute the insert command
                    command.ExecuteNonQuery();
                }
            }

            string selectCommandTeamA = $"SELECT TOP 11 player_id, player_name FROM Player WHERE team_id = {teamAId}";
            string selectCommandTeamB = $"SELECT TOP 11 player_id, player_name FROM Player WHERE team_id = {teamBId}";

            // Execute the SELECT commands to retrieve the data for both teams
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert data for team A
                InsertDataIntoTeam(connection, selectCommandTeamA, "TeamA", matchId);

                // Insert data for team B
                InsertDataIntoTeam(connection, selectCommandTeamB, "TeamB", matchId);

                // Update Score
                string insertCommand = $"INSERT INTO Score VALUES ({matchId}, 0, 0, 0, 0, 0, 0, 0, 0)";

                // Create a command object
                using (SqlCommand command = new SqlCommand(insertCommand, connection))
                {
                    // Execute the insert command
                    command.ExecuteNonQuery();
                }
            }



            return "Teams Created Successfully";
        }

        private void InsertDataIntoTeam(SqlConnection connection, string selectCommand, string targetTableName, int matchId)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(selectCommand, connection))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);

                // Iterate over each row in the DataSet
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    // Extract data from the current row
                    int playerId = (int)row["player_id"];
                    string playerName = row["player_name"].ToString();

                    // Define the SQL command to insert data into the target table
                    string insertCommand = $"INSERT INTO {targetTableName} (MatchId, PlayerId, PlayerName, Status) " +
                                           $"VALUES ({matchId}, {playerId}, '{playerName}', 'YetToBat')";

                    // Create a command object
                    using (SqlCommand command = new SqlCommand(insertCommand, connection))
                    {
                        // Execute the insert command
                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        Score IScoreUpdate.GetScore(int matchId, int pid1, int pid2, int bid, int innings)
        {

            // Retrieve player names for team A
            Score score = new Score();

            if(innings == 1)
            {
                SetBatsmanDetails1(matchId, "TeamA", pid1, score);
                SetBatsmanDetails2(matchId, "TeamA", pid2, score);
                SetBowlerDetails(matchId, "TeamB", bid, score);
                SetScoreDetails(matchId, score);
            }
            else if (innings == 2)
            {
                SetBatsmanDetails1(matchId, "TeamB", pid1, score);
                SetBatsmanDetails2(matchId, "TeamB", pid2, score);
                SetBowlerDetails(matchId, "TeamA", bid, score);
                SetScoreDetails(matchId, score);
            }

            return score;
        }

        private void SetBatsmanDetails1(int matchId, string targetTable, int playerId, Score score)
        {

            string selectCommand = $"SELECT PlayerName, PlayerRuns, PlayerBalls FROM {targetTable} WHERE PlayerId = {playerId} AND MatchID = {matchId}";

            // Execute the SELECT command to retrieve the batsman's details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            score.Player1 = reader.GetString(0);
                            score.Player1Runs = reader.GetInt32(1);
                            score.Player1balls = reader.GetInt32(2);
                        }
                        else
                        {
                            // Handle the case where no batsman is found with the given ID
                            throw new InvalidOperationException("No batsman found with the specified ID.");
                        }
                    }
                }
            }
        }

        private void SetBatsmanDetails2(int matchId, string targetTable ,int playerId, Score score)
        {

            string selectCommand = $"SELECT PlayerName, PlayerRuns, PlayerBalls FROM {targetTable} WHERE PlayerId = {playerId} AND MatchID = {matchId}";

            // Execute the SELECT command to retrieve the batsman's details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            score.Player2 = reader.GetString(0);
                            score.Player2Runs = reader.GetInt32(1);
                            score.Player2balls = reader.GetInt32(2);
                        }
                        else
                        {
                            // Handle the case where no batsman is found with the given ID
                            throw new InvalidOperationException("No batsman found with the specified ID.");
                        }
                    }
                }
            }
        }
        private void SetBowlerDetails(int matchId, string targetTable, int playerId, Score score)
        {

            string selectCommand = $"SELECT PlayerName, BowlingRuns, BowlingBalls, BowlingWickets FROM {targetTable} WHERE PlayerId = {playerId} AND MatchID = {matchId}";

            // Execute the SELECT command to retrieve the bowler's details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            score.Bowler = reader.GetString(0);
                            score.BowlerRuns = reader.GetInt32(1);
                            score.BowlerBalls = reader.GetInt32(2);
                            score.BowlerWickets = reader.GetInt32(3);
                        }
                        else
                        {
                            // Handle the case where no bowler is found with the given ID
                            throw new InvalidOperationException("No bowler found with the specified ID.");
                        }
                    }
                }
            }
        }

        private void SetScoreDetails(int matchId, Score score)
        {
            string selectCommand;

            selectCommand = $"SELECT TeamARuns, TeamABalls, TeamAWickets, TeamAExtra, TeamBRuns, TeamBBalls, TeamBWickets, TeamBExtra FROM Score WHERE MatchId = {matchId}";

            // Execute the SELECT command to retrieve the bowler's details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            score.TeamARuns = reader.GetInt32(0);
                            score.TeamABalls = reader.GetInt32(1);
                            score.TeamAWickets = reader.GetInt32(2);
                            score.TeamAExtra = reader.GetInt32(3);
                            score.TeamBRuns = reader.GetInt32(4);
                            score.TeamBBalls = reader.GetInt32(5);
                            score.TeamBWickets = reader.GetInt32(6);
                            score.TeamBExtra = reader.GetInt32(7);
                        }
                        else
                        {
                            // Handle the case where no bowler is found with the given ID
                            throw new InvalidOperationException("No bowler found with the specified ID.");
                        }
                    }
                }
            }
        }


        void IScoreUpdate.ScoreUpdate(int matchId, int pid, int bid, int runs, int extra, bool dot, bool wickets, int innings)
        {

            // Construct the SQL command to update the database
            string updateCommand = "";

            if (innings == 1)
            {
                if (extra > 0)
                {

                    updateCommand = $"UPDATE TeamB SET BowlingRuns = BowlingRuns + 1 WHERE PlayerId = {bid} AND MatchId = {matchId} ";

                    updateCommand += $"; UPDATE Score SET TeamAExtra = TeamAExtra + {extra}, TeamARuns = TeamARuns + {extra} WHERE MatchId = {matchId}";

                }
                else if (dot)
                {
                    updateCommand = $"UPDATE TeamA SET PlayerBalls = PlayerBalls + 1 WHERE PlayerId = {pid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE TeamB SET BowlingBalls = BowlingBalls + 1 WHERE PlayerId = {bid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE Score SET TeamABalls = TeamABalls + 1 WHERE MatchId = {matchId}";
                }
                else if(wickets)
                {
                    updateCommand = $" UPDATE TeamB SET BowlingBalls = BowlingBalls + 1, BowlingWickets = BowlingWickets + 1 WHERE PlayerId = {bid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE Score SET TeamABalls = TeamABalls + 1, TeamAWickets = TeamAWickets + 1 WHERE MatchId = {matchId}";
                }
                else
                {

                    updateCommand = $"UPDATE TeamA SET PlayerRuns = PlayerRuns + {runs}, PlayerBalls = PlayerBalls + 1 WHERE PlayerId = {pid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE TeamB SET BowlingRuns = BowlingRuns + {runs}, BowlingBalls = BowlingBalls + 1 WHERE PlayerId = {bid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE Score SET TeamARuns = TeamARuns + {runs}, TeamABalls = TeamABalls + 1 WHERE MatchId = {matchId}";

                }
            }
            else if (innings == 2)
            {
                if (extra > 0)
                {

                    updateCommand = $"UPDATE TeamA SET BowlingRuns = BowlingRuns + 1 WHERE PlayerId = {bid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE Score SET TeamBExtra = TeamBExtra + {extra}, TeamBRuns = TeamBRuns + {extra} WHERE MatchId = {matchId}";

                }
                else if (dot)
                {
                    updateCommand = $"UPDATE TeamB SET PlayerBalls = PlayerBalls + 1 WHERE PlayerId = {pid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE TeamA SET BowlingBalls = BowlingBalls + 1 WHERE PlayerId = {bid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE Score SET TeamBBalls = TeamBBalls + 1 WHERE MatchId = {matchId}";
                }
                else if (wickets)
                {
                    updateCommand = $" UPDATE TeamA SET BowlingBalls = BowlingBalls + 1, BowlingWickets = BowlingWickets + 1 WHERE PlayerId = {bid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE Score SET TeamBBalls = TeamBBalls + 1, TeamBWickets = TeamBWickets + 1 WHERE MatchId = {matchId}";
                }
                else
                {

                    updateCommand = $"UPDATE TeamB SET PlayerRuns = PlayerRuns + {runs}, PlayerBalls = PlayerBalls + 1 WHERE PlayerId = {pid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE TeamA SET BowlingRuns = BowlingRuns + {runs}, BowlingBalls = BowlingBalls + 1 WHERE PlayerId = {bid} AND MatchId = {matchId}";

                    updateCommand += $"; UPDATE Score SET TeamBRuns = TeamBRuns + {runs}, TeamBBalls = TeamBBalls + 1 WHERE MatchId = {matchId}";

                }
            }

            // Execute the update command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateCommand, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataSet GetPlayerName(int matchId, int innings)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectCommand = "";
                if (innings == 1)
                {
                    selectCommand = $"SELECT TOP 11 PlayerId, PlayerName, Status FROM TeamA WHERE MatchId = {matchId}";
                }
                else if (innings == 2)
                {
                     selectCommand = $"SELECT TOP 11 PlayerId, PlayerName, Status FROM TeamB WHERE MatchId = {matchId}";
                }
                using (SqlDataAdapter da = new SqlDataAdapter(selectCommand, connection))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public DataSet GetTeamName()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectCommand = $"SELECT TOP 11 team_id, team_name FROM Teams";

                using (SqlDataAdapter da = new SqlDataAdapter(selectCommand, connection))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public void UpdateStatus(int matchId,int pid,string status,int innings)
        {
            if (innings == 1)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateCommand = "UPDATE TeamA SET Status = @status WHERE MatchId = @matchId AND PlayerId = @playerId";

                    using (SqlCommand command = new SqlCommand(updateCommand, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@matchId", matchId);
                        command.Parameters.AddWithValue("@playerId", pid);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateCommand = "UPDATE TeamB SET Status = @status WHERE MatchId = @matchId AND PlayerId = @playerId";

                    using (SqlCommand command = new SqlCommand(updateCommand, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@matchId", matchId);
                        command.Parameters.AddWithValue("@playerId", pid);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdateWinner(int matchId, string team)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateCommand = "UPDATE Tournament SET Winner = @winner WHERE MatchId = @matchId";

                using (SqlCommand command = new SqlCommand(updateCommand, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@winner", team);
                    command.Parameters.AddWithValue("@matchId", matchId);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
