using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicManager : MonoBehaviour
{
   
        public static MusicManager instance;
        LevelManager levelManager;
        public AudioSource musicSource;
        public AudioSource musicSource2;
        public AudioClip menuMusic;
        public AudioClip overworldMusic;
        public AudioClip ShadowSightMusic;
        public AudioMixerGroup Music;
        public AudioMixerGroup Music2;
        public AudioMixerSnapshot overworld;
        public AudioMixerSnapshot shadowSight;
    
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    public void setmusicstate(string musicState)
    {
       if (musicState == "overWorld")
        {
            overworld.TransitionTo(0.5f);
        }
       else if (musicState == "shadowSight")
        {
            shadowSight.TransitionTo(0.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
        {
        musicSource = GetComponent<AudioSource>();
        PlayOverworldMusic();
        PlayShadowSight();
        }
      
    public void PlayMenuMusic()
    {
    
    }

    public void PlayOverworldMusic()
    {
        //overworld.TransitionTo(1f);
        musicSource.clip = overworldMusic;
        musicSource.loop = true;
        musicSource.outputAudioMixerGroup = Music;
        musicSource.Play();
    }

    public void PlayShadowSight()
    {
        //shadowSight.TransitionTo(1f);
        musicSource2.clip = ShadowSightMusic;
        musicSource2.loop = true;
        musicSource2.outputAudioMixerGroup = Music2;
        musicSource2.Play();
    }


}
