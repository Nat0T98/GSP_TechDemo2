using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public SFX_Controller[] Sounds;
    public static AudioManager Manager;

    private void Awake()
    {
        if (AudioManager.Manager == null)
            AudioManager.Manager = this;
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (SFX_Controller s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;
        }
    }

    public void PlaySFX(string name)
    {
        SFX_Controller s = Array.Find(Sounds, SFX_Controller => SFX_Controller.Name == name);
        s.source.Play();


        // m.source.Play();

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
    }
    public void StopSoundEffect(string name)
    {
        SFX_Controller s = Array.Find(Sounds, sound => sound.Name == name);
        if (s != null)
        {
            s.source.Stop();
        }
    }
}