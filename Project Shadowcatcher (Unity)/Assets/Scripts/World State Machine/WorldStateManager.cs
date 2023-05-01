using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateManager : MonoBehaviour
{
    [SerializeField] public GameObject shadowWorldPostProcessing;

    InputManager inputManager;

    WorldBlankState currentState;
    public RealWorldState realWorldState = new RealWorldState();
    public ShadowWorldState shadowWorldState = new ShadowWorldState();

    ShadowStateManager[] shadows;

    Battery battery;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        shadows = FindObjectsOfType<ShadowStateManager>();
        currentState = realWorldState;
        realWorldState.EnterState(this);
        battery = FindObjectOfType<Battery>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SwitchState()
    {

        if (currentState == shadowWorldState)
        {
            var newState = realWorldState;
            currentState = newState;
            currentState.EnterState(this);
        }

        else if (currentState == realWorldState)
        {
            var newState = shadowWorldState;
            currentState = newState;
            currentState.EnterState(this);
        }
    }

    public IEnumerator DrainBattery()
    {
        while (true)
        {
            battery.ReduceBatteryLife();
            yield return new WaitForSeconds(0.01f);

        }

    }

    public void ShadowsVisible(bool setter)
    {
        foreach (ShadowStateManager shadow in shadows)
        {
            // only change the shadows that haven't been caught
            if (!shadow.captured)
            {
                if (currentState == shadowWorldState)
                {
                    shadow.SetShadowSprite(shadow.shadowWorldSprite);
                }

                else if (currentState == realWorldState)
                {
                    shadow.SetShadowSprite(shadow.shadowWorldSprite);
                }

                shadow.MakeVisible(setter);
            }
        }
    }

    public IEnumerator CheckForShadows()
    {
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("shadow found!");

                foreach (ShadowStateManager shadow in shadows)
                {
                    shadow.CheckWithinCapRange();
                }

                if (currentState == realWorldState)
                {
                    yield break;
                }

                yield return new WaitForSecondsRealtime(0.25f);
            }
        }

    }

    // After we come back into the real world, we turn isWithinCapRange off again
    public void ResetAllWithinCapRange()
    {
        foreach (ShadowStateManager shadow in shadows)
        {
            shadow.isWithinCapRange = false;
        }
    }

}
