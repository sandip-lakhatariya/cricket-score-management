using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ServiceModel;

namespace PlayerService
{
    [ServiceContract]
    internal interface PlayerInterface
    {
        [OperationContract]
        DataSet GetPlayers();

        [OperationContract]
        Player GetPlayer(int id);

        [OperationContract]
        DataSet GetPlayersByTeam(int team_id);

        [OperationContract]
        void AddPlayer(Player player, int team_id);

        [OperationContract]
        void UpdatePlayerDetails(int id, int runs, int wickets);

        [OperationContract]
        void RemovePlayer(int id);
    }
}
