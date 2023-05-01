using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   
        public static MusicManager instance;
    LevelManager levelManager;
        private AudioSource audioSource;
        public AudioClip menuMusic;
        public AudioClip overworldMusic;
        public AudioClip underworldMusic;
    
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
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
      
    public void PlayMenuMusic()
    {
             
        audioSource.clip = menuMusic;
        audioSource.playOnAwake = true;
        
    }

    public void PlayOverworldMusic()
    {
        audioSource.clip = overworldMusic;
        audioSource.Play();
    }

    public void PlayUnderworldMusic()
    {
        audioSource.clip = underworldMusic;
        audioSource.Play();
    }

}
