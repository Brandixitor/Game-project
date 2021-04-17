using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public Sound[] Sounds;

    private void Awake() {

        if(instance == null) {

            instance = this;

        }

        foreach(Sound s in Sounds) {

            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.Loop;

        }

    }

    public void PlayClip(string name) {

        Sound s = Array.Find(Sounds, sound => sound.Name == name);

        s.source.Play();

    }

}

[System.Serializable]
public class Sound {

    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;
    public string Name;
    public bool Loop;
    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Pitch = 1;

}