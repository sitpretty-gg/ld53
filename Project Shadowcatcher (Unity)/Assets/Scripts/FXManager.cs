using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager instance;
    private AudioSource audioSource;
    public AudioClip skate1;
    public AudioClip shadowSightOn;
    public AudioClip shadowSightOff;
    public AudioClip shadowAttach;
    public AudioClip shadowMoveUnder;
    public AudioClip shadowMoveOver;
    public AudioClip batteryDrain;




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
                    private void VaryAudio()
    {

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

    //launch and stop of FX
    public void PlaySkate()
    {
      audioSource.clip = skate1;
      audioSource.loop = true;
      audioSource.Play();
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
        //Debug.Log("ShadowON");
    }

    public void ShadowSightOFF()
    {
        audioSource.clip = shadowSightOff;
        audioSource.Play();
        //Debug.Log("ShadowOFF");
    }
    public void ShadowAttach()
    {
        audioSource.clip = shadowAttach;
        audioSource.Play();
        //Debug.Log("ShadowAttach");
    }
        
    public void ShadowOver()
    {
        audioSource.clip = shadowMoveUnder;
        audioSource.Play();
        //Debug.Log("ShadowOver");
    }

    public void ShadowUnder()
    {
        audioSource.clip = shadowMoveOver;
        audioSource.Play();
        //Debug.Log("ShadowUnder");
    }

    public void BatteryDraining()
    {
        audioSource.clip = batteryDrain;
        audioSource.Play();
        //Debug.Log("batteryDrain");
    }
}
