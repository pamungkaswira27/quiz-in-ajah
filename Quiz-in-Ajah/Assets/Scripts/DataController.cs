using UnityEngine;

public class DataController : MonoBehaviour
{
    const string LEVEL_KEY = "levelReached";

    int firstLevelReached = 1;

    public void SaveLevelReached(int currentLevel)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, currentLevel + 1);
    }

    public int LoadLevelReached()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY, firstLevelReached);
    }
}
