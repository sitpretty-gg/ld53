using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    int hours = 9;
    int seconds = 0;
    [SerializeField] TextMeshProUGUI secondsTimeUI;
    [SerializeField] TextMeshProUGUI hoursTimeUI;

    GameManager gameManager;
    FXManager fxManager;
    MusicManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        fxManager = FindObjectOfType<FXManager>();
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(StartTimer());
        musicManager = FindObjectOfType<MusicManager>();

        
    }

    IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(7.5f);
            seconds += 15;

            if (seconds >= 60)
            {
                // DANIEL: Hour clock time trigger here
                fxManager.PlayClockTickBell();

                hours++;
                seconds = 0;
            }

            if (seconds == 30)
            {
                // DANIEL: Half hour time here if you wanted to use it
            }

            UpdateSecondsUI(seconds);
            UpdateHoursUI(hours);

            gameManager.TriggerTimeBasedEvents(hours, seconds);
            
        }
    }

    private void UpdateSecondsUI(int setter)
    {
        secondsTimeUI.text = setter.ToString(":00");
    }

    private void UpdateHoursUI(int setter)
    {
        hoursTimeUI.text = setter.ToString("00");
    }
}
