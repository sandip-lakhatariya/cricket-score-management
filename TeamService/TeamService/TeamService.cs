using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TeamService
{
    public class TeamService : ITeamService
    {
        public string connectionString = "Data Source=LAPTOP-SANDIP\\MSSQLSERVER01;Initial Catalog=CMS;Integrated Security=True";

        DataSet ITeamService.GetTeams()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT team_id, team_name FROM Teams", @connectionString);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        void ITeamService.CreateTeam(Team team)
        {
            try
            {

                SqlConnection cnn = new SqlConnection(@connectionString);
                SqlCommand cmd = new SqlCommand();

                string query = "INSERT INTO Teams (team_name) VALUES (@tn)";

                cmd = new SqlCommand(query, cnn);

                cmd.Parameters.AddWithValue("@tn", team.TeamName);

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or rethrow it if necessary
                Console.WriteLine("An error occurred while adding player: " + ex.Message);
            }
        }

        public int GetTeamId(string tname)
        {
            int teamId = -1; // Default value if team does not exist

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    string query = "SELECT team_id FROM Teams WHERE team_name = @tn";

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@tn", tname);

                        cnn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                teamId = reader.GetInt32(0);
                            }
                            else
                            {
                                Console.WriteLine("Team does not exist.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or rethrow it if necessary
                Console.WriteLine("An error occurred while querying the database: " + ex.Message);
            }

            return teamId;
        }

        public DataSet GetScoreCardA(int matchId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectCommand = $"SELECT * FROM TeamA WHERE MatchId = {matchId}";

                using (SqlDataAdapter da = new SqlDataAdapter(selectCommand, connection))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public DataSet GetScoreCardB(int matchId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectCommand = $"SELECT * FROM TeamB WHERE MatchId = {matchId}";

                using (SqlDataAdapter da = new SqlDataAdapter(selectCommand, connection))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public DataSet GetTotalScore(int matchId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectCommand = $"SELECT TOP 1 * FROM Score WHERE MatchId = {matchId}";

                using (SqlDataAdapter da = new SqlDataAdapter(selectCommand, connection))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public DataSet GetTournament()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectCommand = $"SELECT * FROM Tournament";

                using (SqlDataAdapter da = new SqlDataAdapter(selectCommand, connection))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public void updateDetails(int matchId)
        {
            // Define the SQL query to retrieve data
            string selectQueryA = "SELECT * FROM TeamA WHERE MatchId = @MatchId";
            string selectQueryB = "SELECT * FROM TeamB WHERE MatchId = @MatchId";

            // Define the SQL query to update the record in another table
            string updateQuery = "UPDATE Player SET matches_played = matches_played + 1, total_runs = total_runs + @Value1, total_wickets = total_wickets + @Value2 WHERE player_id = @Id"; // Modify the destination table and columns as needed

            // Create a new DataSet
            DataSet dataSet = new DataSet();

            // Create a new SqlConnection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Retrieve data into the DataSet
                using (SqlDataAdapter adapterA = new SqlDataAdapter(selectQueryA, connection))
                {
                    // Add parameter for select query condition
                    adapterA.SelectCommand.Parameters.AddWithValue("@MatchId", matchId); // Replace YourCondition with the actual condition value

                    // Fill the DataSet with data from the source table
                    adapterA.Fill(dataSet, "SourceDataA");
                }

                using (SqlDataAdapter adapterB = new SqlDataAdapter(selectQueryB, connection))
                {
                    // Add parameter for select query condition
                    adapterB.SelectCommand.Parameters.AddWithValue("@MatchId", matchId); // Replace YourCondition with the actual condition value

                    // Fill the DataSet with data from the source table
                    adapterB.Fill(dataSet, "SourceDataB");
                }

                // Modify the data in the DataSet as needed

                // Open the connection
                connection.Open();

                // Update data in another table using a loop through the DataSet
                foreach (DataRow row in dataSet.Tables["SourceDataA"].Rows)
                {
                    // Create a new SqlCommand for update query
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters for update query
                        command.Parameters.AddWithValue("@Value1", row["PlayerRuns"]); // Assuming Column1 is present in SourceData
                        command.Parameters.AddWithValue("@Value2", row["BowlingWickets"]); // Assuming Column2 is present in SourceData
                        command.Parameters.AddWithValue("@Id", row["PlayerId"]); // Assuming Id is present in SourceData

                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }

                foreach (DataRow row in dataSet.Tables["SourceDataB"].Rows)
                {
                    // Create a new SqlCommand for update query
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters for update query
                        command.Parameters.AddWithValue("@Value1", row["PlayerRuns"]); // Assuming Column1 is present in SourceData
                        command.Parameters.AddWithValue("@Value2", row["BowlingWickets"]); // Assuming Column2 is present in SourceData
                        command.Parameters.AddWithValue("@Id", row["PlayerId"]); // Assuming Id is present in SourceData

                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
        }

        public string GetTeamById(int teamId)
        {
            string teamName = "";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    string query = "SELECT team_name FROM Teams WHERE team_id = @teamId";

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@teamId", teamId);

                        cnn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                teamName = reader.GetString(0);
                            }
                            else
                            {
                                Console.WriteLine("Team does not exist.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or rethrow it if necessary
                Console.WriteLine("An error occurred while querying the database: " + ex.Message);
            }

            return teamName;
        }
    }
}
