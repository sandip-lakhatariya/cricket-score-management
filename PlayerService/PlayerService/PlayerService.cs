using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlayerService
{
    public class PlayerService : PlayerInterface
    {
        public string connectionString = "Data Source=LAPTOP-SANDIP\\MSSQLSERVER01;Initial Catalog=CMS;Integrated Security=True;";
        // Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;Application=ReadWrite;MultiSubnetFailover=False

       DataSet PlayerInterface.GetPlayers()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT player_id, player_name, matches_played, total_runs, total_wickets FROM Player", @connectionString);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        Player PlayerInterface.GetPlayer(int pid)
        {   
            SqlConnection cnn = new SqlConnection(@connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT player_id, player_name, matches_played, total_runs, total_wickets FROM Player WHERE player_id=@pid";
            SqlParameter p = new SqlParameter("@pid", pid);
            cmd.Parameters.Add(p);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Player player = new Player();
            while (dr.Read())
            {
                player.PlayerID = dr.GetInt32(0);
                player.PlayerName = dr.GetString(1);
                player.MatchesPlayed = dr.GetInt32(2);
                player.TotalRuns = dr.GetInt32(3);
                player.TotalWickets = dr.GetInt32(4);
            }
            dr.Close();
            cnn.Close();
            return player;
        }

        DataSet PlayerInterface.GetPlayersByTeam(int team_id)
        {
            try
            {
                string query = "SELECT player_id, player_name, matches_played, total_runs, total_wickets FROM Player WHERE team_id = @teamId";

                SqlDataAdapter da = new SqlDataAdapter(query, @connectionString);

                da.SelectCommand.Parameters.AddWithValue("@teamId", team_id);

                DataSet ds = new DataSet();

                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or rethrow it if necessary
                Console.WriteLine("An error occurred while retrieving players by team ID: " + ex.Message);
                return null;
            }
        }


        void PlayerInterface.AddPlayer(Player pr, int team_id)
        {
            try
            {

                SqlConnection cnn = new SqlConnection(@connectionString);
                SqlCommand cmd = new SqlCommand();

                string query = "INSERT INTO Player (player_name, matches_played, total_runs, total_wickets, team_id) VALUES (@pn, @mp, @tr, @tw, @ti)";

                cmd = new SqlCommand(query, cnn);

                cmd.Parameters.AddWithValue("@pn", pr.PlayerName);
                cmd.Parameters.AddWithValue("@mp", pr.MatchesPlayed);
                cmd.Parameters.AddWithValue("@tr", pr.TotalRuns);
                cmd.Parameters.AddWithValue("@tw", pr.TotalWickets);
                cmd.Parameters.AddWithValue("@ti", team_id);

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

        void PlayerInterface.UpdatePlayerDetails(int id, int runs, int wickets)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@connectionString);
                SqlCommand cmd = new SqlCommand();

                string query = "UPDATE Player SET matches_played = matches_played + 1, total_runs = total_runs + @trIncrement, total_wickets = total_wickets + @twIncrement WHERE player_id = @pid";

                cmd = new SqlCommand(query, cnn);

                cmd.Parameters.AddWithValue("@pid", id);
                cmd.Parameters.AddWithValue("@trIncrement", runs);
                cmd.Parameters.AddWithValue("@twIncrement", wickets);

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or rethrow it if necessary
                Console.WriteLine("An error occurred while updating total runs: " + ex.Message);
            }
        }

        void PlayerInterface.RemovePlayer(int id)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@connectionString);
                SqlCommand cmd = new SqlCommand();

                string query = "DELETE FROM Player WHERE player_id = @pid";

                cmd = new SqlCommand(query, cnn);

                cmd.Parameters.AddWithValue("@pid", id);

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or rethrow it if necessary
                Console.WriteLine("An error occurred while removing player: " + ex.Message);
            }

        }

    }
}
