﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource[] music;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Audiomanager found!");
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

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
