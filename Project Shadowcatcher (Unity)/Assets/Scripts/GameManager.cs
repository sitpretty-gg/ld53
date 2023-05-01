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

    Backpack backpack;

    // Start is called before the first frame update
    void Start()
    {
        shadows = FindObjectsOfType<ShadowStateManager>();
        backpack = FindObjectOfType<Backpack>();
    }

    public void UpdateCapturedGhosts(int increase)
    {
        capturedGhosts += increase;
        backpack.UpdateCollectedShadows(capturedGhosts);
    }

    public void TriggerTimeBasedEvents(int hours, int seconds)
    {

        if (hours == startHNPC1 && seconds == startMNPC1)
        {
            Debug.Log("Ninja boy go");
            NPC1.SwitchState(NPC1.movementState);
        }

        if (hours == startHNPC2 && seconds == startMNPC2)
        {
            Debug.Log("Someone fell off the water tower");
            NPC2.SwitchState(NPC2.movementState);
        }

        if (hours == startHNPC3 && seconds == startMNPC3)
        {
            Debug.Log("barber shadow left the balcony");
            NPC3.SwitchState(NPC3.movementState);
        }

        if (hours == startHNPC4 && seconds == startMNPC4)
        {
            Debug.Log("Windmill girl is a go");
            NPC4.SwitchState(NPC4.movementState);
        }

        if (hours == startHNPC5 && seconds == startMNPC5)
        {
            Debug.Log("Bus boy called");
            NPC5.SwitchState(NPC5.movementState);
        }
    }

}
