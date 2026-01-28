using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound [] Sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (Sound sound in Sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
        }
    }

    public void PlaySound (string name)
    {
        Sound sound = Array.Find(Sounds, Sound => Sound.name == name);
        if (sound == null) 
        { 
            return; 
        }
        sound.source.Play();
    }
}
