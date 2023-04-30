using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] ShadowStateManager NPC1;
    [SerializeField] int startHNPC1;
    [SerializeField] int startMNPC1;

    [SerializeField] ShadowStateManager NPC2;
    [SerializeField] int startHNPC2;
    [SerializeField] int startMNPC2;

    [SerializeField] ShadowStateManager NPC3;
    [SerializeField] int startHNPC3;
    [SerializeField] int startMNPC3;

    [SerializeField] ShadowStateManager NPC4;
    [SerializeField] int startHNPC4;
    [SerializeField] int startMNPC4;

    [SerializeField] ShadowStateManager NPC5;
    [SerializeField] int startHNPC5;
    [SerializeField] int startMNPC5;

    [SerializeField] Slider batterySliderUI;

    int capturedGhosts = 0;
    [SerializeField] TextMeshProUGUI capturedGhostsUI;

    ShadowStateManager[] shadows;

    // Start is called before the first frame update
    void Start()
    {
        shadows = FindObjectsOfType<ShadowStateManager>();
    }

    public void UpdateCapturedGhosts(int increase)
    {
        capturedGhosts += increase;
        capturedGhostsUI.text = capturedGhosts.ToString("000");
    }

    public void TriggerTimeBasedEvents(int hours, int seconds)
    {
        if (hours == startHNPC1 && seconds == startMNPC1)
        {
            NPC1.SwitchState(NPC1.movementState);
        }

        if (hours == startHNPC2 && seconds == startMNPC2)
        {
            NPC2.SwitchState(NPC2.movementState);
        }
    }

}
