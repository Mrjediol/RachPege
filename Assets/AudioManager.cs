using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixerGroup outputGroup;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = outputGroup;
        }
    }
    public void Play(string name)
    {
        
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            return;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;


        s.source.Play();
        Debug.Log(s.source.name + "" + sounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
