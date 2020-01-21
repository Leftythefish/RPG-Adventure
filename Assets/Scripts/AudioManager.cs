using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource[] music;
    public static AudioManager instance;
    //public AudioMixer masterMixer;
    public AudioMixerGroup master;


    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void PlaySFX(int soundToPlay)
    {
        if (soundToPlay < sfx.Length)
        {
            sfx[soundToPlay].Play();
        }
    }

    public void PlayMusic(int musicToPlay)
    {
        if (!music[musicToPlay].isPlaying)
        {
            StopMusic();

            if (musicToPlay < music.Length)
            {
                music[musicToPlay].Play();
            }
        }
    }
    public void StopMusic()
    {
        for (int i = 0; i < music.Length; i++)
        {
            music[i].Stop();
        }
    }
    public void PlayMusic()
    {
        for (int i = 0; i < music.Length; i++)
        {
            music[i].Play();
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    public void AudioOff()
    {
        master.audioMixer.SetFloat("musicVolume", -80f);
        master.audioMixer.SetFloat("sfxVolume", -80f);
    }
    public void AudioOn()
    {
        master.audioMixer.SetFloat("musicVolume", 0f);
        master.audioMixer.SetFloat("sfxVolume", 0f);
    }

}
