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

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(15);
            seconds += 15;

            if (seconds >= 60)
            {
                hours++;
                seconds = 0;
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
