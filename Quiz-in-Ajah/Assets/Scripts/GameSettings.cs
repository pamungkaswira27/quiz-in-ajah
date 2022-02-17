using UnityEngine;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
