using System.Collections.Generic;

namespace WhackAMole.SaveSystems
{
    [System.Serializable]
    public class PlayerListData
    {
        public List<PlayerData> playerDatas = new List<PlayerData>();
    }
}