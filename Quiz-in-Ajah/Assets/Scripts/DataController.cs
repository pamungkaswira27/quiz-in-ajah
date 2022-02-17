using UnityEngine;

public class DataController : MonoBehaviour
{
    // Level Data
    const string LEVEL_KEY = "levelReached";
    int firstLevelReached = 1;

    // Volume Data
    const string VOLUME_KEY = "volumeLevel";
    float defaultVolume = 1f;

    public void SaveLevelReached(int currentLevel)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, currentLevel + 1);
    }

    public int LoadLevelReached()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY, firstLevelReached);
    }

    public void SaveVolumeSettings(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(VOLUME_KEY, volume);
    }

    public float LoadVolumeSettings()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY, defaultVolume);
    }
}
