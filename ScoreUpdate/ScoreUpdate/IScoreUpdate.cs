using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ScoreUpdate
{
    [ServiceContract]
    internal interface IScoreUpdate
    {
        [OperationContract]
        string CreateTeam(int matchId, int teamAId, int teamBId, int overs);

        [OperationContract]
        void ScoreUpdate(int matchId, int pid, int bid, int runs, int extra, bool dot, bool wickets, int innings);

        [OperationContract]
        Score GetScore(int matchId, int pid1, int pid2, int bid, int innings);

        [OperationContract]
        DataSet GetPlayerName(int matchId, int innings);

        [OperationContract]
        DataSet GetTeamName();

        [OperationContract]
        void UpdateStatus(int matchId,int pid,string status,int innings);

        [OperationContract]
        void UpdateWinner(int matchId, string team);
    }
}
