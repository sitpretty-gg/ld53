using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FXManager : MonoBehaviour
{
    public static FXManager instance;
        
    private AudioSource audioSource
        ;
   

    public AudioMixerGroup Footsteps;
    public AudioClip skate1;
        
    public AudioMixer ShadowSight;
    public AudioClip shadowSightOn;
    public AudioClip shadowSightOff;

    public AudioMixerGroup Shadow;
    public AudioClip shadowAttach;
    public AudioClip shadowMoveUnder;
    public AudioClip shadowMoveOver;
    
    public AudioMixerGroup Clock;
    public AudioClip batteryDrain;
    public AudioClip clockTick;
    public AudioClip clockTickBell;
          

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

    //Get Clips
    AudioClip GetRandomClip(AudioClip[] audioClips)
    {
        int randomIndex = Random.Range(0, audioClips.Length);
        AudioClip audioClip = audioClips[randomIndex];
        return audioClip;
    }

    //audio utilites
              
    IEnumerator WaitUntilClipEnd()
    {
        audioSource.loop = false;
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        // The audio clip has finished playing, now it can be stopped.
        audioSource.clip = null;
        audioSource.Stop();
    }


   
    
    public void PlaySkate()
    {
        audioSource.clip = skate1;
        audioSource.loop = true;
        audioSource.Play();
        audioSource.outputAudioMixerGroup = Footsteps;
      
       
      //Debug.Log("Skate.Audio");
    }
        public void StopSkate()
    {
       audioSource.clip = skate1;
       StartCoroutine(WaitUntilClipEnd());
       audioSource.Stop();

    }

  

    public void ShadowSightON()
    {
        audioSource.clip = shadowSightOn;
        audioSource.Play();
        audioSource.outputAudioMixerGroup = Shadow;
        //Debug.Log("ShadowON");
    }

    public void ShadowSightOFF()
    {
        audioSource.clip = shadowSightOff;
        audioSource.Play();
        //Debug.Log("ShadowOFF");
    }
    public void PlayShadowAttach()
    {
        audioSource.clip = shadowAttach;
        audioSource.Play();
        Debug.Log("AShadowAttaches");
    }
        
    public void PlayShadowOver()
    {
        audioSource.clip = shadowMoveUnder;
        audioSource.Play();
        //Debug.Log("ShadowOver");
    }

    public void PlayShadowUnder()
    {
        
        audioSource.clip = shadowMoveOver;
        audioSource.Play();
        Debug.Log("ShadowUnder");
    }

    //
    //FX COMMENTED OUT
    //
    public void PlayBatteryDraining()
    {
       // audioSource.clip = batteryDrain;
       //audioSource.Play();
        //Debug.Log("batteryDrain");
    }

    public void PlayClockTick()
    {
        audioSource.clip = clockTick;
        audioSource.Play();
        audioSource.outputAudioMixerGroup = Clock;
    }
        public void PlayClockTickBell()
    {
        audioSource.clip = clockTickBell;
        audioSource.Play();
        Debug.Log("DINGDONGMINUTESGONE");
        audioSource.outputAudioMixerGroup = Clock;
    }

}
