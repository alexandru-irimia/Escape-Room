using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    void Start()
    {
        Play("MainTheme");
    }

    public void Play(string name)
    {
        Sound sound = findSound(name);
    
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = findSound(name);
        
        sound.source.Stop();
    }

    public void Pause(string name)
    {
        Sound sound = findSound(name);
        
        sound.source.Pause();
    }

    Sound findSound(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        
        if(sound == null){
            throw new Exception("Sound " + name + "not found.");
        }

        return sound;
    }

    public void setVolume(string name, float volume)
    {
        Sound sound = findSound(name);
        
        sound.source.volume = volume;

        Debug.Log(sound.volume);
    }
}
