namespace WhackAMole.SaveSystems
{
    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public float score;
        public PlayerData(string name, float score)
        {
            this.name = name;
            this.score = score;
        }
    }
}