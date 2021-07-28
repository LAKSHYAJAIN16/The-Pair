using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    public static AudioManager instance;
    public static AudioManager Instance { get; set; }
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null) { instance = this; Instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        //Loop through all sounds with a foreach loop
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.audioMixer;
        }

        Play("Background");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
        }

        else
        {
            Debug.LogWarning("Sound " + name + " Not Found");
        }
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Stop();
        }

        else
        {
            Debug.LogWarning("Sound " + name + " Not Found");
        }
    }
}
