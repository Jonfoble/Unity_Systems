[System.Serializable]
public class PlayerSaveData
{
    public int level;
    public float health;
    public Vector3 position;
    // ... Other Player Data
}

[System.Serializable]
public class GameProgressSaveData
{
    public List<string> completedLevels;
    public int currentScore;
    // ... Other Game Data
}
