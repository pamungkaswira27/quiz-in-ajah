using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [Header("Music List")]
    [SerializeField] Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void PlayAudio(string bgmName)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == bgmName);

        if (sound == null)
        {
            Debug.LogWarning("Audio with name " + bgmName + " is not found");
            return;
        }

        if (!sound.source.isPlaying)
        {
            sound.source.Play();
        }
    }

    public void StopAudio(string bgmName)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == bgmName);

        if (sound == null)
        {
            Debug.LogWarning("Audio with name " + bgmName + " is not found");
            return;
        }

        if (sound.source.isPlaying)
        {
            sound.source.Stop();
        }
    }
}
