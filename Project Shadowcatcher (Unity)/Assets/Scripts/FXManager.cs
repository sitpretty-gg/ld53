using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FXManager : MonoBehaviour
{
    public static FXManager instance;

    private AudioSource audioSource;

    public AudioMixerGroup Footsteps;
    public AudioClip skate1;

    public AudioMixerGroup ShadowSight;
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

    public AudioSource audioSource1;
    public Coroutine skateCoroutine = null;
    PlayerMovement playerMovement;

    private bool footstepIsPlaying = false;
    private float lastFootstepPlayed = -0.5f;
    private float footstepSpace = 0.5f;

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
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    //Get Clips
    AudioClip GetRandomClip(AudioClip[] audioClips)
    {
        int randomIndex = Random.Range(0, audioClips.Length);
        AudioClip audioClip = audioClips[randomIndex];
        return audioClip;
    }

    //audio utilites
    private void Update()
    {
            PlaySkate();
        
    }
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
    if (Time.time >= lastFootstepPlayed + footstepSpace && playerMovement.stepsCanPlay)
    {
        lastFootstepPlayed = Time.time;
        audioSource.outputAudioMixerGroup = Footsteps;
        audioSource.PlayOneShot(skate1);
        footstepIsPlaying = true;
    }
    }

    public IEnumerator LoopSkate()
    {


        while (playerMovement.stepsCanPlay)
        {
            if (footstepIsPlaying == false)
            {
                PlaySkate();
                yield return new WaitForSecondsRealtime(0.5f);
                footstepIsPlaying = false;
            }
        }
        
    }
    //public void StopSkate()
   // {
     //   instance.clip = skate1;
       // StartCoroutine(WaitUntilClipEnd());
        //instance.Stop();

    //}



    public void ShadowSightON()
    {
        audioSource.outputAudioMixerGroup = ShadowSight;
        audioSource.PlayOneShot(shadowSightOn);
        //Debug.Log("ShadowON");
    }

    public void ShadowSightOFF()
    {
        audioSource.outputAudioMixerGroup = ShadowSight;
        audioSource.PlayOneShot(shadowSightOff);
        
        //Debug.Log("ShadowOFF");
    }
    public void PlayShadowAttach()
    {
        audioSource.outputAudioMixerGroup = Shadow;
        audioSource.PlayOneShot(shadowAttach);
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

        audioSource.outputAudioMixerGroup = Shadow;
        audioSource.PlayOneShot(shadowMoveUnder);
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
