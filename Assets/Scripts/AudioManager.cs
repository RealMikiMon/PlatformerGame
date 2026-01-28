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

        foreach (Sound S in Sounds)
        {
            S.source = gameObject.AddComponent<AudioSource>();
            S.source.clip = S.clip;

            S.source.volume = S.volume;
        }
    }

    public void PlaySound (string name)
    {
        Sound S = Array.Find(Sounds, Sound => Sound.name == name);
        if (S == null) 
        { 
            return; 
        }
        S.source.Play();
    }
}
