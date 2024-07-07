using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TeamService
{
    [ServiceContract]
    internal interface ITeamService
    {
        [OperationContract]
        DataSet GetTeams();

        [OperationContract]
        void CreateTeam(Team team);

        [OperationContract]
        int GetTeamId(string tname);

        [OperationContract]
        DataSet GetScoreCardA(int matchId);

        [OperationContract]
        DataSet GetScoreCardB(int matchId);

        [OperationContract]
        DataSet GetTotalScore(int matchId);

        [OperationContract]
        DataSet GetTournament();

        [OperationContract]
        string GetTeamById(int teamId);

        [OperationContract]
        void updateDetails(int  matchId);
    }
}
