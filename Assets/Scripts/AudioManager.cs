using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound [] sounds;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }


    public void PlaySound (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) 
        { 
            Debug.LogWarning("Sound not find"); 
            return; 
        }
        s.source.Play();
    }
}
