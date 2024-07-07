using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TeamService
{
    [DataContract]
    internal class Team
    {  
        private int team_id;
        private string team_name;

        [DataMember]
        public int TeamID { get { return team_id; } set { team_id = value; } }

        [DataMember]
        public string TeamName { get { return team_name; } set { team_name = value; } }
    }
}
