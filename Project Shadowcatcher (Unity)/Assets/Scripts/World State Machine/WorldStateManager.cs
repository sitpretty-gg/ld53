using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateManager : MonoBehaviour
{
    [SerializeField] public GameObject shadowWorldPostProcessing;

    WorldBlankState currentState;
    public RealWorldState realWorldState = new RealWorldState();
    public ShadowWorldState shadowWorldState = new ShadowWorldState();

    Shadow[] shadows;

    // Start is called before the first frame update
    void Start()
    {
        shadows = FindObjectsOfType<Shadow>();
        currentState = realWorldState;
        realWorldState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SwitchState(WorldBlankState newState)
    {
        currentState = newState;
        newState.EnterState(this);
    }

    public IEnumerator ShadowWorldTimer()
    {
        yield return new WaitForSeconds(2.5f);
        SwitchState(realWorldState);

    }

    public void ShadowsVisible(bool setter)
    {
        foreach (Shadow shadow in shadows)
        {
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

    public void SetAllShadowsWithinRange(bool setter)
    {
        foreach (Shadow shadow in shadows)
        {
            shadow.isWithinCapRange = setter;
        }
    }

}
