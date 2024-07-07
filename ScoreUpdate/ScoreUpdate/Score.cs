using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScoreUpdate
{
    [DataContract]
    internal class Score
    {
        private string player1;
        private string player2;
        private int player1Runs;
        private int player2Runs;
        private int player1balls;
        private int player2balls;

        private string bowler;
        private int bowlerRuns;
        private int bowlerBalls;
        private int bowlerWickets;

        private int teamARuns;
        private int teamAWickets;
        private int teamABalls;
        private int teamAextra;

        private int teamBRuns;
        private int teamBWickets;
        private int teamBBalls;
        private int teamBextra;

        [DataMember]
        public string Player1 { get; set; }
        [DataMember] 
        public string Player2 { get; set; }
        [DataMember]
        public int Player1Runs { get; set;}
        [DataMember]
        public int Player2Runs { get; set;}
        [DataMember]
        public int Player1balls { get; set;}
        [DataMember]
        public int Player2balls { get;set;}
        [DataMember]
        public string Bowler { get; set; }
        [DataMember]
        public int BowlerRuns { get;set;}
        [DataMember]
        public int BowlerBalls { get; set;}
        [DataMember]
        public int BowlerWickets { get; set;}
        [DataMember]
        public int TeamARuns { get; set;}
        [DataMember]
        public int TeamAWickets { get;set;}

        [DataMember]
        public int TeamABalls { get; set;}

        [DataMember]
        public int TeamAExtra { get; set;}

        [DataMember]
        public int TeamBRuns { get; set; }
        [DataMember]
        public int TeamBWickets { get; set; }

        [DataMember]
        public int TeamBBalls { get; set; }

        [DataMember]
        public int TeamBExtra { get; set; }
    }
}
