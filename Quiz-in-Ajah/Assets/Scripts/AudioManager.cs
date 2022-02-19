using UnityEngine;
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

    public void PlayAudio(string audioName)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == audioName);

        if (sound == null)
        {
            Debug.LogWarning("Audio with name " + audioName + " is not found");
            return;
        }

        if (!sound.source.isPlaying)
        {
            sound.source.Play();
        }
    }

    public void StopAudio(string audioName)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == audioName);

        if (sound == null)
        {
            Debug.LogWarning("Audio with name " + audioName + " is not found");
            return;
        }

        if (sound.source.isPlaying)
        {
            sound.source.Stop();
        }
    }
}
