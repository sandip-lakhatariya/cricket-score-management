using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PlayerService
{
    [DataContract]
    internal class Player
    {
        private int player_id;
        private string player_name;
        private int matches_played;
        private int total_runs;
        private int total_wickets;

        [DataMember]
        public int PlayerID { get { return player_id; } set { player_id = value; } }
        [DataMember] 
        public string PlayerName { get { return player_name; } set { player_name = value; } }
        [DataMember]
        public int MatchesPlayed { get { return matches_played; } set { matches_played = value; } }
        [DataMember]
        public int TotalRuns { get { return total_runs; } set { total_runs = value; } }
        [DataMember]
        public int TotalWickets { get {  return total_wickets; } set { total_wickets = value; } }
    }
}
